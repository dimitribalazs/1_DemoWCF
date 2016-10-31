using BFH.Demo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
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

namespace BFH.Demo.ClientUI
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

        private void AppDomain_Clicked(object sender, RoutedEventArgs e)
        {
            IDemo proxy = null;
            try
            {
                //create channel erstellt den proxy
                proxy = ChannelFactory<IDemo>.CreateChannel(new BasicHttpBinding(), new EndpointAddress("http://localhost:4711/DemoService"));
                AppDomainNameServer.Text = proxy.GetApplicationDomainName();
            }
            catch (Exception)
            { 
                throw;
            }
            finally
            {
                var channel = proxy as IChannel;
                if (channel != null && channel.State == CommunicationState.Opened)
                {
                    channel.Close();                    
                }
            }
            
        }

        private void GetValue_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void SetValue_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void NextEnum_Clicked(object sender, RoutedEventArgs e)
        {

        }


        private void FillList_Clicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
