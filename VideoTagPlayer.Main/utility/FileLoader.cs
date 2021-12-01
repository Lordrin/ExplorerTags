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
        private IVideoTagRepository _tagRepository;

        public FileLoader()
        {
            Files = new List<FileInfo>();
            LoadLastPath();
            if(!LastPath.Equals("") && LastPath != null)
            {
                LoadFromDisk(this.LastPath);
            }
        }
        public void OpenDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "( *.mp4) |  *.mp4",
                FilterIndex = 1
            };
            // openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                string sFileName = openFileDialog1.FileName;
                //string[] arrAllFiles = openFileDialog1.FileNames; //used when Multiselect = true  
                string folderPath = Path.GetDirectoryName(sFileName);
                LoadFromDisk(folderPath);
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
        private void LoadFromDisk(String path)
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
                // check and add to database
                // add path to table
                // var databaseFiles = 
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
