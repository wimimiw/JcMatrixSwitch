
// DlgProxy.h: header file
//

#pragma once

class Czne_ip_cfgDlg;


// Czne_ip_cfgDlgAutoProxy command target

class Czne_ip_cfgDlgAutoProxy : public CCmdTarget
{
	DECLARE_DYNCREATE(Czne_ip_cfgDlgAutoProxy)

	Czne_ip_cfgDlgAutoProxy();           // protected constructor used by dynamic creation

// Attributes
public:
	Czne_ip_cfgDlg* m_pDialog;

// Operations
public:

// Overrides
	public:
	virtual void OnFinalRelease();

// Implementation
protected:
	virtual ~Czne_ip_cfgDlgAutoProxy();

	// Generated message map functions

	DECLARE_MESSAGE_MAP()
	DECLARE_OLECREATE(Czne_ip_cfgDlgAutoProxy)

	// Generated OLE dispatch map functions

	DECLARE_DISPATCH_MAP()
	DECLARE_INTERFACE_MAP()
};

