using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;
using System.Diagnostics;

namespace ZNE_100TL_Factory_Config
{
    class Program
    {
        static void Main(string[] args)
        {
            ZConfig.Run();
        }
    }

    public class ZConfig
    {
        static string __ipBak = "192.168.0.178";
        static string __ipCur = "192.168.0.178";            //当前IP
        static string __ip = "192.168.0.178";                 //设置IP
        static string __mark = "255.255.255.0";
        static string __gateway = "192.168.0.1";
        static string __baud = "19200";

        public static void Run()
        {
            Thread thrd = new Thread(new ThreadStart(ConfigIOProc), 0);
            thrd.Start();
        }

        private static void CmdProcess(TcpClient __tcpClient,string[] cmdList,string info)
        {
            byte[] buffer = new byte[1024];
            NetworkStream netStr = __tcpClient.GetStream();

            bool result = true;
            for (int i = 0; i < cmdList.Length; i++)
            {
                try
                {
                    netStr.Write(Encoding.ASCII.GetBytes(cmdList[i]), 0, cmdList[i].Length);
                    Thread.Sleep(250);//不要改延时                                            
                    Array.Clear(buffer, 0, buffer.Length);
                    netStr.Read(buffer, 0, buffer.Length);   
                    string str  = Encoding.ASCII.GetString(buffer);
                    if (!str.Contains("OK") && "AT+MODE=0\r\n" != cmdList[i]){ result = false; break; }
                    //复位后首次连接会绘制图形交互界面，这里不对AT+MODE的结果做判断，不会产生影响。
                }
                catch
                {
                    netStr.Close();
                    __tcpClient.Close();
                    Console.WriteLine("CmdInit failure! Enter Any Key Exit!");
                    Console.ReadLine();
                    return;
                }
            }

            //Console.WriteLine("发送消息：{0}", result ? info+" success!" : info+" failure!");            
        }

        private static void ConfigIOProc()
        {
            Console.Title = "华为测试柜——开关箱网络IP地址——工厂配置工具——V1.0.2015.1";

            string reqStr;
            byte[] buffer = new byte[1024];       
                             
            TcpClient __tcpClient;

            while(true)
            {
                Console.WriteLine(">>====================使用说明============================>>");
                Console.WriteLine(">>ZNE-100TL的默认IP地址为:192.168.0.178");
                Console.WriteLine(">>如果忘记配置过的IP地址，请重置ZNE-100TL，还原默认IP地址");
                Console.WriteLine(">>重置方法：");
                Console.WriteLine(">>          1、断电后将ZNE-100TL上的(PA4)上通孔用镊子短接。");
                Console.WriteLine(">>          2、上电后保持短接状5秒，然后撤去短接，断开复位即可。");
                Console.WriteLine(">>本模块固定掩码为：255.255.255.0");
                Console.WriteLine(">>注意：请确保本地连接与ZNE-100TL在同一网段");
                Console.WriteLine(">>========================================================>>");
                Console.WriteLine("");
                Console.WriteLine("");
                
                Console.WriteLine("==>请输入当前模块IP（回车即使用缺省IP：192.168.0.178）:");
                Console.Write("==>");
                reqStr = Console.ReadLine();
                if (reqStr != string.Empty)
                    __ipCur = reqStr;
                else
                {
                    __ipCur = __ipBak;
                    Console.WriteLine(__ipBak);
                }

                Console.WriteLine("==>请输入需要修改的IP（回车即使用缺省IP：192.168.0.178）:");
                Console.Write("==>");
                reqStr = Console.ReadLine();

                if (reqStr != string.Empty)
                    __ip = reqStr;
                else
                {
                    __ip = __ipBak;
                    Console.WriteLine(__ipBak);
                } 

                __gateway = __ip.Remove( __ip.LastIndexOf('.') ) + ".1";

                string[] cmdInit = new string[]{
                    "AT+MODE=0\r\n",                
                    "AT+LOGIN=88888\r\n",
                    "AT\r\n",
                    "AT+ECHO=0\r\n",   
                    "AT+IP="+__ip+"\r\n",               //设置IP
                    "AT+MARK="+__mark+"\r\n",           //设置掩码
                    "AT+GATEWAY="+__gateway+"\r\n",     //设置网关
                    "AT+C1_OP=0\r\n",		            //工作状态。0 - TCP Server ；1 - TCP CLIENT ；2 - REAL COM;3 - UDP；4 - DISABLE
                    "AT+C1_IT=0\r\n",		            //超时断开时间。设置0可以关闭该功能,单位10ms
                    "AT+C1_TCP_CLS=1\r\n",              //硬件断开时关闭TCP 连接。
                    "AT+C1_TCPAT=20\r\n",	            //心跳检测时间。单位s，为0 时表示关闭心跳检测功能
                    "AT+C1_BUF_CLS=1\r\n",          	//TCP连接后清空串口缓存
                    "AT+C1_BAUD="+__baud+"\r\n",        //设置串口波特率
                    "AT+C1_DATAB=8\r\n",                //设置串口数据位
                    "AT+C1_STOPB=1\r\n",                //设置串口停止位
                    "AT+C1_PARITY=0\r\n",               //设置串口校验位	 0-无NONE(默认值)；1- 奇.ODD;2- 偶.EVEN ； 3- 强制为0.SPACE ；4- 强制为1.MARK 。          
                    "AT+RESET=88888\r\n",               //复位设备
                };  

                __tcpClient = new TcpClient();

                try
                {
                    Console.WriteLine("==>正在连接...");
                    __tcpClient.Connect(__ipCur, 3003);
                    Console.WriteLine("==>连接服务器成功！");
                }
                catch
                {
                    Console.WriteLine("==>连接服务器失败！");
                    Console.WriteLine("==>*回车，重新进入配置界面*");
                    Console.ReadLine();                  
                    Console.Clear();
                    continue;
                }

                //通过clientSocket接收数据，第一帧广告要舍弃
                Thread.Sleep(300);//延时必须
                NetworkStream netStr = __tcpClient.GetStream();                
                netStr.Read(buffer, 0, buffer.Length);
                string str = Encoding.ASCII.GetString(buffer);
                
                //初始化                
                Console.WriteLine("==>正在配置，请耐心等待...");

                CmdProcess(__tcpClient, cmdInit, "Cmmand Init");

                __tcpClient.Close();

                Console.WriteLine("==>配置完成，正在重启...");
                Thread.Sleep(2000);
                Console.WriteLine("==>重启完成！");
                Console.WriteLine("==>**回车，重新进入配置界面**");
                Console.ReadLine();
                Console.Clear();
            }
        }    
    }
}
