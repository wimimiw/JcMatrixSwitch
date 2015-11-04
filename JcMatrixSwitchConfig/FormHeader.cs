using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JcMatrixSwitchConfig
{
    public partial class FormHeader : Form
    {
        public FormHeader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.ShowDialog();

            this.label3.Text = ofd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.ShowDialog();

            this.label4.Text = ofd.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "头文件(.h)|*.h";
            sfd.FileName = "switch_info_"+this.textBox1.Text+".h";

            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)return;

            StreamReader rdSwitch = File.OpenText(this.label3.Text);
            StreamReader rdMatrix = File.OpenText(this.label4.Text);
            FileStream fs = File.Create(sfd.FileName);
            StreamWriter wdHeader = new StreamWriter(fs);

            wdHeader.WriteLine("/*******************************Copyright (c)***********************************");
            wdHeader.WriteLine("*");
            wdHeader.WriteLine("*              Copyright (C), 1999-2015, Jointcom . Co., Ltd.");
            wdHeader.WriteLine("*");
            wdHeader.WriteLine("*------------------------------------------------------------------------------");
            wdHeader.WriteLine("* @file	:");
            wdHeader.WriteLine("* @author	:mashuai");
            wdHeader.WriteLine("* @version	:v2.0");
            wdHeader.WriteLine("* @date		:2015.3.1");
            wdHeader.WriteLine("* @brief	:");
            wdHeader.WriteLine("*------------------------------------------------------------------------------*/");

            wdHeader.WriteLine("#ifndef __SWITCH_CONFIG_" + this.textBox1.Text.ToUpper() + "_H__");
            wdHeader.WriteLine("#define __SWITCH_CONFIG_" + this.textBox1.Text.ToUpper() + "_H__");

            wdHeader.Write("#define IO_STRING_" + this.textBox1.Text.ToUpper() + "      ");

            while (!rdSwitch.EndOfStream)
            {
                wdHeader.WriteLine("\"" + rdSwitch.ReadLine().Trim() + "\\n\"\\");
            }

            wdHeader.WriteLine();

            wdHeader.Write("#define IMPLEMENT_STRING_" + this.textBox1.Text.ToUpper() + "      ");

            while (!rdMatrix.EndOfStream)
            {
                wdHeader.WriteLine("\"" + rdMatrix.ReadLine().Trim() + "\\n\"\\");
            }

            wdHeader.WriteLine("");

            wdHeader.WriteLine("#endif");

            wdHeader.Close();
            fs.Close();
            rdSwitch.Close();
            rdMatrix.Close();

            MessageBox.Show("完成！");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件(.txt)|*.txt";
            sfd.FileName = "table.txt";

            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            inifile.SetPath(label4.Text);

            FileStream fs = File.Create(sfd.FileName);
            StreamWriter wdHeader = new StreamWriter(fs);

            string[] sectionList = new string[] { "ip", "switch", "actiontx1", "actiontx2", "actionpim", "actiondet" };

            foreach (var item1 in sectionList)
            {
                string[] section = inifile.Read(item1,"namelist","").Split(',');

                foreach (var item2 in section)
                {
                    wdHeader.WriteLine(item2);
                }

                wdHeader.WriteLine();                
            }

            wdHeader.Close();
            fs.Close();
        }
    }
}
