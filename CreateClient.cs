using System;
using System.Net.Sockets;
using System.IO;

namespace TalkWithOtherPeopleThing
{
    public partial class CreateClient : MainWindow
    {
        string message;
        TcpClient client = null;
        NetworkStream stream = null;
        BinaryReader binaryReader = null;
        StreamWriter streamWriter = null;
        public CreateClient(string ip, Int32 port)
        {
            client = new TcpClient(ip, port);
            streamWriter = new StreamWriter(client.GetStream(), System.Text.Encoding.ASCII);
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
        void WriteToUI(string message)
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
        public void Read()
        {
            streamWriter.Write(WriteTextBox.Text);
            stream = client.GetStream();
            stream.Flush();
            WriteToUI(WriteTextBox.Text);
            //WriteTextBox.Text = "";
            WriteTextBox.Dispatcher.Invoke(() => { WriteTextBox.Text = ""; });
        }

        public void Send()
        {
            streamWriter.Write(WriteTextBox.Text);
            //this flush might cause problems if not sending delete
            stream.Flush();
        }
    }
}
