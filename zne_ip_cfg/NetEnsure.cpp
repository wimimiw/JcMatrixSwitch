// NetEnsure.cpp : implementation file
//

#include "stdafx.h"
#include "zne_ip_cfg.h"
#include "NetEnsure.h"
#include "afxdialogex.h"


// NetEnsure dialog

IMPLEMENT_DYNAMIC(NetEnsure, CDialogEx)

NetEnsure::NetEnsure(CWnd* pParent /*=NULL*/)
	: CDialogEx(NetEnsure::IDD, pParent)
	, m_maskValue(NULL)
	, m_hostValue(NULL)
{

}

NetEnsure::~NetEnsure()
{
}

void NetEnsure::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_IPADDRESS4, m_mask);
	DDX_Control(pDX, IDC_IPADDRESS5, m_host);
	DDX_Control(pDX, IDOK, m_btnOK);
	DDX_Control(pDX, IDCANCEL, m_btnCancel);
	DDX_Control(pDX, IDC_EDIT2, m_Info);
}


BEGIN_MESSAGE_MAP(NetEnsure, CDialogEx)
END_MESSAGE_MAP()


// NetEnsure message handlers


BOOL NetEnsure::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// TODO:  Add extra initialization here
	this->SetBackgroundColor(RGB(0x8B, 0x63, 0x6C), 1);

	m_mask.SetAddress(*(this->m_maskValue));
	m_host.SetAddress(*(this->m_hostValue));

	string cmask,cgate,cprint;
	int temp = htonl(*(this->m_maskValue));

	cmask.assign(inet_ntoa(*(in_addr*)&temp));

	temp = htonl(*(this->m_hostValue));

	cgate.assign(inet_ntoa(*(in_addr*)&temp));

	cprint = "请确认本地网段！是否如下\r\n掩码："+cmask+"\r\n网关："+cgate+"\r\n否则无法连接开关箱！";

	int ret = MessageBoxA(this->GetSafeHwnd(), cprint.c_str(), "注意", 1);

	if (ret == 2)
		exit(0);
		//exit(0);
	//char szHostName[MAX_PATH + 1];
	//gethostname(szHostName, MAX_PATH);  //得到计算机名
	//hostent*p = gethostbyname(szHostName); //从计算机名得到主机信息

	//if (p == NULL)
	//{
	//	MessageBoxA(this->GetSafeHwnd(),"得到本机网络信息失败!","警报",1);
	//	return TRUE;
	//}

	//char *pIP = inet_ntoa(*(in_addr *)p->h_addr_list[0]);//将32位IP转化为字符串IP
	//pIP = inet_ntoa(*(in_addr *)p->h_addr_list[1]);//将32位IP转化为字符串IP
	//pIP = inet_ntoa(*(in_addr *)p->h_addr_list[2]);//将32位IP转化为字符串IP

	m_Info.SetWindowTextW(_T("如果需要修改开关箱的掩码及网关地址\r\n,请在此界面修改后，点击OK，后续设\r\n置的掩码和网关以此为准！"));

	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}


void NetEnsure::OnOK()
{
	// TODO: Add your specialized code here and/or call the base class
	this->m_mask.GetAddress((DWORD&)*this->m_maskValue);
	this->m_host.GetAddress((DWORD&)*this->m_hostValue);

	CDialogEx::OnOK();
}


void NetEnsure::OnCancel()
{
	// TODO: Add your specialized code here and/or call the base class

	CDialogEx::OnCancel();
	exit(0);
}


void NetEnsure::LoadMaskHost(int* mask, int* host)
{
	this->m_maskValue = mask;
	this->m_hostValue = host;
}
