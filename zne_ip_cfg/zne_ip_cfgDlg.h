
// zne_ip_cfgDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include <string>
#include <string.h>
#include <map>
#include <list>
#include <vector>
#include "afxcmn.h"
#include "NetEnsure.h"


class Czne_ip_cfgDlgAutoProxy;

using namespace std;

// Czne_ip_cfgDlg dialog
class Czne_ip_cfgDlg : public CDialogEx
{
	DECLARE_DYNAMIC(Czne_ip_cfgDlg);
	friend class Czne_ip_cfgDlgAutoProxy;

// Construction
public:
	Czne_ip_cfgDlg(CWnd* pParent = NULL);	// standard constructor
	virtual ~Czne_ip_cfgDlg();

// Dialog Data
	enum { IDD = IDD_ZNE_IP_CFG_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	CBrush m_bkBrush;

	Czne_ip_cfgDlgAutoProxy* m_pAutoProxy;
	HICON m_hIcon;

	BOOL CanExit();

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClose();
	virtual void OnOK();
	virtual void OnCancel();
	DECLARE_MESSAGE_MAP()
public:
	CButton m_btn1;
	CButton m_btn2;
	CButton m_btn3;
	CButton m_btn4;
	CButton m_btn5;
	CButton m_btn6;
	CButton m_btn7;
	CButton m_btn8;
	CButton m_btn9;
	CIPAddressCtrl m_ipCurr1;
	CIPAddressCtrl m_ipCurr2;
	CIPAddressCtrl m_ipCurr3;
	CIPAddressCtrl m_ipCurr4;
	CIPAddressCtrl m_ipCurr5;
	CIPAddressCtrl m_ipCurr6;
	CIPAddressCtrl m_ipCurr7;
	CIPAddressCtrl m_ipCurr8;
	CIPAddressCtrl m_ipCurr9;
	CIPAddressCtrl m_ipChang1;
	CIPAddressCtrl m_ipChang2;
	CIPAddressCtrl m_ipChang3;
	CIPAddressCtrl m_ipChang4;
	CIPAddressCtrl m_ipChang5;
	CIPAddressCtrl m_ipChang6;
	CIPAddressCtrl m_ipChang7;
	CIPAddressCtrl m_ipChang8;
	CIPAddressCtrl m_ipChang9;

	static void GetIPPortFromStringchar(const char* str, int* ip, int* port);
//	virtual HRESULT accDoDefaultAction(VARIANT varChild);
	afx_msg void OnBnClickedButton2();

	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedButton4();
	afx_msg void OnBnClickedButton5();
	afx_msg void OnBnClickedButton6();
	afx_msg void OnBnClickedButton7();
	afx_msg void OnBnClickedButton8();
	afx_msg void OnBnClickedButton9();
	afx_msg void OnBnClickedButton10();
	string v_iniPath;
	vector<string> v_section;
	vector<int> v_listip;
	vector<int> v_listport;
	int v_mask;
	int v_host;
	SOCKET hSocket;
	bool PcsIPConfig(CButton* btn, CIPAddressCtrl* cips, CIPAddressCtrl* cipd, int idx);
	static int IPStrToInt(string ip);
	static void IPIntToStr(int ipi, string&stro);
};
