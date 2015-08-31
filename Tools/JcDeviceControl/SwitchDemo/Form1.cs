using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace SwitchDemo
{
    public partial class Form1 : Form
    {
        private com_io_ctl cic;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 14; i++)
            {
                this.checkedListBox1.Items.Add("SPDT"+i.ToString());
            }

            for (int i = 1; i <= 12; i++)
            {
                this.checkedListBox2.Items.Add("SP12T_1_" + i.ToString());
                this.checkedListBox3.Items.Add("SP12T_2_" + i.ToString());
            }

            this.toolStripStatusLabel1.Text = string.Empty;
            //mcuGpio[0] = 0xC013;
            //mcuGpio[1] = 0xf138;
            //mcuGpio[2] = 0x7c0c;
            //mcuGpio[3] = 0x1ff7;
            //mcuGpio[4] = 0x007e;
            //SetCheckList();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
           
            if (this.timer1.Enabled)
                this.timer1.Enabled = false;

            if (cbb.Text == string.Empty) return;

            if (cic != null) cic.Dispose();

            cic = new com_io_ctl(cbb.Text, Application.StartupPath + @"\io.ini");            
            cic.readEvent += new com_io_ctl.ReadEventHandler(cic_readEvent);

            this.timer1.Enabled = true;     
        }

        void cic_readEvent(object sender, ReadEventArgs e)
        {
            this.Invoke(new EventHandler( delegate{
                SetCheckList();
                this.toolStripStatusLabel1.Text = "正常通信中...";
            }));
            //throw new NotImplementedException();
        }

        private void CheckListPcs(bool write)
        {
            CheckedListBox clb;
            for (int k = 0; k < 3; k++)
            {
                if (k == 0) clb = checkedListBox1;
                else if (k == 1) clb = checkedListBox2;
                else if (k == 2) clb = checkedListBox3;
                else break;

                for (int i = 0; i < clb.Items.Count; i++)
                {
                    if (write)
                    {
                        if (cic.GetGpioState(clb.Items[i].ToString()))
                        {
                            clb.SetItemChecked(i, true);
                        }
                        else
                        {
                            clb.SetItemChecked(i, false);
                        }
                    }
                    else
                    {
                        cic.SetSwitchState(clb.Items[i].ToString(), clb.GetItemChecked(i));
                    }
                }                
            }
        }

        private void SetCheckList()
        {
            CheckListPcs(true);
        }

        private void GetCheckList()
        {
            CheckListPcs(false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           
            if (this.radioButton1.Checked)
            {
                GetCheckList();
                cic.StartWrite();
            }

            if (this.radioButton2.Checked)
            {
                try
                {
                    cic.SelectPort(int.Parse(this.textBox1.Text.Trim()), int.Parse(this.textBox2.Text.Trim()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            this.toolStripStatusLabel1.Text = "正在发送，等待接收...";
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            cbb.Items.Clear();
            cbb.Items.AddRange(SerialPort.GetPortNames());
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox clb = sender as CheckedListBox;
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (i != clb.SelectedIndex && clb.GetItemChecked(clb.SelectedIndex))
                    clb.SetItemChecked(i, false);
            }
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox clb = sender as CheckedListBox;
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (i != clb.SelectedIndex && clb.GetItemChecked(clb.SelectedIndex))
                    clb.SetItemChecked(i, false);
            }
        }
    }
}
