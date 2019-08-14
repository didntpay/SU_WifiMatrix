using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LEDController
{



    public partial class Form1 : Form
    {
        public Socket ledconnection = null;

        public const byte DATA_MESSAGE = 0x80;
        public const byte DATA_CMD = 0x90;
        public const byte DATA_BMP = 0xA0;

        public const byte SCROLL_LEFT = 0x10;
        public const byte SCROLL_RIGHT = 0x01;
        public const byte SCROLL_TOP = 0x11;
        public const byte SCROLL_BOTTOM = 0x12;

        public const byte CMD_DEFAULT = 0x40;
        public const byte CMD_AONE = 0x50;
        public const byte CMD_ATWO = 0x60;
        public const byte CMD_ATHREE = 0x70;
        public const byte CMD_AFOUR = 0x80;
        public const byte CMD_AFIVE = 0x90;
        public const byte CMD_ASIX = 0x10;
        public const byte CMD_ASEVEN = 0x20;
        public const byte CMD_AEIGHT = 0x30;
        public const byte CMD_ANINE = 0xA0;
        public const byte CMD_ATEN = 0xB0;

        public struct header
        {
            public byte datatype;
            public char length;
            public byte messageoption;

            header(byte cmd = 0x00, char len = (char)0, byte option = SCROLL_LEFT)
            {
                this.datatype = cmd;
                this.length = len;
                this.messageoption = option;
            }

            public byte[] toBytes()
            {
                byte[] value = new byte[3];
                value[0] = datatype;
                value[1] = (byte)length;
                value[2] = messageoption;

                return value;
            }
        }

        public header socket_header = new header();
        public Form1()
        {
            InitializeComponent();
        }



        private void connect_Click(object sender, EventArgs e)
        {
            if (!isIPValid())
            {
                MessageBox.Show("Invalid IP address or it isn't a local IP address", 
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String targetip = TargetIp.Text;
            int portnum = Convert.ToInt32(Port_Num.Text);
            ledconnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (ledconnection.Connected)
            {
                endConnection(ref ledconnection);
                //log it, and tell user to try again.
                MessageBox.Show("Disconnected with the previous device, try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Ping pingsender = new Ping();
                PingReply reply = pingsender.Send(IPAddress.Parse(targetip), 3000);
                if (reply.Status == IPStatus.Success)
                {
                    try
                    {
                        IPEndPoint tmpEP = new IPEndPoint(IPAddress.Parse(targetip), portnum);
                        ledconnection.Connect(tmpEP);
                        connectionPanel.Visible = false;
                        connstatus.Text = "Connected";
                        remoteip.Text = "Connected IP\n  " + ledconnection.RemoteEndPoint.ToString();

                    }
                    catch (SocketException se)
                    {
                        ledconnection = null;

                    }
                }
                else
                {
                    MessageBox.Show("Connection time out, try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            //get it out of the way after it is connected
            
        }

        private bool isIPValid()//implement this later and run before connect.
        {
            string ip = TargetIp.Text;
            string[] tmp = ip.Split('.');
            if (tmp.Length < 4)
            {
                return false;
            }
            else
            {
                IPHostEntry entry = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress address in entry.AddressList)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        string localip = address.ToString();
                        string[] localipfrag = localip.Split('.');
                        int count = 0;
                        for (int i = 0; i < 3; i++)
                        {
                            if (localipfrag[i].Equals(tmp[i]))
                                count++;
                        }
                        return count == 3;
                    }
                }
            }
            return false;

        }

        private void send(ref Socket connection, String mes, byte datatype)
        {
            TextBox[] textlist = { messageinput1, messageinput2, messageinput3, messageinput4, messageinput5 };
            
            //length of the header struct
            int headerlength = 3;
            byte[] messagelist_byte = new byte[textlist[0].Text.Length + textlist[1].Text.Length
                                    + textlist[2].Text.Length + textlist[3].Text.Length + textlist[4].Text.Length + 5];
            byte[] buffer = new byte[messagelist_byte.Length + headerlength + 5];
            byte[] header_byte = socket_header.toBytes();
            string[] messagelist = new string[5];
            
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                messagelist[i] = textlist[i].Text;

                if (i != 0)
                {
                    messagelist_byte[index] = 0xFF;
                    index++;
                }

                foreach (char x in messagelist[i])
                {
                    messagelist_byte[index] = (byte)x;
                    index++;
                }
                
            }

            for (int i = 0; i < header_byte.Length; i++)
            {
                buffer[i] = header_byte[i];
            }

            

            for (int i = headerlength; i < messagelist_byte.Length + headerlength; i++)
            {
                buffer[i] = messagelist_byte[i - headerlength];
            }
            connection.Send(buffer, SocketFlags.None);
        }

        

        private void Disconnect_Click(object sender, EventArgs e)
        {
            endConnection(ref ledconnection);

        }

        private void Sendmes_Click(object sender, EventArgs e)
        {
            if (ledconnection == null || ledconnection.Connected == false)
                return;
            TextBox[] textlist = { messageinput1, messageinput2, messageinput3, messageinput4, messageinput5 };

            try
            {
                socket_header.length = (char)(textlist[0].Text.Length + textlist[1].Text.Length
                                + textlist[2].Text.Length + textlist[3].Text.Length + textlist[4].Text.Length + 5);
                socket_header.datatype = DATA_MESSAGE;
                //to put save all the messages locally
                updateMessageFile();
                send(ref ledconnection, messageinput1.Text, DATA_MESSAGE);
            }
            catch (SocketException se)
            {
            }
            

        }

        private void Scrollingoption_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (scrollingoption.SelectedItem.ToString())
            {
                case "left_most":
                    socket_header.messageoption = SCROLL_LEFT;
                    break;
                case "right_most":
                    socket_header.messageoption = SCROLL_RIGHT;
                    break;
                case "top_most":
                    socket_header.messageoption = SCROLL_TOP;
                    break;
                case "bottom_most":
                    socket_header.messageoption = SCROLL_BOTTOM;
                    break;


            }
        }

        private void Sendcmd_Click(object sender, EventArgs e)
        {
            if (ledconnection == null || !ledconnection.Connected)
                return;

            socket_header.length = (char)0;
            socket_header.datatype = DATA_CMD;
            byte[] header = socket_header.toBytes();
            byte[] buffer = new byte[3];
            byte mode = CMD_DEFAULT;
            switch (modeoptions.SelectedItem.ToString())
            {
                case "Default mode":
                    mode = CMD_DEFAULT;
                    break;
                case "Animation 1":
                    mode = CMD_AONE;
                    break;
                case "Animation 2":
                    mode = CMD_ATWO;
                    break;
                case "Animation 3":
                    mode = CMD_ATHREE;
                    break;
                case "Animation 4":
                    mode = CMD_AFOUR;
                    break;
                case "Animation 5":
                    mode = CMD_AFIVE;
                    break;
                case "Animation 6":
                    mode = CMD_ASIX;
                    break;
                case "Animation 7":
                    mode = CMD_ASEVEN;
                    break;
                case "Animation 8":
                    mode = CMD_AEIGHT;
                    break;
                case "Animation 9":
                    mode = CMD_ANINE;
                    break;
                case "Animation 10":
                    mode = CMD_ATEN;
                    break;
                case "Sleep mode":
                    break;
            }
            buffer[0] = header[0];
            buffer[1] = header[1];
            buffer[2] = mode;
            ledconnection.Send(buffer, SocketFlags.None);


        }

        private void endConnection(ref Socket connection)
        {
            if (ledconnection == null || !connection.Connected)
            {
                MessageBox.Show("Connect to a esp8266 first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    connection.Shutdown(SocketShutdown.Both);
                    connection.Close();
                    connection = null;
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message + "\n assigned socket to null, please try to reconnect.",
                                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ledconnection = null;

                }

            }
        }

        private void updateMessageFile()
        {
            string path = "./message.txt";
            if (!File.Exists(path))
                File.CreateText(path);
            string[] tobeupdate = new string[5];
            using (StreamReader sr = File.OpenText(path))
            {
                string line;
                int index = 0;
                TextBox[] messagelist = { messageinput1, messageinput2, messageinput3, messageinput4, messageinput5 };
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Equals(messagelist[index].Text))
                    {
                        line = messagelist[index].Text;
                    }
                    tobeupdate[index] = line;
                    index++;
                }
            }

            File.WriteAllLines(path, tobeupdate);
        }
        private void connectionPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                connectionPanel.BringToFront();
                connectionPanel.Location = new System.Drawing.Point(Cursor.Position.X - 80 , Cursor.Position.Y - 80);
            }
        }

        private void Mainclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Message inputs
        private void Messageinput1_TextChanged(object sender, EventArgs e)
        {
            messageinput1.TextAlign = HorizontalAlignment.Center;
        }

        private void Messageinput2_TextChanged(object sender, EventArgs e)
        {
            messageinput2.TextAlign = HorizontalAlignment.Center;
        }

        private void Messageinput3_TextChanged(object sender, EventArgs e)
        {
            messageinput3.TextAlign = HorizontalAlignment.Center;
        }

        private void Messageinput4_TextChanged(object sender, EventArgs e)
        {
            messageinput4.TextAlign = HorizontalAlignment.Center;
        }

        private void Messageinput5_TextChanged(object sender, EventArgs e)
        {
            messageinput5.TextAlign = HorizontalAlignment.Center;
        }

        private void Deletemessage1_Click(object sender, EventArgs e)
        {
            messageinput1.Clear();
            messageinput1.Text = "Message 1";
            updateMessageFile();
        }

        private void Deletemessage2_Click(object sender, EventArgs e)
        {
            messageinput2.Clear();
            messageinput2.Text = "Message 2";
            updateMessageFile();
        }

        private void Deletemessage3_Click(object sender, EventArgs e)
        {
            messageinput3.Clear();
            messageinput3.Text = "Message 3";
            updateMessageFile();
        }

        private void Deletemessage4_Click(object sender, EventArgs e)
        {
            messageinput4.Clear();
            messageinput4.Text = "Message 4";
            updateMessageFile();
        }

        private void Deletemessage5_Click(object sender, EventArgs e)
        {
            messageinput5.Clear();
            messageinput5.Text = "Message 5";
            updateMessageFile();
        }


        #endregion

        private void setAnimation_Click(object sender, EventArgs e)
        {
            animationsetting.Visible = true;
            addMessage.Size = new Size(173, 35);
            setanimation.Size = new Size(173, 40);
            setanimation.Location = new Point(280, 38);
            addMessage.Location = new Point(105, 40);
            addMessage.BringToFront();
            setanimation.BringToFront();
        }

        private void AddMessage_Click(object sender, EventArgs e)
        {
            animationsetting.Visible = false;
            addMessage.Size = new Size(168, 40);
            addMessage.Location = new Point(107, 38);
            setanimation.Location = new Point(280, 40);
            setanimation.Size = new Size(168, 35);
            addMessage.BringToFront();
            setanimation.BringToFront();
        }

        private void Cmd_Click(object sender, EventArgs e)
        {
            if (ledconnection == null || !ledconnection.Connected)
                return;

            socket_header.length = (char)0;
            socket_header.datatype = DATA_CMD;
            byte[] header = socket_header.toBytes();
            byte[] buffer = new byte[3];
            byte mode = CMD_DEFAULT;
            switch (modeoption2.SelectedItem.ToString())
            {
                case "Default mode":
                    mode = CMD_DEFAULT;
                    break;
                case "Fading Rectangle":
                    mode = CMD_AONE;
                    break;
                case "Flashing Cicle":
                    mode = CMD_ATWO;
                    break;
                case "ZigZag Traverse":
                    mode = CMD_ATHREE;
                    break;
                case "Back And Forth":
                    mode = CMD_AFOUR;
                    break;
                case "Flashing Word":
                    mode = CMD_AFIVE;
                    break;
                case "Breath Effect":
                    mode = CMD_ASIX;
                    break;
                case "Opposite Random Line":
                    mode = CMD_ASEVEN;
                    break;
                case "Music Bar":
                    mode = CMD_AEIGHT;
                    break;
                case "Color Transition Line":
                    mode = CMD_ANINE;
                    break;
                case "Screen Bomb":
                    mode = CMD_ATEN;
                    break;
            }
            buffer[0] = header[0];
            buffer[1] = header[1];
            buffer[2] = mode;
            ledconnection.Send(buffer, SocketFlags.None);
        }
    }
}
