// jc_pim_huawei_switch_patch.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <Winsock2.h>
#include <mswsock.h>

#pragma comment(lib, "ws2_32.lib")
#pragma comment(lib, "mswsock.lib")

#include <stdio.h>
#include <Windows.h>
#include <memory>
#include <iostream>
#include <list>
#include <string>
#include <vector>
#include <functional>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	cout << "运行开关箱更新补丁..." << endl;

	int iResult;
	WSADATA wsaData;

	//----------------------
	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != NO_ERROR) {
		wprintf(L"WSAStartup failed with error: %d\n", iResult);
		return 1;
	}

	//读取路径
	char pathBuf[MAX_PATH];
	GetModuleFileNameA(NULL, pathBuf, MAX_PATH);
	string path(pathBuf);
	path = path.substr(0, path.rfind('\\'));
	path.append("\\JcConfig.ini");
	//读取键值
#define BUF_SIZE 4096
	shared_ptr<char>pbuf(new char[BUF_SIZE]);
	char *tbuf = pbuf.get();
	vector<string> keyList;

	int charLen = GetPrivateProfileStringA("ip", NULL, NULL, tbuf, BUF_SIZE, path.c_str());

	for (int i = 0; i < charLen; i++)
	{
		if (tbuf[i] == 0 && i + 1 < charLen)
		{
			keyList.push_back(&tbuf[i + 1]);
		}
		else if (i == 0)
		{
			keyList.push_back(&tbuf[i]);
		}
	}
	//组织命令
	list<string> cmdInit;
	cmdInit.push_back("AT+MODE=0\r\n");
	cmdInit.push_back("AT+LOGIN=88888\r\n");
	cmdInit.push_back("AT\r\n");
	cmdInit.push_back("AT+ECHO=0\r\n");
	//cmdInit.push_back("AT+C1_OP=3\r\n");
	cmdInit.push_back("AT+C1_OP=0\r\n");
	cmdInit.push_back("AT+RESET=88888\r\n");//复位设备

	bool tashResult = true;

	//执行操作
	for (auto itr = keyList.begin();
		itr != keyList.end();
		itr++)
	{
		bool result = true;
		char buf[1024];
		char valueBuf[256];
		GetPrivateProfileStringA("ip", (*itr).c_str(), "", valueBuf, 256, path.c_str());
		string ip(valueBuf);
		ip = ip.substr(0, ip.rfind(':'));
		string port(valueBuf);
		port = port.substr(port.find_first_of(':') + 1, port.size());
		port = "3003";

		SOCKET hSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
		sockaddr_in clientService;

		// The sockaddr_in structure specifies the address family,
		// IP address, and port of the server to be connected to.
		clientService.sin_family = AF_INET;
		clientService.sin_addr.s_addr = inet_addr(ip.c_str());
		clientService.sin_port = htons(atoi(port.c_str()));

		[=](){
			bool result;
			int iTimeOut = 3000;

			result = SOCKET_ERROR != setsockopt(hSocket, SOL_SOCKET, SO_RCVTIMEO, (char*)&iTimeOut, sizeof(iTimeOut));
			result = SOCKET_ERROR != setsockopt(hSocket, SOL_SOCKET, SO_SNDTIMEO, (char*)&iTimeOut, sizeof(iTimeOut));
		}();

		u_long ul = 1;
		ioctlsocket(hSocket, FIONBIO, &ul); //设置为非阻塞模式
		//----------------------
		// Connect to server.
		iResult = connect(hSocket, (SOCKADDR*)&clientService, sizeof(clientService));

		[&](){
			timeval tm;
			fd_set fdwrite;

			tm.tv_sec = 3;
			tm.tv_usec = 0;

			FD_ZERO(&fdwrite);
			FD_SET(hSocket, &fdwrite);

			//阻塞一定时间，超时时间自定义
			iResult = select(NULL, NULL, &fdwrite, NULL, &tm);
			if (fdwrite.fd_count > 0)
			{
				iResult = FD_ISSET(hSocket, &fdwrite) != 0;
			}
			else
				iResult = false;

			FD_CLR(hSocket,&fdwrite);
		}();

		ul = 0;
		ioctlsocket(hSocket, FIONBIO, &ul); //设置为阻塞模式

		if (!iResult) {
			cout << "module : " << ip << " connect failed! error = " << WSAGetLastError() << endl;
			closesocket(hSocket);
			tashResult = false;
			goto FAILED;
		}

		cout << "module : " << ip << " connect success!" << endl;

		for (auto itr = cmdInit.begin();
			itr != cmdInit.end();
			itr++
			)
		{
			send(hSocket, (*itr).c_str(), (*itr).size(), 0);
			Sleep(250);
			memset(buf, 0, 1024);
			int rec = recv(hSocket, buf, 1024, 0);

			string strprint(buf);

			if (strstr(buf, "OK") == NULL && "AT+MODE=0\r\n" != *itr && "AT+LOGIN=88888\r\n" != *itr)				
			{
				result = false;
				tashResult = false;
				cout << "module : " << ip << " config failed!" << endl;
				goto FAILED;
			}
		}

		cout << "module : " << ip << " config success!" << endl;

		//shutdown(hSocket,SEND)
		struct linger so_linger;
		so_linger.l_onoff = 1;
		so_linger.l_linger = 0;  //强制断开连接
		setsockopt(hSocket, SOL_SOCKET, SO_LINGER, (const char*)&so_linger, sizeof(&so_linger));
		closesocket(hSocket);
		Sleep(1000);
	}	

FAILED:
	//---------------------------------------------
	// Clean up and quit.

	if (tashResult)
		cout << "更新成功！" << endl;
	else
		cout << "更新失败！退出..." << endl;

	WSACleanup();

	getchar();

	return 0;
}

