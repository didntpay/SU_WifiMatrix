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
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(217, 60);
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
            this.Port_Num.Text = "12345";
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
            this.messageinput.Location = new System.Drawing.Point(30, 172);
            this.messageinput.Name = "messageinput";
            this.messageinput.Size = new System.Drawing.Size(367, 22);
            this.messageinput.TabIndex = 5;
            this.messageinput.Text = "Input your text message here, no long than 128 character";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Message";
            // 
            // sendmes
            // 
            this.sendmes.Location = new System.Drawing.Point(430, 171);
            this.sendmes.Name = "sendmes";
            this.sendmes.Size = new System.Drawing.Size(104, 23);
            this.sendmes.TabIndex = 7;
            this.sendmes.Text = "Send";
            this.sendmes.UseVisualStyleBackColor = true;
            this.sendmes.Click += new System.EventHandler(this.Sendmes_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(312, 60);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(104, 23);
            this.disconnect.TabIndex = 8;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 276);
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
            this.Text = "Form1";
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
    }
}

