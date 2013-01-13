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
        byte[] b = new byte[2000000];
        static ManualResetEvent clientDone = new ManualResetEvent(false);

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

        private static Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            // Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket =
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                
               // tempSocket.Connect(ipe);
                
                tempSocket.Bind(ipe);
                tempSocket.Listen(5);
                tempSocket.Accept();
                

                s = tempSocket;
            }
            return s;
        }

        void SAsEvArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Accept:
                    ProcessConnect(e);
                    break;

                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;

                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;

                default:
                    throw new Exception("Invalid operation completed");
            }
        }
        private void ProcessConnect(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                // Successfully connected to the server

                // Send 'Hello World' to the server
               /* byte[] buffer = Encoding.UTF8.GetBytes("Hello World");
                e.SetBuffer(buffer, 0, buffer.Length);
                Socket sock = e.UserToken as Socket;
                bool willRaiseEvent = sock.SendAsync(e);

                if (!willRaiseEvent)
                {
                    ProcessSend(e);
                }*/
                b = null;
                MessageBox.Show("Done!");


                int k = sock.Receive(b);

                ImageConverter conv = new ImageConverter();
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


            }
            else
            {
                throw new SocketException((int)e.SocketError);
            }
        }

        // Called when a ReceiveAsync operation completes
        // </summary>
        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                // Received data from server

                // Data has now been sent and received from the server. 
                // Disconnect from the server
                Socket sock = e.UserToken as Socket;
                sock.Shutdown(SocketShutdown.Send);
                sock.Close();
                clientDone.Set();
            }
            else
            {
                throw new SocketException((int)e.SocketError);
            }
        }


        // Called when a SendAsync operation completes
        private void ProcessSend(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                // Sent "Hello World" to the server successfully

                //Read data sent from the server
                Socket sock = e.UserToken as Socket;
                bool willRaiseEvent = sock.ReceiveAsync(e);

                if (!willRaiseEvent)
                {
                    ProcessReceive(e);
                }
            }
            else
            {
                throw new SocketException((int)e.SocketError);
            }
        }
        private void server()
        {
            int port = 8000;
            port++;


            //Socket sock = ConnectSocket(ip, port);
            //Socket s = null;
            IPHostEntry hostEntry = null;

            // Get host related information.
            hostEntry = Dns.GetHostEntry(ip);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, 8001);
                Socket sock =
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                SocketAsyncEventArgs SAsEvArg = new SocketAsyncEventArgs();
                SAsEvArg.RemoteEndPoint = ipe;
                SAsEvArg.UserToken = sock;

                SAsEvArg.Completed += new EventHandler<SocketAsyncEventArgs>(SAsEvArg_Completed);

                // tempSocket.Connect(ipe);
                Console.WriteLine("Waiting for a connection.....");
                sock.Bind(ipe);
                sock.Listen(5);
                //sock.AcceptAsync(




                //byte[] b = new byte[2000000];

                b = null;
                MessageBox.Show("Done!");
               

                int k = sock.Receive(b);

                ImageConverter conv = new ImageConverter();
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
                sock.Send(asen.GetBytes(to_send_str));

                Console.WriteLine("\nSent Acknowledgement");
                sock.Close();
            }
            


      /*      IPAddress ipAd = IPAddress.Parse(ip);
            
            
            // use local m/c IP address, and 
            // use the same in the client

            /* Initializes the Listener */
         /*   TcpListener myList = new TcpListener(ipAd, port);
            

            /* Start Listeneting at the specified port */
        /*    myList.Start();
            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("The local End point is  :" +
                              myList.LocalEndpoint);
            byte[] b = new byte[2000000];
            while (!stoped)
            {
               /* try
                {*/
                   
            /*
                    
                    Console.WriteLine("Waiting for a connection.....");

                    Socket s = myList.AcceptSocket();
                    Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                    //b = null;
                    int k = s.Receive(b);
                    Console.WriteLine("Recieved...");
                    /*for (int i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(b[i]));*/
/*
                    ImageConverter conv = new ImageConverter();
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
                    s.Send(asen.GetBytes(to_send_str));
                    Console.WriteLine("\nSent Acknowledgement");
                    /* clean up */
             //       s.Close();
                   
                    

              /*  }
                catch (Exception e)
                {
                    Console.WriteLine("Error..... " + e.StackTrace);
                    stoped = true;
                }   */
                
        //   }
          //  myList.Stop();
          //  Console.WriteLine("Server stopped");
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
