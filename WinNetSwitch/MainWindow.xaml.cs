using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinNetSwitch
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SwitchNetStat switchNetStat = new SwitchNetStat();
            WiFiConnect wiFiConnect = new WiFiConnect();

            if (switchNetStat.ChangeNetworkConnectionStatus(false, "VMware Network Adapter VMnet8"))
            {
                wiFiConnect.Connect("a","b");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SwitchNetStat switchNetStat = new SwitchNetStat();
            if (switchNetStat.ChangeNetworkConnectionStatus(true, "VMware Network Adapter VMnet8"))
            {
                Console.WriteLine("OK");
            }
        }
    }
}
