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
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(327, 57);
            this.connect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(112, 36);
            this.connect.TabIndex = 0;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // TargetIp
            // 
            this.TargetIp.Location = new System.Drawing.Point(45, 62);
            this.TargetIp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TargetIp.Name = "TargetIp";
            this.TargetIp.Size = new System.Drawing.Size(246, 31);
            this.TargetIp.TabIndex = 1;
            this.TargetIp.Text = "1.1.1.2";
            this.TargetIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address";
            // 
            // Port_Num
            // 
            this.Port_Num.Location = new System.Drawing.Point(45, 133);
            this.Port_Num.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Port_Num.Name = "Port_Num";
            this.Port_Num.Size = new System.Drawing.Size(246, 31);
            this.Port_Num.TabIndex = 3;
            this.Port_Num.Text = "12345";
            this.Port_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // messageinput
            // 
            this.messageinput.Location = new System.Drawing.Point(45, 500);
            this.messageinput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.messageinput.Name = "messageinput";
            this.messageinput.Size = new System.Drawing.Size(548, 31);
            this.messageinput.TabIndex = 5;
            this.messageinput.Text = "Input your text message here, no long than 128 character";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 469);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Message";
            // 
            // sendmes
            // 
            this.sendmes.Location = new System.Drawing.Point(645, 498);
            this.sendmes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendmes.Name = "sendmes";
            this.sendmes.Size = new System.Drawing.Size(156, 36);
            this.sendmes.TabIndex = 7;
            this.sendmes.Text = "Send";
            this.sendmes.UseVisualStyleBackColor = true;
            this.sendmes.Click += new System.EventHandler(this.Sendmes_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(310, 133);
            this.disconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(156, 36);
            this.disconnect.TabIndex = 8;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // scrollingoption
            // 
            this.scrollingoption.AllowDrop = true;
            this.scrollingoption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scrollingoption.FormattingEnabled = true;
            this.scrollingoption.Items.AddRange(new object[] {
            "left_most",
            "right_most",
            "top_most",
            "bottom_most",
            "custom"});
            this.scrollingoption.Location = new System.Drawing.Point(45, 205);
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
            "Sleep mode"});
            this.modeoptions.Location = new System.Drawing.Point(588, 85);
            this.modeoptions.Name = "modeoptions";
            this.modeoptions.Size = new System.Drawing.Size(231, 33);
            this.modeoptions.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(583, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Command";
            // 
            // sendcmd
            // 
            this.sendcmd.Location = new System.Drawing.Point(630, 153);
            this.sendcmd.Name = "sendcmd";
            this.sendcmd.Size = new System.Drawing.Size(171, 41);
            this.sendcmd.TabIndex = 14;
            this.sendcmd.Text = "Change mode";
            this.sendcmd.UseVisualStyleBackColor = true;
            this.sendcmd.Click += new System.EventHandler(this.Sendcmd_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 686);
            this.Controls.Add(this.sendcmd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.modeoptions);
            this.Controls.Add(this.scrollingoption);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.sendmes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.messageinput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Port_Num);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TargetIp);
            this.Controls.Add(this.connect);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "SU_WifiMatrix";
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
    }
}

