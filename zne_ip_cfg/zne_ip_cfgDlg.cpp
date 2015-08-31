
// zne_ip_cfgDlg.cpp : implementation file
//

#include "stdafx.h"
#include "zne_ip_cfg.h"
#include "zne_ip_cfgDlg.h"
#include "DlgProxy.h"
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


// Czne_ip_cfgDlg dialog


IMPLEMENT_DYNAMIC(Czne_ip_cfgDlg, CDialogEx);

Czne_ip_cfgDlg::Czne_ip_cfgDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(Czne_ip_cfgDlg::IDD, pParent)
	, v_section(NULL)
	, v_mask(0)
	, v_host(0)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	m_pAutoProxy = NULL;
}

Czne_ip_cfgDlg::~Czne_ip_cfgDlg()
{
	// If there is an automation proxy for this dialog, set
	//  its back pointer to this dialog to NULL, so it knows
	//  the dialog has been deleted.
	if (m_pAutoProxy != NULL)
		m_pAutoProxy->m_pDialog = NULL;
}

void Czne_ip_cfgDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_BUTTON10, m_btn9);
	DDX_Control(pDX, IDC_BUTTON2, m_btn1);
	DDX_Control(pDX, IDC_BUTTON3, m_btn2);
	DDX_Control(pDX, IDC_BUTTON4, m_btn3);
	DDX_Control(pDX, IDC_BUTTON5, m_btn4);
	DDX_Control(pDX, IDC_BUTTON6, m_btn5);
	DDX_Control(pDX, IDC_BUTTON7, m_btn6);
	DDX_Control(pDX, IDC_BUTTON8, m_btn7);
	DDX_Control(pDX, IDC_BUTTON9, m_btn8);
	DDX_Control(pDX, IDC_IPADDRESS1, m_ipCurr1);
	DDX_Control(pDX, IDC_IPADDRESS3, m_ipCurr2);
	DDX_Control(pDX, IDC_IPADDRESS5, m_ipCurr3);
	DDX_Control(pDX, IDC_IPADDRESS7, m_ipCurr4);
	DDX_Control(pDX, IDC_IPADDRESS9, m_ipCurr5);
	DDX_Control(pDX, IDC_IPADDRESS11, m_ipCurr6);
	DDX_Control(pDX, IDC_IPADDRESS13, m_ipCurr7);
	DDX_Control(pDX, IDC_IPADDRESS15, m_ipCurr8);
	DDX_Control(pDX, IDC_IPADDRESS17, m_ipCurr9);
	DDX_Control(pDX, IDC_IPADDRESS2, m_ipChang1);
	DDX_Control(pDX, IDC_IPADDRESS4, m_ipChang2);
	DDX_Control(pDX, IDC_IPADDRESS6, m_ipChang3);
	DDX_Control(pDX, IDC_IPADDRESS8, m_ipChang4);
	DDX_Control(pDX, IDC_IPADDRESS10, m_ipChang5);
	DDX_Control(pDX, IDC_IPADDRESS12, m_ipChang6);
	DDX_Control(pDX, IDC_IPADDRESS14, m_ipChang7);
	DDX_Control(pDX, IDC_IPADDRESS16, m_ipChang8);
	DDX_Control(pDX, IDC_IPADDRESS18, m_ipChang9);
}

BEGIN_MESSAGE_MAP(Czne_ip_cfgDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_CLOSE()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON2, &Czne_ip_cfgDlg::OnBnClickedButton2)
//	ON_WM_MOUSEHWHEEL()
ON_BN_CLICKED(IDC_BUTTON3, &Czne_ip_cfgDlg::OnBnClickedButton3)
ON_BN_CLICKED(IDC_BUTTON4, &Czne_ip_cfgDlg::OnBnClickedButton4)
ON_BN_CLICKED(IDC_BUTTON5, &Czne_ip_cfgDlg::OnBnClickedButton5)
ON_BN_CLICKED(IDC_BUTTON6, &Czne_ip_cfgDlg::OnBnClickedButton6)
ON_BN_CLICKED(IDC_BUTTON7, &Czne_ip_cfgDlg::OnBnClickedButton7)
ON_BN_CLICKED(IDC_BUTTON8, &Czne_ip_cfgDlg::OnBnClickedButton8)
ON_BN_CLICKED(IDC_BUTTON9, &Czne_ip_cfgDlg::OnBnClickedButton9)
ON_BN_CLICKED(IDC_BUTTON10, &Czne_ip_cfgDlg::OnBnClickedButton10)
END_MESSAGE_MAP()


// Czne_ip_cfgDlg message handlers

BOOL Czne_ip_cfgDlg::OnInitDialog()
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

	// TODO: Add extra initialization here
	this->SetBackgroundColor(RGB(0x8B,0x63,0x6C), 1);

	char buf[256];

	memset(buf, 0, sizeof(buf));

	GetModuleFileNameA(NULL, buf, 256);

	//m_btn1.EnableWindow(false);
	string path(buf);
	path = path.substr(0,path.rfind('\\'));
	path.append("\\JcConfig.ini");
	v_iniPath = path;
	int ip=0,port;

	if (!PathFileExistsA(path.c_str()))
	{
		MessageBoxA(NULL, "本工具运行根目录需要文件：JcConfig.ini", "警告", 1);
		exit(0);
	}	

	//printf("ajhfkahghafsghlasfkl");

	GetPrivateProfileSectionA("ip",buf, 256, path.c_str());

	v_section.push_back("Signalswich");
	v_section.push_back("Paspecumpwmt");
	v_section.push_back("Testmdlte700");
	v_section.push_back("Testmddd800");
	v_section.push_back("Testmdgsm900");
	v_section.push_back("Testmddcs1800");
	v_section.push_back("Testmdpcs1900");
	v_section.push_back("Testmdwcdma2100");
	v_section.push_back("Testmdlte2600");

	//v_section.reverse();

	for (vector<string>::iterator itr = v_section.begin();
		itr != v_section.end();
		itr++)
	{
		GetPrivateProfileStringA("ip", (*itr).c_str(), "", buf, 256, path.c_str());
		GetIPPortFromStringchar(buf, &ip, &port);
		v_listip.push_back(ip);
		v_listport.push_back(port);
	}	

	m_btn1.SetWindowTextW(_T("连接"));
	m_btn2.SetWindowTextW(_T("连接"));
	m_btn3.SetWindowTextW(_T("连接"));
	m_btn4.SetWindowTextW(_T("连接"));
	m_btn5.SetWindowTextW(_T("连接"));
	m_btn6.SetWindowTextW(_T("连接"));
	m_btn7.SetWindowTextW(_T("连接"));
	m_btn8.SetWindowTextW(_T("连接"));
	m_btn9.SetWindowTextW(_T("连接"));

	m_ipCurr1.SetAddress(v_listip[0]);	m_ipCurr1.EnableWindow(false); m_ipChang1.SetAddress(v_listip[0]);	m_ipChang1.EnableWindow(false);
	m_ipCurr2.SetAddress(v_listip[1]);	m_ipCurr2.EnableWindow(false); m_ipChang2.SetAddress(v_listip[1]);	m_ipChang2.EnableWindow(false);
	m_ipCurr3.SetAddress(v_listip[2]);	m_ipCurr3.EnableWindow(false); m_ipChang3.SetAddress(v_listip[2]);	m_ipChang3.EnableWindow(false);
	m_ipCurr4.SetAddress(v_listip[3]);	m_ipCurr4.EnableWindow(false); m_ipChang4.SetAddress(v_listip[3]);	m_ipChang4.EnableWindow(false);
	m_ipCurr5.SetAddress(v_listip[4]);	m_ipCurr5.EnableWindow(false); m_ipChang5.SetAddress(v_listip[4]);	m_ipChang5.EnableWindow(false);
	m_ipCurr6.SetAddress(v_listip[5]);	m_ipCurr6.EnableWindow(false); m_ipChang6.SetAddress(v_listip[5]);	m_ipChang6.EnableWindow(false);
	m_ipCurr7.SetAddress(v_listip[6]);	m_ipCurr7.EnableWindow(false); m_ipChang7.SetAddress(v_listip[6]);	m_ipChang7.EnableWindow(false);
	m_ipCurr8.SetAddress(v_listip[7]);	m_ipCurr8.EnableWindow(false); m_ipChang8.SetAddress(v_listip[7]);	m_ipChang8.EnableWindow(false);
	m_ipCurr9.SetAddress(v_listip[8]);	m_ipCurr9.EnableWindow(false); m_ipChang9.SetAddress(v_listip[8]);	m_ipChang9.EnableWindow(false);

	NetEnsure ne;
	int hostTemp = v_listip[0];
	v_mask = (255 << 24) + (255 << 16) + (255 << 8);
	v_host = (hostTemp & 0xFFFFFF00) | 1;

	ne.LoadMaskHost(&v_mask, &v_host);
	if (1 == ne.DoModal()){}

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void Czne_ip_cfgDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void Czne_ip_cfgDlg::OnPaint()
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
HCURSOR Czne_ip_cfgDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

// Automation servers should not exit when a user closes the UI
//  if a controller still holds on to one of its objects.  These
//  message handlers make sure that if the proxy is still in use,
//  then the UI is hidden but the dialog remains around if it
//  is dismissed.

void Czne_ip_cfgDlg::OnClose()
{
	closesocket(hSocket);
	if (CanExit())
		CDialogEx::OnClose();
}

void Czne_ip_cfgDlg::OnOK()
{
	if (CanExit())
		CDialogEx::OnOK();
}

void Czne_ip_cfgDlg::OnCancel()
{
	if (CanExit())
		CDialogEx::OnCancel();
}

BOOL Czne_ip_cfgDlg::CanExit()
{
	// If the proxy object is still around, then the automation
	//  controller is still holding on to this application.  Leave
	//  the dialog around, but hide its UI.
	if (m_pAutoProxy != NULL)
	{
		ShowWindow(SW_HIDE);
		return FALSE;
	}

	return TRUE;
}



void Czne_ip_cfgDlg::GetIPPortFromStringchar(const char* str, int*ip, int* port)
{
	*ip = 0;

	std::string ipstr(str), strBuf;

	for (int i = 0; i < 3; i++)
	{
		strBuf = ipstr.substr(0, ipstr.find('.'));
		ipstr = ipstr.substr(strBuf.size() + 1, ipstr.size());
		*ip += atoi(strBuf.c_str()) << ((3 - i) * 8);
	}

	strBuf = ipstr.substr(0, ipstr.find(':'));
	ipstr = ipstr.substr(strBuf.size() + 1, ipstr.size());
	*ip += atoi(strBuf.c_str());
	*port = atoi(ipstr.c_str());
}



void Czne_ip_cfgDlg::OnBnClickedButton2()
{
	// TODO: Add your control notification handler code here
	PcsIPConfig(&m_btn1,&m_ipCurr1,&m_ipChang1,0);
	//this->m_btn1.SetWindowTextW(__T("123"));
}


void Czne_ip_cfgDlg::OnBnClickedButton3()
{
	// TODO: Add your control notification handler code here
	PcsIPConfig(&m_btn2, &m_ipCurr2, &m_ipChang2, 1);
	//this->m_btn2.SetWindowTextW(__T("123"));
}


void Czne_ip_cfgDlg::OnBnClickedButton4()
{
	// TODO: Add your control notification handler code here
	PcsIPConfig(&m_btn3, &m_ipCurr3, &m_ipChang3, 2);
	//this->m_btn3.SetWindowTextW(__T("123"));
}


void Czne_ip_cfgDlg::OnBnClickedButton5()
{
	// TODO: Add your control notification handler code here
	PcsIPConfig(&m_btn4, &m_ipCurr4, &m_ipChang4, 3);
	//this->m_btn4.SetWindowTextW(__T("123"));
}


void Czne_ip_cfgDlg::OnBnClickedButton6()
{
	// TODO: Add your control notification handler code here
	PcsIPConfig(&m_btn5, &m_ipCurr5, &m_ipChang5, 4);
	//this->m_btn5.SetWindowTextW(__T("123"));
}


void Czne_ip_cfgDlg::OnBnClickedButton7()
{
	// TODO: Add your control notification handler code here
	PcsIPConfig(&m_btn6, &m_ipCurr6, &m_ipChang6, 5);
	//this->m_btn6.SetWindowTextW(__T("123"));
}


void Czne_ip_cfgDlg::OnBnClickedButton8()
{
	// TODO: Add your control notification handler code here
	PcsIPConfig(&m_btn7, &m_ipCurr7, &m_ipChang7, 6);
	//this->m_btn7.SetWindowTextW(__T("123"));
}


void Czne_ip_cfgDlg::OnBnClickedButton9()
{
	// TODO: Add your control notification handler code here
	PcsIPConfig(&m_btn8, &m_ipCurr8, &m_ipChang8, 7);
	//this->m_btn8.SetWindowTextW(__T("123"));
}


void Czne_ip_cfgDlg::OnBnClickedButton10()
{
	// TODO: Add your control notification handler code here
	PcsIPConfig(&m_btn9, &m_ipCurr9, &m_ipChang9, 8);
	//this->m_btn9.SetWindowTextW(__T("123"));
}


bool Czne_ip_cfgDlg::PcsIPConfig(CButton* btn, CIPAddressCtrl* cips, CIPAddressCtrl* cipd, int idx)
{
	vector<CButton*>btnVec;
	btnVec.push_back(&m_btn1);
	btnVec.push_back(&m_btn2);
	btnVec.push_back(&m_btn3);
	btnVec.push_back(&m_btn4);
	btnVec.push_back(&m_btn5);
	btnVec.push_back(&m_btn6);
	btnVec.push_back(&m_btn7);
	btnVec.push_back(&m_btn8);
	btnVec.push_back(&m_btn9);

	CString textBtn;
	btn->GetWindowTextW(textBtn);

	if (textBtn == "连接")
	{
		btn->SetWindowTextW(__T("等待"));

		hSocket = WSASocket(AF_INET, SOCK_STREAM, 0, NULL, 0, NULL);

		if (hSocket == INVALID_SOCKET)
		{
			btn->SetWindowTextW(_T("连接"));
			cipd->EnableWindow(false);
			return false;
		}

		SOCKADDR_IN addr;
		string ips;
		UINT ipSouce;

		cips->GetAddress((DWORD&)ipSouce);
		IPIntToStr(ipSouce, ips);

		addr.sin_family = AF_INET;
		addr.sin_addr.s_addr = inet_addr(ips.c_str());
		//addr.sin_addr.s_addr = inet_addr("127.0.0.1");
		addr.sin_port = htons(3003);

		if (0 != connect(hSocket, (struct sockaddr *)&addr, sizeof(addr)))
		{
			MessageBoxA(this->GetSafeHwnd(), "连接失败！", "警告", 0);
			closesocket(hSocket);
			btn->SetWindowTextW(_T("连接"));
			cipd->EnableWindow(false);
			return false;
		}

		for (vector<CButton*>::iterator itr = btnVec.begin();
			itr != btnVec.end();
			itr++)
		{
			(*itr)->EnableWindow(false);
		}

		btn->SetWindowTextW(_T("配置"));
		btn->EnableWindow(true);
		cipd->EnableWindow(true);

		//MessageBoxA(this->GetSafeHwnd(), "请修改IP地址！", "提示", 0);
	}
	else
	{
		for (vector<CButton*>::iterator itr = btnVec.begin();
			itr != btnVec.end();
			itr++)
		{
			(*itr)->EnableWindow(true);
		}

		string atip, oip;
		UINT ipDest;
		cipd->GetAddress((DWORD&)ipDest);

		if ((ipDest&v_mask) != (v_host&v_mask))
		{
			MessageBoxA(this->GetSafeHwnd(), "与先前设置的网关网段不符，退出配置！", "警告", 0);
			closesocket(hSocket);
			btn->SetWindowTextW(_T("连接"));
			cipd->EnableWindow(false);
			return false;
		}

		btn->SetWindowTextW(_T("稍等！"));

		IPIntToStr(ipDest, oip);
		atip.append("AT+IP=" + oip + "\r\n");

		string atmark, omask;
		IPIntToStr(v_mask, omask);
		atmark.append("AT+MARK=" + omask + "\r\n");

		string atgate, ogate;
		IPIntToStr(v_host, ogate);
		atgate.append("AT+GATEWAY=" + ogate + "\r\n");

		list<string> cmdInit;

		cmdInit.push_back("AT+MODE=0\r\n");
		cmdInit.push_back("AT+LOGIN=88888\r\n");
		cmdInit.push_back("AT\r\n");
		cmdInit.push_back("AT+ECHO=0\r\n");
		cmdInit.push_back(atip);
		cmdInit.push_back(atmark);
		cmdInit.push_back(atgate);
		cmdInit.push_back("AT+RESET=88888\r\n");//复位设备

		char buf[1024];
		bool result = true;

		for (list<string>::iterator itr = cmdInit.begin();
			itr != cmdInit.end();
			itr++
			)
		{
			send(hSocket, (*itr).c_str(), (*itr).size(), 0);
			Sleep(250);
			memset(buf,0,1024);
			int rec = recv(hSocket, buf, 1024, 0);
			string strprint(buf);

			if (strstr(buf, "OK") == NULL && "AT+MODE=0\r\n" != *itr && "AT+LOGIN=88888\r\n" != *itr)
			//if (strstr(buf, "OK") == NULL && "AT+MODE=0\r\n" != *itr)//"AT+LOGIN=88888\r\n"回复可能不包含“OK”
			{  
				result = false;				
				MessageBoxA(this->GetSafeHwnd(), "配置失败！", "警告", 0);
				break;
			}
		}

		if (result)
		{
			cips->SetAddress(IPStrToInt(oip));

			oip.append(":4001");
			//保存
			BOOL wrps = WritePrivateProfileStringA("ip", v_section[idx].c_str(), oip.c_str(), v_iniPath.c_str());

			if (!wrps)
			{
				MessageBoxA(this->GetSafeHwnd(), "保存失败！", "警告", 0);
			}
			else
			{
				MessageBoxA(this->GetSafeHwnd(), "配置并保存成功！", "提示", 0);
			}
		}

		closesocket(hSocket);

		btn->SetWindowTextW(_T("连接"));
		cipd->EnableWindow(false);
	}

	return false;
}


int Czne_ip_cfgDlg::IPStrToInt(string ip)
{
	ip.append(":5002");

	int ipt, port;

	GetIPPortFromStringchar(ip.c_str(),&ipt,&port);

	return ipt;
}


void Czne_ip_cfgDlg::IPIntToStr(int ipi, string&stro)
{
	unsigned char a, b, c, d;

	a = ipi >> 24;
	b = (ipi >> 16) & 0xff;
	c = (ipi >> 8) & 0xff;
	d = ipi & 0xff;

	char buf[50];
	string ip;

	_itoa_s(a,buf,10);
	ip.assign(buf);
	ip.append(".");

	_itoa_s(b, buf, 10);
	ip.append(buf);
	ip.append(".");

	_itoa_s(c, buf, 10);
	ip.append(buf);
	ip.append(".");

	_itoa_s(d, buf, 10);
	ip.append(buf);

	stro.assign(ip);
}
