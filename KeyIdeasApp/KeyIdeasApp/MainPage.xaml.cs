using Android.Content.Res;
using KeyIdeasApp.ViewModels;
using KeyIdeasApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KeyIdeasApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
         private void ButtonClicked(object sender, EventArgs e)
        {
            var userList=new UserViewModel();
            Console.WriteLine(userList);
          Navigation.PushAsync(new UserPage()); 
        }

        private void ButtonEditor(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImageEditor()); 
        }
    }
}
