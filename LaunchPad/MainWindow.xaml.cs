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
        public class SystemFuncs 
        {
            //A class for callable program functions
            public void OpenFE() //Funciton opens file explorer for user to click and add apps to Launcher
            {
                //Specifying directory to load into when called
                const string DefDir = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\";
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = DefDir;
                //Filter to EXEs and Shortcuts
                fileDialog.Filter = "Shortcut (*.lnk) |*.lnk|Executable (*.exe) | *.exe";
                fileDialog.Title = "Add An App To LaunchPad";
                fileDialog.ShowDialog();

                //Create string of users input
                string FilePath = fileDialog.FileName;
                //string fileExtension = System.IO.Path.GetExtension(FilePath);

                //Condition
                if (FilePath == "") //Null input - notify user
                {
                    MessageBox.Show($"User did not select a path!");
                    return;
                }
                else //Else - Continue with function logic
                {
                    //Store file paths in a text file
                    File.AppendAllText("ProgsLaunch.txt", FilePath + Environment.NewLine);

                }
            }

            public void Launcher() //Function to launch selected apps -  this will read the text file and launch the stored paths
            {
                //Read the text file for stored paths
                string TextPath = "ProgsLaunch.txt";

                if(!File.Exists(TextPath))
                {
                    MessageBox.Show("LaunchPad has no apps to launch! Please add apps to the launcher");
                    return;
                }

                string[] StoredPaths = File.ReadAllLines(TextPath);

                foreach (string Path in StoredPaths)
                {
                    try
                    { 
                        var ProcessStarter = new ProcessStartInfo
                        {
                            FileName = Path,
                            UseShellExecute = true
                        };

                        Process.Start(ProcessStarter);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show($"Error launching {Path} : {ex.Message}");
                    }
                }

            }

        }
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            SystemFuncs Funcs = new SystemFuncs();
            Funcs.OpenFE();

        }
        public void Button_Click_Launch(object sender, RoutedEventArgs e)
        {
            SystemFuncs Funcs = new SystemFuncs();
            MessageBox.Show($"Launch!");
            Funcs.Launcher();
        }
    }
}