using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ocrtestclient
{
    public partial class Form1 : Form
    {
        Bitmap to_send;

        public Form1()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, EventArgs e)
        {
            response.Text = "";
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                tcpclnt.Connect(address.Text, 8001);
                // use the ipaddress as in the server program

                Console.WriteLine("Connected");
                Console.Write("Enter the string to be transmitted : ");

                //String str = message.Text;
                NetworkStream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                ImageConverter conv = new ImageConverter();
                byte[] ba = (byte[])conv.ConvertTo(to_send, typeof(byte[]));//asen.GetBytes(str)
                Console.WriteLine("Transmitting.....");
                //var write = new StreamWriter(stm);
                stm.Write(ba, 0, ba.Length);
                Console.WriteLine("Transmited!");
                //stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[1000000];
                //var read = new StreamReader(stm);

                int k = stm.Read(bb, 0, 1000000);

                //int k = read.Read(bb, 0, 1000000);

                for (int i = 0; i < k; i++) response.Text += Convert.ToChar(bb[i]);

                tcpclnt.Close();
            }

            catch (Exception exp)
            {
                Console.WriteLine("Error..... " + exp.StackTrace);
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                to_send = new Bitmap(openFileDialog.FileName);
                FileBox.Text = openFileDialog.FileName.Split('\\').Last();
                
            }
        }
    }
}
