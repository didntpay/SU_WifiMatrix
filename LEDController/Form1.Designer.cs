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
            this.debug = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(218, 36);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 0;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // TargetIp
            // 
            this.TargetIp.Location = new System.Drawing.Point(30, 40);
            this.TargetIp.Name = "TargetIp";
            this.TargetIp.Size = new System.Drawing.Size(165, 22);
            this.TargetIp.TabIndex = 1;
            this.TargetIp.Text = "1.1.1.2";
            this.TargetIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address";
            // 
            // Port_Num
            // 
            this.Port_Num.Location = new System.Drawing.Point(30, 85);
            this.Port_Num.Name = "Port_Num";
            this.Port_Num.Size = new System.Drawing.Size(165, 22);
            this.Port_Num.TabIndex = 3;
            this.Port_Num.Text = "789";
            this.Port_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // messageinput
            // 
            this.messageinput.Location = new System.Drawing.Point(30, 320);
            this.messageinput.Name = "messageinput";
            this.messageinput.Size = new System.Drawing.Size(367, 22);
            this.messageinput.TabIndex = 5;
            this.messageinput.Text = "Input your text message here, no long than 128 character";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Message";
            // 
            // sendmes
            // 
            this.sendmes.Location = new System.Drawing.Point(430, 319);
            this.sendmes.Name = "sendmes";
            this.sendmes.Size = new System.Drawing.Size(104, 23);
            this.sendmes.TabIndex = 7;
            this.sendmes.Text = "Send";
            this.sendmes.UseVisualStyleBackColor = true;
            this.sendmes.Click += new System.EventHandler(this.Sendmes_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(207, 85);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(104, 23);
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
            this.scrollingoption.Location = new System.Drawing.Point(30, 131);
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
            "Sleep mode"});
            this.modeoptions.Location = new System.Drawing.Point(392, 54);
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
            this.sendcmd.Location = new System.Drawing.Point(420, 98);
            this.sendcmd.Margin = new System.Windows.Forms.Padding(2);
            this.sendcmd.Name = "sendcmd";
            this.sendcmd.Size = new System.Drawing.Size(114, 26);
            this.sendcmd.TabIndex = 14;
            this.sendcmd.Text = "Change mode";
            this.sendcmd.UseVisualStyleBackColor = true;
            this.sendcmd.Click += new System.EventHandler(this.Sendcmd_Click);
            // 
            // debug
            // 
            this.debug.Location = new System.Drawing.Point(207, 355);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(169, 72);
            this.debug.TabIndex = 15;
            this.debug.Text = "Debug Info:";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 439);
            this.Controls.Add(this.debug);
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
        private System.Windows.Forms.RichTextBox debug;
    }
}

