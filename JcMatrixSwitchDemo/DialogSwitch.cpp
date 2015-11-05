// DialogSwitch.cpp : implementation file
//

#include "stdafx.h"
#include "JcMatrixSwitchDemo.h"
#include "DialogSwitch.h"
#include "afxdialogex.h"


// CDialogSwitch dialog

IMPLEMENT_DYNAMIC(CDialogSwitch, CDialogEx)

CDialogSwitch::CDialogSwitch(CWnd* pParent /*=NULL*/,int matrixType)
	: CDialogEx(CDialogSwitch::IDD, pParent)
{
	if (matrixType == 2)
	{
		m_cbbModel.ResetContent();
		m_cbbModel.AddString(L"Signalswich                 ");
		m_cbbModel.AddString(L"Paspecumpwmt         ");
		m_cbbModel.AddString(L"PaspecumpwmtP       ");
		m_cbbModel.AddString(L"Testmdlte700             ");
		m_cbbModel.AddString(L"Testmddd800             ");
		m_cbbModel.AddString(L"Testmdgsm900          ");
		m_cbbModel.AddString(L"Testmddcs1800         ");
		m_cbbModel.AddString(L"Testmdpcs1900         ");
		m_cbbModel.AddString(L"Testmdwcdma2100  ");
		m_cbbModel.AddString(L"Testmdlte2600           ");
		m_cbbModel.AddString(L"Testmd4501               ");
		m_cbbModel.AddString(L"Testmd4502               ");
		m_cbbModel.AddString(L"Testmd700h               ");
		m_cbbModel.AddString(L"Testmd700apt            ");
		m_cbbModel.AddString(L"Testmd800cdma        ");
		m_cbbModel.SetCurSel(0);

		m_cbbSwitch.ResetContent();
		m_cbbSwitch.AddString(L"Signal1swich               " );
		m_cbbSwitch.AddString(L"Signal2swich               " );
		m_cbbSwitch.AddString(L"Powermeterswich1    ");
		m_cbbSwitch.AddString(L"Spectrumswich1        " );
		m_cbbSwitch.AddString(L"PA1swich1                   " );
		m_cbbSwitch.AddString(L"PA1swich2                   " );
		m_cbbSwitch.AddString(L"PA2swich1                   " );
		m_cbbSwitch.AddString(L"PA2swich2                   " );
		m_cbbSwitch.AddString(L"Powermeterswich2    ");
		m_cbbSwitch.AddString(L"Spectrumswich2        " );
		m_cbbSwitch.AddString(L"PA3swich1                   " );
		m_cbbSwitch.AddString(L"PA3swich2                   " );
		m_cbbSwitch.AddString(L"Couplerswich              " );
		m_cbbSwitch.AddString(L"Pimswich                      ");
		m_cbbSwitch.AddString(L"Txoutswich 					");
		m_cbbSwitch.SetCurSel(0);

		m_cbbIdx.ResetContent();
		m_cbbIdx.AddString(L"1  ");
		m_cbbIdx.AddString(L"2  ");
		m_cbbIdx.AddString(L"3  ");
		m_cbbIdx.AddString(L"4  ");
		m_cbbIdx.AddString(L"5  ");
		m_cbbIdx.AddString(L"6  ");
		m_cbbIdx.AddString(L"7  ");
		m_cbbIdx.SetCurSel(0);
	}
}

CDialogSwitch::~CDialogSwitch()
{
}

void CDialogSwitch::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	//  DDX_Control(pDX, IDC_COMBO1, m_ccbModel);
	DDX_Control(pDX, IDC_COMBO20, m_cbbModel);
	//  DDX_Control(pDX, IDC_COMBO21, m_cbbModel);
	DDX_Control(pDX, IDC_COMBO22, m_cbbIdx);
	DDX_Control(pDX, IDC_COMBO21, m_cbbSwitch);
	//DDX_Control(pDX, IDC_COMBO20, m_cbbModel);
}


BEGIN_MESSAGE_MAP(CDialogSwitch, CDialogEx)
	ON_CBN_SELCHANGE(IDC_COMBO20, &CDialogSwitch::OnSelchangeCombo1)
	ON_CBN_SELCHANGE(IDC_COMBO21, &CDialogSwitch::OnSelchangeCombo2)
	ON_CBN_SELCHANGE(IDC_COMBO22, &CDialogSwitch::OnSelchangeCombo3)
END_MESSAGE_MAP()

// CDialogSwitch message handlers


void CDialogSwitch::OnSelchangeCombo1()
{
	// TODO: Add your control notification handler code here
}


void CDialogSwitch::OnSelchangeCombo2()
{
	// TODO: Add your control notification handler code here
}


void CDialogSwitch::OnSelchangeCombo3()
{
	int result = MartrixSwitchExcute(m_cbbSwitch.GetCurSel() + 1, m_cbbModel.GetCurSel() + 1, m_cbbIdx.GetCurSel() + 1);

	if (result != MATRIX_SWITCH_OK)
	{
		wchar_t tmp[10];
		swprintf_s(tmp, L"Error Return Code = %d", result);
		MessageBox(tmp);
	}
	// TODO: Add your control notification handler code here
}
