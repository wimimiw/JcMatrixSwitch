#pragma once
#include "afxcmn.h"
#include "afxwin.h"
#include <string>

using namespace std;
// NetEnsure dialog

class NetEnsure : public CDialogEx
{
	DECLARE_DYNAMIC(NetEnsure)

public:
	NetEnsure(CWnd* pParent = NULL);   // standard constructor
	virtual ~NetEnsure();

// Dialog Data
	enum { IDD = IDD_DIALOG1 };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	CIPAddressCtrl m_mask;
	CIPAddressCtrl m_host;
	CButton m_btnOK;
	CButton m_btnCancel;
	virtual void OnOK();
	virtual void OnCancel();
	void LoadMaskHost(int* mask, int* host);
	int* m_maskValue;
	int* m_hostValue;
	CEdit m_Info;
};
