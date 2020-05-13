using System;
using System.Windows;
using System.Windows.Navigation;
using System.Diagnostics;

namespace Praktika
{
    public partial class DopInfo : Window
    {
        public DopInfo(string name)
        {
            InitializeComponent();
            TechnoPark[] Parks = ParksData.GetParks(name);
            AdditionalInfo.ItemsSource = Parks;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start("https://" + e.Uri.ToString());
            e.Handled = true;
        }
    }
}
