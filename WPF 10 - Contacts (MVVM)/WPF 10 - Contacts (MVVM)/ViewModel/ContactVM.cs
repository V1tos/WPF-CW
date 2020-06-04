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
        private Contact changingContact;
        bool isVisibleEditPanel = false;
        bool isEnabledMainPanel = true;

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

        public Contact ChangingContact
        {
            get => changingContact;
            set
            {
                changingContact = value;
                OnNotify();
            }
        }

        public bool IsVisibleEditPanel
        {
            get => isVisibleEditPanel;
            set
            {
                isVisibleEditPanel = value;
                OnNotify();
            }
        }
        public bool IsEnabledMainPanel
        {
            get => isEnabledMainPanel;
            set
            {
                isEnabledMainPanel = value;
                OnNotify();
            }
        }
        public AddCommand AddCommand { get; set; }
        public ClearCommand ClearCommand { get; set; }
        public DeleteCommand DeleteCommand { get; set; }
        public SaveCommand SaveCommand { get; set; }
        public CloseCommand CloseCommand { get; set; }

        public ContactVM()
        {
            AddCommand = new AddCommand(this);
            ClearCommand = new ClearCommand(this);
            DeleteCommand = new DeleteCommand(this);
            SaveCommand = new SaveCommand(this);
            CloseCommand = new CloseCommand(this);
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
            ClearContact();
        }
        
        public void DeleteSelectedContact(string phoneNumber)
        {
            if (SelectedContact.Phone == phoneNumber&&SelectedContact!=null)
            {
                Contacts.Remove(SelectedContact);
                ClearContact();
            }           
        }

        private void CopyToContact()
        {
            if (SelectedContact != null)
                Contact = new Contact { Name = SelectedContact.Name, Phone = SelectedContact.Phone, Surname = SelectedContact.Surname };
        }

        public void EditContact(string phoneNumber)
        {
            if (SelectedContact.Phone == phoneNumber && SelectedContact != null)
            {
                ChangingContact = new Contact { Name = SelectedContact.Name, Phone = SelectedContact.Phone, Surname = SelectedContact.Surname };
                ClearContact();
                ChangeVisible();
            }
        }
        public void Save()
        {
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (Contacts[i] == SelectedContact)
                {
                    Contacts[i] = SelectedContact = ChangingContact;
                }
            }
            ClearContact();
            ChangeVisible();
        }
        public void ClearContact()
        {
            Contact = new Contact();
        }
        public void Close()
        {
            ChangingContact = null;
            ChangeVisible();
        }
        private void ChangeVisible()
        {
            IsVisibleEditPanel = !IsVisibleEditPanel;
            IsEnabledMainPanel = !IsEnabledMainPanel;
        }
       

       

      


    }
}
