using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ComputerProjects.Models;

namespace ComputerProjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Computer> Computers = new List<Computer>();
        public List<Motherboard> Motherboards = new List<Motherboard>();
        
        public string SelectedProcessor { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            #region declaringObjects
                
            #endregion
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var comboCaseText = comboCase.Text;
            var comboMotherboardText = comboMotherboards.Text;
            var comboProcessorText = comboProcessor.Text;
            var processor = new Processor(){ Model = comboProcessorText };
            var motherboard = new Motherboard(){Name = comboMotherboardText,Processor = processor};
            var computer = new Computer(){Case = comboCaseText, Motherboard = motherboard};

            MessageBox.Show("wartosc to " + comboCaseText + "," +comboMotherboardText+","+comboProcessorText);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void downloadJSONBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void downloadXMLBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteSelectedBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboProcessor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboProcessor_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> processors = new List<string>();
            processors.Add("Intel i3" );
            processors.Add("Intel i5" );
            processors.Add("Intel i7");
            var combo = sender as ComboBox;
            combo.ItemsSource = processors;
            combo.SelectedIndex = 0;
        }

        private void comboMotherboards_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> motherboards = new List<string>();
            motherboards.Add("Asus 432");
            motherboards.Add("Asus X");
            motherboards.Add("MSI 22");
            var combo = sender as ComboBox;
            combo.ItemsSource = motherboards;
            combo.SelectedIndex = 0;
        }

        private void comboCase_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> cases = new List<string>();
            cases.Add("Small case");
            cases.Add("Medium case");
            cases.Add("Big case");
            var combo = sender as ComboBox;
            combo.ItemsSource = cases;
            combo.SelectedIndex = 0;
        }

        private void comboBuilder_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> builds = new List<string>();
            builds.Add("First build");
            builds.Add("Second");
            builds.Add("Third");
            var combo = sender as ComboBox;
            combo.ItemsSource = builds;
            combo.SelectedIndex = 0;
        }
    }
}
