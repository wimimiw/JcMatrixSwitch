using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;

namespace SwitchDemo
{
    public partial class Form4 : Form
    {
        ushort[, ,] swMap = new ushort[,,] { 
            {//1
                {0,0,0,0,2},{0,0,0,0,1},{0,512,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0}
            },            
            {//2
                {0,0,0,16,0},{0,0,0,8,0},{0,0,0,4,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0}
            },
            {//3
                {0,0,0,16,0},{0,0,0,8,0},{0,0,0,4,0},{0,0,0,2,0},{0,0,0,1,0},{0,0,4096,0,0},{0,0,2048,0,0}
            },     
            {//4
                {0,0,0,0,2},{0,0,0,0,1},{0,512,0,0,0},{0,256,0,0,0},{0,32,0,0,0},{0,16,0,0,0},{0,8,0,0,0}
            },
            {//5
                {16,0,0,0,0},{32,0,0,0,0},{64,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0}
            },
            {//6
                {128,0,0,0,0},{0,0,16,0,0},{0,0,32,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0}
            },
            {//7
                {0,0,0,0,1024},{0,0,0,0,2048},{0,0,0,0,4096},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0}
            },   
            {//8
                {0,0,0,0,8192},{0,0,0,0,16384},{0,0,0,0,32768},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0}
            },
            {//10
                {32,0,0,0,0},{16,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0}
            },
            {//9
                {0,16,0,0,0},{0,8,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0}
            },
            {//11
                {0,0,16,0,0},{128,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0}
            },
        };

        TcpClient[] __tcpClient = new TcpClient[9]; 
        ushort[,] __bakValue = new ushort[9,5];

        public Form4()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
			{
			    for (int j = 0; j < 5; j++)
			    {
			        __bakValue[i,j]=0;
			    }
			}

            xIniFile.SetFileName(Application.StartupPath+@"\JcConfig.ini");
            tb000.Text = xIniFile.GetString("ip", "Signalswich", "").Split(new char[]{':'})[0];
            tb001.Text = xIniFile.GetString("ip", "Paspecumpwmt", "").Split(new char[] { ':' })[0];
            tb002.Text = xIniFile.GetString("ip", "Testmdlte700", "").Split(new char[] { ':' })[0];
            tb003.Text = xIniFile.GetString("ip", "Testmddd800", "").Split(new char[] { ':' })[0];
            tb004.Text = xIniFile.GetString("ip", "Testmdgsm900", "").Split(new char[] { ':' })[0];
            tb005.Text = xIniFile.GetString("ip", "Testmddcs1800", "").Split(new char[] { ':' })[0];
            tb006.Text = xIniFile.GetString("ip", "Testmdpcs1900", "").Split(new char[] { ':' })[0];
            tb007.Text = xIniFile.GetString("ip", "Testmdwcdma2100", "").Split(new char[] { ':' })[0];
            tb008.Text = xIniFile.GetString("ip", "Testmdlte2600", "").Split(new char[] { ':' })[0];
        }

        bool TcpConnect(int dex,string ip)
        {
            try
            {
                __tcpClient[dex] = new TcpClient();
                __tcpClient[dex].Connect(ip, 4001);               
            }
            catch
            {
                //__tcpClient[dex].Close();
                __tcpLink[dex] = false;
                return false;
            }

            return true;
        }

        void TcpDisConnect(int dex)
        {
            __tcpLink[dex] = false;

            if (__tcpClient[dex] != null)
            {
                __tcpClient[dex].Close();
            }
        }

        bool Send(int dex)
        {
            Button[] btnColl = new Button[] { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8 }; 
            bool result = true;
            ushort[] code = new ushort[5];

            for (int i = 0; i < 5; i++)
            {
                code[i] = __bakValue[dex, i];
            }

            TcpClient tc = __tcpClient[dex];

            try
            {

                if (tc != null && tc.Connected)
                {
                    Byte[] buf = new Byte[12];
                    Byte[] rxbuf = new Byte[12];

                    buf[0] = Convert.ToByte('W');
                    Array.Copy(BitConverter.GetBytes(code[0]), 0, buf, 1, 2);
                    Array.Copy(BitConverter.GetBytes(code[1]), 0, buf, 3, 2);
                    Array.Copy(BitConverter.GetBytes(code[2]), 0, buf, 5, 2);
                    Array.Copy(BitConverter.GetBytes(code[3]), 0, buf, 7, 2);
                    Array.Copy(BitConverter.GetBytes(code[4]), 0, buf, 9, 2);

                    Byte chk = 0;
                    for (int i = 1; i < 11; i++)
                    {
                        chk ^= buf[i];
                    }

                    buf[11] = chk;

                    tc.ReceiveTimeout = 3000;

                    tc.GetStream().Write(buf, 0, 12);
                    Thread.Sleep(100);
                    Array.Clear(rxbuf, 0, 12);
                    tc.GetStream().Read(rxbuf, 0, 12);

                    for (int i = 0; i < 12; i++)
                    {
                        if (rxbuf[i] != buf[i])
                        {
                            btnColl[dex].Text = "连接";
                            __tcpLink[dex] = false;
                            MessageBox.Show(this, "开关箱错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                btnColl[dex].Text = "连接";
                __tcpLink[dex] = false;
                MessageBox.Show(this,"连接异常","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                result = false;
            }

            return result;
        }

        bool SwitchConfig(int dex,int swID,int swPin)
        {
            ushort[] temp = new ushort[5];
            ushort[] mask = new ushort[5];

            swPin -= 1;

            Array.Clear(mask,0,5);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mask[j] |= (ushort)(swMap[swID, i, j]);
                }                
            }

            for (int i = 0; i < 5; i++)
			{
			    temp[i] = __bakValue[dex, i];
                temp[i] &= (ushort)~mask[i];
                temp[i] |= (ushort)(swMap[swID,swPin, i]);
			}
           
            for (int i = 0; i < 5; i++)
			{
			    __bakValue[dex, i] = temp[i];
			}

            if (button1.Enabled) return true;

            return Send(dex);
        }

        bool ReadStatue(int dex)
        {
            TcpClient tc = __tcpClient[dex];

            if ( tc != null && tc.Connected )
            {
                try
                {
                    Byte[] txBuf = new Byte[12];
                    Array.Clear(txBuf, 0, 12);
                    txBuf[0] = Convert.ToByte('R');
                    tc.ReceiveTimeout = 3000;
                    tc.GetStream().Write(txBuf,0,12);
                    Thread.Sleep(100);
                    tc.GetStream().Read(txBuf, 0, 12);

                    __bakValue[dex, 0] |= BitConverter.ToUInt16(txBuf,1);
                    __bakValue[dex, 1] |= BitConverter.ToUInt16(txBuf, 3);
                    __bakValue[dex, 2] |= BitConverter.ToUInt16(txBuf, 5);
                    __bakValue[dex, 3] |= BitConverter.ToUInt16(txBuf, 7);
                    __bakValue[dex, 4] |= BitConverter.ToUInt16(txBuf, 9);
                    

                    if (dex == 0)
                    {
                        __sw1_3s1 = GetSwitchPin(txBuf, 0);
                        __sw2_3s1 = GetSwitchPin(txBuf, 1);

                        switch (__sw1_3s1)
                        {
                            case 1: rb8_11.Checked = true; break;
                            case 2: rb8_12.Checked = true; break;
                            case 3: rb8_13.Checked = true; break;
                            default: break;
                        }

                        switch (__sw2_3s1)
                        {
                            case 1: rb8_21.Checked = true; break;
                            case 2: rb8_22.Checked = true; break;
                            case 3: rb8_23.Checked = true; break;
                            default: break;
                        }

                    }//开关箱2
                    else if (dex == 1)
                    {
                        __sw3_7s1 = GetSwitchPin(txBuf,2);
                        __sw4_7s1 = GetSwitchPin(txBuf, 3);
                        __sw5_3s1 = GetSwitchPin(txBuf, 4);
                        __sw6_3s1 = GetSwitchPin(txBuf, 5);
                        __sw7_3s1 = GetSwitchPin(txBuf, 6);
                        __sw8_3s1 = GetSwitchPin(txBuf, 7);

                        switch (__sw3_7s1)
                        {
                            case 1: rb8_31.Checked = true; break;
                            case 2: rb8_32.Checked = true; break;
                            case 3: rb8_33.Checked = true; break;
                            case 4: rb8_34.Checked = true; break;
                            case 5: rb8_35.Checked = true; break;
                            case 6: rb8_36.Checked = true; break;
                            case 7: rb8_37.Checked = true; break;
                            default: break;
                        }

                        switch (__sw4_7s1)
                        {
                            case 1: rb8_41.Checked = true; break;
                            case 2: rb8_42.Checked = true; break;
                            case 3: rb8_43.Checked = true; break;
                            case 4: rb8_44.Checked = true; break;
                            case 5: rb8_45.Checked = true; break;
                            case 6: rb8_46.Checked = true; break;
                            case 7: rb8_47.Checked = true; break;
                            default: break;
                        }

                        switch (__sw5_3s1)
                        {
                            case 1: rb8_51.Checked = true; break;
                            case 2: rb8_52.Checked = true; break;
                            case 3: rb8_53.Checked = true; break;
                            default: break;
                        }

                        switch (__sw6_3s1)
                        {
                            case 1: rb8_61.Checked = true; break;
                            case 2: rb8_62.Checked = true; break;
                            case 3: rb8_63.Checked = true; break;
                            default: break;
                        }

                        switch (__sw7_3s1)
                        {
                            case 1: rb8_71.Checked = true; break;
                            case 2: rb8_72.Checked = true; break;
                            case 3: rb8_73.Checked = true; break;
                            default: break;
                        }

                        switch (__sw8_3s1)
                        {
                            case 1: rb8_81.Checked = true; break;
                            case 2: rb8_82.Checked = true; break;
                            case 3: rb8_83.Checked = true; break;
                            default: break;
                        }

                    }
                    else if (dex >= 2)
                    {
                        __sw_host[dex-2,0] = GetSwitchPin(txBuf,8);
                        __sw_host[dex - 2, 1] = GetSwitchPin(txBuf, 9);
                        __sw_host[dex - 2, 2] = GetSwitchPin(txBuf, 10);

                        /////////////////////////////////////////1
                        switch (__sw_host[0, 0])
                        {
                            case 1: rb711.Checked = true; break;
                            case 2: rb712.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[0, 1])
                        {
                            case 1: rb721.Checked = true; break;
                            case 2: rb722.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[0, 2])
                        {
                            case 1: rb731.Checked = true; break;
                            case 2: rb732.Checked = true; break;
                            default: break;
                        }
                        /////////////////////////////////////////2
                        switch (__sw_host[1, 0])
                        {
                            case 1: rb811.Checked = true; break;
                            case 2: rb812.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[1, 1])
                        {
                            case 1: rb821.Checked = true; break;
                            case 2: rb822.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[1, 2])
                        {
                            case 1: rb831.Checked = true; break;
                            case 2: rb832.Checked = true; break;
                            default: break;
                        }
                        /////////////////////////////////////////3
                        switch (__sw_host[2, 0])
                        {
                            case 1: rb911.Checked = true; break;
                            case 2: rb912.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[2, 1])
                        {
                            case 1: rb921.Checked = true; break;
                            case 2: rb922.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[2, 2])
                        {
                            case 1: rb931.Checked = true; break;
                            case 2: rb932.Checked = true; break;
                            default: break;
                        }
                        /////////////////////////////////////////4
                        switch (__sw_host[3, 0])
                        {
                            case 1: rb1811.Checked = true; break;
                            case 2: rb1812.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[3, 1])
                        {
                            case 1: rb1821.Checked = true; break;
                            case 2: rb1822.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[3, 2])
                        {
                            case 1: rb1831.Checked = true; break;
                            case 2: rb1832.Checked = true; break;
                            default: break;
                        }
                        /////////////////////////////////////////5
                        switch (__sw_host[4, 0])
                        {
                            case 1: rb1911.Checked = true; break;
                            case 2: rb1912.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[4, 1])
                        {
                            case 1: rb1921.Checked = true; break;
                            case 2: rb1922.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[4, 2])
                        {
                            case 1: rb1931.Checked = true; break;
                            case 2: rb1932.Checked = true; break;
                            default: break;
                        }
                        /////////////////////////////////////////6
                        switch (__sw_host[5, 0])
                        {
                            case 1: rb2111.Checked = true; break;
                            case 2: rb2112.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[5, 1])
                        {
                            case 1: rb2121.Checked = true; break;
                            case 2: rb2122.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[5, 2])
                        {
                            case 1: rb2131.Checked = true; break;
                            case 2: rb2132.Checked = true; break;
                            default: break;
                        }
                        /////////////////////////////////////////7
                        switch (__sw_host[6, 0])
                        {
                            case 1: rb2611.Checked = true; break;
                            case 2: rb2612.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[6, 1])
                        {
                            case 1: rb2621.Checked = true; break;
                            case 2: rb2622.Checked = true; break;
                            default: break;
                        }

                        switch (__sw_host[6, 2])
                        {
                            case 1: rb2631.Checked = true; break;
                            case 2: rb2632.Checked = true; break;
                            default: break;
                        }

                    }                   

                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        int GetSwitchPin(Byte[] txBuf,int swid)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if ((swMap[swid, i, j] & BitConverter.ToUInt16(txBuf, 1 + j * 2)) != 0)
                    {
                        return i + 1;                        
                    }
                }
            }

            return 0;
        }

        void BtnConnect(Button btn,string ip,int dex)
        {
            if(btn.Text.Equals("连接"))
            {
                TcpConnect(dex,ip);
                if (!ReadStatue(dex)) return;
                __tcpLink[dex] = true;
                btn.Text = "断开";
            }
            else
            {
                TcpDisConnect(dex);
                btn.Text = "连接";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BtnConnect(sender as Button,tb000.Text,0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BtnConnect(sender as Button, tb001.Text, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnConnect(sender as Button, tb002.Text, 2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BtnConnect(sender as Button, tb003.Text, 3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BtnConnect(sender as Button, tb004.Text, 4);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            BtnConnect(sender as Button, tb005.Text, 5);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            BtnConnect(sender as Button, tb006.Text, 6);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            BtnConnect(sender as Button, tb007.Text, 7);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            BtnConnect(sender as Button, tb008.Text, 8);
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                TcpDisConnect(i);
            }
        }

        bool[] __tcpLink = new bool[9];

        int __sw1_3s1,
            __sw2_3s1,
            __sw3_7s1,
            __sw4_7s1,
            __sw5_3s1,
            __sw6_3s1,
            __sw7_3s1,
            __sw8_3s1;

        int[,] __sw_host = new int[10, 3];

        private void timer1_Tick(object sender, EventArgs e)
        {            
            if (rb8_11.Checked && __sw1_3s1 != 1){if(SwitchConfig(0,0,1)){__sw1_3s1 = 1;}}else
            if (rb8_12.Checked && __sw1_3s1 != 2){if(SwitchConfig(0,0,2)){__sw1_3s1 = 2;}}else
            if (rb8_13.Checked && __sw1_3s1 != 3){if(SwitchConfig(0,0,3)){__sw1_3s1 = 3;}}

            if (rb8_21.Checked && __sw2_3s1 != 1){if(SwitchConfig(0,1,1)){__sw2_3s1 = 1;}}else
            if (rb8_22.Checked && __sw2_3s1 != 2){if(SwitchConfig(0,1,2)){__sw2_3s1 = 2;}}else
            if (rb8_23.Checked && __sw2_3s1 != 3){if(SwitchConfig(0,1,3)){__sw2_3s1 = 3;}}

            if (rb8_31.Checked && __sw3_7s1 != 1){if(SwitchConfig(1,2,1)){__sw3_7s1 = 1;}}else
            if (rb8_32.Checked && __sw3_7s1 != 2){if(SwitchConfig(1,2,2)){__sw3_7s1 = 2;}}else
            if (rb8_33.Checked && __sw3_7s1 != 3){if(SwitchConfig(1,2,3)){__sw3_7s1 = 3;}}else
            if (rb8_34.Checked && __sw3_7s1 != 4){if(SwitchConfig(1,2,4)){__sw3_7s1 = 4;}}else
            if (rb8_35.Checked && __sw3_7s1 != 5){if(SwitchConfig(1,2,5)){__sw3_7s1 = 5;}}else
            if (rb8_36.Checked && __sw3_7s1 != 6){if(SwitchConfig(1,2,6)){__sw3_7s1 = 6;}}else
            if (rb8_37.Checked && __sw3_7s1 != 7){if(SwitchConfig(1,2,7)){__sw3_7s1 = 7;}}

            if (rb8_41.Checked && __sw4_7s1 != 1){if(SwitchConfig(1,3,1)){__sw4_7s1 = 1;}}else
            if (rb8_42.Checked && __sw4_7s1 != 2){if(SwitchConfig(1,3,2)){__sw4_7s1 = 2;}}else
            if (rb8_43.Checked && __sw4_7s1 != 3){if(SwitchConfig(1,3,3)){__sw4_7s1 = 3;}}else
            if (rb8_44.Checked && __sw4_7s1 != 4){if(SwitchConfig(1,3,4)){__sw4_7s1 = 4;}}else
            if (rb8_45.Checked && __sw4_7s1 != 5){if(SwitchConfig(1,3,5)){__sw4_7s1 = 5;}}else
            if (rb8_46.Checked && __sw4_7s1 != 6){if(SwitchConfig(1,3,6)){__sw4_7s1 = 6;}}else
            if (rb8_47.Checked && __sw4_7s1 != 7){if(SwitchConfig(1,3,7)){__sw4_7s1 = 7;}}

            if (rb8_51.Checked && __sw5_3s1 != 1){if(SwitchConfig(1,4,1)){__sw5_3s1 = 1;}}else
            if (rb8_52.Checked && __sw5_3s1 != 2){if(SwitchConfig(1,4,2)){__sw5_3s1 = 2;}}else
            if (rb8_53.Checked && __sw5_3s1 != 3){if(SwitchConfig(1,4,3)){__sw5_3s1 = 3;}}

            if (rb8_61.Checked && __sw6_3s1 != 1){if(SwitchConfig(1,5,1)){__sw6_3s1 = 1;}}else
            if (rb8_62.Checked && __sw6_3s1 != 2){if(SwitchConfig(1,5,2)){__sw6_3s1 = 2;}}else
            if (rb8_63.Checked && __sw6_3s1 != 3){if(SwitchConfig(1,5,3)){__sw6_3s1 = 3;}}

            if (rb8_71.Checked && __sw7_3s1 != 1){if(SwitchConfig(1,6,1)){__sw7_3s1 = 1;}}else
            if (rb8_72.Checked && __sw7_3s1 != 2){if(SwitchConfig(1,6,2)){__sw7_3s1 = 2;}}else
            if (rb8_73.Checked && __sw7_3s1 != 3){if(SwitchConfig(1,6,3)){__sw7_3s1 = 3;}}

            if (rb8_81.Checked && __sw8_3s1 != 1){if(SwitchConfig(1,7,1)){__sw8_3s1 = 1;}}else
            if (rb8_82.Checked && __sw8_3s1 != 2){if(SwitchConfig(1,7,2)){__sw8_3s1 = 2;}}else
            if (rb8_83.Checked && __sw8_3s1 != 3){if(SwitchConfig(1,7,3)){__sw8_3s1 = 3;}}

            int hostIdx = 0, boxId = 2;
            ///////////////////////////////////////////////////////////////////////////////////////////
            if (rb711.Checked && __sw_host[hostIdx,0] != 1){if(SwitchConfig(boxId,8,1)) {__sw_host[hostIdx,0] = 1;}}else
            if (rb712.Checked && __sw_host[hostIdx,0] != 2){if(SwitchConfig(boxId,8,2)) {__sw_host[hostIdx,0] = 2;} }

            if (rb721.Checked && __sw_host[hostIdx,1] != 1){if(SwitchConfig(boxId,9,1)){__sw_host[hostIdx,1] = 1;}}else
            if (rb722.Checked && __sw_host[hostIdx,1] != 2){if(SwitchConfig(boxId,9,2)){__sw_host[hostIdx,1] = 2;}}

            if (rb731.Checked && __sw_host[hostIdx,2] != 1){if(SwitchConfig(boxId,10,1)){__sw_host[hostIdx,2] = 1;}}else
            if (rb732.Checked && __sw_host[hostIdx,2] != 2){if(SwitchConfig(boxId,10,2)){__sw_host[hostIdx,2] = 2;}}

            hostIdx++; boxId++;           
            ///////////////////////////////////////////////////////////////////////////////////////////
            if (rb811.Checked && __sw_host[hostIdx,0] != 1){if(SwitchConfig(boxId,8,1)) {__sw_host[hostIdx,0] = 1;}}else
            if (rb812.Checked && __sw_host[hostIdx,0] != 2){if(SwitchConfig(boxId,8,2)) {__sw_host[hostIdx,0] = 2;} }

            if (rb821.Checked && __sw_host[hostIdx,1] != 1){if(SwitchConfig(boxId,9,1)){__sw_host[hostIdx,1] = 1;}}else
            if (rb822.Checked && __sw_host[hostIdx,1] != 2){if(SwitchConfig(boxId,9,2)){__sw_host[hostIdx,1] = 2;}}

            if (rb831.Checked && __sw_host[hostIdx,2] != 1){if(SwitchConfig(boxId,10,1)){__sw_host[hostIdx,2] = 1;}}else
            if (rb832.Checked && __sw_host[hostIdx,2] != 2){if(SwitchConfig(boxId,10,2)){__sw_host[hostIdx,2] = 2;}}

            hostIdx++; boxId++;           
            ///////////////////////////////////////////////////////////////////////////////////////////
            if (rb911.Checked && __sw_host[hostIdx,0] != 1){if(SwitchConfig(boxId,8,1)) {__sw_host[hostIdx,0] = 1;}}else
            if (rb912.Checked && __sw_host[hostIdx,0] != 2){if(SwitchConfig(boxId,8,2)) {__sw_host[hostIdx,0] = 2;} }

            if (rb921.Checked && __sw_host[hostIdx,1] != 1){if(SwitchConfig(boxId,9,1)){__sw_host[hostIdx,1] = 1;}}else
            if (rb922.Checked && __sw_host[hostIdx,1] != 2){if(SwitchConfig(boxId,9,2)){__sw_host[hostIdx,1] = 2;}}

            if (rb931.Checked && __sw_host[hostIdx,2] != 1){if(SwitchConfig(boxId,10,1)){__sw_host[hostIdx,2] = 1;}}else
            if (rb932.Checked && __sw_host[hostIdx,2] != 2){if(SwitchConfig(boxId,10,2)){__sw_host[hostIdx,2] = 2;}}

            hostIdx++; boxId++;           
            ///////////////////////////////////////////////////////////////////////////////////////////
            if (rb1811.Checked && __sw_host[hostIdx,0] != 1){if(SwitchConfig(boxId,8,1)) {__sw_host[hostIdx,0] = 1;}}else
            if (rb1812.Checked && __sw_host[hostIdx,0] != 2){if(SwitchConfig(boxId,8,2)) {__sw_host[hostIdx,0] = 2;} }

            if (rb1821.Checked && __sw_host[hostIdx,1] != 1){if(SwitchConfig(boxId,9,1)){__sw_host[hostIdx,1] = 1;}}else
            if (rb1822.Checked && __sw_host[hostIdx,1] != 2){if(SwitchConfig(boxId,9,2)){__sw_host[hostIdx,1] = 2;}}

            if (rb1831.Checked && __sw_host[hostIdx,2] != 1){if(SwitchConfig(boxId,10,1)){__sw_host[hostIdx,2] = 1;}}else
            if (rb1832.Checked && __sw_host[hostIdx,2] != 2){if(SwitchConfig(boxId,10,2)){__sw_host[hostIdx,2] = 2;}}

            hostIdx++; boxId++;           
            ///////////////////////////////////////////////////////////////////////////////////////////
            if (rb1911.Checked && __sw_host[hostIdx,0] != 1){if(SwitchConfig(boxId,8,1)) {__sw_host[hostIdx,0] = 1;}}else
            if (rb1912.Checked && __sw_host[hostIdx,0] != 2){if(SwitchConfig(boxId,8,2)) {__sw_host[hostIdx,0] = 2;} }

            if (rb1921.Checked && __sw_host[hostIdx,1] != 1){if(SwitchConfig(boxId,9,1)){__sw_host[hostIdx,1] = 1;}}else
            if (rb1922.Checked && __sw_host[hostIdx,1] != 2){if(SwitchConfig(boxId,9,2)){__sw_host[hostIdx,1] = 2;}}

            if (rb1931.Checked && __sw_host[hostIdx,2] != 1){if(SwitchConfig(boxId,10,1)){__sw_host[hostIdx,2] = 1;}}else
            if (rb1932.Checked && __sw_host[hostIdx,2] != 2){if(SwitchConfig(boxId,10,2)){__sw_host[hostIdx,2] = 2;}}

            hostIdx++; boxId++;           
            ///////////////////////////////////////////////////////////////////////////////////////////
            if (rb2111.Checked && __sw_host[hostIdx,0] != 1){if(SwitchConfig(boxId,8,1)) {__sw_host[hostIdx,0] = 1;}}else
            if (rb2112.Checked && __sw_host[hostIdx,0] != 2){if(SwitchConfig(boxId,8,2)) {__sw_host[hostIdx,0] = 2;} }

            if (rb2121.Checked && __sw_host[hostIdx,1] != 1){if(SwitchConfig(boxId,9,1)){__sw_host[hostIdx,1] = 1;}}else
            if (rb2122.Checked && __sw_host[hostIdx,1] != 2){if(SwitchConfig(boxId,9,2)){__sw_host[hostIdx,1] = 2;}}

            if (rb2131.Checked && __sw_host[hostIdx,2] != 1){if(SwitchConfig(boxId,10,1)){__sw_host[hostIdx,2] = 1;}}else
            if (rb2132.Checked && __sw_host[hostIdx,2] != 2){if(SwitchConfig(boxId,10,2)){__sw_host[hostIdx,2] = 2;}}

            hostIdx++; boxId++;           
            ///////////////////////////////////////////////////////////////////////////////////////////
            if (rb2611.Checked && __sw_host[hostIdx,0] != 1){if(SwitchConfig(boxId,8,1)) {__sw_host[hostIdx,0] = 1;}}else
            if (rb2612.Checked && __sw_host[hostIdx,0] != 2){if(SwitchConfig(boxId,8,2)) {__sw_host[hostIdx,0] = 2;} }

            if (rb2621.Checked && __sw_host[hostIdx,1] != 1){if(SwitchConfig(boxId,9,1)){__sw_host[hostIdx,1] = 1;}}else
            if (rb2622.Checked && __sw_host[hostIdx,1] != 2){if(SwitchConfig(boxId,9,2)){__sw_host[hostIdx,1] = 2;}}

            if (rb2631.Checked && __sw_host[hostIdx,2] != 1){if(SwitchConfig(boxId,10,1)){__sw_host[hostIdx,2] = 1;}}else
            if (rb2632.Checked && __sw_host[hostIdx,2] != 2){if(SwitchConfig(boxId,10,2)){__sw_host[hostIdx,2] = 2;}}

            gb801.Enabled = gb802.Enabled = __tcpLink[0];
            gb803.Enabled = gb804.Enabled = gb805.Enabled = gb806.Enabled = gb807.Enabled = gb808.Enabled = __tcpLink[1];
            gb71.Enabled = gb72.Enabled = gb73.Enabled = __tcpLink[2];
            gb81.Enabled = gb82.Enabled = gb83.Enabled = __tcpLink[3];
            gb91.Enabled = gb92.Enabled = gb93.Enabled = __tcpLink[4];
            gb181.Enabled = gb182.Enabled = gb183.Enabled = __tcpLink[5];
            gb191.Enabled = gb192.Enabled = gb193.Enabled = __tcpLink[6];
            gb211.Enabled = gb212.Enabled = gb213.Enabled = __tcpLink[7];
            gb261.Enabled = gb262.Enabled = gb263.Enabled = __tcpLink[8];        
        }

        private void cbCollect_Click(object sender, EventArgs e)
        {
        }

        private void cbCollect_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = cbCollect.Checked;            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                if (__tcpLink[i]) Send(i);
                Thread.Sleep(50);
            }
        }
    }
}
