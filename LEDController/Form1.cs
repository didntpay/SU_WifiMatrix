using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace LEDController
{
    public partial class Form1 : Form
    {
        public Socket ledconnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Form1()
        {
            InitializeComponent();
        }



        private void connect_Click(object sender, EventArgs e)
        {
            String targetip = TargetIp.Text;
            int portnum = Convert.ToInt32(Port_Num.Text);
            if (ledconnection.Connected)
            {
                endConnection(ledconnection);
                //log it, and tell user to try again.
            }
            else
            {
                try
                {
                    IPEndPoint tmpEP = new IPEndPoint(IPAddress.Parse(targetip), portnum);
                    ledconnection.Connect(tmpEP);
                    sendMessage(ledconnection, "YO, turn on my guy");
                }
                catch(SocketException se)
                {
                    //do nothing for now.
                }
            }
        }

        private void isIPValid()//implement this later and run before connect.
        {

        }

        private void sendMessage(Socket connection, String mes)
        {
            Byte[] buffer = Encoding.ASCII.GetBytes(mes);
            connection.Send(buffer, SocketFlags.None);
        }

        private void endConnection(Socket connection)
        {
            if (!connection.Connected)
            {
                //something went wrong, log it.
            }
            else
            {
                connection.EndConnect((IAsyncResult)connection);
            }
        }
    }
}
