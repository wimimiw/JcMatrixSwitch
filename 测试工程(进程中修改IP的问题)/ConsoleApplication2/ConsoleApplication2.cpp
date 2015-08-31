// ConsoleApplication2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <Winsock2.h> 
#include <stdio.h>
#include <iostream>
#include <fstream>
#include <memory>
#include <thread>
#include <chrono>
#include <thread>
#include <regex>

#pragma comment(lib, "ws2_32.lib")

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	wstring filePath;
	wchar_t wbuf[1024];

	GetModuleFileName(NULL, wbuf, 1024);

	filePath.assign(wbuf);

	filePath = filePath.substr(0, filePath.find_last_of(L"\\"));

	filePath.append(L"\\implementsetting.ini");

	wifstream ifstream1;

	ifstream1.open(filePath);
	
	wfilebuf wfb;	

	ifstream1.seekg(0, ios_base::end);
	int fileSize = ifstream1.tellg();

	shared_ptr<wchar_t> pfilebuf(new wchar_t[fileSize]);

	ifstream1.seekg(0,ios_base::beg);

	ifstream1.read(pfilebuf.get(),fileSize);

	ifstream1.close();

	wstring wtext(pfilebuf.get());
	wsmatch match;

	pfilebuf.reset();

	wregex pattern(L"\\d{1,6}");

	regex_match(wtext,match,pattern);

	//////////////////////////////////////////////////致此处

	cin.get();

	this_thread::sleep_for(chrono::seconds(1));

	//此例失败，修改IP地址后，需要重启进程，才能用新的IP地址进行连接	
	system("netsh interface ip set address 本地连接 static 192.168.6.10 255.255.255.0 192.168.6.1");
	Sleep(1000);
	system("netsh interface ip set address 本地连接 static 192.168.0.10 255.255.255.0 192.168.0.1");
	//禁用网卡
	system("netsh interface set interface name=\"本地连接\" admin = DISABLED");
	//启用网卡
	system("netsh interface set interface name=\"本地连接\" admin = ENABLED");
	Sleep(1000);

	WORD wVersionRequested;
	WSADATA wsaData;
	int err;

	wVersionRequested = MAKEWORD(1, 1);
	err = WSAStartup(wVersionRequested, &wsaData);//该函数的功能是加载一个Winsocket库版本
	
	if (err != 0) {
		return 0;		
	}
			
	if (LOBYTE(wsaData.wVersion) != 1 ||
		HIBYTE(wsaData.wVersion) != 1) {

		WSACleanup();

		return 0;		
	}

	//建立通讯socket
	SOCKET sockClient = socket(AF_INET, SOCK_STREAM, 0);
	SOCKADDR_IN addrSrv;

	addrSrv.sin_addr.S_un.S_addr = inet_addr("192.168.0.178");//设定需要连接的服务器的ip地址
	addrSrv.sin_family = AF_INET;
	addrSrv.sin_port = htons(4001);//设定需要连接的服务器的端口地址
	
	if (SOCKET_ERROR == connect(sockClient, (SOCKADDR*)&addrSrv, sizeof(SOCKADDR)))//与服务器进行连接
	{
		cout << "Connect Failed!" << endl;
	}
	else
		cout << "Connect Success!" << endl;

	closesocket(sockClient);
	WSACleanup();

	cin.get();

	return 0;
}

