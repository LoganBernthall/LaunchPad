using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
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
                //Specifying directory to load into when called
                const string DefDir = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\";
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = DefDir;
                //Filter
                fileDialog.Filter = "Shortcut (*.lnk) |*.lnk|Executable (*.exe) | *.exe";
                fileDialog.Title = "Add An App To LaunchPad";
                fileDialog.ShowDialog();

                string FilePath = fileDialog.FileName;
                //string fileExtension = System.IO.Path.GetExtension(FilePath);

                // Example usage
                MessageBox.Show($"Extension: {FilePath}");


            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            SystemFuncs Funcs = new SystemFuncs();
            Funcs.OpenFE();

        }
    }
}