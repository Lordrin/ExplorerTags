using System;
using System.Diagnostics;
using System.IO;

namespace VideoTagPlayer.Main.videoPlayer
{
    internal class ProcessStarter
    {

        //private Process process = new Process();
        internal static void StartProcess(string path)
        {
            Process process = Process.Start(path);
            process.WaitForExit();
            process.Dispose();
        }

        internal static void StartProcess(FileInfo fileInfo)
        {
            Process process = Process.Start(fileInfo.FullName);
            try
            {
                if (process == null)
                {
                    return;
                }
                process.WaitForExit();
                process.Dispose();
            }
            catch(NullReferenceException)
            {
                process = null;
            }
           
        }
        // Configure the process using the StartInfo properties.
        //      process.StartInfo.FileName = "process.exe";
        //      process.StartInfo.Arguments = "-n";
        //      process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
        //      process.Start();
        //      process.WaitForExit();// Waits here for the process to exit.
    }
}
