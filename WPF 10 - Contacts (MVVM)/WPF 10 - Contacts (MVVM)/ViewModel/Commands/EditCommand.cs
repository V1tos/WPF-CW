using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_10___Contacts__MVVM_.ViewModel.Commands
{
    public class EditCommand : ICommand
    {
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
        public ContactVM VM { get; set; }
        public EditCommand(ContactVM vm)
        {
            VM = vm;
        }
        public EditCommand()
        {

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string phoneNumber = parameter.ToString();
            VM.EditContact(phoneNumber);
        }
    }
}
