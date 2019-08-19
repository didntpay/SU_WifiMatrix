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

        //flags for processing network transfer
        public const byte DATA_MESSAGE = 0x80;
        public const byte DATA_CMD = 0x90;
        public const byte DATA_BMP = 0xA0;

        //flags for displaying text
        public const byte SCROLL_LEFT = 0x10;
        public const byte SCROLL_RIGHT = 0x01;
        public const byte SCROLL_TOP = 0x11;
        public const byte SCROLL_BOTTOM = 0x12;

        //flags for different animation(mode)
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
        public const byte CMD_AEVELEN = 0xC0;

        //in between each message, a spliter of 0xFF is set for server to accurately
        //receive array.
        public const byte NUM_SPLITER = 4;

        /*********************************************************************
         * 
         * Network header for ESP8266
         * 
         *********************************************************************/
        public struct header
        {
            //public field
            public byte datatype;
            public char length;
            public byte messageoption;

            //constructor
            header(byte cmd = 0x00, char len = (char)0, byte option = SCROLL_LEFT)
            {
                this.datatype = cmd;
                this.length = len;
                this.messageoption = option;
            }

            /*********************************************************************             * 
             * Convert the header struct to byte array
             * @Return byte array representing the header struct
             *********************************************************************/
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


        /*********************************************************************
         * Connect button event handler
         * 
         * @Param sender the component that detected the event and transfered to this handler
         * @param e Informations about the type of events
         *********************************************************************/
        private void connect_Click(object sender, EventArgs e)
        {
            if (!isIPValid())
            {
                MessageBox.Show("Invalid IP address or it isn't a local IP address", 
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String targetip = TargetIp.Text;
            //check the arduino code before changing port num
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
                //ping to check if IP is responding
                Ping pingsender = new Ping();
                PingReply reply = pingsender.Send(IPAddress.Parse(targetip), 1000);
                if (reply.Status == IPStatus.Success)
                {
                    try
                    {
                        IPEndPoint tmpEP = new IPEndPoint(IPAddress.Parse(targetip), portnum);
                        ledconnection.Connect(tmpEP);
                        connectionPanel.Visible = false;
                        connstatus.Text = "Connected";
                        remoteip.Text = "Connected IP\n" + ledconnection.RemoteEndPoint.ToString();

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

        /*********************************************************************         
         * Check if given IP address is valid         
         * @Return returns true if IP is valid, false otherwise
         *********************************************************************/
        private bool isIPValid()
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

        /*********************************************************************   
         * Proceed to send a package to the target
         * @Param Socket the connected socket with the target
         * @Param byte a flag from the data type region
         *********************************************************************/
        private void send(ref Socket connection, byte datatype)
        {
            String[] textlist = { messageinput1.Text, messageinput2.Text, messageinput3.Text,
                                messageinput4.Text, messageinput5.Text};
            
            //length of the header struct
            int headerlength = 3;
            byte[] messagelist_byte = new byte[textlist[0].Length + textlist[1].Length
                                    + textlist[2].Length + textlist[3].Length + textlist[4].Length + NUM_SPLITER];
            byte[] buffer = new byte[messagelist_byte.Length + headerlength];
            byte[] header_byte = socket_header.toBytes();
            
            int index = 0;
            for (int i = 0; i < 5; i++)
            {

                if (i != 0)
                {
                    messagelist_byte[index] = 0xFF;
                    index++;
                }

                foreach (char x in textlist[i])
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


        /*********************************************************************   
         * Event handler for the disconnect button
         * @Param object The receiver of this event
         * @Param EventArgs Informations about the event
         *********************************************************************/
        private void Disconnect_Click(object sender, EventArgs e)
        {
            endConnection(ref ledconnection);
            this.connstatus.Text = "Disconnected";
            this.remoteip.Text = "Connected IP\n     None";
        }


        /*********************************************************************   
         * Event handler for the send button
         * @Param object The receiver of this event
         * @Param EventArgs Informations about the event
         *********************************************************************/
        private void Sendmes_Click(object sender, EventArgs e)
        {
            if (ledconnection == null || ledconnection.Connected == false)
                return;
            TextBox[] textlist = { messageinput1, messageinput2, messageinput3, messageinput4, messageinput5 };

            try
            {
                socket_header.length = (char)(textlist[0].Text.Length + textlist[1].Text.Length
                                + textlist[2].Text.Length + textlist[3].Text.Length + textlist[4].Text.Length + NUM_SPLITER);
                socket_header.datatype = DATA_MESSAGE;
                //to put save all the messages locally
                updateMessageFile();
                send(ref ledconnection, DATA_MESSAGE);
            }
            catch (SocketException se)
            {
            }
            

        }

        /*********************************************************************   
         * Event handler for the send button
         * @Param object The receiver of this event
         * @Param EventArgs Informations about the event
         *********************************************************************/
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

        /*********************************************************************   
         * Disconnects with the target ip safely
         * @Param Socket The connected socket with the target IP
         *********************************************************************/
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

        /*********************************************************************   
         * Updates the messages file stored locally
         *********************************************************************/
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

        /*********************************************************************   
         * Event handler for draging the application
         * @Param object The receiver of this event
         * @Param EventArgs Informations about the event
         *********************************************************************/
        private void connectionPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                connectionPanel.BringToFront();
                connectionPanel.Location = new System.Drawing.Point(Cursor.Position.X - 80 , Cursor.Position.Y - 80);
            }
        }

        /*********************************************************************   
         * Event handler for dragging the form
         * @Param object The receiver of this event
         * @Param EventArgs Informations about the event
         *********************************************************************/
        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(Cursor.Position.X - 80, Cursor.Position.Y - 80);
            }
        }

        /*********************************************************************   
         * Event handler for the red X button
         * @Param object The receiver of this event
         * @Param EventArgs Informations about the event
         *********************************************************************/
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

        /*********************************************************************   
         * Event handler for the setanimation buttons
         * @Param object The receiver of this event
         * @Param EventArgs Informations about the event
         *********************************************************************/
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

        /*********************************************************************   
         * Event handler for the addmessage button
         * @Param object The receiver of this event
         * @Param EventArgs Informations about the event
         *********************************************************************/
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

        /*********************************************************************   
         * Event handler for the send button(Animation side)
         * @Param object The receiver of this event
         * @Param EventArgs Informations about the event
         *********************************************************************/
        private void Cmd_Click(object sender, EventArgs e)
        {
            if (ledconnection == null || !ledconnection.Connected)
                return;

            TextBox[] textlist = { messageinput1, messageinput2, messageinput3, messageinput4, messageinput5 };

            socket_header.length = (char)(textlist[0].Text.Length + textlist[1].Text.Length
                                + textlist[2].Text.Length + textlist[3].Text.Length + textlist[4].Text.Length + NUM_SPLITER);
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
                case "Flashing Circle":
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
                case "Clap to light":
                    mode = CMD_AEVELEN;
                    break;
            }
            buffer[0] = header[0];
            buffer[1] = header[1];
            buffer[2] = mode;
            ledconnection.Send(buffer, SocketFlags.None);
        }

        /*********************************************************************   
         * Read from the local file and change the message box's text.
         *********************************************************************/
        private void importTextFromFile()
        {
            String path = "message.txt";
            if (!File.Exists(path))
                return;


            using (StreamReader sr = File.OpenText(path))
            {
                TextBox[] messagelist = { messageinput1, messageinput2, messageinput3,
                                        messageinput4, messageinput5 };
                string line = "";
                int index = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    messagelist[index].Text = line;
                    index++;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            importTextFromFile();
        }

        /*********************************************************************   
         * Event handler for the reconnect button
         * @Param object The receiver of this event
         * @Param EventArgs Informations about the event
         *********************************************************************/
        private void Connectagain_Click(object sender, EventArgs e)
        {
            connectionPanel.Visible = true;
            connectionPanel.BringToFront();
        }
    }
}
