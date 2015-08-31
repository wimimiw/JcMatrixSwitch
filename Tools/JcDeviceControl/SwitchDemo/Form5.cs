using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SwitchDemo
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //textBox1.Text =
            //">>====================使用说明============================>>\n" +
            //">>ZNE-100TL的默认IP地址为:192.168.0.178\n" +
            //">>如果忘记配置过的IP地址，请重置ZNE-100TL，还原默认IP地址\n" +
            //">>重置方法：\n" +
            //">>          1、断电后将ZNE-100TL上的(PA4)上通孔用镊子短接。\n" +
            //">>          2、上电后保持短接状5秒，然后撤去短接，断开复位即可。\n" +
            //">>本模块固定掩码为：255.255.255.0\n" +
            //">>注意：请确保本地连接与ZNE-100TL在同一网段\n" +
            //">>========================================================>>";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
            Close();            
        }
    }
}
