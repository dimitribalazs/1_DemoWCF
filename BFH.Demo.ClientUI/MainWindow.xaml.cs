using BFH.Common;
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

            using (var factory = new WcfFactory<IDemo>())
            {
                AppDomainNameServer.Text = factory.Proxy.GetApplicationDomainName();
            }

        }

        private void GetValue_Clicked(object sender, RoutedEventArgs e)
        {
            //create channel erstellt den 
            var factory = new WcfFactory<IDemo>();
            ValueRead.Text = factory.Proxy.GetValue().ToString();

        }

        private void SetValue_Clicked(object sender, RoutedEventArgs e)
        {
            //create channel erstellt den 
            var factory = new WcfFactory<IDemo>();
            var entry = Convert.ToDouble(ValueEntry.Text);
            factory.Proxy.SetValue(entry);

        }

        private void NextEnum_Clicked(object sender, RoutedEventArgs e)
        {
            //create channel erstellt den 
            using (var factory = new WcfFactory<IDemo>())
            {
                var result = factory.Proxy.NextValue(DemoEnum.Unknown);
                EnumValue.Text = Enum.GetName(typeof(DemoEnum), result);
            }
        }


        private void FillList_Clicked(object sender, RoutedEventArgs e)
        {
            var demoData = new DemoData
            {
                Data = new byte[] { 0x99 },
                Date = DateTime.MinValue,
                EnumValue = DemoEnum.Large,
                Id = Guid.NewGuid(),
                Name = "Test",
                Value = 22d
            };

            var factory = new WcfFactory<IDemo>();
            var result = factory.Proxy.Update(demoData, 20);
            factory.CloseProxy();

            result.ToList().ForEach(r => DetailList.Items.Add(r.Data + " " + r.Date + "  " + r.Id + " " + r.Name + " " + r.Value));
        }
    }
}
