namespace S21Debug
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbPower = new System.Windows.Forms.ComboBox();
            this.tbFreq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDebug = new System.Windows.Forms.CheckBox();
            this.cbOutp = new System.Windows.Forms.CheckBox();
            this.rbrx = new System.Windows.Forms.RadioButton();
            this.rbtx = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbVersion = new System.Windows.Forms.CheckBox();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.cbOffTimer = new System.Windows.Forms.CheckBox();
            this.tbOffTimer = new System.Windows.Forms.TextBox();
            this.cbSn = new System.Windows.Forms.CheckBox();
            this.tbSn = new System.Windows.Forms.TextBox();
            this.tbDetecH = new System.Windows.Forms.TextBox();
            this.cbDetecH = new System.Windows.Forms.CheckBox();
            this.cbDetecL = new System.Windows.Forms.CheckBox();
            this.tbDetecL = new System.Windows.Forms.TextBox();
            this.tbOpwr = new System.Windows.Forms.TextBox();
            this.cbOpwr = new System.Windows.Forms.CheckBox();
            this.tbDuring = new System.Windows.Forms.TextBox();
            this.cbDuting = new System.Windows.Forms.CheckBox();
            this.cbAddr = new System.Windows.Forms.CheckBox();
            this.cbFreq = new System.Windows.Forms.CheckBox();
            this.cbPwr = new System.Windows.Forms.CheckBox();
            this.cbAtt = new System.Windows.Forms.CheckBox();
            this.tbAtt = new System.Windows.Forms.TextBox();
            this.btCom = new System.Windows.Forms.Button();
            this.cbBetween = new System.Windows.Forms.CheckBox();
            this.cbFloat = new System.Windows.Forms.CheckBox();
            this.tbBetween = new System.Windows.Forms.TextBox();
            this.tbFloat = new System.Windows.Forms.TextBox();
            this.tbAddr = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btPaOpen = new System.Windows.Forms.Button();
            this.cbbPACom = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRPower = new System.Windows.Forms.TextBox();
            this.tbRFreq = new System.Windows.Forms.TextBox();
            this.tbRAddr = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.tbMoniter = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbEnable = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbLiner = new System.Windows.Forms.RadioButton();
            this.rbLog = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbPAFreq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPAPower = new System.Windows.Forms.TextBox();
            this.cbWuMa = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lbTimeSum = new System.Windows.Forms.Label();
            this.lbTimeSingle = new System.Windows.Forms.Label();
            this.lbCntLost = new System.Windows.Forms.Label();
            this.lbCntTx = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudOffset
            // 
            resources.ApplyResources(this.nudOffset, "nudOffset");
            this.nudOffset.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.ValueChanged += new System.EventHandler(this.nudOffset_ValueChanged);
            this.nudOffset.Click += new System.EventHandler(this.nudOffset_Click);
            this.nudOffset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numericUpDown1_MouseClick);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 38400;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // cbPower
            // 
            this.cbPower.FormattingEnabled = true;
            this.cbPower.Items.AddRange(new object[] {
            resources.GetString("cbPower.Items"),
            resources.GetString("cbPower.Items1"),
            resources.GetString("cbPower.Items2"),
            resources.GetString("cbPower.Items3")});
            resources.ApplyResources(this.cbPower, "cbPower");
            this.cbPower.Name = "cbPower";
            // 
            // tbFreq
            // 
            resources.ApplyResources(this.tbFreq, "tbFreq");
            this.tbFreq.Name = "tbFreq";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDebug);
            this.groupBox1.Controls.Add(this.cbOutp);
            this.groupBox1.Controls.Add(this.rbrx);
            this.groupBox1.Controls.Add(this.rbtx);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cbDebug
            // 
            resources.ApplyResources(this.cbDebug, "cbDebug");
            this.cbDebug.Name = "cbDebug";
            this.cbDebug.UseVisualStyleBackColor = true;
            this.cbDebug.Click += new System.EventHandler(this.cbDebug_Click);
            // 
            // cbOutp
            // 
            resources.ApplyResources(this.cbOutp, "cbOutp");
            this.cbOutp.Name = "cbOutp";
            this.cbOutp.UseVisualStyleBackColor = true;
            this.cbOutp.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // rbrx
            // 
            resources.ApplyResources(this.rbrx, "rbrx");
            this.rbrx.Name = "rbrx";
            this.rbrx.UseVisualStyleBackColor = true;
            this.rbrx.Click += new System.EventHandler(this.rbrx_Click);
            // 
            // rbtx
            // 
            resources.ApplyResources(this.rbtx, "rbtx");
            this.rbtx.Checked = true;
            this.rbtx.Name = "rbtx";
            this.rbtx.TabStop = true;
            this.rbtx.UseVisualStyleBackColor = true;
            this.rbtx.Click += new System.EventHandler(this.rbtx_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbVersion);
            this.groupBox2.Controls.Add(this.tbVersion);
            this.groupBox2.Controls.Add(this.cbOffTimer);
            this.groupBox2.Controls.Add(this.tbOffTimer);
            this.groupBox2.Controls.Add(this.cbSn);
            this.groupBox2.Controls.Add(this.tbSn);
            this.groupBox2.Controls.Add(this.tbDetecH);
            this.groupBox2.Controls.Add(this.cbDetecH);
            this.groupBox2.Controls.Add(this.cbDetecL);
            this.groupBox2.Controls.Add(this.tbDetecL);
            this.groupBox2.Controls.Add(this.tbOpwr);
            this.groupBox2.Controls.Add(this.cbOpwr);
            this.groupBox2.Controls.Add(this.tbDuring);
            this.groupBox2.Controls.Add(this.cbDuting);
            this.groupBox2.Controls.Add(this.cbAddr);
            this.groupBox2.Controls.Add(this.cbFreq);
            this.groupBox2.Controls.Add(this.nudOffset);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.cbPwr);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbAtt);
            this.groupBox2.Controls.Add(this.tbAtt);
            this.groupBox2.Controls.Add(this.btCom);
            this.groupBox2.Controls.Add(this.tbFreq);
            this.groupBox2.Controls.Add(this.cbBetween);
            this.groupBox2.Controls.Add(this.cbFloat);
            this.groupBox2.Controls.Add(this.tbBetween);
            this.groupBox2.Controls.Add(this.cbPower);
            this.groupBox2.Controls.Add(this.tbFloat);
            this.groupBox2.Controls.Add(this.tbAddr);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // cbVersion
            // 
            resources.ApplyResources(this.cbVersion, "cbVersion");
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.UseVisualStyleBackColor = true;
            // 
            // tbVersion
            // 
            resources.ApplyResources(this.tbVersion, "tbVersion");
            this.tbVersion.Name = "tbVersion";
            // 
            // cbOffTimer
            // 
            resources.ApplyResources(this.cbOffTimer, "cbOffTimer");
            this.cbOffTimer.Name = "cbOffTimer";
            this.cbOffTimer.UseVisualStyleBackColor = true;
            // 
            // tbOffTimer
            // 
            resources.ApplyResources(this.tbOffTimer, "tbOffTimer");
            this.tbOffTimer.Name = "tbOffTimer";
            // 
            // cbSn
            // 
            resources.ApplyResources(this.cbSn, "cbSn");
            this.cbSn.Name = "cbSn";
            this.cbSn.UseVisualStyleBackColor = true;
            // 
            // tbSn
            // 
            resources.ApplyResources(this.tbSn, "tbSn");
            this.tbSn.Name = "tbSn";
            // 
            // tbDetecH
            // 
            resources.ApplyResources(this.tbDetecH, "tbDetecH");
            this.tbDetecH.Name = "tbDetecH";
            // 
            // cbDetecH
            // 
            resources.ApplyResources(this.cbDetecH, "cbDetecH");
            this.cbDetecH.Name = "cbDetecH";
            this.cbDetecH.UseVisualStyleBackColor = true;
            // 
            // cbDetecL
            // 
            resources.ApplyResources(this.cbDetecL, "cbDetecL");
            this.cbDetecL.Name = "cbDetecL";
            this.cbDetecL.UseVisualStyleBackColor = true;
            // 
            // tbDetecL
            // 
            resources.ApplyResources(this.tbDetecL, "tbDetecL");
            this.tbDetecL.Name = "tbDetecL";
            // 
            // tbOpwr
            // 
            resources.ApplyResources(this.tbOpwr, "tbOpwr");
            this.tbOpwr.Name = "tbOpwr";
            // 
            // cbOpwr
            // 
            resources.ApplyResources(this.cbOpwr, "cbOpwr");
            this.cbOpwr.Name = "cbOpwr";
            this.cbOpwr.UseVisualStyleBackColor = true;
            // 
            // tbDuring
            // 
            resources.ApplyResources(this.tbDuring, "tbDuring");
            this.tbDuring.Name = "tbDuring";
            // 
            // cbDuting
            // 
            resources.ApplyResources(this.cbDuting, "cbDuting");
            this.cbDuting.Name = "cbDuting";
            this.cbDuting.UseVisualStyleBackColor = true;
            // 
            // cbAddr
            // 
            resources.ApplyResources(this.cbAddr, "cbAddr");
            this.cbAddr.Name = "cbAddr";
            this.cbAddr.UseVisualStyleBackColor = true;
            // 
            // cbFreq
            // 
            resources.ApplyResources(this.cbFreq, "cbFreq");
            this.cbFreq.Name = "cbFreq";
            this.cbFreq.UseVisualStyleBackColor = true;
            // 
            // cbPwr
            // 
            resources.ApplyResources(this.cbPwr, "cbPwr");
            this.cbPwr.Name = "cbPwr";
            this.cbPwr.UseVisualStyleBackColor = true;
            // 
            // cbAtt
            // 
            resources.ApplyResources(this.cbAtt, "cbAtt");
            this.cbAtt.Name = "cbAtt";
            this.cbAtt.UseVisualStyleBackColor = true;
            // 
            // tbAtt
            // 
            resources.ApplyResources(this.tbAtt, "tbAtt");
            this.tbAtt.Name = "tbAtt";
            // 
            // btCom
            // 
            resources.ApplyResources(this.btCom, "btCom");
            this.btCom.Name = "btCom";
            this.btCom.UseVisualStyleBackColor = true;
            this.btCom.Click += new System.EventHandler(this.btCom_Click);
            // 
            // cbBetween
            // 
            resources.ApplyResources(this.cbBetween, "cbBetween");
            this.cbBetween.Name = "cbBetween";
            this.cbBetween.UseVisualStyleBackColor = true;
            // 
            // cbFloat
            // 
            resources.ApplyResources(this.cbFloat, "cbFloat");
            this.cbFloat.Name = "cbFloat";
            this.cbFloat.UseVisualStyleBackColor = true;
            // 
            // tbBetween
            // 
            resources.ApplyResources(this.tbBetween, "tbBetween");
            this.tbBetween.Name = "tbBetween";
            // 
            // tbFloat
            // 
            resources.ApplyResources(this.tbFloat, "tbFloat");
            this.tbFloat.Name = "tbFloat";
            // 
            // tbAddr
            // 
            resources.ApplyResources(this.tbAddr, "tbAddr");
            this.tbAddr.Name = "tbAddr";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btPaOpen);
            this.groupBox3.Controls.Add(this.cbbPACom);
            this.groupBox3.Controls.Add(this.label8);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // btPaOpen
            // 
            resources.ApplyResources(this.btPaOpen, "btPaOpen");
            this.btPaOpen.Name = "btPaOpen";
            this.btPaOpen.UseVisualStyleBackColor = true;
            this.btPaOpen.Click += new System.EventHandler(this.btPaOpen_Click);
            // 
            // cbbPACom
            // 
            this.cbbPACom.FormattingEnabled = true;
            resources.ApplyResources(this.cbbPACom, "cbbPACom");
            this.cbbPACom.Name = "cbbPACom";
            this.cbbPACom.Click += new System.EventHandler(this.comboBox2_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // tbRPower
            // 
            resources.ApplyResources(this.tbRPower, "tbRPower");
            this.tbRPower.Name = "tbRPower";
            // 
            // tbRFreq
            // 
            resources.ApplyResources(this.tbRFreq, "tbRFreq");
            this.tbRFreq.Name = "tbRFreq";
            // 
            // tbRAddr
            // 
            resources.ApplyResources(this.tbRAddr, "tbRAddr");
            this.tbRAddr.Name = "tbRAddr";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Checked = true;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbMoniter
            // 
            resources.ApplyResources(this.tbMoniter, "tbMoniter");
            this.tbMoniter.Name = "tbMoniter";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbEnable);
            this.groupBox4.Controls.Add(this.tbMoniter);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // cbEnable
            // 
            resources.ApplyResources(this.cbEnable, "cbEnable");
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbLiner);
            this.groupBox5.Controls.Add(this.rbLog);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // rbLiner
            // 
            resources.ApplyResources(this.rbLiner, "rbLiner");
            this.rbLiner.Checked = true;
            this.rbLiner.Name = "rbLiner";
            this.rbLiner.TabStop = true;
            this.rbLiner.UseVisualStyleBackColor = true;
            // 
            // rbLog
            // 
            resources.ApplyResources(this.rbLog, "rbLog");
            this.rbLog.Name = "rbLog";
            this.rbLog.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButton2);
            this.groupBox6.Controls.Add(this.radioButton1);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbPAFreq);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.tbPAPower);
            this.groupBox7.Controls.Add(this.tbRFreq);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.tbRPower);
            this.groupBox7.Controls.Add(this.tbRAddr);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // tbPAFreq
            // 
            resources.ApplyResources(this.tbPAFreq, "tbPAFreq");
            this.tbPAFreq.Name = "tbPAFreq";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tbPAPower
            // 
            resources.ApplyResources(this.tbPAPower, "tbPAPower");
            this.tbPAPower.Name = "tbPAPower";
            // 
            // cbWuMa
            // 
            resources.ApplyResources(this.cbWuMa, "cbWuMa");
            this.cbWuMa.Name = "cbWuMa";
            this.cbWuMa.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Name = "label7";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lbTimeSum);
            this.groupBox8.Controls.Add(this.lbTimeSingle);
            this.groupBox8.Controls.Add(this.lbCntLost);
            this.groupBox8.Controls.Add(this.lbCntTx);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.label5);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // lbTimeSum
            // 
            resources.ApplyResources(this.lbTimeSum, "lbTimeSum");
            this.lbTimeSum.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTimeSum.Name = "lbTimeSum";
            // 
            // lbTimeSingle
            // 
            resources.ApplyResources(this.lbTimeSingle, "lbTimeSingle");
            this.lbTimeSingle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTimeSingle.Name = "lbTimeSingle";
            // 
            // lbCntLost
            // 
            resources.ApplyResources(this.lbCntLost, "lbCntLost");
            this.lbCntLost.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCntLost.Name = "lbCntLost";
            // 
            // lbCntTx
            // 
            resources.ApplyResources(this.lbCntTx, "lbCntTx");
            this.lbCntTx.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCntTx.Name = "lbCntTx";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Name = "label12";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.cbWuMa);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox6);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudOffset;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cbPower;
        private System.Windows.Forms.TextBox tbFreq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbrx;
        private System.Windows.Forms.RadioButton rbtx;
        private System.Windows.Forms.CheckBox cbOutp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbAddr;
        private System.Windows.Forms.CheckBox cbDebug;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbBetween;
        private System.Windows.Forms.TextBox tbFloat;
        private System.Windows.Forms.CheckBox cbBetween;
        private System.Windows.Forms.CheckBox cbFloat;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbPACom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRPower;
        private System.Windows.Forms.TextBox tbRFreq;
        private System.Windows.Forms.TextBox tbRAddr;
        private System.Windows.Forms.TextBox tbMoniter;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbEnable;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button btCom;
        private System.Windows.Forms.CheckBox cbAtt;
        private System.Windows.Forms.TextBox tbAtt;
        private System.Windows.Forms.CheckBox cbFreq;
        private System.Windows.Forms.CheckBox cbPwr;
        private System.Windows.Forms.CheckBox cbAddr;
        private System.Windows.Forms.CheckBox cbDuting;
        private System.Windows.Forms.TextBox tbDuring;
        private System.Windows.Forms.CheckBox cbOpwr;
        private System.Windows.Forms.TextBox tbOpwr;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbLiner;
        private System.Windows.Forms.RadioButton rbLog;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btPaOpen;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox tbPAFreq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPAPower;
        private System.Windows.Forms.TextBox tbDetecH;
        private System.Windows.Forms.CheckBox cbDetecH;
        private System.Windows.Forms.CheckBox cbDetecL;
        private System.Windows.Forms.TextBox tbDetecL;
        private System.Windows.Forms.CheckBox cbWuMa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbTimeSum;
        private System.Windows.Forms.Label lbTimeSingle;
        private System.Windows.Forms.Label lbCntLost;
        private System.Windows.Forms.Label lbCntTx;
        private System.Windows.Forms.CheckBox cbVersion;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.CheckBox cbOffTimer;
        private System.Windows.Forms.TextBox tbOffTimer;
        private System.Windows.Forms.CheckBox cbSn;
        private System.Windows.Forms.TextBox tbSn;
    }
}

