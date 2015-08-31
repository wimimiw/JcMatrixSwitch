
// DlgProxy.cpp : implementation file
//

#include "stdafx.h"
#include "zne_ip_cfg.h"
#include "DlgProxy.h"
#include "zne_ip_cfgDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// Czne_ip_cfgDlgAutoProxy

IMPLEMENT_DYNCREATE(Czne_ip_cfgDlgAutoProxy, CCmdTarget)

Czne_ip_cfgDlgAutoProxy::Czne_ip_cfgDlgAutoProxy()
{
	EnableAutomation();
	
	// To keep the application running as long as an automation 
	//	object is active, the constructor calls AfxOleLockApp.
	AfxOleLockApp();

	// Get access to the dialog through the application's
	//  main window pointer.  Set the proxy's internal pointer
	//  to point to the dialog, and set the dialog's back pointer to
	//  this proxy.
	ASSERT_VALID(AfxGetApp()->m_pMainWnd);
	if (AfxGetApp()->m_pMainWnd)
	{
		ASSERT_KINDOF(Czne_ip_cfgDlg, AfxGetApp()->m_pMainWnd);
		if (AfxGetApp()->m_pMainWnd->IsKindOf(RUNTIME_CLASS(Czne_ip_cfgDlg)))
		{
			m_pDialog = reinterpret_cast<Czne_ip_cfgDlg*>(AfxGetApp()->m_pMainWnd);
			m_pDialog->m_pAutoProxy = this;
		}
	}
}

Czne_ip_cfgDlgAutoProxy::~Czne_ip_cfgDlgAutoProxy()
{
	// To terminate the application when all objects created with
	// 	with automation, the destructor calls AfxOleUnlockApp.
	//  Among other things, this will destroy the main dialog
	if (m_pDialog != NULL)
		m_pDialog->m_pAutoProxy = NULL;
	AfxOleUnlockApp();
}

void Czne_ip_cfgDlgAutoProxy::OnFinalRelease()
{
	// When the last reference for an automation object is released
	// OnFinalRelease is called.  The base class will automatically
	// deletes the object.  Add additional cleanup required for your
	// object before calling the base class.

	CCmdTarget::OnFinalRelease();
}

BEGIN_MESSAGE_MAP(Czne_ip_cfgDlgAutoProxy, CCmdTarget)
END_MESSAGE_MAP()

BEGIN_DISPATCH_MAP(Czne_ip_cfgDlgAutoProxy, CCmdTarget)
END_DISPATCH_MAP()

// Note: we add support for IID_Izne_ip_cfg to support typesafe binding
//  from VBA.  This IID must match the GUID that is attached to the 
//  dispinterface in the .IDL file.

// {E911E8BA-93F0-40F8-8240-AC098A1B3C8B}
static const IID IID_Izne_ip_cfg =
{ 0xE911E8BA, 0x93F0, 0x40F8, { 0x82, 0x40, 0xAC, 0x9, 0x8A, 0x1B, 0x3C, 0x8B } };

BEGIN_INTERFACE_MAP(Czne_ip_cfgDlgAutoProxy, CCmdTarget)
	INTERFACE_PART(Czne_ip_cfgDlgAutoProxy, IID_Izne_ip_cfg, Dispatch)
END_INTERFACE_MAP()

// The IMPLEMENT_OLECREATE2 macro is defined in StdAfx.h of this project
// {D605316E-743B-491B-969D-5ED551929DA9}
IMPLEMENT_OLECREATE2(Czne_ip_cfgDlgAutoProxy, "zne_ip_cfg.Application", 0xd605316e, 0x743b, 0x491b, 0x96, 0x9d, 0x5e, 0xd5, 0x51, 0x92, 0x9d, 0xa9)


// Czne_ip_cfgDlgAutoProxy message handlers
