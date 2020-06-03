using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_10___Contacts__MVVM_.Model;
using WPF_10___Contacts__MVVM_.ViewModel.Commands;

namespace WPF_10___Contacts__MVVM_.ViewModel
{
    public class ContactVM : INotifyPropertyChanged
    {
        private Contact contact;
        private Contact selectedContact;
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        public Contact Contact
        {
            get => contact;
            set
            {
                contact = value;
                OnNotify();
            }
        }
        public Contact SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                CopyToContact();
                OnNotify();
            }
        }
        public AddCommand AddCommand { get; set; }

        public ContactVM()
        {
            AddCommand = new AddCommand(this);
            Contact = new Contact();
            contact = new Contact();
        }
    
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void AddContact()
        {
            Contacts.Add(contact);
            Contact = new Contact();
        }

        private void CopyToContact()
        {
            if (SelectedContact != null)
                Contact = new Contact { Name = SelectedContact.Name, Phone = SelectedContact.Phone, Surname = SelectedContact.Surname };
        }

     
    }
}
