namespace LEDController
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.connect = new System.Windows.Forms.Button();
            this.TargetIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Port_Num = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.messageinput1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sendmes = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.scrollingoption = new System.Windows.Forms.ComboBox();
            this.modeoptions = new System.Windows.Forms.ComboBox();
            this.sendcmd = new System.Windows.Forms.Button();
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.connectionClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainclose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.connectagain = new System.Windows.Forms.Button();
            this.remoteip = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.connstatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.addMessage = new System.Windows.Forms.Button();
            this.setanimation = new System.Windows.Forms.Button();
            this.messageinput2 = new System.Windows.Forms.TextBox();
            this.messageinput3 = new System.Windows.Forms.TextBox();
            this.messageinput4 = new System.Windows.Forms.TextBox();
            this.messageinput5 = new System.Windows.Forms.TextBox();
            this.deletemessage1 = new System.Windows.Forms.Button();
            this.deletemessage2 = new System.Windows.Forms.Button();
            this.deletemessage3 = new System.Windows.Forms.Button();
            this.deletemessage4 = new System.Windows.Forms.Button();
            this.deletemessage5 = new System.Windows.Forms.Button();
            this.animationsetting = new System.Windows.Forms.Panel();
            this.modeoption2 = new System.Windows.Forms.ComboBox();
            this.cmd = new System.Windows.Forms.Button();
            this.connectionPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.animationsetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.connect.FlatAppearance.BorderSize = 0;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.connect.ForeColor = System.Drawing.Color.White;
            this.connect.Location = new System.Drawing.Point(98, 291);
            this.connect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(150, 50);
            this.connect.TabIndex = 0;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = false;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // TargetIp
            // 
            this.TargetIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.TargetIp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TargetIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TargetIp.ForeColor = System.Drawing.Color.Transparent;
            this.TargetIp.Location = new System.Drawing.Point(144, 127);
            this.TargetIp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TargetIp.Multiline = true;
            this.TargetIp.Name = "TargetIp";
            this.TargetIp.Size = new System.Drawing.Size(248, 39);
            this.TargetIp.TabIndex = 1;
            this.TargetIp.Text = "199.99.0.90";
            this.TargetIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(207, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address";
            // 
            // Port_Num
            // 
            this.Port_Num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.Port_Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Port_Num.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Port_Num.ForeColor = System.Drawing.Color.Transparent;
            this.Port_Num.Location = new System.Drawing.Point(144, 220);
            this.Port_Num.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Port_Num.Multiline = true;
            this.Port_Num.Name = "Port_Num";
            this.Port_Num.Size = new System.Drawing.Size(248, 50);
            this.Port_Num.TabIndex = 3;
            this.Port_Num.Text = "789";
            this.Port_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(238, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // messageinput1
            // 
            this.messageinput1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.messageinput1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageinput1.ForeColor = System.Drawing.Color.White;
            this.messageinput1.Location = new System.Drawing.Point(274, 280);
            this.messageinput1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.messageinput1.Multiline = true;
            this.messageinput1.Name = "messageinput1";
            this.messageinput1.Size = new System.Drawing.Size(548, 45);
            this.messageinput1.TabIndex = 5;
            this.messageinput1.Text = "Message 1";
            this.messageinput1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.messageinput1.TextChanged += new System.EventHandler(this.Messageinput1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(488, 241);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Message";
            // 
            // sendmes
            // 
            this.sendmes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.sendmes.FlatAppearance.BorderSize = 0;
            this.sendmes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendmes.ForeColor = System.Drawing.Color.White;
            this.sendmes.Location = new System.Drawing.Point(477, 570);
            this.sendmes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendmes.Name = "sendmes";
            this.sendmes.Size = new System.Drawing.Size(165, 53);
            this.sendmes.TabIndex = 7;
            this.sendmes.Text = "Send";
            this.sendmes.UseVisualStyleBackColor = false;
            this.sendmes.Click += new System.EventHandler(this.Sendmes_Click);
            // 
            // disconnect
            // 
            this.disconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.disconnect.FlatAppearance.BorderSize = 0;
            this.disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.disconnect.ForeColor = System.Drawing.Color.White;
            this.disconnect.Location = new System.Drawing.Point(321, 291);
            this.disconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(146, 50);
            this.disconnect.TabIndex = 8;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = false;
            this.disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // scrollingoption
            // 
            this.scrollingoption.AllowDrop = true;
            this.scrollingoption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.scrollingoption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scrollingoption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scrollingoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scrollingoption.ForeColor = System.Drawing.Color.White;
            this.scrollingoption.FormattingEnabled = true;
            this.scrollingoption.Items.AddRange(new object[] {
            "left_most",
            "right_most",
            "top_most",
            "bottom_most",
            "custom"});
            this.scrollingoption.Location = new System.Drawing.Point(440, 188);
            this.scrollingoption.Name = "scrollingoption";
            this.scrollingoption.Size = new System.Drawing.Size(254, 33);
            this.scrollingoption.TabIndex = 10;
            this.scrollingoption.SelectedIndexChanged += new System.EventHandler(this.Scrollingoption_SelectedIndexChanged);
            // 
            // modeoptions
            // 
            this.modeoptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeoptions.FormattingEnabled = true;
            this.modeoptions.Items.AddRange(new object[] {
            "Default mode",
            "Animation 1",
            "Animation 2",
            "Animation 3",
            "Animation 4",
            "Animation 5",
            "Animation 6",
            "Animation 7",
            "Animation 8",
            "Animation 9",
            "Animation 10"});
            this.modeoptions.Location = new System.Drawing.Point(70, 50);
            this.modeoptions.Name = "modeoptions";
            this.modeoptions.Size = new System.Drawing.Size(230, 33);
            this.modeoptions.TabIndex = 12;
            // 
            // sendcmd
            // 
            this.sendcmd.Location = new System.Drawing.Point(98, 142);
            this.sendcmd.Name = "sendcmd";
            this.sendcmd.Size = new System.Drawing.Size(171, 41);
            this.sendcmd.TabIndex = 14;
            this.sendcmd.Text = "Change mode";
            this.sendcmd.UseVisualStyleBackColor = true;
            this.sendcmd.Click += new System.EventHandler(this.Sendcmd_Click);
            // 
            // connectionPanel
            // 
            this.connectionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.connectionPanel.Controls.Add(this.panel3);
            this.connectionPanel.Controls.Add(this.TargetIp);
            this.connectionPanel.Controls.Add(this.Port_Num);
            this.connectionPanel.Controls.Add(this.label1);
            this.connectionPanel.Controls.Add(this.label2);
            this.connectionPanel.Controls.Add(this.connect);
            this.connectionPanel.Controls.Add(this.disconnect);
            this.connectionPanel.Location = new System.Drawing.Point(274, 120);
            this.connectionPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(536, 353);
            this.connectionPanel.TabIndex = 15;
            this.connectionPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.connectionPanel_MouseMove);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(43)))), ((int)(((byte)(49)))));
            this.panel3.Controls.Add(this.connectionClose);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(536, 64);
            this.panel3.TabIndex = 9;
            // 
            // connectionClose
            // 
            this.connectionClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.connectionClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.connectionClose.FlatAppearance.BorderSize = 0;
            this.connectionClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.connectionClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.connectionClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectionClose.Image = ((System.Drawing.Image)(resources.GetObject("connectionClose.Image")));
            this.connectionClose.Location = new System.Drawing.Point(495, 6);
            this.connectionClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connectionClose.Name = "connectionClose";
            this.connectionClose.Size = new System.Drawing.Size(36, 48);
            this.connectionClose.TabIndex = 10;
            this.connectionClose.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(206, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "Connection";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.panel2.Controls.Add(this.mainclose);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(202, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(716, 116);
            this.panel2.TabIndex = 16;
            // 
            // mainclose
            // 
            this.mainclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mainclose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.mainclose.FlatAppearance.BorderSize = 0;
            this.mainclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.mainclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.mainclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainclose.Image = ((System.Drawing.Image)(resources.GetObject("mainclose.Image")));
            this.mainclose.Location = new System.Drawing.Point(660, 31);
            this.mainclose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainclose.Name = "mainclose";
            this.mainclose.Size = new System.Drawing.Size(36, 36);
            this.mainclose.TabIndex = 11;
            this.mainclose.UseVisualStyleBackColor = true;
            this.mainclose.Click += new System.EventHandler(this.Mainclose_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.modeoptions);
            this.panel4.Controls.Add(this.sendcmd);
            this.panel4.Location = new System.Drawing.Point(0, 120);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(716, 527);
            this.panel4.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.panel1.Controls.Add(this.connectagain);
            this.panel1.Controls.Add(this.remoteip);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.connstatus);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 650);
            this.panel1.TabIndex = 17;
            // 
            // connectagain
            // 
            this.connectagain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.connectagain.FlatAppearance.BorderSize = 0;
            this.connectagain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectagain.ForeColor = System.Drawing.Color.White;
            this.connectagain.Location = new System.Drawing.Point(26, 494);
            this.connectagain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connectagain.Name = "connectagain";
            this.connectagain.Size = new System.Drawing.Size(148, 58);
            this.connectagain.TabIndex = 4;
            this.connectagain.Text = "Recoonect";
            this.connectagain.UseVisualStyleBackColor = false;
            this.connectagain.Click += new System.EventHandler(this.Connectagain_Click);
            // 
            // remoteip
            // 
            this.remoteip.AutoSize = true;
            this.remoteip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remoteip.ForeColor = System.Drawing.Color.White;
            this.remoteip.Location = new System.Drawing.Point(10, 345);
            this.remoteip.Name = "remoteip";
            this.remoteip.Size = new System.Drawing.Size(179, 124);
            this.remoteip.TabIndex = 3;
            this.remoteip.Text = "Connected IP\r\n \r\n      None\r\n\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(20, 586);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 31);
            this.label7.TabIndex = 2;
            this.label7.Text = "v1.01";
            // 
            // connstatus
            // 
            this.connstatus.AutoSize = true;
            this.connstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connstatus.ForeColor = System.Drawing.Color.White;
            this.connstatus.Location = new System.Drawing.Point(10, 198);
            this.connstatus.Name = "connstatus";
            this.connstatus.Size = new System.Drawing.Size(180, 31);
            this.connstatus.TabIndex = 1;
            this.connstatus.Text = "Disconnected";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 46);
            this.label6.TabIndex = 0;
            this.label6.Text = "SU Matrix";
            // 
            // addMessage
            // 
            this.addMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.addMessage.FlatAppearance.BorderSize = 0;
            this.addMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addMessage.ForeColor = System.Drawing.Color.White;
            this.addMessage.Location = new System.Drawing.Point(210, 83);
            this.addMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addMessage.Name = "addMessage";
            this.addMessage.Size = new System.Drawing.Size(350, 75);
            this.addMessage.TabIndex = 1;
            this.addMessage.Text = "Add message";
            this.addMessage.UseVisualStyleBackColor = false;
            this.addMessage.Click += new System.EventHandler(this.AddMessage_Click);
            // 
            // setanimation
            // 
            this.setanimation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.setanimation.FlatAppearance.BorderSize = 0;
            this.setanimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setanimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setanimation.ForeColor = System.Drawing.Color.White;
            this.setanimation.Location = new System.Drawing.Point(566, 94);
            this.setanimation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.setanimation.Name = "setanimation";
            this.setanimation.Size = new System.Drawing.Size(345, 64);
            this.setanimation.TabIndex = 18;
            this.setanimation.Text = "Change Animation";
            this.setanimation.UseVisualStyleBackColor = false;
            this.setanimation.Click += new System.EventHandler(this.setAnimation_Click);
            // 
            // messageinput2
            // 
            this.messageinput2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.messageinput2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageinput2.ForeColor = System.Drawing.Color.White;
            this.messageinput2.Location = new System.Drawing.Point(274, 336);
            this.messageinput2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.messageinput2.Multiline = true;
            this.messageinput2.Name = "messageinput2";
            this.messageinput2.Size = new System.Drawing.Size(548, 45);
            this.messageinput2.TabIndex = 20;
            this.messageinput2.Text = "Message 2";
            this.messageinput2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.messageinput2.TextChanged += new System.EventHandler(this.Messageinput2_TextChanged);
            // 
            // messageinput3
            // 
            this.messageinput3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.messageinput3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageinput3.ForeColor = System.Drawing.Color.White;
            this.messageinput3.Location = new System.Drawing.Point(274, 392);
            this.messageinput3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.messageinput3.Multiline = true;
            this.messageinput3.Name = "messageinput3";
            this.messageinput3.Size = new System.Drawing.Size(548, 45);
            this.messageinput3.TabIndex = 21;
            this.messageinput3.Text = "Message 3";
            this.messageinput3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.messageinput3.TextChanged += new System.EventHandler(this.Messageinput3_TextChanged);
            // 
            // messageinput4
            // 
            this.messageinput4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.messageinput4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageinput4.ForeColor = System.Drawing.Color.White;
            this.messageinput4.Location = new System.Drawing.Point(274, 448);
            this.messageinput4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.messageinput4.Multiline = true;
            this.messageinput4.Name = "messageinput4";
            this.messageinput4.Size = new System.Drawing.Size(548, 45);
            this.messageinput4.TabIndex = 22;
            this.messageinput4.Text = "Message 4";
            this.messageinput4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.messageinput4.TextChanged += new System.EventHandler(this.Messageinput4_TextChanged);
            // 
            // messageinput5
            // 
            this.messageinput5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.messageinput5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageinput5.ForeColor = System.Drawing.Color.White;
            this.messageinput5.Location = new System.Drawing.Point(274, 505);
            this.messageinput5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.messageinput5.Multiline = true;
            this.messageinput5.Name = "messageinput5";
            this.messageinput5.Size = new System.Drawing.Size(548, 45);
            this.messageinput5.TabIndex = 23;
            this.messageinput5.Text = "Message 5";
            this.messageinput5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.messageinput5.TextChanged += new System.EventHandler(this.Messageinput5_TextChanged);
            // 
            // deletemessage1
            // 
            this.deletemessage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deletemessage1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.deletemessage1.FlatAppearance.BorderSize = 0;
            this.deletemessage1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.deletemessage1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.deletemessage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletemessage1.Image = ((System.Drawing.Image)(resources.GetObject("deletemessage1.Image")));
            this.deletemessage1.Location = new System.Drawing.Point(831, 280);
            this.deletemessage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deletemessage1.Name = "deletemessage1";
            this.deletemessage1.Size = new System.Drawing.Size(36, 36);
            this.deletemessage1.TabIndex = 24;
            this.deletemessage1.UseVisualStyleBackColor = true;
            this.deletemessage1.Click += new System.EventHandler(this.Deletemessage1_Click);
            // 
            // deletemessage2
            // 
            this.deletemessage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deletemessage2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.deletemessage2.FlatAppearance.BorderSize = 0;
            this.deletemessage2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.deletemessage2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.deletemessage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletemessage2.Image = ((System.Drawing.Image)(resources.GetObject("deletemessage2.Image")));
            this.deletemessage2.Location = new System.Drawing.Point(831, 336);
            this.deletemessage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deletemessage2.Name = "deletemessage2";
            this.deletemessage2.Size = new System.Drawing.Size(36, 36);
            this.deletemessage2.TabIndex = 25;
            this.deletemessage2.UseVisualStyleBackColor = true;
            this.deletemessage2.Click += new System.EventHandler(this.Deletemessage2_Click);
            // 
            // deletemessage3
            // 
            this.deletemessage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deletemessage3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.deletemessage3.FlatAppearance.BorderSize = 0;
            this.deletemessage3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.deletemessage3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.deletemessage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletemessage3.Image = ((System.Drawing.Image)(resources.GetObject("deletemessage3.Image")));
            this.deletemessage3.Location = new System.Drawing.Point(831, 392);
            this.deletemessage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deletemessage3.Name = "deletemessage3";
            this.deletemessage3.Size = new System.Drawing.Size(36, 36);
            this.deletemessage3.TabIndex = 26;
            this.deletemessage3.UseVisualStyleBackColor = true;
            this.deletemessage3.Click += new System.EventHandler(this.Deletemessage3_Click);
            // 
            // deletemessage4
            // 
            this.deletemessage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deletemessage4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.deletemessage4.FlatAppearance.BorderSize = 0;
            this.deletemessage4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.deletemessage4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.deletemessage4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletemessage4.Image = ((System.Drawing.Image)(resources.GetObject("deletemessage4.Image")));
            this.deletemessage4.Location = new System.Drawing.Point(831, 448);
            this.deletemessage4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deletemessage4.Name = "deletemessage4";
            this.deletemessage4.Size = new System.Drawing.Size(36, 36);
            this.deletemessage4.TabIndex = 27;
            this.deletemessage4.UseVisualStyleBackColor = true;
            this.deletemessage4.Click += new System.EventHandler(this.Deletemessage4_Click);
            // 
            // deletemessage5
            // 
            this.deletemessage5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deletemessage5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.deletemessage5.FlatAppearance.BorderSize = 0;
            this.deletemessage5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.deletemessage5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.deletemessage5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletemessage5.Image = ((System.Drawing.Image)(resources.GetObject("deletemessage5.Image")));
            this.deletemessage5.Location = new System.Drawing.Point(832, 505);
            this.deletemessage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deletemessage5.Name = "deletemessage5";
            this.deletemessage5.Size = new System.Drawing.Size(36, 36);
            this.deletemessage5.TabIndex = 28;
            this.deletemessage5.UseVisualStyleBackColor = true;
            this.deletemessage5.Click += new System.EventHandler(this.Deletemessage5_Click);
            // 
            // animationsetting
            // 
            this.animationsetting.Controls.Add(this.modeoption2);
            this.animationsetting.Controls.Add(this.cmd);
            this.animationsetting.Location = new System.Drawing.Point(202, 120);
            this.animationsetting.Name = "animationsetting";
            this.animationsetting.Size = new System.Drawing.Size(712, 523);
            this.animationsetting.TabIndex = 29;
            this.animationsetting.Visible = false;
            // 
            // modeoption2
            // 
            this.modeoption2.AllowDrop = true;
            this.modeoption2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.modeoption2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeoption2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modeoption2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.modeoption2.ForeColor = System.Drawing.Color.White;
            this.modeoption2.FormattingEnabled = true;
            this.modeoption2.Items.AddRange(new object[] {
            "Default mode",
            "Fading Rectangle",
            "Flashing Circle",
            "ZigZag Traverse",
            "Back And Forth",
            "Flashing Word",
            "Breath Effect",
            "Opposite Random Line",
            "Music Bar",
            "Color Transition Line",
            "Screen Bomb",
            "Clap to light"});
            this.modeoption2.Location = new System.Drawing.Point(220, 81);
            this.modeoption2.Name = "modeoption2";
            this.modeoption2.Size = new System.Drawing.Size(254, 33);
            this.modeoption2.TabIndex = 11;
            // 
            // cmd
            // 
            this.cmd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cmd.FlatAppearance.BorderSize = 0;
            this.cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd.ForeColor = System.Drawing.Color.White;
            this.cmd.Location = new System.Drawing.Point(272, 441);
            this.cmd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmd.Name = "cmd";
            this.cmd.Size = new System.Drawing.Size(165, 53);
            this.cmd.TabIndex = 8;
            this.cmd.Text = "Send";
            this.cmd.UseVisualStyleBackColor = false;
            this.cmd.Click += new System.EventHandler(this.Cmd_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(916, 648);
            this.Controls.Add(this.animationsetting);
            this.Controls.Add(this.deletemessage5);
            this.Controls.Add(this.deletemessage4);
            this.Controls.Add(this.deletemessage3);
            this.Controls.Add(this.deletemessage2);
            this.Controls.Add(this.deletemessage1);
            this.Controls.Add(this.connectionPanel);
            this.Controls.Add(this.scrollingoption);
            this.Controls.Add(this.sendmes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addMessage);
            this.Controls.Add(this.setanimation);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.messageinput1);
            this.Controls.Add(this.messageinput2);
            this.Controls.Add(this.messageinput3);
            this.Controls.Add(this.messageinput4);
            this.Controls.Add(this.messageinput5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "SU_WifiMatrix";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.connectionPanel.ResumeLayout(false);
            this.connectionPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.animationsetting.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox TargetIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Port_Num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox messageinput1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendmes;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.ComboBox scrollingoption;
        private System.Windows.Forms.ComboBox modeoptions;
        private System.Windows.Forms.Button sendcmd;
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button connectionClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addMessage;
        private System.Windows.Forms.Button setanimation;
        private System.Windows.Forms.Button mainclose;
        private System.Windows.Forms.Label remoteip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label connstatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox messageinput2;
        private System.Windows.Forms.TextBox messageinput3;
        private System.Windows.Forms.TextBox messageinput4;
        private System.Windows.Forms.TextBox messageinput5;
        private System.Windows.Forms.Button deletemessage1;
        private System.Windows.Forms.Button deletemessage2;
        private System.Windows.Forms.Button deletemessage3;
        private System.Windows.Forms.Button deletemessage4;
        private System.Windows.Forms.Button deletemessage5;
        private System.Windows.Forms.Panel animationsetting;
        private System.Windows.Forms.ComboBox modeoption2;
        private System.Windows.Forms.Button cmd;
        private System.Windows.Forms.Button reconnect;
        private System.Windows.Forms.Button connectagain;
    }
}

