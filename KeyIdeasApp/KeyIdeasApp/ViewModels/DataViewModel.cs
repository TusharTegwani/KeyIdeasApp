using KeyIdeasApp.Datas;
using KeyIdeasApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using KeyIdeasApp.Models;
using KeyIdeasApp.ViewModels;
using KeyIdeasApp.Views;


namespace KeyIdeasApp.ViewModel
{
    public class DataViewModel : INotifyPropertyChanged
    {
        private static Database database = null;

        private static Database GetConnection()
        {
            if (database == null)
                database = new Database();
            return database;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private IEnumerable<OneCallAPI> _user;

        public IEnumerable<OneCallAPI> OneCallAPI
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        private OneCallAPI selectedUsers;
        public OneCallAPI SelectedUsers
        {
            get { return selectedUsers; }
            set
            {
                selectedUsers = value;
                OnPropertyChanged();
            }
        }
        private OneCallAPI _userr;
        public OneCallAPI Userr
        {
            get { return _userr; }
            set
            {
                _userr = value;
                OnPropertyChanged();
            }
        }
        public DataViewModel()
        {
            //   GetConnection().FullDelete();
            OneCallAPI = GetConnection().GetAll();
        }
        public ICommand SelectionCommand => new Command(GoToUserAsync);
        private async void GoToUserAsync(object obj)
        {

            if (selectedUsers != null)
            {
                var viewModel = new UserViewModel();
                var userPage = new UserPage { BindingContext = viewModel };
                await Shell.Current.Navigation.PushAsync(userPage);
            }
        }




       
    }
}