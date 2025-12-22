using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaunchPad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class SystemFuncs() 
        {
            //A class for callable program functions
            public void OpenFE()
            {
                Process.Start("explorer.exe",
                    @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            SystemFuncs Funcs = new SystemFuncs();
            MessageBox.Show("Hey I have Been Clicked!");
            Funcs.OpenFE();

        }
    }
}