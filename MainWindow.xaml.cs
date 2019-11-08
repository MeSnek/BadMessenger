using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Input;


namespace TalkWithOtherPeopleThing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int a = 3;
        public string username;
        public CreateClient client;
        public CreateServer server;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ConnectToOtherPerson(string name, string clientIpString, IPAddress clientIp, IPAddress hostIp, Int32 clientPort, Int32 listenerPort, int clientOrServer)
        {
            //0 = client
            //1 = server
            if (clientOrServer == 0)
            {
                client = new CreateClient(clientIpString, clientPort);
                a = 0;
            }
            else if (clientOrServer == 1)
            {
                server = new CreateServer(hostIp, listenerPort);
                a = 1;
            }
        }
        public void DoWork(CreateServer server)
        {
            Thread serverThread = new Thread(new ThreadStart(serverThreadPoll));
        }
        public void DoWork(CreateClient client)
        {
            Thread clientThread = new Thread(new ThreadStart(clientThreadPoll));
        }
        //we hate threads!
        private void clientThreadPoll()
        {
            client.Poll();
        }
        private void serverThreadPoll()
        {
            server.Poll();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void OnEnterKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (a == 0)
                {
                    client.Send();
                }
                if (a == 1)
                {
                    server.Send();
                }
            }
        }
    }
}