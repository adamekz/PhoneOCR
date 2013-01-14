using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;

namespace ocrserver
{
    public partial class Form1 : Form
    {
        public bool stoped = false;
        string ip = "127.0.0.1";
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = ip;
        }

        private void start()
        {
            Thread serv = new Thread(new ThreadStart(preserver));
            serv.Name = "server";
            serv.Start();
        }

        private void preserver()
        {
           /* if (pictureBox1.InvokeRequired)
            {
                MethodInvoker pic_invoker = new MethodInvoker(preserver);
                pictureBox1.Invoke(pic_invoker);
            }
            else
            {*/
                server();
           // }

        }

        private void server()
        {
            int port = 8001;
            //port++;
            IPAddress ipAd = IPAddress.Parse(ip);
            
            
            // use local m/c IP address, and 
            // use the same in the client
            ASCIIEncoding asen = new ASCIIEncoding();
            /* Initializes the Listener */
            TcpListener myList = new TcpListener(IPAddress.Any, port);
            
            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("The local End point is  :" +
                              myList.LocalEndpoint);
            /* Start Listeneting at the specified port */
            
            byte[] b = new byte[2000000];
            myList.Start();

            while (!stoped)
            {
               /* try
                {*/
                                       
                    Console.WriteLine("Waiting for a connection.....");

                    TcpClient s = myList.AcceptTcpClient();
                    Console.WriteLine("Connection accepted");
                    NetworkStream stream = s.GetStream();
                    //b = null;
                    //int k = s.Receive(b);
                    var reader = new StreamReader(stream);

                    b =  asen.GetBytes(reader.ReadToEnd());

                    Console.WriteLine("Recieved...");
                    /*for (int i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(b[i]));*/

                   /* ImageConverter conv = new ImageConverter();
                    Bitmap rec = new Bitmap((Bitmap)conv.ConvertFrom(b));
                   // pictureBox1.Image = rec;
                    rec.Save("G:\\serv_test.bmp");
                    Console.WriteLine("Recognicion...");
                    Tesseract ocr = new Tesseract("tessdata", "eng", Tesseract.OcrEngineMode.OEM_DEFAULT);

                    ocr.Recognize<Bgr>(new Emgu.CV.Image<Bgr, Byte>(rec));
                   // recognizedText.Text = ocr.GetText();
                    string to_send_str = ocr.GetText();
                    ocr.Dispose();
                    Console.Write(to_send_str + "\n");
                    ASCIIEncoding asen = new ASCIIEncoding();
                    s.Send(asen.GetBytes(to_send_str));*/
                    var writer = new StreamWriter(stream);

                    //s.Send(asen.GetBytes("OK!"));
                    writer.Write("OK!");
                    Console.WriteLine("\nSent Acknowledgement");
                    /* clean up */
                    s.Close();
                   
                    

              /*  }
                catch (Exception e)
                {
                    Console.WriteLine("Error..... " + e.StackTrace);
                    stoped = true;
                }   */
                
           }
            myList.Stop();
            Console.WriteLine("Server stopped");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stoped = false;
            textBox1.Enabled = false;
            //start();
            server();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stoped = true;
            textBox1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ip = textBox1.Text;
        }
    }
}
