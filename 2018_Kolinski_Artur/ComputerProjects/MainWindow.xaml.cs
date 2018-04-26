﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
        public ObservableCollection<Computer> Computers { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Computers = new ObservableCollection<Computer>();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            
            var processor = new Processor{ Model = comboProcessor.Text };
            var motherboard = new Motherboard{Name = comboMotherboards.Text, Processor = processor};
            var computer = new Computer{Case = comboCase.Text, Motherboard = motherboard};
            Computers.Add(computer);
            
            //MessageBox.Show("Dodany koputer: \n Obudowa: " + comboCase.Text + ",\n Płyta gł.: " + comboMotherboards.Text + ", \n Procesor: "+ comboProcessor.Text);
        }

        private void downloadJSONBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void downloadXMLBtn_Click(object sender, RoutedEventArgs e)
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
            cases.Add("Zalman Z9");
            cases.Add("Sharkoon TG5");
            cases.Add("SilentiumPC RG2");
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

        private void ProjectList_Loaded(object sender, RoutedEventArgs e)
        {
            lvComputers.ItemsSource = Computers;
        }

        private void deleteSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Computer selected = lvComputers.SelectedItems[0] as Computer;
                Computers.Remove(selected);
                lvComputers.ItemsSource = Computers;
                MessageBox.Show("Poprawnie usunięto element");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Wystąpił błąd podczas usuwania!");
            }
            
        }

        private void copySelectedBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Computer selected = lvComputers.SelectedItems[0] as Computer;
                Computer newComputer = selected.DeepClone();
                Computers.Add(newComputer);
                lvComputers.ItemsSource = Computers;
                MessageBox.Show("Poprawnie skopiowano element");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Wystąpił błąd podczas kopiowania!");
            }
        }
    }
}
