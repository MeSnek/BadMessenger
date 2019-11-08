using System;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Net.Sockets;

namespace TalkWithOtherPeopleThing
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        int clientOrServer = 2;
        public WelcomeWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            IPAddress clientIp = IPAddress.Parse(IpTextBox.Text);
            string clientIpString = IpTextBox.Text;
            IPAddress hostIp = IPAddress.Parse(UserIpTextBox.Text);
            Int32 clientPort = Int32.Parse(ClientPortTextBox.Text);
            Int32 listenerPort = Int32.Parse(ListenerPortTextBox.Text);
            //0 for client
            //1 for server
            
            if (ClientRadioButton.IsChecked == true)
            {
                clientOrServer = 0;
            }
            else if (ServerRadioButton.IsChecked == true)
            {
                clientOrServer = 1;
            }

            BeginConnection(name, clientIpString, clientIp, hostIp, clientPort, listenerPort , clientOrServer);
        }
        private void BeginConnection(string name, string clientIpString, IPAddress clientIp, IPAddress hostIp, Int32 clientPort, Int32 listenerPort , int clientOrServer)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ConnectToOtherPerson(name, clientIpString, clientIp, hostIp, clientPort , listenerPort, clientOrServer);
            mainWindow.Show();
            mainWindow.DoWork(mainWindow.client);
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void IpTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
