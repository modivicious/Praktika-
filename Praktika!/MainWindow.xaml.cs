using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Praktika
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ParksData.LoadData("ProgramData.json");
            InitializeComponent();
            TechnoPark[] Parks = ParksData.GetParks();
            ListViewTechnoparks.ItemsSource = Parks;
            //Бананы не существуют
        }

        private void DopInfo_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement button = (FrameworkElement)e.Source;
            FrameworkElement grid = (FrameworkElement)button.Parent;
            DopInfo dopInfo = new DopInfo(grid.Tag.ToString());
            dopInfo.Show();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string SearchValue = this.SearchTextBox.Text;
            ListViewTechnoparks.ItemsSource = ParksData.GetParks(SearchValue);
        }
    }
}
  
