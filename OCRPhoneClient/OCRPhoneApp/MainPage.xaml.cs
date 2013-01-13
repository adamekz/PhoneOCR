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
using SocketEx;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using System.Text;
using Microsoft.Hawaii;
using Microsoft.Hawaii.Ocr.Client;



namespace OCRPhoneApp
{
    public static class HawaiiClient
    {
        /// <summary>
        /// The Hawaii Application Id.
        /// </summary>
        public const string HawaiiApplicationId = "52075fe8-c496-49dc-bafe-a4054ddaa840";
    }

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
            OcrService.RecognizeImageAsync(HawaiiClient.HawaiiApplicationId, img, (output) => { this.Dispatcher.BeginInvoke(() => rozpoznany(output)); });
            //textBox4.Text = stream.Length.ToString();
        }
        private void rozpoznany(OcrServiceResult output)
        {
            
            if (output.Status == Status.Success)
            {
                StringBuilder tmp = new StringBuilder();
                textBox4.Text = output.OcrResult.OcrTexts.Count.ToString();
                foreach (OcrText text in output.OcrResult.OcrTexts)
                {
                    tmp.Append(text.Text);                    
                }
                textBox2.Text = tmp.ToString();
            }
            else
            {

                textBox4.Text = "Recognition error";
            }
        }
    }
}