using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoTagPlayer.Main.utility
{
    public class OpenExplorerDialog
    {
        public void OpenDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "( *.mp4) |  *.mp4",
                FilterIndex = 1
            };
            // openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                //string[] arrAllFiles = openFileDialog1.FileNames; //used when Multiselect = true  
                string folderPath = Path.GetDirectoryName(sFileName);
                new FileLoader().LoadFromDisk(folderPath);
            }

        }
    }
}
