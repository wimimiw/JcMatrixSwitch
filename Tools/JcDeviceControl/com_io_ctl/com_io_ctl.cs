/****************************************************************************
 * 文件名称：com_io_ctl.cs
 * 作        者：ms
 * 日        期：2014/11/6
 * 版        本：
 * **************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace com_io_ctl
{
    #region 配置文件

    internal class xIniFile
    {
        private static string fName = "";

        private static readonly uint maxCharCount = 256;

        // DWORD WINAPI GetPrivateProfileString(
        // __in   LPCTSTR lpAppName,
        // __in   LPCTSTR lpKeyName,
        // __in   LPCTSTR lpDefault,
        // __out  LPTSTR lpReturnedString,
        // __in   DWORD nSize,
        // __in   LPCTSTR lpFileName
        // );
        [DllImport("Kernel32.dll", EntryPoint="GetPrivateProfileStringA")]
        private static extern uint GetPrivateProfileStringA( [In()] [MarshalAs(UnmanagedType.LPStr)] string sectionName,
                                                             [In()] [MarshalAs(UnmanagedType.LPStr)] string keyName,
                                                             [In()] [MarshalAs(UnmanagedType.LPStr)] string defaultString,         
                                                             [Out()] [MarshalAs(UnmanagedType.LPStr)] StringBuilder returnedString,
                                                             uint charCount,
                                                             [In()] [MarshalAs(UnmanagedType.LPStr)] string fName);
                
        //  BOOL WINAPI WritePrivateProfileString(
        //  __in  LPCTSTR lpAppName,
        //  __in  LPCTSTR lpKeyName,
        //  __in  LPCTSTR lpString,
        //  __in  LPCTSTR lpFileName
        //  );
        [DllImport("Kernel32.dll",  EntryPoint="WritePrivateProfileStringA")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileStringA( [In()] [MarshalAs(UnmanagedType.LPStr)] string sectionName,
                                                               [In()] [MarshalAs(UnmanagedType.LPStr)] string keyName,
                                                               [In()] [MarshalAs(UnmanagedType.LPStr)] string value,
                                                               [In()] [MarshalAs(UnmanagedType.LPStr)] string fName);



        internal static string GetString(string section,
                                         string key,
                                         string defaultValue)
        {
            StringBuilder sb = new StringBuilder((int)maxCharCount);

            GetPrivateProfileStringA(section, key, defaultValue, sb, maxCharCount, fName);

            return sb.ToString();
        }

        internal static bool SetString(string section,
                                       string key,
                                       string value)
        {
           return WritePrivateProfileStringA(section, key, value, fName);
        }

        internal static void SetFileName(string fileName)
        {
            fName = fileName;
        }
   
        /// <summary>
        /// 从以逗号和空格隔开的字符串str
        /// 获取第i项，最多maxCount项，索引从零开始
        /// </summary>
        /// <param name="str"></param>
        /// <param name="i"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        internal static string GetItemFrom(string str, int i, int maxCount)
        {
            int j1, j2, k;
            string item = "";

            //获取最后一项
            if (i >= (maxCount - 1))
            {
                j1 = str.LastIndexOf(",");

                if (j1 >= 0)
                    item = str.Substring((j1+1), (str.Length - j1 - 1));

            //获取前面的项
            } else {
                k = 0;
                j1 = 0;
                j2 = str.IndexOf(',', j1);
                if (j2 < 0)
                    item = str;
                
                while (j2 > 0)
                {
                    k++;

                    if (k >= (i + 1))
                        break;

                    j1 = j2;

                    j2 = str.IndexOf(',', (j1 + 1));
                }

                if (k == (i + 1))
                {
                    if (j1 > 0)
                        item = str.Substring((j1+1), (j2 - j1 - 1));
                    else
                        item = str.Substring(j1, (j2 - j1));
                }
            }

            //返回找到的项
            return item.Trim();
        }


        /// <summary>
        /// 在以逗号和空格隔开的字符串, 获知其包含数据项的数目
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static int CountOfItemIn(string str)
        {
            int c  = 0;
            int i1 = 0;
            int i2 = 0;
            string item = "";
         
            i2 = str.IndexOf(',', i1);

            while (i2 > 0)
            {
                c++;              

                i1 = i2;

                i2 = str.IndexOf(',', (i1 + 1));
            }

            if (c > 0)
            {
                i1 = str.LastIndexOf(",");

                item = str.Substring(i1, (str.Length - i1));

                if (!String.IsNullOrEmpty(item.Trim()))
                    c++;
            }

            return c;
        }
    }

    #endregion

    public class ReadEventArgs {
        public ReadEventArgs(string s) { Text = s; }
        public String Text {get; private set;}       
    }

    public class com_io_ctl
    {
        #region 注释
        //        private string[, ,] swGpio = new string[,,] {
        //{
        //{"PA0","SPDT3"},
        //{"PA1","SPDT4"},
        //{"PA2",""},
        //{"PA3",""},
        //{"PA4","SPDT5"},
        //{"PA5",""},
        //{"PA6",""},
        //{"PA7",""},
        //{"PA8",""},
        //{"PA9",""},
        //{"PA10",""},
        //{"PA11",""},
        //{"PA12",""},
        //{"PA13",""},
        //{"PA14","SP12T_2_8"},
        //{"PA15","SP12T_2_7"},
        //},{
        //{"PB0",""},
        //{"PB1",""},
        //{"PB2",""},
        //{"PB3","SP12T_2_1"},
        //{"PB4","SP12T_2_2"},
        //{"PB5","SP12T_2_3"},
        //{"PB6",""},
        //{"PB7",""},
        //{"PB8","SP12T_2_4"},
        //{"PB9",""},
        //{"PB10",""},
        //{"PB11",""},
        //{"PB12","SPDT6"},
        //{"PB13","SPDT7"},
        //{"PB14","SPDT8"},
        //{"PB15","SPDT9"},
        //},{
        //{"PC0",""},
        //{"PC1",""},
        //{"PC2","SPDT1"},
        //{"PC3","SPDT2"},
        //{"PC4",""},
        //{"PC5",""},
        //{"PC6",""},
        //{"PC7",""},
        //{"PC8",""},
        //{"PC9",""},
        //{"PC10","SP12T_2_6"},
        //{"PC11","SP12T_2_5"},
        //{"PC12","SP12T_2_9"},
        //{"PC13","SP12T_1_7"},
        //{"PC14","SP12T_1_8"},
        //{"PC15",""},
        //},{
        //{"PD0","SP12T_2_10"},
        //{"PD1","SP12T_2_11"},
        //{"PD2","SP12T_2_12"},
        //{"PD3",""},
        //{"PD4","SP12T_1_12"},
        //{"PD5","SP12T_1_11"},
        //{"PD6","SP12T_1_10"},
        //{"PD7","SP12T_1_9"},
        //{"PD8","SPDT10"},
        //{"PD9","SPDT11"},
        //{"PD10","SPDT12"},
        //{"PD11","SPDT13"},
        //{"PD12","SPDT14"},
        //{"PD13",""},
        //{"PD14",""},
        //{"PD15",""},
        //},{
        //{"PE0",""},
        //{"PE1","SP12T_1_4"},
        //{"PE2","SP12T_1_3"},
        //{"PE3","SP12T_1_2"},
        //{"PE4","SP12T_1_1"},
        //{"PE5","SP12T_1_5"},
        //{"PE6","SP12T_1_6"},
        //{"PE7",""},
        //{"PE8",""},
        //{"PE9",""},
        //{"PE10",""},
        //{"PE11",""},
        //{"PE12",""},
        //{"PE13",""},
        //{"PE14",""},
        //{"PE15",""},
        //}
        //        };

        //private PortMap[] portMap = new PortMap[] { 
        //    new PortMap("",1,1,1,1),
        //    new PortMap("",1,1,1,1),
        //    new PortMap("",1,1,1,1),
        //    new PortMap("",1,1,1,1),
        //    new PortMap("",1,1,1,1),
        //    new PortMap("",1,1,1,1),
        //    new PortMap("",1,1,1,1),
        //    new PortMap("",1,1,1,1),
        //    new PortMap("",1,1,1,1),
        //    new PortMap("",1,1,1,1),
        //    new PortMap("",1,1,1,1),
        //};

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    IniFile.SetFileName(Application.StartupPath + @"\lt.ini");
        //    for (int j = 0; j < 5; j++)
        //        for (int i = 0; i <= 15; i++)
        //        {
        //            IniFile.SetString("gpio_map", swGpio[j, i, 0], swGpio[j, i, 1]);
        //        }
        //}
        #endregion

        #region 变量
        private struct PortMap {
            public string id;
            public string port1_spdt;
            public string port1_sp12;
            public string port2_spdt;
            public string port2_sp12;

            public PortMap(string id, string port1_spdt, string port1_sp12, string port2_spdt, string port2_sp12)
            {
                this.id = id;
                this.port1_spdt = port1_spdt;
                this.port1_sp12 = port1_sp12;
                this.port2_spdt = port2_spdt;
                this.port2_sp12 = port2_sp12;
            }
        }

        private PortMap[] portMap = new PortMap[12];
        private ushort[] mcuGpio = new ushort[5] { 0, 0, 0, 0, 0 };
        public List<ushort[]> stateValue = new List<ushort[]>();
        public List<string> stateName = new List<string>();
        private string[,] swGpio = new string[5, 16];

        private ManualResetEvent comRcvEvent = new ManualResetEvent(false);
        public delegate void ReadEventHandler (object sender,ReadEventArgs e);
        public event ReadEventHandler readEvent;
        private SerialPort cport;
        private string iniPath = string.Empty;
        private IPEndPoint __TcpEP;
        private TcpClient __TcpClient;
        private bool __enable_Com = false;
        private bool __enable_Tcp = false;
        private const int PACKET_LEN = 12;

        #endregion

        #region 构造
        /// <summary>
        /// 装载配置
        /// </summary>
        /// <param name="Name"></param>
        public com_io_ctl(string path)
        {
            this.iniPath = path;
            this.LoadConfig(path);
            this.LoadConfigEx(path);
        }
        /// <summary>
        /// 装载配置并打开串口
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="path"></param>
        public com_io_ctl(string Name, string path)
        {
            this.iniPath = path;
            this.LoadConfig(path);
            this.LoadConfigEx(path);
            this.OpenCom(Name);
        }

        /// <summary>
        /// 装载配置并打开串口
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="path"></param>
        //public com_io_ctl(string Name,string path)
        //{
        //    this.cport = new SerialPort(Name, 19200, Parity.None, 8, StopBits.One);
        //    this.cport.ReadTimeout = 50;
        //    this.cport.ReceivedBytesThreshold = 12;
        //    this.cport.DataReceived += new SerialDataReceivedEventHandler(cport_DataReceived);
        //    this.cport.Open();

        //    this.iniPath = path;
        //    this.LoadConfig(path);
        //    //this.LoadConfigEx(path);
        //}
        #endregion

        #region 开关
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        public void OpenCom(string Name)
        {             
            this.cport = new SerialPort(Name, 19200, Parity.None, 8, StopBits.One);
            this.cport.ReadTimeout = 50;
            this.cport.ReceivedBytesThreshold = 12;
            this.cport.DataReceived += new SerialDataReceivedEventHandler(cport_DataReceived);
            this.cport.Open();

            this.__enable_Com = true;
            this.__enable_Tcp = false;            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool TcpConnect(string ip,int port)
        {
            bool result = true;

            try
            {
                this.__TcpEP = new IPEndPoint(IPAddress.Parse(ip),port);
                this.__TcpClient = new TcpClient();
                //this.__TcpClient.Client.Blocking = false;
                this.__TcpClient.Connect(this.__TcpEP);
                //Thread.Sleep(500);
                //this.__TcpClient.Client.Blocking = true;

                if (this.__TcpClient.Connected)
                {
                    this.__enable_Com = false;
                    this.__enable_Tcp = true;
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }
        #endregion

        #region 封装操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool LoadConfigEx(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    return false;
                }

                xIniFile.SetFileName(path);

                string[] str = new string[5];

                for (int i = 0; i < 50; i++)
                {
                    str = xIniFile.GetString("STATE", i.ToString() , string.Empty).Split(',');

                    if ( str[0] == string.Empty ) continue;

                    ushort[] us = new ushort[5];

                    for (int j = 0; j < us.Length; j++)
                    {
                        us[j] = ushort.Parse(str[j]);
                    }

                    stateName.Add(i.ToString());
                    stateValue.Add(us);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void StateStore(int index,ushort[] item)
        {
            if (item == null || item.Length < 5) return;

            xIniFile.SetFileName(this.iniPath);

            string str = string.Empty;

            for (int i = 0; i < item.Length; i++)
			{
			    str += item[i].ToString() + ",";
			}

            if (index >= stateName.Count)
            {
                stateName.Add(index.ToString());
                stateValue.Add(item);
            }

            xIniFile.SetString("STATE", index.ToString(), str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void StateDelete(int index)
        {
            xIniFile.SetFileName(this.iniPath);
            xIniFile.SetString("STATE", index.ToString(), string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void StateUpdate(int index, ushort[] item)
        {
            if (item == null || item.Length < 5) return;

            xIniFile.SetFileName(this.iniPath);

            string str = string.Empty;

            for (int i = 0; i < item.Length; i++)
            {
                str += item[i].ToString() + ",";
            }

            xIniFile.SetString("STATE", index.ToString(), str);
            Array.Copy(item, stateValue[index], item.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool BaseStateWrite(int state)
        {
            Array.Copy(stateValue[state],mcuGpio,mcuGpio.Length);
            return this.StartWrite();
        }

        #endregion

        #region 旧代码

        public void Dispose()
        {
            if (this.cport != null && this.cport.IsOpen)
            {
                this.cport.Close();
                this.cport.Dispose();
            }

            if (this.__TcpClient != null && this.__TcpClient.Connected)
            {
                this.__TcpClient.Close();
            }
        }

        void cport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = sender as SerialPort;
            Byte[] buf = new Byte[sp.BytesToRead];
            sp.Read(buf, 0, buf.Length);
            bool result1 = ComSwitchWriteUnpack(buf, buf.Length);
            bool result2 = ComSwitchReadUnpack(buf, buf.Length);
            sp.DiscardInBuffer();

            if (result1 || result2)
            {
                comRcvEvent.Set();
            }

            if (this.readEvent != null)
                this.readEvent(this,null);
           
            //throw new NotImplementedException();
        }
        
        private bool ComSwitchReadUnpack(Byte[] buf, int len)
        {
            bool result = true;

            if (buf[0] == Convert.ToByte('R') && len >= PACKET_LEN)
            {
                byte check = 0;

                for (int i = 1; i < PACKET_LEN - 1; i++)
                {
                    check ^= buf[i];
                }

                if (check != buf[PACKET_LEN-1]) result = false;

                for (int i = 0; i < mcuGpio.Length; i++)
                {
                    int idx = i * 2 + 1;
                    mcuGpio[i] = (ushort)(buf[idx] + buf[idx + 1] * 256);
                }
            }
            else if (buf[0] == Convert.ToByte('X'))
            {
                result = false;
            }

            return result;
        }

        private Byte[] ComSwitchReadPack()
        {
            Byte[] buf = new Byte[PACKET_LEN];
            Array.Clear(buf, 0, buf.Length);
            buf[0] = Convert.ToByte('R');
            
            byte check = 0;

            for (int i = 1; i < PACKET_LEN - 1; i++)
            {
                check ^= buf[i];
            }

            buf[PACKET_LEN - 1] = check;

            return buf;
        }

        private bool ComSwitchWriteUnpack(Byte[] buf, int len)
        {
            bool result = true;

            if (buf[0] == Convert.ToByte('W') && len >= PACKET_LEN)
            {
                byte check = 0;

                for (int i = 1; i < PACKET_LEN - 1; i++)
                {
                    check ^= buf[i];
                }

                if (check != buf[PACKET_LEN-1]) result = false;

                for (int i = 0; i < mcuGpio.Length; i++)
                {
                    int idx = i * 2 + 1;
                    mcuGpio[i] = (ushort)(buf[idx] + buf[idx + 1] * 256);
                }                
            }
            else if (buf[0] == Convert.ToByte('X'))
            {
                result = false;
            }

            return result;
        }

        private Byte[] ComSwitchWritePack()
        {
            Byte[] buf = new Byte[PACKET_LEN];
            Array.Clear(buf, 0, buf.Length);
            buf[0] = Convert.ToByte('W');

            for (int i = 0; i < mcuGpio.Length; i++)
            {
                int idx = i * 2 + 1;
                buf[idx] = (Byte)(mcuGpio[i] % 256);
                buf[idx + 1] = (Byte)(mcuGpio[i] / 256);
            }

            byte check = 0;

            for (int i = 1; i < PACKET_LEN - 1; i++)
            {
                check ^= buf[i];
            }

            buf[PACKET_LEN - 1] = check;

            return buf;
        }

        public bool GetGpioState(string name)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (swGpio[i, j] == name)
                    {
                        int temp = mcuGpio[i] & (1 << j);
                        return temp != 0;
                    }
                }
            }
            return false;
        }

        public void SetSwitchState(string name, bool state)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (swGpio[i, j] == name)
                    {
                        if (state)
                            mcuGpio[i] |= (ushort)(1 << j);
                        else
                            mcuGpio[i] &= (ushort)(~(1 << j));
                    }
                }
            }
        }

        /// <summary>
        /// 清缓存
        /// </summary>
        private void Clear()
        {
            Array.Clear(mcuGpio, 0, mcuGpio.Length);
        }

        /// <summary>
        /// 开始写GPIO，成功返回TRUE，失败返回FALSE
        /// </summary>
        /// <returns></returns>
        public bool StartWrite()
        {
            bool result = true;

            Byte[] buf = ComSwitchWritePack();

            if (this.__enable_Com)
            {
                int cnt = 0;
                comRcvEvent.Reset();
                do
                {
                    this.cport.Write(buf, 0, buf.Length);
                } while (!comRcvEvent.WaitOne(100) && ++cnt < 3);

                result = cnt != 3;
            }

            if (this.__enable_Tcp && this.__TcpClient != null)
            {
                if (this.__TcpClient.Connected)
                {
                    try
                    {
                        NetworkStream ms = this.__TcpClient.GetStream();
                        ms.Write(buf, 0, buf.Length);
                        Byte[] bufRd = new Byte[buf.Length];
                        ms.ReadTimeout = 1000;
                        ms.Read(bufRd, 0, bufRd.Length);
                        result = string.Compare(Encoding.ASCII.GetString(buf), Encoding.ASCII.GetString(bufRd))==0;
                    }
                    catch (Exception ex)
                    {
                        this.__TcpClient.Close();
                        //this.__TcpClient = new TcpClient();
                        //this.__TcpClient.Connect(this.__TcpEP);
                        result = false;
                    }
                }
                else
                    result = false;
            }

            return result;
        }

        public void StartRead()
        {
            Byte[] buf = ComSwitchReadPack();
            this.cport.Write(buf, 0, buf.Length);
        }

        /// <summary>
        /// 12选1开关
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        private void SP12T_Set(int id, int index,bool polar)
        {
            for (int i = 1; i <= 12; i++)
            {
                if(i == index)
                    SetSwitchState("SP12T_" + id.ToString() + "_" + i.ToString(), polar);
                else
                    SetSwitchState("SP12T_" + id.ToString() + "_" + i.ToString(), !polar);
            }

            //return StartWrite();
        }

        /// <summary>
        /// 单刀双掷开关
        /// </summary>
        /// <param name="index"></param>
        /// <param name="polar"></param>
        /// <returns></returns>
        private void SPDT_Set(int index, bool polar)
        {
            if (index > 14 || index < 1) return;
            SetSwitchState("SPDT" + index.ToString(), polar);
            //return StartWrite();
        }

        private bool LoadConfig(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    return false;
                }

                xIniFile.SetFileName(path);

                for (int j = 0; j < 5; j++)
                {
                    string key = string.Empty;
                    switch (j)
                    {
                        case 0: key = "PA"; break;
                        case 1: key = "PB"; break;
                        case 2: key = "PC"; break;
                        case 3: key = "PD"; break;
                        case 4: key = "PE"; break;
                    }
                    for (int i = 0; i <= 15; i++)
                    {
                        swGpio[j, i] = xIniFile.GetString("gpio_map", key + i.ToString(), string.Empty);
                    }
                }

                for (int i = 0; i < 12; i++)
                {
                    string[] str = xIniFile.GetString("port_map", (i + 1).ToString(), string.Empty).Trim().Split(',');
                    portMap[i].id = str[0];
                    portMap[i].port1_sp12 = str[2];
                    portMap[i].port1_spdt = str[1];
                    portMap[i].port2_sp12 = str[4];
                    portMap[i].port2_spdt = str[3];
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;                
            }
        }

        public bool SelectPort(int port1,int port2)
        {
            for (int i = 1; i <= 14; i++)
                SPDT_Set(i, false);

            for (int i = 1; i <= 12; i++)
			{
                if (port1 == i)
                {
                    SP12T_Set(1, int.Parse(portMap[i - 1].port1_sp12), true);
                    SPDT_Set(int.Parse(portMap[i - 1].port1_spdt), true);
                }

                if (port2 == i)
                {
                    SP12T_Set(2, int.Parse(portMap[i - 1].port2_sp12), true);
                    SPDT_Set(int.Parse(portMap[i - 1].port2_spdt), true);
                }
			}

            return this.StartWrite();
        }

        #endregion
    }
}
