
// JcMatrixSwitchDemoDlg.cpp : implementation file
//

#include "stdafx.h"
#include "JcMatrixSwitchDemo.h"
#include "JcMatrixSwitchDemoDlg.h"
#include "DialogSwitch.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAboutDlg dialog used for App About

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)		
END_MESSAGE_MAP()


// CJcMatrixSwitchDemoDlg dialog



CJcMatrixSwitchDemoDlg::CJcMatrixSwitchDemoDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CJcMatrixSwitchDemoDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CJcMatrixSwitchDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_COMBO2, m_cbbSwitch);
	DDX_Control(pDX, IDC_COMBO3, m_ccbTx1);
	DDX_Control(pDX, IDC_COMBO4, m_ccbTx2);
	DDX_Control(pDX, IDC_COMBO5, m_ccbPim);
	DDX_Control(pDX, IDC_COMBO6, m_ccbDet);
	DDX_Control(pDX, IDC_BUTTON2, m_ccbCommit);
	DDX_Control(pDX, IDC_COMBO7, m_ccbSWType);
	DDX_Control(pDX, IDC_BUTTON1, m_btnSwitch);
	DDX_Control(pDX, IDC_COMBO1, m_cbbSwitch2);
	DDX_Control(pDX, IDC_COMBO8, m_cbbSwitchIdx);
}

BEGIN_MESSAGE_MAP(CJcMatrixSwitchDemoDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()

//{{AFX_MSG_MAP(CJcMatrixSwitchDemoDlg)
//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDS_RADIO1, OnMyRadio1)
	ON_BN_CLICKED(IDS_RADIO2, OnMyRadio2)
	ON_BN_CLICKED(IDS_RADIO3, OnMyRadio3)
	ON_BN_CLICKED(IDS_RADIO4, OnMyRadio4)
	ON_BN_CLICKED(IDS_RADIO5, OnMyRadio5)
	ON_BN_CLICKED(IDS_RADIO6, OnMyRadio6)
	ON_BN_CLICKED(IDS_RADIO7, OnMyRadio7)
	ON_BN_CLICKED(IDS_RADIO8, OnMyRadio8)
	ON_BN_CLICKED(IDS_RADIO9, OnMyRadio9)
	ON_BN_CLICKED(IDS_RADIO10, OnMyRadio10)
	ON_BN_CLICKED(IDS_RADIO11, OnMyRadio11)
	ON_BN_CLICKED(IDS_RADIO12, OnMyRadio12)
	ON_BN_CLICKED(IDS_RADIO13, OnMyRadio13)
	ON_BN_CLICKED(IDS_RADIO14, OnMyRadio14)
	ON_BN_CLICKED(IDS_RADIO15, OnMyRadio15)
	ON_BN_CLICKED(IDS_RADIO16, OnMyRadio16)
	ON_BN_CLICKED(IDS_RADIO17, OnMyRadio17)
	ON_BN_CLICKED(IDS_RADIO18, OnMyRadio18)
	ON_BN_CLICKED(IDS_RADIO19, OnMyRadio19)
	ON_BN_CLICKED(IDS_RADIO20, OnMyRadio20)
	ON_BN_CLICKED(IDS_RADIO21, OnMyRadio21)
	ON_BN_CLICKED(IDS_RADIO22, OnMyRadio22)
	ON_BN_CLICKED(IDS_RADIO23, OnMyRadio23)
	ON_BN_CLICKED(IDS_RADIO24, OnMyRadio24)
	ON_BN_CLICKED(IDS_RADIO25, OnMyRadio25)
	ON_BN_CLICKED(IDS_RADIO26, OnMyRadio26)
	ON_BN_CLICKED(IDS_RADIO27, OnMyRadio27)
	ON_BN_CLICKED(IDS_RADIO28, OnMyRadio28)
	ON_BN_CLICKED(IDS_RADIO29, OnMyRadio29)
	ON_BN_CLICKED(IDS_RADIO30, OnMyRadio30)
	ON_BN_CLICKED(IDS_RADIO31, OnMyRadio31)
	ON_BN_CLICKED(IDS_RADIO32, OnMyRadio32)
	ON_BN_CLICKED(IDS_RADIO33, OnMyRadio33)
	ON_BN_CLICKED(IDS_RADIO34, OnMyRadio34)
	ON_BN_CLICKED(IDS_RADIO35, OnMyRadio35)
	ON_BN_CLICKED(IDS_RADIO36, OnMyRadio36)
	ON_BN_CLICKED(IDS_RADIO37, OnMyRadio37)
	ON_BN_CLICKED(IDS_RADIO38, OnMyRadio38)
	ON_BN_CLICKED(IDS_RADIO39, OnMyRadio39)
	ON_BN_CLICKED(IDS_RADIO40, OnMyRadio40)
	ON_BN_CLICKED(IDS_RADIO80, OnMyRadio80)
	ON_BN_CLICKED(IDS_RADIO81, OnMyRadio81)
	//ON_BN_CLICKED(IDS_RADIO82, OnMyRadio82)
	//ON_BN_CLICKED(IDS_RADIO83, OnMyRadio83)
	//ON_BN_CLICKED(IDS_RADIO84, OnMyRadio84)
	//ON_BN_CLICKED(IDS_RADIO85, OnMyRadio85)
	ON_CBN_SELCHANGE(IDC_COMBO2, &CJcMatrixSwitchDemoDlg::OnSelchangeCombo2)
	ON_CBN_SELCHANGE(IDC_COMBO3, &CJcMatrixSwitchDemoDlg::OnSelchangeCombo3)
	ON_CBN_SELCHANGE(IDC_COMBO4, &CJcMatrixSwitchDemoDlg::OnSelchangeCombo4)
	ON_CBN_SELCHANGE(IDC_COMBO5, &CJcMatrixSwitchDemoDlg::OnSelchangeCombo5)
	ON_CBN_SELCHANGE(IDC_COMBO6, &CJcMatrixSwitchDemoDlg::OnSelchangeCombo6)
	ON_BN_CLICKED(IDC_BUTTON2, &CJcMatrixSwitchDemoDlg::OnClickedButton2)
	ON_CBN_SELCHANGE(IDC_COMBO7, &CJcMatrixSwitchDemoDlg::OnCbnSelchangeCombo7)
	ON_BN_CLICKED(IDC_BUTTON1, &CJcMatrixSwitchDemoDlg::OnBnClickedButton1)
END_MESSAGE_MAP()

// CJcMatrixSwitchDemoDlg message handlers

BOOL CJcMatrixSwitchDemoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	for (size_t i = 0; i < 100; i++)
	{
		p_MyRadio[i] = NULL;
	}

	// TODO: Add extra initialization here
	int btIdx = 0,grp = 0;
	//信号源开关1
	{
		int x = 50, y = 100;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO1, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO2, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO3, CRect(x + 100, y + 40, x + 140, y + 60), 0);
		//p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO80, CRect(x + 140, y + 40, x + 180, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP1, CRect(x + 10, y + 20, x + 190, y + 65), 0);
	}
	//信号源开关2
	{
		int x = 240, y = 100;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO4, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO5, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO6, CRect(x + 100, y + 40, x + 140, y + 60), 0);
		//p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO81, CRect(x + 140, y + 40, x + 180, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP2, CRect(x + 10, y + 20, x + 190, y + 65), 0);
	}
	//收信开关
	{
		int x = 50, y = 160;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO15, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO16, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO17, CRect(x + 100, y + 40, x + 140, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO18, CRect(x + 140, y + 40, x + 180, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO19, CRect(x + 180, y + 40, x + 220, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO20, CRect(x + 220, y + 40, x + 260, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO21, CRect(x + 260, y + 40, x + 300, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP5, CRect(x + 10, y + 20, x + 310, y + 65), 0);
	}
	//检测开关
	{
		int x = 360, y = 160;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO22, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO23, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO24, CRect(x + 100, y + 40, x + 140, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO25, CRect(x + 140, y + 40, x + 180, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO26, CRect(x + 180, y + 40, x + 220, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO27, CRect(x + 220, y + 40, x + 260, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO28, CRect(x + 260, y + 40, x + 300, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP6, CRect(x + 10, y + 20, x + 310, y + 65), 0);
	}

	//功放开关1
	{
		int x = 50, y = 220;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO7, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO8, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO9, CRect(x + 100, y + 40, x + 140, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO10, CRect(x + 140, y + 40, x + 180, y + 60), 0);
		//p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO82, CRect(x + 180, y + 40, x + 220, y + 60), 0);
		//p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO83, CRect(x + 220, y + 40, x + 260, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP3, CRect(x + 10, y + 20, x + 270, y + 65), 0);
	}
	//功放开关2
	{
		int x = 250, y = 220;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO11, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO12, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO13, CRect(x + 100, y + 40, x + 140, y + 60), 0);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO14, CRect(x + 140, y + 40, x + 180, y + 60), 0);
		//p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO84, CRect(x + 180, y + 40, x + 220, y + 60), 0);
		//p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO85, CRect(x + 220, y + 40, x + 260, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP4, CRect(x + 10, y + 20, x + 270, y + 65), 0);
	}

	{
		int x = 50, y = 280;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO31, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO32, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP8, CRect(x + 10, y + 20, x + 100, y + 65), 0);
	}

	{
		int x = 150, y = 280;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO33, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO34, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP9, CRect(x + 10, y + 20, x + 100, y + 65), 0);
	}

	{
		int x = 250, y = 280;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO35, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO36, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP10, CRect(x + 10, y + 20, x + 100, y + 65), 0);
	}


	{
		int x = 350, y = 280;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO29, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO30, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP7, CRect(x + 10, y + 20, x + 100, y + 65), 0);
	}

	{
		int x = 450, y = 280;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO39, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO40, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP12, CRect(x + 10, y + 20, x + 100, y + 65), 0);
	}

	{
		int x = 550, y = 280;
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO37, CRect(x + 20, y + 40, x + 60, y + 60), WS_GROUP);
		p_MyRadio[btIdx++] = NewMyRadio(IDS_RADIO38, CRect(x + 60, y + 40, x + 100, y + 60), 0);
		p_MyGroup[grp++] = NewMyGroup(IDS_GROUP11, CRect(x + 10, y + 20, x + 100, y + 65), 0);
	}

	for (size_t i = 0; i < 100; i++)
	{
		if (p_MyRadio[i] != NULL)
			p_MyRadio[i]->EnableWindow(FALSE);
	}

	for (size_t i = 0; i < 6; i++)
	{
		if (p_MyRadio[i] != NULL)
			p_MyRadio[i]->EnableWindow(TRUE);
	}

	m_ccbSWType.AddString(L"POI");
	m_ccbSWType.AddString(L"HUAWEI");
	m_ccbSWType.AddString(L"HUAWEI_EXT");

	m_btnSwitch.EnableWindow(FALSE);
	//m_ccbSWType.SetCurSel(0);

	//HINSTANCE hDLL;

	//hDLL = LoadLibrary(L"JcMatrixSwitch.dll");

	//pMSI = (pMartrixSwitchInit)GetProcAddress(hDLL, "MartrixSwitchInit");
	//pMSE1= (pMartrixSwitchBoxExcute)GetProcAddress(hDLL, "MartrixSwitchBoxExcute");
	//pMSE2= (pMartrixSwitchExcute)GetProcAddress(hDLL, "MartrixSwitchExcute");
	//pMSD = (pMartrixSwitchDispose)GetProcAddress(hDLL, "MartrixSwitchDispose");

	//int result = pMSI(NULL, NULL, ID_POI, COMM_TYPE_TCP);	

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CJcMatrixSwitchDemoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CJcMatrixSwitchDemoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CJcMatrixSwitchDemoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

CButton* CJcMatrixSwitchDemoDlg::NewMyRadio(int nID, CRect rect, int nStyle)
{
	CString m_Caption;
	m_Caption.LoadString(nID);
	CButton *p_Radio = new CButton();
	ASSERT_VALID(p_Radio);
	p_Radio->Create(m_Caption, WS_CHILD | WS_VISIBLE | nStyle | WS_TABSTOP | BS_AUTORADIOBUTTON, rect, this, nID); //创建按钮
	return p_Radio;
}

CButton* CJcMatrixSwitchDemoDlg::NewMyGroup(int nID, CRect rect, int nStyle)
{
	CString m_Caption;
	m_Caption.LoadString(nID);
	CButton *p_Radio = new CButton();
	ASSERT_VALID(p_Radio);
	p_Radio->Create(m_Caption, WS_CHILD | WS_VISIBLE | nStyle | WS_TABSTOP | BS_GROUPBOX, rect, this, nID); //创建按钮
	return p_Radio;
}

BOOL CJcMatrixSwitchDemoDlg::SwitchManual(int swId,int swIdx)
{
	wchar_t buf[256];
	wsprintf(buf, L"开关序号 = #%d , 开关引脚 = #%d", swId, swIdx);
	
	MessageBox(buf);

	int i = m_cbbSwitch.GetCurSel();

	int result = MartrixSwitchExcute(i+1, swId, swIdx);

	if (result != MATRIX_SWITCH_OK)
	{
		wchar_t tmp[10];
		swprintf_s(tmp, L"Error Return Code = %d", result);
		MessageBox(tmp);
	}

	return true;
}

void CJcMatrixSwitchDemoDlg::OnMyRadio1(){ SwitchManual(ID_SW1_SDT3,1);}
void CJcMatrixSwitchDemoDlg::OnMyRadio2(){ SwitchManual(ID_SW1_SDT3,2);} 
void CJcMatrixSwitchDemoDlg::OnMyRadio3(){ SwitchManual(ID_SW1_SDT3,3);} 
void CJcMatrixSwitchDemoDlg::OnMyRadio4(){ SwitchManual(ID_SW2_SDT3,1);} 
void CJcMatrixSwitchDemoDlg::OnMyRadio5(){ SwitchManual(ID_SW2_SDT3,2);} 
void CJcMatrixSwitchDemoDlg::OnMyRadio6(){ SwitchManual(ID_SW2_SDT3,3);} 
void CJcMatrixSwitchDemoDlg::OnMyRadio7(){ SwitchManual(ID_SW3_SDT4,1);} 
void CJcMatrixSwitchDemoDlg::OnMyRadio8(){ SwitchManual(ID_SW3_SDT4,2);} 
void CJcMatrixSwitchDemoDlg::OnMyRadio9(){ SwitchManual(ID_SW3_SDT4,3);} 
void CJcMatrixSwitchDemoDlg::OnMyRadio10(){SwitchManual(ID_SW3_SDT4,4);}
void CJcMatrixSwitchDemoDlg::OnMyRadio11(){SwitchManual(ID_SW4_SDT4,1);}
void CJcMatrixSwitchDemoDlg::OnMyRadio12(){SwitchManual(ID_SW4_SDT4,2);}
void CJcMatrixSwitchDemoDlg::OnMyRadio13(){SwitchManual(ID_SW4_SDT4,3);}
void CJcMatrixSwitchDemoDlg::OnMyRadio14(){SwitchManual(ID_SW4_SDT4,4);}
void CJcMatrixSwitchDemoDlg::OnMyRadio15(){SwitchManual(ID_SW5_SDT7,1);}
void CJcMatrixSwitchDemoDlg::OnMyRadio16(){SwitchManual(ID_SW5_SDT7,2);}
void CJcMatrixSwitchDemoDlg::OnMyRadio17(){SwitchManual(ID_SW5_SDT7,3);}
void CJcMatrixSwitchDemoDlg::OnMyRadio18(){SwitchManual(ID_SW5_SDT7,4);}
void CJcMatrixSwitchDemoDlg::OnMyRadio19(){SwitchManual(ID_SW5_SDT7,5);}
void CJcMatrixSwitchDemoDlg::OnMyRadio20(){SwitchManual(ID_SW5_SDT7,6);}
void CJcMatrixSwitchDemoDlg::OnMyRadio21(){SwitchManual(ID_SW5_SDT7,7);}
void CJcMatrixSwitchDemoDlg::OnMyRadio22(){SwitchManual(ID_SW6_SDT7,1);}
void CJcMatrixSwitchDemoDlg::OnMyRadio23(){SwitchManual(ID_SW6_SDT7,2);}
void CJcMatrixSwitchDemoDlg::OnMyRadio24(){SwitchManual(ID_SW6_SDT7,3);}
void CJcMatrixSwitchDemoDlg::OnMyRadio25(){SwitchManual(ID_SW6_SDT7,4);}
void CJcMatrixSwitchDemoDlg::OnMyRadio26(){SwitchManual(ID_SW6_SDT7,5);}
void CJcMatrixSwitchDemoDlg::OnMyRadio27(){SwitchManual(ID_SW6_SDT7,6);}
void CJcMatrixSwitchDemoDlg::OnMyRadio28(){SwitchManual(ID_SW6_SDT7,7);}
void CJcMatrixSwitchDemoDlg::OnMyRadio29(){SwitchManual(ID_SW7_SDT2,1);}
void CJcMatrixSwitchDemoDlg::OnMyRadio30(){SwitchManual(ID_SW7_SDT2,2);}
void CJcMatrixSwitchDemoDlg::OnMyRadio31(){SwitchManual(ID_SW8_SDT2,1);}
void CJcMatrixSwitchDemoDlg::OnMyRadio32(){SwitchManual(ID_SW8_SDT2,2);}
void CJcMatrixSwitchDemoDlg::OnMyRadio33(){SwitchManual(ID_SW9_SDT2,1);}
void CJcMatrixSwitchDemoDlg::OnMyRadio34(){SwitchManual(ID_SW9_SDT2,2);}
void CJcMatrixSwitchDemoDlg::OnMyRadio35(){SwitchManual(ID_SW10_SDT2,1);}
void CJcMatrixSwitchDemoDlg::OnMyRadio36(){SwitchManual(ID_SW10_SDT2,2);}
void CJcMatrixSwitchDemoDlg::OnMyRadio37(){SwitchManual(ID_SW11_SDT2,1);}
void CJcMatrixSwitchDemoDlg::OnMyRadio38(){SwitchManual(ID_SW11_SDT2,2);}
void CJcMatrixSwitchDemoDlg::OnMyRadio39(){SwitchManual(ID_SW12_SDT2,1);}
void CJcMatrixSwitchDemoDlg::OnMyRadio40(){SwitchManual(ID_SW12_SDT2,2);}
void CJcMatrixSwitchDemoDlg::OnMyRadio80(){SwitchManual(ID_SW1_SDT3, 4); }
void CJcMatrixSwitchDemoDlg::OnMyRadio81(){ SwitchManual(ID_SW2_SDT3, 4); }
//void CJcMatrixSwitchDemoDlg::OnMyRadio82(){ SwitchManual(ID_SW1_SDT3, 5); }
//void CJcMatrixSwitchDemoDlg::OnMyRadio83(){ SwitchManual(ID_SW2_SDT3, 6); }
//void CJcMatrixSwitchDemoDlg::OnMyRadio84(){ SwitchManual(ID_SW1_SDT3, 5); }
//void CJcMatrixSwitchDemoDlg::OnMyRadio85(){ SwitchManual(ID_SW2_SDT3, 6); }

void CJcMatrixSwitchDemoDlg::OnSelchangeCombo2()
{
	// TODO: Add your control notification handler code here
	int i = m_cbbSwitch.GetCurSel();

	for (size_t j = 0; j < 100; j++)
	{
		if (p_MyRadio[j] != NULL)
			p_MyRadio[j]->EnableWindow(FALSE);
	}

	if (i == 0)
	{
		for (size_t k = 0; k < 6; k++)
		{
			p_MyRadio[k]->EnableWindow(TRUE);
		}		
	}
	else if (i == 1)
	{
		for (size_t k = 6; k < 28; k++)
		{
			p_MyRadio[k]->EnableWindow(TRUE);
		}
	}
	else
	{
		for (size_t k = 28; k < 40; k++)
		{
			p_MyRadio[k]->EnableWindow(TRUE);
		}
	}
}


void CJcMatrixSwitchDemoDlg::OnSelchangeCombo3()
{
	// TODO: Add your control notification handler code here
	int i = m_ccbTx1.GetCurSel();
}


void CJcMatrixSwitchDemoDlg::OnSelchangeCombo4()
{
	// TODO: Add your control notification handler code here
	int i = m_ccbTx2.GetCurSel();
}


void CJcMatrixSwitchDemoDlg::OnSelchangeCombo5()
{
	// TODO: Add your control notification handler code here
	int i = m_ccbPim.GetCurSel();
}


void CJcMatrixSwitchDemoDlg::OnSelchangeCombo6()
{
	// TODO: Add your control notification handler code here
	int i = m_ccbDet.GetCurSel();
}


void CJcMatrixSwitchDemoDlg::OnClickedButton2()
{
	// TODO: Add your control notification handler code here
	int a = m_ccbTx1.GetCurSel();
	int b = m_ccbTx2.GetCurSel();
	int c = m_ccbPim.GetCurSel();
	int d = m_ccbDet.GetCurSel();

	int result = MartrixSwitchBoxExcute(a, b, c, d);

	if (result != MATRIX_SWITCH_OK)
	{
		wchar_t tmp[10];
		swprintf_s(tmp, L"Error Return Code = %d", result);
		MessageBox(tmp);
	}
}


void CJcMatrixSwitchDemoDlg::OnCbnSelchangeCombo7()
{
	// TODO: Add your control notification handler code here
	int idx = m_ccbSWType.GetCurSel();

	m_btnSwitch.EnableWindow(TRUE);

	m_cbbSwitch.ResetContent();
	m_cbbSwitch2.ResetContent();
	m_cbbSwitchIdx.ResetContent();
	
	if (idx == 0)
	{		

		for (size_t j = 0; j < 6; j++)
		{
			if (p_MyRadio[j] != NULL)
				p_MyRadio[j]->EnableWindow(TRUE);
		}

		m_cbbSwitch.ResetContent();
		m_cbbSwitch.AddString(L"IP_Signalswich");
		m_cbbSwitch.AddString(L"IP_Paspecumpwmt");
		m_cbbSwitch.AddString(L"IP_Testmdcdmagsm");
		m_cbbSwitch.AddString(L"IP_Testmdfdd18");
		m_cbbSwitch.AddString(L"IP_Testmdfdd21");
		m_cbbSwitch.AddString(L"IP_Testmdtdftda");
		m_cbbSwitch.AddString(L"IP_Testmdtdd23");
		m_cbbSwitch.SetCurSel(0);

		m_ccbTx1.ResetContent();
		m_ccbTx1.AddString(L"1Cmgsmtx1 ");
		m_ccbTx1.AddString(L"2Cucdmatx1");
		m_ccbTx1.AddString(L"3Ctfd18tx1");
		m_ccbTx1.AddString(L"4Cufd18tx1");
		m_ccbTx1.AddString(L"5Ctfd21tx1");
		m_ccbTx1.AddString(L"6Cuw21tx1 ");
		m_ccbTx1.AddString(L"7Cmdcstx1 ");
		m_ccbTx1.AddString(L"8Cmtdftx1 ");
		m_ccbTx1.AddString(L"9null");
		m_ccbTx1.AddString(L"10Cmtdetx1");
		m_ccbTx1.AddString(L"11Cttdetx1");
		m_ccbTx1.AddString(L"12null");
		m_ccbTx1.AddString(L"13Cmtdftx1 ");
		m_ccbTx1.AddString(L"14null");
		m_ccbTx1.AddString(L"15Cmtdetx1");
		m_ccbTx1.AddString(L"16Cttdetx1");
		m_ccbTx1.AddString(L"17null");
		m_ccbTx1.SetCurSel(0);

		m_ccbTx2.ResetContent();
		m_ccbTx2.AddString(L"1Cmgsmtx2 ");
		m_ccbTx2.AddString(L"2Cucdmatx2");
		m_ccbTx2.AddString(L"3Ctfd18tx2");
		m_ccbTx2.AddString(L"4Cufd18tx2");
		m_ccbTx2.AddString(L"5Ctfd21tx2");
		m_ccbTx2.AddString(L"6Cuw21tx2 ");
		m_ccbTx2.AddString(L"7Cmdcstx2 ");
		m_ccbTx2.AddString(L"8Cmtdftx2 ");
		m_ccbTx2.AddString(L"9Cmtdatx2 ");
		m_ccbTx2.AddString(L"10Cmtdetx2");
		m_ccbTx2.AddString(L"11null");
		m_ccbTx2.AddString(L"12Cutdetx2");
		m_ccbTx2.AddString(L"13Cmtdftx2 ");
		m_ccbTx2.AddString(L"14Cmtdatx2 ");
		m_ccbTx2.AddString(L"15Cmtdetx2");
		m_ccbTx2.AddString(L"16null");
		m_ccbTx2.AddString(L"17Cutdetx2");
		m_ccbTx2.SetCurSel(0);

		m_ccbPim.ResetContent();
		m_ccbPim.AddString(L"1gsmpim    ");
		m_ccbPim.AddString(L"2cdmapim   ");
		m_ccbPim.AddString(L"3ctfd18pim ");
		m_ccbPim.AddString(L"4cufd18pim ");
		m_ccbPim.AddString(L"5ctfd21pim ");
		m_ccbPim.AddString(L"6cuw21pim  ");
		m_ccbPim.AddString(L"7cmdcspim  ");
		m_ccbPim.AddString(L"8cmtdfpim  ");
		m_ccbPim.AddString(L"9null");
		m_ccbPim.AddString(L"10cmtde23pim");
		m_ccbPim.AddString(L"11cttde23pim");
		m_ccbPim.AddString(L"12null");
		m_ccbPim.AddString(L"13cmtdfpim  ");
		m_ccbPim.AddString(L"14null");
		m_ccbPim.AddString(L"15cmtde23pim");
		m_ccbPim.AddString(L"16cttde23pim");
		m_ccbPim.AddString(L"17null");
		m_ccbPim.SetCurSel(0);

		m_ccbDet.ResetContent();
		m_ccbDet.AddString(L"1Cdmagsmcp1");
		m_ccbDet.AddString(L"2Cdmagsmcp2");
		m_ccbDet.AddString(L"3fdd18cp1  ");
		m_ccbDet.AddString(L"4fdd18cp2  ");
		m_ccbDet.AddString(L"5fdd21cp1  ");
		m_ccbDet.AddString(L"6fdd21cp2  ");
		m_ccbDet.AddString(L"7tdftdacp1 ");
		m_ccbDet.AddString(L"8tdftdacp2 ");
		m_ccbDet.AddString(L"9tdftdacp3 ");
		m_ccbDet.AddString(L"10tde23cp1  ");
		m_ccbDet.AddString(L"11tde23cp2  ");
		m_ccbDet.SetCurSel(0);

		MartrixSwitchDispose();
		int result = MartrixSwitchInit(NULL, "JcMatrixSwitchDemo.exe", ID_POI, COMM_TYPE_TCP);

		if (result != MATRIX_SWITCH_OK)
		{
			wchar_t tmp[10];
			swprintf_s(tmp, L"Error Return Code = %d", result);
			MessageBox(tmp);
		}
	}
	else if (idx == 1)
	{

		for (size_t j = 0; j < 100; j++)
		{
			if (p_MyRadio[j] != NULL)
				p_MyRadio[j]->EnableWindow(FALSE);
		}

		m_ccbTx1.ResetContent();
		m_ccbTx1.AddString(L"TX1_1_700");
		m_ccbTx1.AddString(L"TX1_2_700");
		m_ccbTx1.AddString(L"TX1_1_800");
		m_ccbTx1.AddString(L"TX1_2_800");
		m_ccbTx1.AddString(L"TX1_1_900");
		m_ccbTx1.AddString(L"TX1_2_900 ");
		m_ccbTx1.AddString(L"TX1_1_1800 ");
		m_ccbTx1.AddString(L"TX1_2_1800 ");
		m_ccbTx1.AddString(L"TX1_1_1900");
		m_ccbTx1.AddString(L"TX1_2_1900");
		m_ccbTx1.AddString(L"TX1_1_2100");
		m_ccbTx1.AddString(L"TX1_2_2100");
		m_ccbTx1.AddString(L"TX1_1_2600");
		m_ccbTx1.AddString(L"TX1_2_2600");
		m_ccbTx1.SetCurSel(0);

		m_ccbTx2.ResetContent();
		m_ccbTx2.AddString(L"TX2_1_700");
		m_ccbTx2.AddString(L"TX2_2_700");
		m_ccbTx2.AddString(L"TX2_1_800");
		m_ccbTx2.AddString(L"TX2_2_800");
		m_ccbTx2.AddString(L"TX2_1_900");
		m_ccbTx2.AddString(L"TX2_2_900 ");
		m_ccbTx2.AddString(L"TX2_1_1800 ");
		m_ccbTx2.AddString(L"TX2_2_1800 ");
		m_ccbTx2.AddString(L"TX2_1_1900");
		m_ccbTx2.AddString(L"TX2_2_1900");
		m_ccbTx2.AddString(L"TX2_1_2100");
		m_ccbTx2.AddString(L"TX2_2_2100");
		m_ccbTx2.AddString(L"TX2_1_2600");
		m_ccbTx2.AddString(L"TX2_2_2600");
		m_ccbTx2.SetCurSel(0);

		m_ccbPim.ResetContent();
		m_ccbPim.AddString(L"PIM_1_700");
		m_ccbPim.AddString(L"PIM_2_700");
		m_ccbPim.AddString(L"PIM_1_800");
		m_ccbPim.AddString(L"PIM_2_800");
		m_ccbPim.AddString(L"PIM_1_900");
		m_ccbPim.AddString(L"PIM_2_900 ");
		m_ccbPim.AddString(L"PIM_1_1800 ");
		m_ccbPim.AddString(L"PIM_2_1800 ");
		m_ccbPim.AddString(L"PIM_1_1900");
		m_ccbPim.AddString(L"PIM_2_1900");
		m_ccbPim.AddString(L"PIM_1_2100");
		m_ccbPim.AddString(L"PIM_2_2100");
		m_ccbPim.AddString(L"PIM_1_2600");
		m_ccbPim.AddString(L"PIM_2_2600");
		m_ccbPim.SetCurSel(0);

		m_ccbDet.ResetContent();
		m_ccbDet.AddString(L"DET_1_700");
		m_ccbDet.AddString(L"DET_2_700");
		m_ccbDet.AddString(L"DET_1_800");
		m_ccbDet.AddString(L"DET_2_800");
		m_ccbDet.AddString(L"DET_1_900");
		m_ccbDet.AddString(L"DET_2_900 ");
		m_ccbDet.AddString(L"DET_1_1800 ");
		m_ccbDet.AddString(L"DET_2_1800 ");
		m_ccbDet.AddString(L"DET_1_1900");
		m_ccbDet.AddString(L"DET_2_1900");
		m_ccbDet.AddString(L"DET_1_2100");
		m_ccbDet.AddString(L"DET_2_2100");
		m_ccbDet.AddString(L"DET_1_2600");
		m_ccbDet.AddString(L"DET_2_2600");
		m_ccbDet.SetCurSel(0);

		m_cbbSwitch.ResetContent();
		m_cbbSwitch.AddString(L"Signalswich                 ");
		m_cbbSwitch.AddString(L"Paspecumpwmt         ");
		m_cbbSwitch.AddString(L"Testmdlte700             ");
		m_cbbSwitch.AddString(L"Testmddd800             ");
		m_cbbSwitch.AddString(L"Testmdgsm900          ");
		m_cbbSwitch.AddString(L"Testmddcs1800         ");
		m_cbbSwitch.AddString(L"Testmdpcs1900         ");
		m_cbbSwitch.AddString(L"Testmdwcdma2100  ");
		m_cbbSwitch.AddString(L"Testmdlte2600           ");
		m_cbbSwitch.SetCurSel(0);

		m_cbbSwitch2.ResetContent();
		m_cbbSwitch2.AddString(L"SW1_Signal1swich              ");
		m_cbbSwitch2.AddString(L"SW2_Signal2swich              ");
		m_cbbSwitch2.AddString(L"SW3_PA1swich1                 ");
		m_cbbSwitch2.AddString(L"SW4_PA1swich2                 ");
		m_cbbSwitch2.AddString(L"SW5_PA2swich1                 ");
		m_cbbSwitch2.AddString(L"SW6_PA2swich2                 ");
		m_cbbSwitch2.AddString(L"SW7_Spectrumswich       ");
		m_cbbSwitch2.AddString(L"SW8_Powermeterswich  ");
		m_cbbSwitch2.AddString(L"SW9_Couplerswich            ");
		m_cbbSwitch2.AddString(L"SW10_Pimswich                    ");
		m_cbbSwitch2.AddString(L"SW11_Txoutswich				");
		m_cbbSwitch2.SetCurSel(0);

		MartrixSwitchDispose();
		int result = MartrixSwitchInit(NULL, "JcMatrixSwitchDemo.exe", ID_HUAWEI, COMM_TYPE_TCP);

		if (result != MATRIX_SWITCH_OK)
		{
			wchar_t tmp[10];
			swprintf_s(tmp, L"Error Return Code = %d", result);
			MessageBox(tmp);
		}
	}
	else if (idx == 2)
	{

		for (size_t j = 0; j < 100; j++)
		{
			if (p_MyRadio[j] != NULL)
				p_MyRadio[j]->EnableWindow(FALSE);
		}

		m_ccbTx1.ResetContent();
		m_ccbTx1.AddString(L"1tx1to4501ant1                ") ;
		m_ccbTx1.AddString(L"2tx1to4501ant2                ") ;
		m_ccbTx1.AddString(L"3tx1to4502ant1                ") ;
		m_ccbTx1.AddString(L"4tx1to4502ant2                ") ;
		m_ccbTx1.AddString(L"5tx1to700lant1                 " ) ;
		m_ccbTx1.AddString(L"6tx1to700lant2                 " ) ;
		m_ccbTx1.AddString(L"7tx1to700hant1                ") ;
		m_ccbTx1.AddString(L"8tx1to700hant2                ") ;
		m_ccbTx1.AddString(L"9tx1to700aptant1            " ) ;
		m_ccbTx1.AddString(L"10tx1to700aptant2          ") ;
		m_ccbTx1.AddString(L"11tx1todd800ant1           ") ;
		m_ccbTx1.AddString(L"12tx1todd800ant2           ") ;
		m_ccbTx1.AddString(L"13tx1tocdma800ant1      ") ;
		m_ccbTx1.AddString(L"14tx1tocdma800ant2      ") ;
		m_ccbTx1.AddString(L"15tx1tocdma800ant1      ") ;
		m_ccbTx1.AddString(L"16tx1tocdma800ant2      ") ;
		m_ccbTx1.AddString(L"17tx1todcs1800ant1        ") ;
		m_ccbTx1.AddString(L"18tx1todcs1800ant2        ") ;
		m_ccbTx1.AddString(L"19tx1topcs1900ant1        ") ;
		m_ccbTx1.AddString(L"20tx1topcs1900ant2        ") ;
		m_ccbTx1.AddString(L"21tx1towcdma2100ant1 ") ;
		m_ccbTx1.AddString(L"22tx1towcdma2100ant2 ") ;
		m_ccbTx1.AddString(L"23tx1towcdma2600ant1 ") ;
		m_ccbTx1.AddString(L"24tx1towcdma2600ant2 ") ;
		m_ccbTx1.SetCurSel(0);

		m_ccbTx2.ResetContent();
		m_ccbTx2.AddString(L"1tx2to4501ant1               ");
		m_ccbTx2.AddString(L"2tx2to4501ant2               ");
		m_ccbTx2.AddString(L"3tx2to4502ant1               ");
		m_ccbTx2.AddString(L"4tx2to4502ant2               ");
		m_ccbTx2.AddString(L"5tx2to700lant1                " );
		m_ccbTx2.AddString(L"6tx2to700lant2                " );
		m_ccbTx2.AddString(L"7tx2to700hant1               ");
		m_ccbTx2.AddString(L"8tx2to700hant2               ");
		m_ccbTx2.AddString(L"9tx2to700aptant1           " );
		m_ccbTx2.AddString(L"10tx2to700aptant2         ");
		m_ccbTx2.AddString(L"11tx2todd800ant1          ");
		m_ccbTx2.AddString(L"12tx2todd800ant2          ");
		m_ccbTx2.AddString(L"13tx2tocdma800ant1     ");
		m_ccbTx2.AddString(L"14tx2tocdma800ant2     ");
		m_ccbTx2.AddString(L"15tx2tocdma800ant1     ");
		m_ccbTx2.AddString(L"16tx2tocdma800ant2     ");
		m_ccbTx2.AddString(L"17tx2todcs1800ant1       ");
		m_ccbTx2.AddString(L"18tx2todcs1800ant2       ");
		m_ccbTx2.AddString(L"19tx2topcs1900ant1       ");
		m_ccbTx2.AddString(L"20tx2topcs1900ant2       ");
		m_ccbTx2.AddString(L"21tx2towcdma2100ant1");
		m_ccbTx2.AddString(L"22tx2towcdma2100ant2");
		m_ccbTx2.AddString(L"23tx1towcdma2600ant1");
		m_ccbTx2.AddString(L"24tx1towcdma2600ant2");
		m_ccbTx2.SetCurSel(0);

		m_ccbPim.ResetContent();
		m_ccbPim.AddString(L"1pimant1of4501                ");
		m_ccbPim.AddString(L"2pimant2of4501                ");
		m_ccbPim.AddString(L"3pimant1of4502                ");
		m_ccbPim.AddString(L"4pimant2of4502                ");
		m_ccbPim.AddString(L"5pimant1of700l                 ");
		m_ccbPim.AddString(L"6pimant2of700l                 ");
		m_ccbPim.AddString(L"7pimant1of700h                ");
		m_ccbPim.AddString(L"8pimant2of700h                ");
		m_ccbPim.AddString(L"9pimant1of700apt            ");
		m_ccbPim.AddString(L"10pimant2of700apt          ");
		m_ccbPim.AddString(L"11pimant1ofdd800           ");
		m_ccbPim.AddString(L"12pimant2ofdd800           ");
		m_ccbPim.AddString(L"13pimant1ofcdma800      ");
		m_ccbPim.AddString(L"14pimant2ofcdma800      ");
		m_ccbPim.AddString(L"15pimant1ofgsm900        ");
		m_ccbPim.AddString(L"16pimant2ofgsm900        ");
		m_ccbPim.AddString(L"17pimant1ofdcs1800        ");
		m_ccbPim.AddString(L"18pimant2ofdcs1800        ");
		m_ccbPim.AddString(L"19pimant1ofpcs1900        ");
		m_ccbPim.AddString(L"20pimant2ofpcs1900        ");
		m_ccbPim.AddString(L"21pimant1ofwcdam2100 ");
		m_ccbPim.AddString(L"22pimant2ofwcdma2100 ");
		m_ccbPim.AddString(L"23pimant1oflte2600         ");
		m_ccbPim.AddString(L"24pimant2oflte2600         ");
		m_ccbPim.SetCurSel(0);

		m_ccbDet.ResetContent();
		m_ccbDet.AddString(L"1couptx1of4501               ");
		m_ccbDet.AddString(L"2couptx2of4501               ");
		m_ccbDet.AddString(L"3couptx1of4502               ");
		m_ccbDet.AddString(L"4couptx2of4502               ");
		m_ccbDet.AddString(L"5couptx1of700l                ");
		m_ccbDet.AddString(L"6couptx2of700l                ");
		m_ccbDet.AddString(L"7couptx1of700h               ");
		m_ccbDet.AddString(L"8couptx2of700h               ");
		m_ccbDet.AddString(L"9couptx1of700apt           ");
		m_ccbDet.AddString(L"10couptx2of700apt         ");
		m_ccbDet.AddString(L"11couptx1ofdd800          ");
		m_ccbDet.AddString(L"12couptx2ofdd800          ");
		m_ccbDet.AddString(L"13couptx1ofcdma800     ");
		m_ccbDet.AddString(L"14couptx2ofcdma800     ");
		m_ccbDet.AddString(L"15couptx1ofgsm900       ");
		m_ccbDet.AddString(L"16couptx2ofgsm900       ");
		m_ccbDet.AddString(L"17couptx1ofdcs1800       ");
		m_ccbDet.AddString(L"18couptx2ofdcs1800       ");
		m_ccbDet.AddString(L"19couptx1ofpcs1900       ");
		m_ccbDet.AddString(L"20couptx2ofpcs1900       ");
		m_ccbDet.AddString(L"21couptx1ofwcdma2100");
		m_ccbDet.AddString(L"22couptx2ofwcdma2100");
		m_ccbDet.AddString(L"23couptx1oflte2600        ");
		m_ccbDet.AddString(L"24couptx2oflte2600        ");
		m_ccbDet.SetCurSel(0);

		m_cbbSwitch.ResetContent();
		m_cbbSwitch.AddString(L"Signalswich                 ");
		m_cbbSwitch.AddString(L"Paspecumpwmt         ");
		m_cbbSwitch.AddString(L"PaspecumpwmtP       ");
		m_cbbSwitch.AddString(L"Testmdlte700             ");
		m_cbbSwitch.AddString(L"Testmddd800             ");
		m_cbbSwitch.AddString(L"Testmdgsm900          ");
		m_cbbSwitch.AddString(L"Testmddcs1800         ");
		m_cbbSwitch.AddString(L"Testmdpcs1900         ");
		m_cbbSwitch.AddString(L"Testmdwcdma2100  ");
		m_cbbSwitch.AddString(L"Testmdlte2600           ");
		m_cbbSwitch.AddString(L"Testmd4501               ");
		m_cbbSwitch.AddString(L"Testmd4502               ");
		m_cbbSwitch.AddString(L"Testmd700h               ");
		m_cbbSwitch.AddString(L"Testmd700apt            ");
		m_cbbSwitch.AddString(L"Testmd800cdma        ");
		m_cbbSwitch.SetCurSel(0);

		m_cbbSwitch2.ResetContent();
		m_cbbSwitch2.AddString(L"SW1_Signal1swich              ");
		m_cbbSwitch2.AddString(L"SW2_Signal2swich              ");
		m_cbbSwitch2.AddString(L"SW3_Powermeterswich1  ");
		m_cbbSwitch2.AddString(L"SW4_Spectrumswich1       ");
		m_cbbSwitch2.AddString(L"SW5_PA1swich1                 ");
		m_cbbSwitch2.AddString(L"SW6_PA1swich2                 ");
		m_cbbSwitch2.AddString(L"SW7_PA2swich1                 ");
		m_cbbSwitch2.AddString(L"SW8_PA2swich2                 ");
		m_cbbSwitch2.AddString(L"SW9_Powermeterswich2  ");
		m_cbbSwitch2.AddString(L"SW10_Spectrumswich2       ");
		m_cbbSwitch2.AddString(L"SW11_PA3swich1                 ");
		m_cbbSwitch2.AddString(L"SW12_PA3swich2                 ");
		m_cbbSwitch2.AddString(L"SW13_Couplerswich            ");
		m_cbbSwitch2.AddString(L"SW14_Pimswich                    ");
		m_cbbSwitch2.AddString(L"SW15_Txoutswich				");
		m_cbbSwitch2.SetCurSel(0);				

		MartrixSwitchDispose();
		int result = MartrixSwitchInit(NULL, "JcMatrixSwitchDemo.exe", ID_HUAWEI_EXT12, COMM_TYPE_TCP);

		if (result != MATRIX_SWITCH_OK)
		{
			wchar_t tmp[10];
			swprintf_s(tmp, L"Error Return Code = %d", result);
			MessageBox(tmp);
		}
	}

	m_cbbSwitchIdx.ResetContent();
	m_cbbSwitchIdx.AddString(L"1  ");
	m_cbbSwitchIdx.AddString(L"2  ");
	m_cbbSwitchIdx.AddString(L"3  ");
	m_cbbSwitchIdx.AddString(L"4  ");
	m_cbbSwitchIdx.AddString(L"5  ");
	m_cbbSwitchIdx.AddString(L"6  ");
	m_cbbSwitchIdx.AddString(L"7  ");
	m_cbbSwitchIdx.SetCurSel(0);
}


void CJcMatrixSwitchDemoDlg::OnBnClickedButton1()
{
	//CDialogSwitch dlg(this, m_ccbSWType.GetCurSel());
	//dlg.DoModal();
	// TODO: Add your control notification handler code here

	int a = m_cbbSwitch.GetCurSel() + 1;
	int b = m_cbbSwitch2.GetCurSel() + 1;
	int c = m_cbbSwitchIdx.GetCurSel() + 1;

	int result = MartrixSwitchExcute(a, b, c);

	if (result != MATRIX_SWITCH_OK)
	{
		wchar_t tmp[10];
		swprintf_s(tmp, L"Error Return Code = %d", result);
		MessageBox(tmp);
	}
}
