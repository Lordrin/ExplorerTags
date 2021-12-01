using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VideoTagPlayer.Main.dialogService
{
    public abstract class DialogViewModelBase
    {
        public string Message
        {
            get;
            private set;
        }

        public DialogViewModelBase(string message)
        {
            this.Message = message;
        }
        public DialogResult UserDialogResult { get; private set; }

        public void CloseDialogWithResult(Window dialog, DialogResult result)
        {
            this.UserDialogResult = result;
            if (dialog != null)
                dialog.DialogResult = true;
        }
    }
}
