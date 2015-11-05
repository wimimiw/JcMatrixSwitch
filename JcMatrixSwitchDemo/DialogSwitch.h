#pragma once
#include "afxwin.h"


// CDialogSwitch dialog

class CDialogSwitch : public CDialogEx
{
	DECLARE_DYNAMIC(CDialogSwitch)

public:
	CDialogSwitch(CWnd* pParent,int matrixType);   // standard constructor
	virtual ~CDialogSwitch();

// Dialog Data
	enum { IDD = IDD_DIALOG1 };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
//	CComboBox m_ccbModel;
//	CComboBox m_cbbModel;
//	CComboBox m_cbbSwitch;
	CComboBox m_cbbIdx;
	afx_msg void OnSelchangeCombo1();
	afx_msg void OnSelchangeCombo2();
	afx_msg void OnSelchangeCombo3();
//	bool m_cbbSwitch;
	CComboBox m_cbbSwitch;
	CComboBox m_cbbModel;
};
