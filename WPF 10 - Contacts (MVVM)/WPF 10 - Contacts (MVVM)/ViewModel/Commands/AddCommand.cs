using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_10___Contacts__MVVM_.ViewModel.Commands
{
    public class AddCommand : ICommand
    {
        ContactVM VM { get; set; }
        public AddCommand(ContactVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }


        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                return !String.IsNullOrEmpty(parameter as string);
            }
            return false;
        }

        public void Execute(object parameter)
        {
            VM.AddContact();
        }
    }
}
