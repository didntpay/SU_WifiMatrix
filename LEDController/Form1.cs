using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LEDController
{
    
    public struct header
    {
        byte datatype;
        char length;

        header(byte cmd, char len)
        {
            this.datatype = cmd;
            this.length = len;
        }
    }

    public partial class Form1 : Form
    {
        public Socket ledconnection = null;

        public const byte DATA_MESSAGE = 0x80;
        public const byte DATA_CMD = 0x90;
        public const byte DATA_BMP = 0xA0;

        public Form1()
        {
            InitializeComponent();
        }



        private void connect_Click(object sender, EventArgs e)
        {
            String targetip = TargetIp.Text;
            int portnum = Convert.ToInt32(Port_Num.Text);
            ledconnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (ledconnection.Connected)
            {
                endConnection(ref ledconnection);
                //log it, and tell user to try again.
            }
            else
            {
                try
                {
                    IPEndPoint tmpEP = new IPEndPoint(IPAddress.Parse(targetip), portnum);
                    ledconnection.Connect(tmpEP);
                    
                }
                catch (SocketException se)
                {
                    //do nothing for now.
                }
            }
        }

        private void isIPValid()//implement this later and run before connect.
        {

        }

        private void send(ref Socket connection, String mes, byte datatype)
        {
            byte[] buffer = new byte[mes.Length + 2];

            buffer[0] = datatype; // the two byte header
            buffer[1] = (byte)mes.Length;

            byte[] temp = Encoding.ASCII.GetBytes(mes);
            for (int i = 2; i < mes.Length + 2; i++)
            {
                buffer[i] = temp[i - 2];
            }
            connection.Send(buffer, SocketFlags.None);
        }

        private void endConnection(ref Socket connection)
        {
            if (!connection.Connected)
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

        private void Disconnect_Click(object sender, EventArgs e)
        {
            endConnection(ref ledconnection);
            
        }

        private void Sendmes_Click(object sender, EventArgs e)
        {
            if(messageinput.Text.Length < 129)
            {
                send(ref ledconnection, messageinput.Text, DATA_MESSAGE);
            }
            
        }
    }
}
