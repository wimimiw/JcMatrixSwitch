using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace JcMatrixSwitchConfig
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> __boxIp = new Dictionary<string, string>();
        Dictionary<string, string> __switch = new Dictionary<string, string>();
        Dictionary<string, string> __switchIdx = new Dictionary<string, string>();
        Dictionary<string, string> __chanTx1 = new Dictionary<string,string>();
        Dictionary<string, string> __chanTx2 = new Dictionary<string, string>();
        Dictionary<string, string> __chanPim = new Dictionary<string, string>();
        Dictionary<string, string> __chanDet = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btAddBox_Click(object sender, EventArgs e)
        {
            if (this.tbBoxName.Text != "" && this.tbBoxIP.Text != "")
            {
                if(this.__boxIp.ContainsKey(this.tbBoxName.Text))
                {
                    MessageBox.Show("条目已存在!");
                    return;
                }

                this.listBoxlist.Items.Add(this.tbBoxName.Text + " = " + this.tbBoxIP.Text);
                ///////////////////////////////////////////////////////////////////////
                try
                {
                    this.__boxIp.Add(this.tbBoxName.Text, this.tbBoxIP.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show(this, "模块名称或者模块IP地址不为空!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listBoxlist.SelectedIndex >= 0)
            {
                string key = this.listBoxlist.SelectedItem.ToString().Split('=')[0].Trim();
                this.tbBoxName.Text = key;
                this.tbBoxIP.Text = this.__boxIp[key]; 
                this.__boxIp.Remove(key);
                this.listBoxlist.Items.RemoveAt(this.listBoxlist.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.tbSwitchName.Text != "")
            {
                if (this.__switch.ContainsKey(this.tbSwitchName.Text))
                {
                    MessageBox.Show("条目已存在!");
                    return;
                }

                this.listBoxSwitch.Items.Add(this.tbSwitchName.Text + ":" + this.numSwtchNum.Value.ToString("F0"));
                /////////////////////////////////////////////////////////////////////////////////
                try
                {
                    this.__switch.Add(this.tbSwitchName.Text, this.numSwtchNum.Value.ToString("F0"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }
            else
            {
                MessageBox.Show(this, "开关名称不为空!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.listBoxSwitch.SelectedIndex >= 0)
            {
                string key = this.listBoxSwitch.SelectedItem.ToString().Split(':')[0].Trim();
                this.tbSwitchName.Text = key;
                this.numSwtchNum.Value = Decimal.Parse(this.__switch[key].Replace("PORT",""));
                this.__switch.Remove(key);
                this.listBoxSwitch.Items.RemoveAt(this.listBoxSwitch.SelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listBoxlist.SelectedIndex>=0  && this.listBoxSwitch.SelectedIndex>=0)
            {
                try
                {
                    //string swName = this.__switch.Keys.ToArray()[this.listBoxSwitch.SelectedIndex];
                    string port = "PORT"+(int)this.numSwitchIdx.Value;
                    //int portNum = int.Parse(this.__switch[swName].Replace("PORT",""));

                    //if (portNum < (int)this.numSwitchIdx.Value)
                    //{
                    //    MessageBox.Show(this, "开关序号超过限定值", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    this.listBoxChan.Items.Add(
                        ((string)(this.listBoxSwitch.SelectedItem)).Split(':')[0] + "(" +
                        ((string)(this.listBoxlist.SelectedItem)).Split('=')[0] + "," +
                        port + " )");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(this, "请选择模块,开关,开关序号!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void Save2File(string path)
        {
            File.Delete(path);

            inifile.SetPath(path);
            string nameList = "";

            foreach (var item in this.__boxIp)
            {
                nameList += (nameList == ""?"":",")+item.Key.ToString();
                inifile.Write("ip", item.Key, item.Value);
            }

            inifile.Write("ip","namelist",nameList);

            nameList = "";
            foreach (var item in this.__switch)
            {
                nameList += (nameList == "" ? "" : ",") + item.Key.ToString();
                inifile.Write("switch", item.Key, item.Value);
            }
            inifile.Write("switch", "namelist", nameList);

            foreach (var item in this.__switch)
            {
                string temp = "";

                for (int i = 1; i <= int.Parse(item.Value.Replace("PORT","")); i++)
                {
                    temp += (temp == ""?"":",")+"PORT"+i;
                }

                inifile.Write("switch", item.Key, temp);
            }

            nameList = "";
            foreach (var item in this.__chanTx1)
            {
                nameList += (nameList == "" ? "" : ",") + item.Key.ToString();
                inifile.Write("actiontx1", item.Key, item.Value);
            }
            inifile.Write("actiontx1", "namelist", nameList);

            nameList = "";
            foreach (var item in this.__chanTx2)
            {
                nameList += (nameList == "" ? "" : ",") + item.Key.ToString();
                inifile.Write("actiontx2", item.Key, item.Value);
            }
            inifile.Write("actiontx2", "namelist", nameList);

            nameList = "";
            foreach (var item in this.__chanPim)
            {
                nameList += (nameList == "" ? "" : ",") + item.Key.ToString();
                inifile.Write("actionpim", item.Key, item.Value);
            }
            inifile.Write("actionpim", "namelist", nameList);

            nameList = "";
            foreach (var item in this.__chanDet)
            {
                nameList += (nameList == "" ? "" : ",") + item.Key.ToString();
                inifile.Write("actiondet", item.Key, item.Value);
            }
            inifile.Write("actiondet", "namelist", nameList);
        }

        void ReadFile(string path)
        {
            inifile.SetPath(path);
            string nameList = "";

            nameList = inifile.Read("ip", "namelist", "");
            this.listBoxlist.Items.Clear();
            foreach (var item in nameList.Split(','))
            {
                string str = inifile.Read("ip", item, "");
                this.__boxIp.Add(item,str);
                this.listBoxlist.Items.Add(item + " = " + str);
            }

            nameList = inifile.Read("switch", "namelist", "");
            this.listBoxSwitch.Items.Clear();
            foreach (var item in nameList.Split(','))
            {
                int count = inifile.Read("switch", item, "").Split(',').Length;
                this.__switch.Add(item,count.ToString());
                this.listBoxSwitch.Items.Add(item + ":" + count);
            }

            this.cbbChan.Text = "TX1";
            nameList = inifile.Read("actiontx1", "namelist", "");
            this.listBoxGive.Items.Clear();
            foreach (var item in nameList.Split(','))
            {
                string str = inifile.Read("actiontx1", item, "");
                this.__chanTx1.Add(item, str);
                this.listBoxGive.Items.Add(item + " = " + str);
            }
            this.listBoxChan.Items.Clear();

            nameList = inifile.Read("actiontx2", "namelist", "");
            foreach (var item in nameList.Split(','))
            {
                string str = inifile.Read("actiontx2", item, "");
                this.__chanTx2.Add(item, str);
            }

            nameList = inifile.Read("actionpim", "namelist", "");
            foreach (var item in nameList.Split(','))
            {
                string str = inifile.Read("actionpim", item, "");
                this.__chanPim.Add(item, str);
            }

            nameList = inifile.Read("actiondet", "namelist", "");
            foreach (var item in nameList.Split(','))
            {
                string str = inifile.Read("actiondet", item, "");
                this.__chanDet.Add(item, str);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.tbItem.Text != "")
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                string str = "";

                foreach (var item in this.listBoxChan.Items)
                {
                    str += item + ",";
                }

                str = str.Substring(0, str.LastIndexOf(','));

                try
                {
                    if (this.cbbChan.SelectedIndex == 0)
                    {
                        if (this.__chanTx1.ContainsKey(this.tbItem.Text))
                        {
                            MessageBox.Show("条目已存在!");
                            return;
                        }
                        this.__chanTx1.Add(this.tbItem.Text, str);
                    }
                    else if (this.cbbChan.SelectedIndex == 1)
                    {
                        if (this.__chanTx2.ContainsKey(this.tbItem.Text))
                        {
                            MessageBox.Show("条目已存在!");
                            return;
                        }
                        this.__chanTx2.Add(this.tbItem.Text, str);
                    }
                    else if (this.cbbChan.SelectedIndex == 2)
                    {
                        if (this.__chanPim.ContainsKey(this.tbItem.Text))
                        {
                            MessageBox.Show("条目已存在!");
                            return;
                        }
                        this.__chanPim.Add(this.tbItem.Text, str);
                    }
                    else if (this.cbbChan.SelectedIndex == 3)
                    {
                        if (this.__chanDet.ContainsKey(this.tbItem.Text))
                        {
                            MessageBox.Show("条目已存在!");
                            return;
                        }
                        this.__chanDet.Add(this.tbItem.Text, str);
                    }

                    this.listBoxGive.Items.Add(this.tbItem.Text + "    =" + str);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
            else
            {
                MessageBox.Show(this, "通道名称或者通道列表不为空!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.listBoxGive.SelectedIndex >= 0)
            {
                string key = this.listBoxGive.SelectedItem.ToString().Split('=')[0].Trim();

                if (this.cbbChan.SelectedIndex == 0)
                {
                    this.__chanTx1.Remove(key);
                }
                else if (this.cbbChan.SelectedIndex == 1)
                {
                    this.__chanTx2.Remove(key);
                }
                else if (this.cbbChan.SelectedIndex == 2)
                {
                    this.__chanPim.Remove(key);
                }
                else if (this.cbbChan.SelectedIndex == 3)
                {
                    this.__chanDet.Remove(key);
                }
                
                string item = (string)this.listBoxGive.SelectedItem;
                string itemKey = item.Split('=')[0];
                string itemValue = item.Split('=')[1];

                this.tbItem.Text = itemKey;
                this.listBoxChan.Items.Clear();
                this.listBoxChan.Items.AddRange(itemValue.Split(','));                

                this.listBoxGive.Items.RemoveAt(this.listBoxGive.SelectedIndex);                
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "配置文件(.ini)|*.ini";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string str = sfd.FileName;
                Save2File(str);
            }            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.listBoxGive.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbbChan.Text = "TX1";

            for (int i = 1; i < 13; i++)
            {
                this.__switchIdx.Add("PORT"+i,i.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.listBoxChan.SelectedIndex >= 0)
            {
                this.listBoxChan.Items.RemoveAt(this.listBoxChan.SelectedIndex);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void cbbChan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBoxGive.Items.Clear();

            if (this.cbbChan.SelectedIndex == 0)
            {
                foreach (var item in this.__chanTx1)
                {
                    this.listBoxGive.Items.Add(item.Key + "="+item.Value);
                }
            }
            else if (this.cbbChan.SelectedIndex == 1)
            {
                foreach (var item in this.__chanTx2)
                {
                    this.listBoxGive.Items.Add(item.Key + "=" + item.Value);
                }
            }
            else if (this.cbbChan.SelectedIndex == 2)
            {
                foreach (var item in this.__chanPim)
                {
                    this.listBoxGive.Items.Add(item.Key + "=" + item.Value);
                }
            }
            else if (this.cbbChan.SelectedIndex == 3)
            {
                foreach (var item in this.__chanDet)
                {
                    this.listBoxGive.Items.Add(item.Key + "=" + item.Value);
                }
            }            
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string str = ofd.FileName;
                ReadFile(str);
            }
        }

        private void listBoxSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string swName = ((string)(this.listBoxSwitch.SelectedItem)).Split(':')[0]; 
            this.numSwitchIdx.Minimum = 1;
            this.numSwitchIdx.Maximum = decimal.Parse(this.__switch[swName].Replace("PORT", ""));
        }

        private void 检查ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCheck fc = new FormCheck();
            fc.ShowDialog();
        }

        private void 生成头文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHeader fc = new FormHeader();
            fc.ShowDialog();
        }

    }
}
