using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoTagPlayer.DataLayer;
using VideoTagPlayer.Main.model;

namespace VideoTagPlayer.Main.utility
{
    public class FileLoader
    {
        public List<FileInfo> Files { get; set; }
        internal string LastPath;
        private readonly string ConfigLocation = "config.ini";

        public void LoadFiles()
        {
            Files = new List<FileInfo>();
            LoadLastPath();
            if (!LastPath.Equals("") && LastPath != null)
            {
                LoadFromDisk(this.LastPath);
            }
        }
        private void UpdateConfig(string path)
        {
            string[] arrLine = File.ReadAllLines(ConfigLocation);
            for (int i = 0; i < arrLine.Length; i++)
            {
                if (arrLine[i].Contains("LastPath"))
                {
                    arrLine[i] = "LastPath = " + path;
                }
            }
            File.WriteAllLines(ConfigLocation, arrLine);
        }
        internal void LoadFromDisk(String path)
        {
            if (!path.Equals(this.LastPath))
            {
                this.LastPath = path;
                UpdateConfig(path);
            }
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                this.Files = directoryInfo.GetFilesByExtensions(".mp4").ToList();
            }
            catch (Exception)
            {
                this.Files = null;
            }
        }

        private string ReadLineFromConfig(string lineToRead)
        {
            try
            {
                using (System.IO.StreamReader file = new StreamReader(ConfigLocation))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var temp = line.Split('=');
                        if (temp[0].Trim(' ').Equals(lineToRead))
                        {
                            return temp[1];
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                return "";
            }
            return "";
        }

        private void LoadLastPath()
        {
            this.LastPath = ReadLineFromConfig("LastPath");
        }
        
    } 
}
