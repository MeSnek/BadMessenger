using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows;

namespace TalkWithOtherPeopleThing
{
    
    public partial class CreateServer : MainWindow
    {
        TcpListener listener;
        TcpClient client = null;
        NetworkStream stream = null; 
        BinaryReader binaryReader = null;
        StreamWriter streamWriter = null;
        string message;
        
        public CreateServer(IPAddress ip, Int32 port)
        {
            
            listener = new TcpListener(ip, port);
            listener.Start();
            AcceptClient();
        }
        public void AcceptClient()
        {
            while (true)
            {
                client = listener.AcceptTcpClient();
                if (client.Connected)
                {
                    streamWriter = new StreamWriter(client.GetStream(), System.Text.Encoding.ASCII);
                    break;
                }
            }
        }
        public void Poll()
        {
            while (true)
            {
                stream = client.GetStream();
                if (stream.DataAvailable)
                {
                    Read();
                }
            }
        }
        //change username to be other persons username, maybe make them each send their username as their first message
        void Read()
        {
            binaryReader = new BinaryReader(stream);
            message = binaryReader.ReadString();
            stream.Flush();
            WriteToUI(message);
        }
        public void Send()
        {
            streamWriter.Write(WriteTextBox.Text);
            stream = client.GetStream();
            stream.Flush();
            WriteToUI(WriteTextBox.Text);
            //WriteTextBox.Text = "";
            //WriteTextBox.Dispatcher.Invoke(() => { WriteTextBox.Text = ""; });
            //Application.Current.Dispatcher.Invoke(() => { WriteTextBox.Text = ""; });
        }
        // add another parmeter that passes username    
        public void WriteToUI(string message)
        {
            if (!string.IsNullOrEmpty(Message7.Text))
                {
                    if (!string.IsNullOrEmpty(Message6.Text))
                    {
                        if (!string.IsNullOrEmpty(Message5.Text))
                        {
                            if (!string.IsNullOrEmpty(Message4.Text))
                            {
                                if (!string.IsNullOrEmpty(Message3.Text))
                                {
                                    if (!string.IsNullOrEmpty(Message2.Text))
                                    {
                                        if (!string.IsNullOrEmpty(Message1.Text))
                                        {
                                            Message1.Text = username + ": " + message;
                                        }
                                        Message2.Text = username + ": " + message;
                                    }
                                    Message3.Text = username + ": " + message;
                                }
                                Message4.Text = username + ": " + message;
                            }
                            Message5.Text = username + ": " + message;
                        }
                        Message6.Text = username + ": " + message;
                    }
                    Message7.Text = username + ": " + message;
                }
        }
    }
}
