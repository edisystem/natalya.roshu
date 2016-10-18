﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace zadacha1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse("95.213.11.129");
            IPEndPoint ep = new IPEndPoint(ip, 80);
            Socket s = new Socket(AddressFamily.InterNetwork,
                               SocketType.Stream, ProtocolType.IP);
            try
            {
                s.Connect(ep);
                if (s.Connected)
                {
                    String strSend = "GET\r\n\r\n";
                    s.Send(System.Text.Encoding.ASCII.GetBytes(strSend));
                    byte[] buffer = new byte[1024];
                    int l;
                    do
                    {
                        l = s.Receive(buffer);
                        textBox1.Text +=
                           System.Text.Encoding.ASCII.GetString(buffer, 0, l);
                    } while (l > 0);
                }
                else
                    MessageBox.Show("Error");
            }
            catch (SocketException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

