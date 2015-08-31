using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JcDeviceControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JcMcuUpgrade.Form1 jmu = new JcMcuUpgrade.Form1();
            jmu.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void 操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchDemo.FormMain fm = new SwitchDemo.FormMain();
            fm.ShowDialog();
        }

        private void 脉冲ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenalPlus.Form1 gp = new GerenalPlus.Form1();
            gp.ShowDialog();
        }

        private void 配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
