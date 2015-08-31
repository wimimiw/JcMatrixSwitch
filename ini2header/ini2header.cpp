// ini2header.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <string>
#include <iostream>
#include <fstream>
#include <Windows.h>
#include "../Debug/switch_info.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{	
	const string iof = "../Debug/io.ini";
	const string implementsettingf = "../Debug/implementsetting.ini";

	const string header = "../Debug/switch_info.h";

	ifstream ifio(iof);
	ifstream ifipt(implementsettingf);

	ofstream ofheader(header,ios::trunc);

	if (ifio.fail())
	{
		cout << "Open io.ini Failed" << endl;
		getchar();
		exit(1);
	}

	if (ifipt.fail())
	{
		cout << "Open implementsetting.ini Failed" << endl;
		getchar();
		exit(1);
	}

	cout << "ok" << endl;

	ifio.seekg(0, ios::end);
	ifipt.seekg(0, ios::end);

	streampos sp = ifio.tellg();

	cout << sp.seekpos() << endl;

	sp = ifipt.tellg();

	cout << sp.seekpos() << endl;

	ifio.seekg(0, ios::beg);
	//ifipt.seekg(0, ios::end);

	char buffer[512];

	string sLine;

	sLine.assign("#ifndef __SWITCH_CONFIG_H__\n"
				 "#define __SWITCH_CONFIG_H__\n"				 
				 "#define IO_STRING	         ");

	ofheader.write(sLine.c_str(), sLine.size());

	while (!ifio.eof())
	{
		ifio.getline(buffer, 512);	
		sLine.assign(buffer); 	
		sLine.insert(0, "\"");
		sLine.append("\\n\"\\");
		ofheader.write(sLine.c_str(), sLine.size());
		ofheader.write("\n",strlen("\n"));
	}
	
	sLine.assign("\"\"\n");
	ofheader.write(sLine.c_str(), sLine.size());

	ifipt.seekg(0,ios::beg);

	sLine.assign("#define IMPLEMENT_STRING  ");
	ofheader.write(sLine.c_str(), sLine.size());

	while (!ifipt.eof())
	{
		ifipt.getline(buffer, 512);
		sLine.assign(buffer);
		sLine.insert(0, "\"");
		sLine.append("\\n\"\\");
		ofheader.write(sLine.c_str(), sLine.size());
		ofheader.write("\n", strlen("\n"));
	}
	
	sLine.assign("\"\"\n");
	ofheader.write(sLine.c_str(), sLine.size());

	ofheader.write("\n", strlen("\n"));

	sLine.assign("#endif\n");
	ofheader.write(sLine.c_str(), sLine.size());

	ifio.close();
	ifipt.close();
	ofheader.close();

	const string sOio = "io.ini";
	const string sOimplt = "implementsetting.ini";

	ofstream ofio(sOio);
	ofstream ofimplt(sOimplt);

	string fg;

	fg.assign(IO_STRING);

	ofio.write(fg.c_str(),fg.size());

	fg.assign(IMPLEMENT_STRING);

	ofimplt.write(fg.c_str(), fg.size());
	
	ofio.close();
	ofimplt.close();

	DeleteFileA(sOio.c_str());
	DeleteFileA(sOimplt.c_str());
	
	return 0;
}

