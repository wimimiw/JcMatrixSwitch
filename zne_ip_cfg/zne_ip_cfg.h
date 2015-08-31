
// zne_ip_cfg.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols
#include <string>


// Czne_ip_cfgApp:
// See zne_ip_cfg.cpp for the implementation of this class
//

class Czne_ip_cfgApp : public CWinApp
{
public:
	Czne_ip_cfgApp();

// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern Czne_ip_cfgApp theApp;