using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
//using SocketEx;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using System.Text;
using Microsoft.Hawaii;
using Microsoft.Hawaii.Ocr.Client;
using System.Threading;


namespace OCRPhoneApp
{
    

    public class SendBitmap
    {
        public BitmapImage image;
    }

    public partial class MainPage : PhoneApplicationPage
    {
        

        StreamReader Reader = null;
        byte[] file = new byte[2000000];
        BitmapImage image = new BitmapImage();
      //  public IDuplexTypedMessageSender<string, SendBitmap> Sender;
        static ManualResetEvent cl_done = new ManualResetEvent(false);
        

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //OpenConnection();
        }
/*
        private void OpenConnection()
        {
           
            IMessagingSystemFactory anUnderlyingMessaging = new HttpMessagingSystemFactory();

            IMessagingSystemFactory aBufferedMessaging =
                new BufferedMonitoredMessagingFactory(
                anUnderlyingMessaging,
                new XmlStringSerializer(),TimeSpan.FromMinutes(1), TimeSpan.FromMilliseconds(500),TimeSpan.FromMilliseconds(1000)
                );
            IDuplexOutputChannel anOutputChannel = aBufferedMessaging.CreateDuplexOutputChannel("http://127.0.0.1:4001/OCR/");

            // Create message sender - response receiver.
            IDuplexTypedMessagesFactory aSenderFactory = new DuplexTypedMessagesFactory();
            Sender = aSenderFactory.CreateDuplexTypedMessageSender<string, SendBitmap>();
            Sender.ResponseReceived += odbiornik;
            
            // Attach duplex output channel and be able to send
            // messages and receive response messages.
            Sender.AttachDuplexOutputChannel(anOutputChannel);
        }
        */
       /* private void odbiornik(object sender, TypedResponseReceivedEventArgs<string> e)
        {            
                textBox2.Text = e.ResponseMessage;            
        }*/

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox4.Text = "test";
            MessageBox.Show("File read attempt");
            IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
           
                IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Intro English.jpg", FileMode.Open, fileStorage);
                //textBox4.Text = "1 step passed!";
                //var image = new BitmapImage();
                //textBox4.Text = "2 step passed!";
                image.SetSource(stream);
                //textBox4.Text = "3 step passed!";
                image1.Source = image;
               // textBox4.Text = "4 step passed!";
                

                //textBox4.Text = file.Length.ToString();
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox2.Text = "";
         /*   try
            {*/
                /*
                TcpClient tcpclnt = new TcpClient();
                textBox4.Text = "Connecting.....";

                tcpclnt.Connect(textBox1.Text, 4001);
                // use the ipaddress as in the server program

                textBox4.Text = "Connected";
                //textBox4.Text = "Enter the string to be transmitted : ";

                //String str = message.Text;
                Stream stm = tcpclnt.GetStream();

                //ASCIIEncoding asen = new ASCIIEncoding();
                //ImageConverter conv = new ImageConverter();
                //byte[] ba = (byte[])conv.ConvertTo(to_send, typeof(byte[]));//asen.GetBytes(str)
                textBox4.Text = "Transmitting.....";

                stm.Write(file, 0, file.Length);

                byte[] bb = new byte[1000000];
                int k = stm.Read(bb, 0, 1000000);

                for (int i = 0; i < k; i++) textBox2.Text += Convert.ToChar(bb[i]);
                */
                //tcpclnt.EndConnect(
          /*  var img = new Image();
            img.Source = image;

            //byte[] file = new byte[2000000];
            *//*
                textBox4.Text = "sending...";
                SendBitmap im = new SendBitmap();
                im.image = image;
                try
                {
                    Sender.SendRequestMessage(im);
                }
                catch(Exception)
                {
                    textBox4.Text = "Null err again!";
                }

/*
            }
            catch (Exception exp)
            {
                textBox4.Text =  "Error..... " + exp.StackTrace;
            }*/
          /*  TcpClient tcpclnt = new TcpClient();
            textBox4.Text = "Connecting.....";

            tcpclnt.Connect(textBox1.Text, 4001);
            // use the ipaddress as in the server program

            textBox4.Text = "Connected";
           // Console.Write("Enter the string to be transmitted : ");

            //String str = message.Text;
            Stream stm = tcpclnt.GetStream();

           /* ASCIIEncoding asen = new ASCIIEncoding();
            ImageConverter conv = new ImageConverter();*/
           // byte[] ba = (byte[])conv.ConvertTo(file, typeof(byte[]));//asen.GetBytes(str)
         /*   textBox4.Text = "Transmitting.....";

            stm.Write(file, 0, file.Length);
            textBox4.Text = "Transmited.....";
            byte[] bb = new byte[1000000];
            int k = stm.Read(bb, 0, 1000000);
            textBox4.Text = "Readed.....";
            for (int i = 0; i < k; i++) textBox2.Text += Convert.ToChar(bb[i]);*/


            //IAsyncResult result = null;
           // tcpclnt.EndConnect(result); 

            


        }

      

      /*  private void LayoutRoot_Unloaded(object sender, RoutedEventArgs e)
        {
            Sender.DetachDuplexOutputChannel();
        }*/

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            textBox4.Text = "test";
            textBox2.Text = "";
            IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();

            IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Intro English.jpg", FileMode.Open, fileStorage);
            //textBox4.Text = "1 step passed!";
            var image = new BitmapImage();
           // textBox4.Text = "2 step passed!";
            image.SetSource(stream);
            //textBox4.Text = "3 step passed!";
            image1.Source = image;
            //textBox4.Text = "4 step passed!";
            //stream.Seek(0,0);
            
            /*for (int i = 0; i < stream.Length; i++)
            {
                file[i] = stream.Read(
            }*/
            //string sim = "";
            byte[] img = new byte[stream.Length];
            long seekPos = stream.Seek(0, SeekOrigin.Begin);
            stream.Read(img, 0, img.Length);
            seekPos = stream.Seek(0, SeekOrigin.Begin);
           /* var cnt = 0;
            foreach (byte x in img)
            {
                textBox4.Text = cnt.ToString() + ":" + x.ToString();
                cnt++;
            }*/
            textBox4.Text = img[3000].ToString();

           // TcpClient to_transmit = new TcpClient();

            SocketAsyncEventArgs socketEvArg = new SocketAsyncEventArgs();

            DnsEndPoint entry = new DnsEndPoint(/*textBox1.Text, 8001*/"http://www.wp.pl",80,AddressFamily.InterNetwork);
            Console.WriteLine(entry.Host.ToString() + ":" + entry.Port.ToString());
            Socket to_transmit = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //to_transmit.Connect(textBox1.Text, 8001);
            //to_transmit.

            socketEvArg.RemoteEndPoint = entry;
            socketEvArg.UserToken = to_transmit;

            socketEvArg.Completed += new EventHandler<SocketAsyncEventArgs>(SocketEvArg_Completed);

            
            to_transmit.ConnectAsync(socketEvArg);
            cl_done.WaitOne();
           // Stream trans_stream = to_transmit.GetStream();

            

           
            /*
            trans_stream.Dispose();
            to_transmit.Dispose();*/

            //to_transmit.EndConnect();
            //textBox4.Text = stream.Length.ToString();
        }

        void SocketEvArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Connect:
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
                IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();

                IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Intro English.jpg", FileMode.Open, fileStorage);
                byte[] img = new byte[stream.Length];
                long seekPos = stream.Seek(0, SeekOrigin.Begin);
                stream.Read(img, 0, img.Length);
                seekPos = stream.Seek(0, SeekOrigin.Begin);
                
                e.SetBuffer(img, 0, img.Length);
                Socket sock = e.UserToken as Socket;
                bool willRaiseEvent = sock.SendAsync(e);

                if (!willRaiseEvent)
                {
                    ProcessSend(e);
                }
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
                for (int i = 0; i < e.Buffer.Length; i++) textBox2.Text += Convert.ToChar(e.Buffer[i]);
                // Data has now been sent and received from the server. 
                // Disconnect from the server
                Socket sock = e.UserToken as Socket;
                sock.Shutdown(SocketShutdown.Send);
                sock.Close();
                cl_done.Set();
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

    }
}