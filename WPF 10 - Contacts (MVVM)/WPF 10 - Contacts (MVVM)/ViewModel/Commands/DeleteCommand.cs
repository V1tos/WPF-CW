using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_10___Contacts__MVVM_.Model;

namespace WPF_10___Contacts__MVVM_.ViewModel.Commands
{
    public class DeleteCommand : ICommand
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
        public DeleteCommand(ContactVM vm)
        {
            VM = vm;
        }
        public DeleteCommand()
        {

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string phoneNumber = parameter.ToString();
            VM.DeleteSelectedContact(phoneNumber);
        }
    }
}
