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
        public WelcomeWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            IPAddress clientIp = IPAddress.Parse(IpTextBox.Text);
            IPAddress hostIp = IPAddress.Parse(HostIpTextBox.Text);
            Int32 port = Int32.Parse(PortTextBox.Text);

            BeginConnection(name, clientIp, hostIp, port);
        }
        private void BeginConnection(string name, IPAddress clientIp, IPAddress hostIp, int port)
        {   
            MainWindow mainWindow = new MainWindow();
            mainWindow.ConnectToOtherPerson(name, clientIp, hostIp, port);
            mainWindow.Show();
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
