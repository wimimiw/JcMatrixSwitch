using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GerenalPlus
{
    public partial class Form1 : Form
    {
        TcpClient __tcpClient = null;
        int __cntTimer = 0;

        public Form1()
        {
            InitializeComponent();
        }

        void GerenalPlusPcs(ushort during,ushort period)
        {
            try
            {
                if (__tcpClient != null && __tcpClient.Connected)
                {
                    Byte[] tbuf = new Byte[12];
                    Byte[] rbuf = new Byte[12];
                    Array.Clear(tbuf, 0, tbuf.Length);
                    Array.Clear(rbuf, 0, rbuf.Length);

                    tbuf[0] = Convert.ToByte('P');
                    tbuf[1] = (Byte)(during % 256);
                    tbuf[2] = (Byte)(during / 256);
                    tbuf[3] = (Byte)(period % 256);
                    tbuf[4] = (Byte)(period / 256);

                    for (int i = 1; i < tbuf.Length - 2; i++)
                    {
                        tbuf[tbuf.Length - 1] ^= tbuf[i];
                    }

                    __tcpClient.GetStream().Write(tbuf, 0, tbuf.Length);
                    __tcpClient.GetStream().Read(rbuf, 0, rbuf.Length);

                    if (NumericUpDown2.Value != 0)
                    {
                        toolStripStatusLabel1.Text = "ok...  PWM Period = " + (10000 / NumericUpDown2.Value).ToString("F2") + " Hz Duty Ratio = " +
                            ((float)(NumericUpDown1.Value / NumericUpDown2.Value) * 100f).ToString("F2") + "%";
                    }
                }
                else
                    toolStripStatusLabel1.Text = "无法连接从机...";
            }
            catch (Exception ex)
            {
                __tcpClient = null;
                button2.Enabled = true;
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            if ( __tcpClient == null )
            {
                MessageBox.Show("确认连接!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ( NumericUpDown2.Value == 0 )
            {
                __cntTimer++;
                GerenalPlusPcs((ushort)(NumericUpDown1.Value),0);
            }
            else
            {
                //__cntTimer = 0;
                //timer1.Interval = (int)(10 * NumericUpDown2.Value);
                //timer1.Enabled = bt.Text.Equals("提交");
                //bt.Text = bt.Text.Equals("提交")?"终止":"提交";

                if (bt.Text.Equals("提交"))
                {
                    bt.Text = "终止";

                    if (NumericUpDown1.Value >= NumericUpDown2.Value)
                    {
                        MessageBox.Show("周期触发的时间必须大于单次触发的时间,或者周期触发的时间为0(=关闭)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    GerenalPlusPcs((ushort)(NumericUpDown1.Value), (ushort)(NumericUpDown2.Value));


                }
                else 
                {
                    bt.Text = "提交";
                    GerenalPlusPcs((ushort)(NumericUpDown1.Value), 0);
                }
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            if (bt.Text.Equals("连接"))
            {
                try
                {
                    __tcpClient = new TcpClient("192.168.0.178", 4001);
                    __tcpClient.SendTimeout = 1000;
                    bt.Text = "断开";
                }
                catch (Exception ex)
                {
                    __tcpClient = null;
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (__tcpClient != null && __tcpClient.Connected)
                {
                    __tcpClient.Close();
                }

                bt.Text = "连接";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            __cntTimer++;
            //GerenalPlusPcs((ushort)(NumericUpDown1.Value));
        }
    }
}
