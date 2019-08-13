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
            this.messageinput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sendmes = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.scrollingoption = new System.Windows.Forms.ComboBox();
            this.modeoptions = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sendcmd = new System.Windows.Forms.Button();
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.connectionClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.addMessage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mainclose = new System.Windows.Forms.Button();
            this.connectionPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.connect.FlatAppearance.BorderSize = 0;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.connect.ForeColor = System.Drawing.Color.White;
            this.connect.Location = new System.Drawing.Point(65, 186);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(76, 32);
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
            this.TargetIp.Location = new System.Drawing.Point(96, 81);
            this.TargetIp.Multiline = true;
            this.TargetIp.Name = "TargetIp";
            this.TargetIp.Size = new System.Drawing.Size(165, 25);
            this.TargetIp.TabIndex = 1;
            this.TargetIp.Text = "1.1.1.2";
            this.TargetIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(138, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address";
            // 
            // Port_Num
            // 
            this.Port_Num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.Port_Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Port_Num.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Port_Num.ForeColor = System.Drawing.Color.Transparent;
            this.Port_Num.Location = new System.Drawing.Point(96, 141);
            this.Port_Num.Multiline = true;
            this.Port_Num.Name = "Port_Num";
            this.Port_Num.Size = new System.Drawing.Size(165, 32);
            this.Port_Num.TabIndex = 3;
            this.Port_Num.Text = "789";
            this.Port_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(159, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // messageinput
            // 
            this.messageinput.Location = new System.Drawing.Point(151, 208);
            this.messageinput.Name = "messageinput";
            this.messageinput.Size = new System.Drawing.Size(367, 22);
            this.messageinput.TabIndex = 5;
            this.messageinput.Text = "Input your text message here, no long than 128 character";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Message";
            // 
            // sendmes
            // 
            this.sendmes.Location = new System.Drawing.Point(317, 361);
            this.sendmes.Name = "sendmes";
            this.sendmes.Size = new System.Drawing.Size(104, 23);
            this.sendmes.TabIndex = 7;
            this.sendmes.Text = "Send";
            this.sendmes.UseVisualStyleBackColor = true;
            this.sendmes.Click += new System.EventHandler(this.Sendmes_Click);
            // 
            // disconnect
            // 
            this.disconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.disconnect.FlatAppearance.BorderSize = 0;
            this.disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.disconnect.ForeColor = System.Drawing.Color.White;
            this.disconnect.Location = new System.Drawing.Point(214, 186);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(97, 32);
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
            this.scrollingoption.Location = new System.Drawing.Point(151, 149);
            this.scrollingoption.Margin = new System.Windows.Forms.Padding(2);
            this.scrollingoption.Name = "scrollingoption";
            this.scrollingoption.Size = new System.Drawing.Size(171, 24);
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
            this.modeoptions.Location = new System.Drawing.Point(412, 149);
            this.modeoptions.Margin = new System.Windows.Forms.Padding(2);
            this.modeoptions.Name = "modeoptions";
            this.modeoptions.Size = new System.Drawing.Size(155, 24);
            this.modeoptions.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Command";
            // 
            // sendcmd
            // 
            this.sendcmd.Location = new System.Drawing.Point(433, 119);
            this.sendcmd.Margin = new System.Windows.Forms.Padding(2);
            this.sendcmd.Name = "sendcmd";
            this.sendcmd.Size = new System.Drawing.Size(114, 26);
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
            this.connectionPanel.Location = new System.Drawing.Point(562, 334);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(357, 226);
            this.connectionPanel.TabIndex = 15;
            this.connectionPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.connectionPanel_MouseMove);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(43)))), ((int)(((byte)(49)))));
            this.panel3.Controls.Add(this.connectionClose);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(357, 41);
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
            this.connectionClose.Location = new System.Drawing.Point(330, 4);
            this.connectionClose.Name = "connectionClose";
            this.connectionClose.Size = new System.Drawing.Size(24, 31);
            this.connectionClose.TabIndex = 10;
            this.connectionClose.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(137, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Connection";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.panel2.Controls.Add(this.mainclose);
            this.panel2.Location = new System.Drawing.Point(135, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 74);
            this.panel2.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 416);
            this.panel1.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 29);
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
            this.addMessage.Location = new System.Drawing.Point(140, 53);
            this.addMessage.Name = "addMessage";
            this.addMessage.Size = new System.Drawing.Size(233, 48);
            this.addMessage.TabIndex = 1;
            this.addMessage.Text = "Add message";
            this.addMessage.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(377, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 41);
            this.button1.TabIndex = 18;
            this.button1.Text = "Change Animation";
            this.button1.UseVisualStyleBackColor = false;
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
            this.mainclose.Location = new System.Drawing.Point(440, 12);
            this.mainclose.Name = "mainclose";
            this.mainclose.Size = new System.Drawing.Size(24, 31);
            this.mainclose.TabIndex = 11;
            this.mainclose.UseVisualStyleBackColor = true;
            this.mainclose.Click += new System.EventHandler(this.Mainclose_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(611, 411);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.connectionPanel);
            this.Controls.Add(this.sendcmd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.modeoptions);
            this.Controls.Add(this.scrollingoption);
            this.Controls.Add(this.sendmes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.messageinput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "SU_WifiMatrix";
            this.connectionPanel.ResumeLayout(false);
            this.connectionPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox TargetIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Port_Num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox messageinput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendmes;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.ComboBox scrollingoption;
        private System.Windows.Forms.ComboBox modeoptions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button sendcmd;
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button connectionClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button mainclose;
    }
}

