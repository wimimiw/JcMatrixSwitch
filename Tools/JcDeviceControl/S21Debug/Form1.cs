using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace S21Debug
{
    public partial class Form1 : Form
    {
        private ManualResetEvent __MRESpRev = new ManualResetEvent(false);
        private ManualResetEvent __MRETestComm = new ManualResetEvent(false);
        private ManualResetEvent __MERRFSigneal = new ManualResetEvent(false);
        public string _strSpRev = string.Empty;
        public int __errCnt;
        public int __PAComIndex;
        public int __CntTx = 0;
        public int __CntLost = 0;        

        public Form1()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                case MessageID.RF_SUCCED_ALL:
                    __MERRFSigneal.Set();
                    break;
                case MessageID.RF_FAILED:
                    __MERRFSigneal.Set();
                    MessageBox.Show(this,"Not ACK","WARNING",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    break;
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Empty;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.serialPort1.PortName = this.comboBox1.Text;
        }

        private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(SerialPort.GetPortNames());
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            this.cbbPACom.Items.Clear();
            this.cbbPACom.Items.AddRange(SerialPort.GetPortNames());
        }

        private void nudOffset_Click(object sender, EventArgs e)
        {
            this.serialPort1.WriteLine("JC:S12:RF:CALIB:OFFSET " + this.nudOffset.Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.serialPort1.IsOpen)
            {
                MessageBox.Show("串口未启用");
                return;
            }
            Thread thrd = new Thread(new ThreadStart(delegate
            {
                bool result = true;

                this.__MRESpRev.Reset();

                if (this.cbPwr.Checked)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Minimum;
                        this.serialPort1.WriteLine("JC:S12:RF:TX:POWER " + this.cbPower.SelectedIndex.ToString("D1"));
                    }), null);

                    if (!this.__MRESpRev.WaitOne(1000)) result = false; ; this.__MRESpRev.Reset();

                    this.Invoke(new EventHandler(delegate { this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Maximum * 1 / 4; }), null);
                }

                if (this.cbFreq.Checked)
                {
                    this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:TX:FREQ " + this.tbFreq.Text + "000"); }), null);

                    if (!this.__MRESpRev.WaitOne(1000)) result = false; ; this.__MRESpRev.Reset();

                    this.Invoke(new EventHandler(delegate { this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Maximum * 2 / 4; }), null);
                }

                if (this.cbFloat.Checked)
                {
                    this.Invoke(new EventHandler(delegate {this.serialPort1.WriteLine("JC:S12:RF:RX:FLOAT " + this.tbFloat.Text); }), null);

                    if (!this.__MRESpRev.WaitOne(1000)) result = false; ; this.__MRESpRev.Reset();

                    this.Invoke(new EventHandler(delegate { this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Maximum * 3 / 4; }), null);

                }

                if (this.cbBetween.Checked)
                {
                    this.Invoke(new EventHandler(delegate{this.serialPort1.WriteLine("JC:S12:RF:RX:BETWEEN " + this.tbBetween.Text);}), null);

                    if (!this.__MRESpRev.WaitOne(1000)) result = false; ; this.__MRESpRev.Reset();

                    this.Invoke(new EventHandler(delegate { this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Maximum * 4/ 4; }), null);

                }

                if (this.cbOpwr.Checked)
                {
                    this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:CALIB:PWR " + this.tbOpwr.Text); }), null);

                    if (!this.__MRESpRev.WaitOne(1000)) result = false; ; this.__MRESpRev.Reset();

                    this.Invoke(new EventHandler(delegate { this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Maximum * 4 / 4; }), null);

                }

                if (this.cbAtt.Checked)
                {
                    this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:ATT " + this.tbAtt.Text); }), null);

                    if (!this.__MRESpRev.WaitOne(1000)) result = false; ; this.__MRESpRev.Reset();

                    this.Invoke(new EventHandler(delegate { this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Maximum * 4 / 4; }), null);

                }

                if (this.cbDuting.Checked)
                {
                    this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:TX:KEEP " + this.tbDuring.Text); }), null);

                    if (!this.__MRESpRev.WaitOne(1000)) result = false; ; this.__MRESpRev.Reset();
                }

                if (this.cbAddr.Checked)
                {
                    this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:ADDR " + this.tbAddr.Text); this.toolStripStatusLabel1.Text = "设置成功"; }), null);

                    if (!this.__MRESpRev.WaitOne(1000)) result = false; ; this.__MRESpRev.Reset();
                }

                if (this.cbDetecH.Checked)
                {
                    ushort h = (ushort)(float.Parse(this.tbDetecH.Text)/3.3*4096);
                    this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:RX:DETECMAX " + h.ToString()); this.toolStripStatusLabel1.Text = "设置成功"; }), null);

                    if (!this.__MRESpRev.WaitOne(1000)) result = false; ; this.__MRESpRev.Reset();
                }

                if (this.cbDetecL.Checked)
                {
                    ushort l = (ushort)(float.Parse(this.tbDetecL.Text) / 3.3 * 4096);
                    this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:RX:DETECMIN " + l.ToString()); this.toolStripStatusLabel1.Text = "设置成功"; }), null);

                    if (!this.__MRESpRev.WaitOne(1000)) result = false; ; this.__MRESpRev.Reset();
                }

                if(result)
                    this.Invoke(new EventHandler(delegate { this.toolStripStatusLabel1.Text = "设置成功"; }), null);
                else
                    this.Invoke(new EventHandler(delegate { this.toolStripStatusLabel1.Text = "设置失败"; }), null);

                this.Invoke(new EventHandler(delegate { this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Maximum; }), null);
                
                Thread.Sleep(1000);

                this.Invoke(new EventHandler(delegate { this.toolStripStatusLabel1.Text = string.Empty; this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Minimum; }), null);
            }));

            thrd.Start();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = sender as SerialPort;
            this._strSpRev = sp.ReadLine().Trim(); //一直读到时NewLine符出现。这里为"\n"

            if (this.cbEnable.Checked)
            {
                this.Invoke(new EventHandler(delegate {

                    string info = string.Empty;

                    if (this._strSpRev.Contains("A"))
                    {
                        info = "=>Rev frame.";
                        this.__MRETestComm.Set();
                    }
                    else
                    if (this._strSpRev.Equals("B"))
                    {
                        info = "=>Switch To Tx.";                        
                    }
                    if (this._strSpRev.Equals("C"))
                    {
                        info = "=>Return To Rx.";
                    }

                    this.tbMoniter.Text += info + Environment.NewLine;
                    this.tbMoniter.SelectionStart = this.tbMoniter.Text.Length;
                    this.tbMoniter.ScrollToCaret();
                }), null);
            }
            
            this.__MRESpRev.Set();
        }

        private void rbtx_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
                this.serialPort1.WriteLine("JC:S12:RF:CHAN 1");
        }

        private void rbrx_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
                this.serialPort1.WriteLine("JC:S12:RF:CHAN 0");
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
                this.serialPort1.WriteLine("JC:S12:RF:TX:OUTP 1");
            else
                this.serialPort1.WriteLine("JC:S12:RF:TX:OUTP 0");
        }

        private void cbDebug_Click(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
                this.serialPort1.WriteLine("JC:S12:RF:DEBUG 1");
            else
                this.serialPort1.WriteLine("JC:S12:RF:DEBUG 0");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(new ThreadStart(delegate
            {
                this.Invoke(new EventHandler(delegate {this.serialPort1.WriteLine("JC:S12:RF:ADDR " + this.tbAddr.Text);this.toolStripStatusLabel1.Text = "设置成功";}), null);
                
                Thread.Sleep(1000);
                this.Invoke(new EventHandler(delegate {this.toolStripStatusLabel1.Text = "";}), null);
            }));
            thrd.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!this.serialPort1.IsOpen)
            {
                MessageBox.Show("串口未启用");
                return;
            }
            //this.cbEnable.Checked = false;
            Thread thrd = new Thread(ThrdComQueryAll);
            thrd.Start();
        }

        private void ThrdComQueryAll()
        {
            bool result = true;

            this.__MRESpRev.Reset();
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:ADDR?");}),null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false;  this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate {  this.tbAddr.Text = this._strSpRev; }), null);
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:DEBUG?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.cbDebug.Checked = this._strSpRev.Contains("1") ? true : false; }), null);
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:CHAN?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate {                 
                this.rbtx.Checked = this._strSpRev.Contains("1") ? true : false;
                this.rbrx.Checked = this._strSpRev.Contains("1") ? false : true;   
            }), null);
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:RX:FLOAT?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.tbFloat.Text = this._strSpRev; }), null);
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:RX:BETWEEN?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.tbBetween.Text = this._strSpRev; }), null);
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:ATT?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.tbAtt.Text = this._strSpRev; }), null);

            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:CALIB:PWR?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.tbOpwr.Text = this._strSpRev; }), null);
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:TX:KEEP?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.tbDuring.Text = this._strSpRev; }), null);        

            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:VERSION?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.tbVersion.Text = this._strSpRev; }), null);       
            
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:SN?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.tbSn.Text = this._strSpRev.Replace("\0",""); }), null);
            
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:OFFTIMER?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.tbOffTimer.Text = this._strSpRev; }), null);       
            
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:TX:FREQ?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false;this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate
            {
                int freq;
                if (int.TryParse(this._strSpRev, out freq))
                {
                    this.tbFreq.Text = (freq / 1000).ToString();
                }
            }), null);

            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:TX:OUTP?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false;  this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.cbOutp.Checked = this._strSpRev.Contains("1") ? true : false; }), null);

            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:TX:POWER?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate
            {
                int index;
                if (int.TryParse(this._strSpRev, out index) && index <= 3)
                {
                    this.cbPower.SelectedIndex = index;
                }
            }), null);

            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:CALIB:OFFSET?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false;  this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate {this.nudOffset.Value = int.Parse(this._strSpRev)%4095; }), null);

            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:RX:DETECMAX?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.tbDetecH.Text = (ushort.Parse(this._strSpRev)*3.3/4096).ToString("F1"); }), null);

            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:RX:DETECMIN?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.tbDetecL.Text = (ushort.Parse(this._strSpRev) * 3.3 / 4096).ToString("F1"); }), null);

            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:CHAN?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.rbtx.Checked = int.Parse(this._strSpRev.Trim()) == 1 ? true:false;
                                                                               this.rbrx.Checked = int.Parse(this._strSpRev.Trim()) == 1 ? false:true;}), null);            
            ///
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:TX:OUTP?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.cbOutp.Checked =  int.Parse(this._strSpRev.Trim()) == 1 ? true:false;}), null);

            //
            this.Invoke(new EventHandler(delegate { this.serialPort1.WriteLine("JC:S12:RF:DEBUG?"); }), null);

            if (!this.__MRESpRev.WaitOne(1000)) result = false; this.__MRESpRev.Reset();

            this.Invoke(new EventHandler(delegate { this.cbDebug.Checked = int.Parse(this._strSpRev.Trim()) == 1 ? true : false; }), null);
           


            this.Invoke(new EventHandler(delegate
            {
                if (result)
                    this.toolStripStatusLabel1.Text = "查询成功";
                else
                    this.toolStripStatusLabel1.Text = "查询失败";                                
            }), null);

            Thread.Sleep(2000);
            
            this.Invoke(new EventHandler(delegate{this.toolStripStatusLabel1.Text = string.Empty;}),null);

        }

        private void btCom_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            if (bt.Text == "打开")
            {
                bt.Text = "关闭";
                this.serialPort1.Open();
            }
            else
            {
                bt.Text = "打开";
                this.serialPort1.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            __errCnt = 0;
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button3_Click(this.button3, null);
        }

        private void nudOffset_ValueChanged(object sender, EventArgs e)
        {
            //if (nudOffset.Value != 1000)
            //    this.lbErr.Text = (++this.__errCnt).ToString();
        }

        private Thread __thrdTrigPlus = null;
        private bool __thrdTrigPlusQuit = false;
        private void TrigPulse()
        {
            int lvl = RFPriority.LvlTwo;

            float p = float.Parse(this.tbPAPower.Text);
            float f = float.Parse(this.tbPAFreq.Text);

            this.__MERRFSigneal.Reset();
            RFSignal.RFClear(this.__PAComIndex, lvl);
            RFSignal.RFPowerFreq(this.__PAComIndex, lvl, p, f);
            RFSignal.RFSetAtt(this.__PAComIndex, lvl, 0);
            RFSignal.RFOn(this.__PAComIndex, lvl);
            RFSignal.RFStart(this.__PAComIndex);
            this.__MERRFSigneal.WaitOne(2000);

            int addr = int.Parse(this.tbRAddr.Text);
            int f1 = int.Parse(this.tbRFreq.Text);
            int p1 = int.Parse(this.tbRPower.Text);

            bool bQuit = false;
            double timeCnt = 0;;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Reset();
            stopWatch.Start();          

            do
            {
                lock(this){bQuit = __thrdTrigPlusQuit;};

                timeCnt = stopWatch.Elapsed.TotalMilliseconds;

                this.__MRETestComm.Reset();

                Stopwatch sw1 = new Stopwatch();
                sw1.Stop();

                this.__MERRFSigneal.Reset();
                RFSignal.RFClear(this.__PAComIndex, lvl);
                RFSignal.RFTrigPlus(this.__PAComIndex, lvl, addr, p1, f1);
                RFSignal.RFStart(this.__PAComIndex);
                sw1.Reset(); sw1.Start();
                this.__MERRFSigneal.WaitOne(3000);
                
                long timer = sw1.ElapsedMilliseconds;

                this.__CntTx++;
                if (!this.__MRETestComm.WaitOne(8000))
                {
                    this.__CntLost++;
                }                

                if (this.cbWuMa.Checked)
                {
                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        this.lbCntTx.Text = this.__CntTx.ToString();
                        this.lbCntLost.Text = this.__CntLost.ToString();
                        this.lbTimeSingle.Text = (stopWatch.Elapsed.TotalMilliseconds - timeCnt).ToString("0")+ " 毫秒";
                        this.lbTimeSum.Text = stopWatch.Elapsed.TotalSeconds.ToString("0") + " 秒";
                    }));
                }

            }while(bQuit && this.radioButton2.Checked);

            stopWatch.Stop();

            Thread.Sleep(1000);

            RFSignal.RFClear(this.__PAComIndex, lvl);
            RFSignal.RFOff(this.__PAComIndex, lvl);
            RFSignal.RFStart(this.__PAComIndex);
            Thread.Sleep(1000);

            this.Invoke(new MethodInvoker(delegate { this.button4.Text = "触发脉冲"; }));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            //if (int.Parse(this.tbPAPower.Text) > 33)
            //{
            //    this.tbPAPower.Text = "20";
            //}

            if (btn.Text.Equals("触发脉冲"))
            {
                if (this.btPaOpen.Text.Equals("打开"))
                {
                    MessageBox.Show("请先打开功放!");
                    return;
                }

                if (this.cbWuMa.Checked && this.radioButton2.Checked)
                {
                    this.__CntTx = 0;
                    this.__CntLost = 0;
                    this.lbCntTx.Text = "0";
                    this.lbCntLost.Text = "0";
                    this.lbTimeSingle.Text = "0";
                    this.lbTimeSum.Text = "0";
                    MessageBox.Show("请确认连接模块串口，并打开模块调试使能！");
                }

                btn.Text = "停止脉冲";
                lock (this) { __thrdTrigPlusQuit = true; };
                __thrdTrigPlus = new Thread(new ThreadStart(TrigPulse));
                __thrdTrigPlus.Start();
            }
            else
            {
                btn.Text = "触发脉冲";

                lock (this) { __thrdTrigPlusQuit = false; };
                //Monitor.Enter(__thrdTrigPlusQuit);
                //__thrdTrigPlusQuit = false;
                //Monitor.Exit(__thrdTrigPlusQuit);
            }
        }

        private void btPaOpen_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            if (bt.Text == "打开")
            {
                if (this.cbbPACom.Text == string.Empty) return;
                string str = this.cbbPACom.Text;
                this.__PAComIndex = int.Parse(str.Replace("COM",string.Empty));                          
                RFSignal.InitRFSignal(this.Handle);                
                RFSignal.NewRFSignal(this.__PAComIndex, RFSignal.clsSunWave, this.rbLiner.Checked?RFSignal.formuleLinar:RFSignal.formuleLog);
                this.__MERRFSigneal.WaitOne(2000);
                bt.Text = "关闭";     
            }
            else {
                bt.Text = "打开";
                RFSignal.FinaRFSignal();
            }
        }
    }
}
