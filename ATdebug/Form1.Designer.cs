
namespace ATdebug
{
    partial class ATcontrol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbSelectCOM = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbSelectBaud = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDataIn = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbConnectStatus = new System.Windows.Forms.PictureBox();
            this.btnCWJAP = new System.Windows.Forms.Button();
            this.tbSSID = new System.Windows.Forms.TextBox();
            this.tbPasswd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDebug = new System.Windows.Forms.TextBox();
            this.tbManuel = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbATcommand = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.tbPing = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbWeb = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbBitcoin = new System.Windows.Forms.TextBox();
            this.labelBitcoin = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnectStatus)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSelectCOM
            // 
            this.cbSelectCOM.FormattingEnabled = true;
            this.cbSelectCOM.Location = new System.Drawing.Point(44, 53);
            this.cbSelectCOM.Name = "cbSelectCOM";
            this.cbSelectCOM.Size = new System.Drawing.Size(121, 21);
            this.cbSelectCOM.TabIndex = 0;
            this.cbSelectCOM.SelectedIndexChanged += new System.EventHandler(this.cbSelectCOM_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(90, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(533, 240);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbSelectBaud
            // 
            this.cbSelectBaud.FormattingEnabled = true;
            this.cbSelectBaud.Location = new System.Drawing.Point(44, 86);
            this.cbSelectBaud.Name = "cbSelectBaud";
            this.cbSelectBaud.Size = new System.Drawing.Size(121, 21);
            this.cbSelectBaud.TabIndex = 3;
            this.cbSelectBaud.SelectedIndexChanged += new System.EventHandler(this.cbSelectBaud_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud:";
            // 
            // tbDataIn
            // 
            this.tbDataIn.Location = new System.Drawing.Point(307, 12);
            this.tbDataIn.Multiline = true;
            this.tbDataIn.Name = "tbDataIn";
            this.tbDataIn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDataIn.Size = new System.Drawing.Size(301, 216);
            this.tbDataIn.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbConnectStatus);
            this.groupBox1.Controls.Add(this.cbSelectCOM);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbSelectBaud);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 113);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port:";
            // 
            // pbConnectStatus
            // 
            this.pbConnectStatus.Location = new System.Drawing.Point(44, 17);
            this.pbConnectStatus.Name = "pbConnectStatus";
            this.pbConnectStatus.Size = new System.Drawing.Size(35, 23);
            this.pbConnectStatus.TabIndex = 6;
            this.pbConnectStatus.TabStop = false;
            // 
            // btnCWJAP
            // 
            this.btnCWJAP.Enabled = false;
            this.btnCWJAP.Location = new System.Drawing.Point(23, 98);
            this.btnCWJAP.Name = "btnCWJAP";
            this.btnCWJAP.Size = new System.Drawing.Size(82, 23);
            this.btnCWJAP.TabIndex = 11;
            this.btnCWJAP.Text = "CWJAP";
            this.btnCWJAP.UseVisualStyleBackColor = true;
            this.btnCWJAP.Click += new System.EventHandler(this.btnCWJAP_Click);
            // 
            // tbSSID
            // 
            this.tbSSID.Location = new System.Drawing.Point(12, 30);
            this.tbSSID.Name = "tbSSID";
            this.tbSSID.Size = new System.Drawing.Size(93, 20);
            this.tbSSID.TabIndex = 12;
            this.tbSSID.TextChanged += new System.EventHandler(this.tbSSID_TextChanged);
            // 
            // tbPasswd
            // 
            this.tbPasswd.Location = new System.Drawing.Point(12, 72);
            this.tbPasswd.Name = "tbPasswd";
            this.tbPasswd.Size = new System.Drawing.Size(93, 20);
            this.tbPasswd.TabIndex = 13;
            this.tbPasswd.UseSystemPasswordChar = true;
            this.tbPasswd.TextChanged += new System.EventHandler(this.tbPasswd_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "SSID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Pwd:";
            // 
            // tbDebug
            // 
            this.tbDebug.Location = new System.Drawing.Point(364, 240);
            this.tbDebug.Name = "tbDebug";
            this.tbDebug.Size = new System.Drawing.Size(83, 20);
            this.tbDebug.TabIndex = 15;
            // 
            // tbManuel
            // 
            this.tbManuel.Location = new System.Drawing.Point(141, 196);
            this.tbManuel.Name = "tbManuel";
            this.tbManuel.Size = new System.Drawing.Size(160, 20);
            this.tbManuel.TabIndex = 16;
            this.tbManuel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbManuel_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(453, 240);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbATcommand
            // 
            this.cbATcommand.FormattingEnabled = true;
            this.cbATcommand.Location = new System.Drawing.Point(141, 152);
            this.cbATcommand.Name = "cbATcommand";
            this.cbATcommand.Size = new System.Drawing.Size(160, 21);
            this.cbATcommand.TabIndex = 19;
            this.cbATcommand.SelectedIndexChanged += new System.EventHandler(this.cbATcommand_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(141, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Select AT Command:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSSID);
            this.groupBox2.Controls.Add(this.tbPasswd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnCWJAP);
            this.groupBox2.Location = new System.Drawing.Point(16, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 126);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WiFi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Manual Command:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(199, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Lookup Host:";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(199, 32);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(93, 20);
            this.tbHost.TabIndex = 23;
            this.tbHost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbHost_KeyDown);
            // 
            // tbPing
            // 
            this.tbPing.Location = new System.Drawing.Point(199, 79);
            this.tbPing.Name = "tbPing";
            this.tbPing.Size = new System.Drawing.Size(93, 20);
            this.tbPing.TabIndex = 25;
            this.tbPing.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPing_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(199, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Ping Host:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(153, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Get Web-page:";
            // 
            // tbWeb
            // 
            this.tbWeb.Location = new System.Drawing.Point(141, 239);
            this.tbWeb.Name = "tbWeb";
            this.tbWeb.Size = new System.Drawing.Size(217, 20);
            this.tbWeb.TabIndex = 27;
            this.tbWeb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWeb_KeyDown);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(207, 105);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "bitcoin test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "ATcommand ver. 1.2 @ralm/2021";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbBitcoin
            // 
            this.tbBitcoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBitcoin.Location = new System.Drawing.Point(346, 107);
            this.tbBitcoin.Name = "tbBitcoin";
            this.tbBitcoin.Size = new System.Drawing.Size(220, 35);
            this.tbBitcoin.TabIndex = 30;
            this.tbBitcoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbBitcoin.Visible = false;
            // 
            // labelBitcoin
            // 
            this.labelBitcoin.AutoSize = true;
            this.labelBitcoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBitcoin.Location = new System.Drawing.Point(321, 79);
            this.labelBitcoin.Name = "labelBitcoin";
            this.labelBitcoin.Size = new System.Drawing.Size(245, 29);
            this.labelBitcoin.TabIndex = 31;
            this.labelBitcoin.Text = "Current Bitcoin rate:";
            this.labelBitcoin.Visible = false;
            // 
            // ATcontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 285);
            this.Controls.Add(this.labelBitcoin);
            this.Controls.Add(this.tbBitcoin);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbWeb);
            this.Controls.Add(this.tbPing);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbATcommand);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbManuel);
            this.Controls.Add(this.tbDebug);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbDataIn);
            this.Controls.Add(this.btnExit);
            this.Name = "ATcontrol";
            this.Text = "ATcommand";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnectStatus)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSelectCOM;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbSelectBaud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDataIn;
        private System.Windows.Forms.GroupBox groupBox1;
        // private System.IO.Ports.SerialPort _serialPort;
        private System.Windows.Forms.Button btnCWJAP;
        private System.Windows.Forms.TextBox tbSSID;
        private System.Windows.Forms.TextBox tbPasswd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDebug;
        private System.Windows.Forms.TextBox tbManuel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cbATcommand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.TextBox tbPing;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbWeb;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pbConnectStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbBitcoin;
        private System.Windows.Forms.Label labelBitcoin;
    }
}

