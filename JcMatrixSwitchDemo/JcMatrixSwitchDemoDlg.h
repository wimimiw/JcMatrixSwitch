
// JcMatrixSwitchDemoDlg.h : header file
//

#pragma once
#include "afxwin.h"

typedef int(*pMartrixSwitchInit)(int, char*, int, int);
typedef int(*pMartrixSwitchExcute)(int, int, int);
typedef int(*pMartrixSwitchBoxExcute)(int, int, int, int);
typedef int(*pMartrixSwitchDispose)();

// CJcMatrixSwitchDemoDlg dialog
class CJcMatrixSwitchDemoDlg : public CDialogEx
{
// Construction
public:
	CJcMatrixSwitchDemoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_JCMATRIXSWITCHDEMO_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	
	CButton* NewMyRadio(int nID, CRect rect, int nStyle);
	CButton* NewMyGroup(int nID, CRect rect, int nStyle);
	CButton *p_MyRadio[100];
	CButton *p_MyGroup[100];

	BOOL SwitchManual(int swId, int swIdx);

	pMartrixSwitchInit pMSI;
	pMartrixSwitchBoxExcute pMSE1;
	pMartrixSwitchExcute pMSE2;
	pMartrixSwitchDispose pMSD;
// Implementation
protected:
	HICON m_hIcon;
//{{AFX_MSG(CJcMatrixSwitchDemoDlg)
	afx_msg void OnIconbut0();
//}}AFX_MSG
	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	
	afx_msg void OnMyRadio1(); 
	afx_msg void OnMyRadio2(); 
	afx_msg void OnMyRadio3(); 
	afx_msg void OnMyRadio4(); 
	afx_msg void OnMyRadio5(); 
	afx_msg void OnMyRadio6(); 
	afx_msg void OnMyRadio7(); 
	afx_msg void OnMyRadio8(); 
	afx_msg void OnMyRadio9(); 
	afx_msg void OnMyRadio10();
	afx_msg void OnMyRadio11();
	afx_msg void OnMyRadio12();
	afx_msg void OnMyRadio13();
	afx_msg void OnMyRadio14();
	afx_msg void OnMyRadio15();
	afx_msg void OnMyRadio16();
	afx_msg void OnMyRadio17();
	afx_msg void OnMyRadio18();
	afx_msg void OnMyRadio19();
	afx_msg void OnMyRadio20();
	afx_msg void OnMyRadio21();
	afx_msg void OnMyRadio22();
	afx_msg void OnMyRadio23();
	afx_msg void OnMyRadio24();
	afx_msg void OnMyRadio25();
	afx_msg void OnMyRadio26();
	afx_msg void OnMyRadio27();
	afx_msg void OnMyRadio28();
	afx_msg void OnMyRadio29();
	afx_msg void OnMyRadio30();
	afx_msg void OnMyRadio31();
	afx_msg void OnMyRadio32();
	afx_msg void OnMyRadio33();
	afx_msg void OnMyRadio34();
	afx_msg void OnMyRadio35();
	afx_msg void OnMyRadio36();
	afx_msg void OnMyRadio37();
	afx_msg void OnMyRadio38();
	afx_msg void OnMyRadio39();
	afx_msg void OnMyRadio40();

	afx_msg void OnMyRadio80();
	afx_msg void OnMyRadio81();
	
	DECLARE_MESSAGE_MAP()
public:
	CComboBox m_cbbSwitch;
	afx_msg void OnSelchangeCombo2();
	CComboBox m_ccbTx1;
	CComboBox m_ccbTx2;
	CComboBox m_ccbPim;
	CComboBox m_ccbDet;
	afx_msg void OnSelchangeCombo3();
	afx_msg void OnSelchangeCombo4();
	afx_msg void OnSelchangeCombo5();
	afx_msg void OnSelchangeCombo6();
	CButton m_ccbCommit;
	afx_msg void OnClickedButton2();
	CComboBox m_ccbSWType;
	afx_msg void OnCbnSelchangeCombo7();
	afx_msg void OnBnClickedButton1();
	CButton m_btnSwitch;
	CComboBox m_cbbSwitch2;
	CComboBox m_cbbSwitchIdx;
	CComboBox m_ccbSwitchType2;
	CEdit m_TestCnt;
	CButton m_TestRun;
	afx_msg void OnBnClickedButton4();
	CStatic m_TestCntRefresh;
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	// 开关测试次数
	int __SwitchTestCnt;
	// 测试时隙
	CEdit m_TestDelay;
};
