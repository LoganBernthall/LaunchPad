using LaunchPad.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static LaunchPad.MainWindow;

namespace LaunchPad
{
    /// <summary>
    /// Interaction logic for DeleteAppsWindow.xaml
    /// </summary>
    public partial class DeleteAppsWindow : Window
    {
        public class DelFuncs
        {
            //A class for callable program functions for the delect Window
        }
        private void LoadListView()
        {
            //Code to load ListView with apps from ProgsLaunch.txt
            //Function also cuts the path down slightly
            ListViewAppsToDel.Items.Clear();

            foreach (string FullProgPath in File.ReadAllLines("ProgsLaunch.txt"))
            {
                if (string.IsNullOrWhiteSpace(FullProgPath)) continue;

                string DisplayName = System.IO.Path.GetFileName(FullProgPath);

                ListViewAppsToDel.Items.Add(DisplayName);
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
            string AppName = (string)ListViewAppsToDel.SelectedItem;
            //Function to delete selected app from ProgsLaunch.txt
            if (string.IsNullOrWhiteSpace(AppName)) return;
            List<string> AllLines = new List<string>(File.ReadAllLines("ProgsLaunch.txt"));
            for (int i = AllLines.Count - 1; i >= 0; i--)
            {
                string FullProgPath = AllLines[i];
                string DisplayName = System.IO.Path.GetFileName(FullProgPath);
                if (DisplayName.Equals(AppName, StringComparison.OrdinalIgnoreCase))
                {
                    AllLines.RemoveAt(i);
                }
            }
            File.WriteAllLines("ProgsLaunch.txt", AllLines);
            Logger.Info($"Deleted {AppName} from ProgsLaunch.txt.");

        }
    }
}
