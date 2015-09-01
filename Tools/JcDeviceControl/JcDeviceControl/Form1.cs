using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace JcDeviceControl
{
    public partial class Form1 : Form
    {
        GerenalPlus.Form1 __gerPlus;
        SwitchDemo.Form3 __frmSwitch;
        SwitchDemo.Form4 __frmComposite;
        S21Debug.Form1 __S12Debug;

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

        void LoadActiveForm(Form frm)
        {            
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Controls.Add(frm);
            frm.Parent = this.panel1;

            this.ClientSize = new Size(this.ClientSize.Width + frm.Size.Width - this.panel1.Size.Width,
                                       this.ClientSize.Height + frm.Size.Height - this.panel1.Size.Height);

            foreach (Control item in this.panel1.Controls)
            {
                if(item!=null)item.Visible = false;
            }
            
            frm.Visible = true;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (__frmComposite != null) __frmComposite.Close();
            //if (__frmSwitch != null) __frmSwitch.Close();
            //if (__gerPlus != null) __gerPlus.Close();

            if (e.Node.Name == "Node0")
            {               
                if (__gerPlus == null) __gerPlus = new GerenalPlus.Form1();
                LoadActiveForm(__gerPlus);
            }
            else if (e.Node.Name == "Node1")
            {
                if (__frmSwitch == null) __frmSwitch = new SwitchDemo.Form3();
                LoadActiveForm(__frmSwitch);
            }
            else if (e.Node.Name == "Node2")
            {
                if (__frmComposite == null) __frmComposite = new SwitchDemo.Form4();
                LoadActiveForm(__frmComposite);
            }
            else if (e.Node.Name == "Node3")
            {
                if (__S12Debug == null) __S12Debug = new S21Debug.Form1();
                LoadActiveForm(__S12Debug);        
                //System.Diagnostics.Process proc = new System.Diagnostics.Process();
                //ZNE_100TL_Factory_Config.ZConfig.Run();            
            }
        }
    }
}
