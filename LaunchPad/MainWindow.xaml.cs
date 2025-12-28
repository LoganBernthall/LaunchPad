using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.IO.Enumeration;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Timer = System.Timers.Timer;

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

                //Check condition to see if file exists
                if (!File.Exists(TextPath))
                {
                    MessageBox.Show("LaunchPad has no apps to launch! Please add apps to the launcher");
                    return;
                }

                //Array to store paths
                string[] StoredPaths = File.ReadAllLines(TextPath);

                //Loop through stored paths and launch each app
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
                        if (new FileInfo(TextPath).Length == 0)
                        {
                            MessageBox.Show($"Error launching {Path} : {ex.Message}");
                        }
                        
                    }
                }

            }

            public void PromptTimer() //Function to time 2 minutes then run CMD commands
            {
                Timer cmdTimer = new Timer(120000); // 2 minutes 120000
                cmdTimer.AutoReset = false; 
                cmdTimer.Elapsed += CmdTimer_Elapsed;
                cmdTimer.Start();

            }
            private void CmdTimer_Elapsed(object sender, ElapsedEventArgs e) //Function called after 2 minutes of running for CMD commands
            {
                //SFC
                Process SFC = new Process();
                SFC.StartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "sfc /scannow"
                   
                };

            }


        }
        public MainWindow()
        {
            //Put code here that runs on app start
            InitializeComponent();
            
            SystemFuncs Funcs = new SystemFuncs();
            Funcs.PromptTimer();

        }

        public void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            //When add apps button is clicked - open FE function
            SystemFuncs Funcs = new SystemFuncs();
            Funcs.OpenFE();

        }
        public void Button_Click_Launch(object sender, RoutedEventArgs e)
        {
            //when launch apps button is clicked - launch function
            SystemFuncs Funcs = new SystemFuncs();
            Funcs.Launcher();
        }

        private void Btn_Del_Apps(object sender, RoutedEventArgs e)
        {
            //When delete apps button is clicked - open the text file in notepad for user to edit
            string FileName = "ProgsLaunch.txt";
            Process.Start("notepad.exe", FileName);

        }
    }
}