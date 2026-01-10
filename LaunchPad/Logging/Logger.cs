using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

/*
 * This file is a used for a callable class to handle logging throughout the LaunchPad application.
 */

namespace LaunchPad.Logging
{
    public static class Logger
    {

        private static readonly string LogFilePath =
                   Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logger.log");

        // Logs an informational message to the log file
        public static void Info(string Message)
        {
            Write("INFO", Message);
        }

        // Logs a warning message to the log file
        public static void Warning(string Message, Exception? Ex = null)
        {
            Write("INFO", Message);
        }

        // Logs an error message to the log file
        public static void Error(string Message)
        {
            Write("ERROR", Message);
        }

        //Write to logger txt
        private static void Write(string level, string message)
        {
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";

            File.AppendAllText(LogFilePath, line + Environment.NewLine);
        }
    }
}
