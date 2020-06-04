using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_10___Contacts__MVVM_.ViewModel.Commands
{
    public class CloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        ContactVM VM { get; set; }
        public CloseCommand(ContactVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Close();
        }
    }
}
