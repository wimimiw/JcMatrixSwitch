using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMatrixSwitchConfig
{
    public partial class FormCheck : Form
    {
        public FormCheck()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.label2.Text = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int errCnt = 0;

            string str = this.label2.Text;

            inifile.SetPath(str);

            string nameList;

            string[] sectionList = new string[] { "ip", "switch", "actiontx1", "actiontx2", "actionpim", "actiondet" };

            foreach (var item in sectionList)
            {
                nameList = "";

                foreach (var item2 in inifile.ReadSectionAllKey(item))
                {
                    if (item2 == "namelist") continue;

                    int temp;
                    if(int.TryParse(inifile.Read(item, item2, ""),out temp))continue;

                    nameList += (nameList == "" ? "" : ",") + item2;
                }

                inifile.Write(item, "namelist", nameList);

                this.listBox1.Items.Add("==>"+item+" generator namelist!");
            }
            
            //////////////////////////////////////////////////////////////

            string[] switchList = inifile.ReadSectionAllKey("switch");

            foreach (var item in switchList)
            {
                if (item == "namelist") continue;

                string[] temp = inifile.Read("switch", item, "").Split(',');

                int inttt;
                if (temp.Length > 0 && int.TryParse(temp[0], out inttt)) continue;

                for (int i = 1; i <= temp.Length; i++)
                {
                    inifile.Write("switch", temp[i - 1], i.ToString());
                }

                this.listBox1.Items.Add("==>switch " + item + " generator pin!");
            }

            ////////////////////检查//////////////////////////////////////////

            string[] actionList = new string[] { "actiontx1", "actiontx2", "actionpim", "actiondet" };

            foreach (var item in actionList)
            {
                string[] itemList = inifile.ReadSectionAllKey(item);

                foreach (var item2 in itemList)
                {
                    if (item2 == "namelist") continue;

                    string[] switchRow = inifile.Read(item, item2, "").Split(')');

                    foreach (var item3 in switchRow)
                    {
                        if (item3 == "") continue;

                        string switchName = item3.Split('(')[0].Replace(",", "");
                        string switchPin = item3.Substring(item3.LastIndexOf(',')).Replace(",", "");
                        string[] switchTab = switchList;
                        bool isExist = false;

                        for (int i = 0; i < switchTab.Length; i++)
                        {
                            if (switchTab[i].Trim() == switchName.Trim()) isExist = true;
                        }

                        if (!isExist)
                        {
                            errCnt++;
                            MessageBox.Show(item + "  " + item2 + " " + item3 + " " + switchName + " 不存在！");
                            continue;
                        }

                        if (!inifile.Read("switch", switchName, "").Contains(switchPin))
                        {
                            errCnt++;
                            MessageBox.Show(item + "  " + item2 + " " + item3 + " " + switchPin + " 不存在！");
                        }
                    }

                }
            }

            this.listBox1.Items.Add("==>处理完成！  ErrorCnt = " + errCnt);            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }
    }
}
