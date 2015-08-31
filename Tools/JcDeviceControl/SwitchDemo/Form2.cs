using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SwitchDemo
{
    public partial class Form2 : Form
    {
        private com_io_ctl cic;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Empty;

            string[] gpioName = new string[16];

            for (int i = 0; i < gpioName.Length; i++)
            {
                gpioName[i] = i.ToString();
            }

            this.checkedListBox1.Items.AddRange(gpioName);
            this.checkedListBox2.Items.AddRange(gpioName);
            this.checkedListBox3.Items.AddRange(gpioName);
            this.checkedListBox4.Items.AddRange(gpioName);
            this.checkedListBox5.Items.AddRange(gpioName);

            this.cic = new com_io_ctl(Application.StartupPath + @"\io.ini");

            this.checkedListBox6.Items.Clear();
            this.checkedListBox6.Items.AddRange(this.cic.stateName.ToArray());
        }

        private void SetGpioValue(ushort[] item)
        {
            CheckedListBox[] clb = new CheckedListBox[] { 
                this.checkedListBox1, 
                this.checkedListBox2,
                this.checkedListBox3,
                this.checkedListBox4,
                this.checkedListBox5 };

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < clb.Length; j++)
                {
                    clb[j].SetItemChecked(i, (item[j] & (1 << i)) > 0);                           
                }
            }        
        }

        private ushort[] GetGpioValue()
        {
            ushort[] item = new ushort[5] { 0, 0, 0, 0, 0 };

            CheckedListBox[] clb = new CheckedListBox[] { 
                this.checkedListBox1, 
                this.checkedListBox2,
                this.checkedListBox3,
                this.checkedListBox4,
                this.checkedListBox5 };

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < clb.Length; j++)
                {
                    if (clb[j].GetItemChecked(i))
                        item[j] |= (ushort)(1 << i);
                }
            }

            return item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string state = string.Empty;

            int index = this.cic.stateName.Count;

            state = index.ToString();
            this.checkedListBox6.Items.Add(state);
            this.cic.StateStore(index, this.GetGpioValue());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox6.Items.Count; i++)
            {
                if (this.checkedListBox6.GetItemChecked(i))
                {
                    this.checkedListBox6.Items.RemoveAt(i);
                    this.cic.StateDelete(i);
                }
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            cbb.Items.Clear();
            cbb.Items.AddRange(SerialPort.GetPortNames());            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            //if (this.timer1.Enabled)
            //    this.timer1.Enabled = false;

            if (cbb.Text == string.Empty) return;

            if (cic != null) cic.Dispose();

            this.cic.OpenCom(cbb.Text);
            this.cic.readEvent += new com_io_ctl.ReadEventHandler(cic_readEvent);
            //this.cic.readEvent += new com_io_ctl.ReadEventHandler(cic_readEvent);
        }

        void cic_readEvent(object sender, ReadEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.toolStripStatusLabel1.Text = "正常通信中...";
            }));

            //throw new NotImplementedException();
        }

        private void checkedListBox6_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox clb = sender as CheckedListBox;

            for (int i = 0; i < clb.CheckedIndices.Count; i++)
            {
                if (clb.CheckedIndices[i] != e.Index)
                {
                    clb.SetItemChecked(clb.CheckedIndices[i], false);
                }
            }

            SetGpioValue(this.cic.stateValue[e.Index]);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.cic.StateUpdate(this.checkedListBox6.SelectedIndex, this.GetGpioValue());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox6.SelectedIndex < 0)
                MessageBox.Show("请选择状态！");
            else
                this.cic.BaseStateWrite(this.checkedListBox6.SelectedIndex);
        }
    }
}
