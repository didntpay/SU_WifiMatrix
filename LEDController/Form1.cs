﻿using System;
using System.Net;
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
            int headerlength = 3;
            byte[] buffer = new byte[mes.Length + headerlength];
            byte[] tmp = socket_header.toBytes();
            for (int i = 0; i < tmp.Length; i++)
            {
                buffer[i] = tmp[i];
            }

            byte[] temp = Encoding.ASCII.GetBytes(mes);
            for (int i = headerlength; i < mes.Length + headerlength; i++)
            {
                buffer[i] = temp[i - headerlength];
            }
            connection.Send(buffer, SocketFlags.None);
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

        private void Disconnect_Click(object sender, EventArgs e)
        {
            endConnection(ref ledconnection);

        }

        private void Sendmes_Click(object sender, EventArgs e)
        {
            if (ledconnection == null || ledconnection.Connected == false)
                return;
            if (messageinput.Text.Length < 129)
            {
                socket_header.length = (char)messageinput.Text.Length;
                socket_header.datatype = DATA_MESSAGE;
                send(ref ledconnection, messageinput.Text, DATA_MESSAGE);
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

            socket_header.length = (char)0;
            socket_header.datatype = DATA_CMD;
            byte[] header = socket_header.toBytes();
            byte[] buffer = new byte[3];
            byte mode = 0x00;
            switch (modeoptions.SelectedItem.ToString())
            {
                case "Change mode":
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
                case "Sleep mode":
                    break;
            }
            buffer[0] = header[0];
            buffer[1] = header[1];
            buffer[2] = mode;
            ledconnection.Send(buffer, SocketFlags.None);


        }
    }
}
