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
using System.Windows.Shapes;
using System.IO;

namespace LaunchPad
{
    /// <summary>
    /// Interaction logic for DeleteAppsWindow.xaml
    /// </summary>
    public partial class DeleteAppsWindow : Window
    {

        private void LoadListView()
        {
            //Code to load ListView with apps from ProgsLaunch.txt
            //Function also cuts the path down slightly
            ListViewAppsToDel.Items.Clear();

            foreach (string FullProgPath in File.ReadAllLines("ProgsLaunch.txt"))
            {
                if (string.IsNullOrWhiteSpace(FullProgPath)) continue;

                string displayName = System.IO.Path.GetFileName(FullProgPath);

                ListViewAppsToDel.Items.Add(displayName);
            }

        }


        public DeleteAppsWindow()
        {
            InitializeComponent();
            LoadListView();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }

        private void BtnDeleteFromLP_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
