using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;


namespace TalkWithOtherPeopleThing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ConnectToOtherPerson(string name, IPAddress clientIp, IPAddress hostIp, int port)
        {
            //listener opens on HOST ipaddress 
            TcpListener tcpListener = new TcpListener(hostIp, port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(null, null);
            
            //recipients ip goes in client
            TcpClient myTcpClient = new TcpClient();
            myTcpClient.BeginConnect(clientIp, port, null, null);
            System.Threading.Thread.Sleep(5000);
            if (myTcpClient.Connected)
            {
                MessageBox.Show("You're connected!");
            }
            else
            {
                MessageBox.Show("You weren't able to connect");
                System.Windows.Application.Current.Shutdown();
            }
            //todo: actually send messages lol
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
