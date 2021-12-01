using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VideoTagPlayer.Main.model;
using VideoTagPlayer.Main.utility;
using VideoTagPlayer.Main.viewModel;

namespace VideoTagPlayer.Main.dialogService
{
    public abstract class DialogViewModelBase : ViewModelBase
    {
        public string Message
        {
            get;
            private set;
        }
        public Video SelectedVideo
        {
            get;
            private set;
        }
        public string NewTag { 
            get; 
            set;  
        }
        public ICommand AddTagCommand { get; set; }

        public DialogViewModelBase(string message, Video video)
        {
            this.Message = message;
            this.SelectedVideo = video;
            this.AddTagCommand = new Command(AddTag);
        }
        public DialogResult UserDialogResult { get; private set; }

        public void CloseDialogWithResult(Window dialog, DialogResult result)
        {
            this.UserDialogResult = result;
            if (dialog != null)
                dialog.DialogResult = true;
        }
        private void AddTag(object tagToAdd)
        {
            var y = NewTag;
            var x = tagToAdd;
        }
    }
}
