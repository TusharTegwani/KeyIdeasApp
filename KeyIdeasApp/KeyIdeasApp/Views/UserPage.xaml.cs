using Android.Views;
using Android.Widget;
using KeyIdeasApp.Datas;
using KeyIdeasApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyIdeasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            //BindingContext = new UserViewModel();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           

            llview.ItemsSource = App.Database.GetAll();
        }

        public void DeleteButton(object sender, EventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(ToDel.Text) && ToDel.Text.Length<=2)
            {
                Console.WriteLine(ToDel.Text); 
                try
                {
                    int val=Int16.Parse(ToDel.Text);
                    if (val >= 1 && val <= 10)
                    {
                        Console.WriteLine(val);
                        App.Database.Delete(val);
                        ToDel.Text = String.Empty;  
                        ToDel.Placeholder = "Enter the ID you wish to delete!";
                    }
                    else
                    {
                        ToDel.Text = string.Empty;
                        ToDel.Placeholder = "Enter a valid ID between 1-10";


                    }
                }
                catch(Exception ex)
                {
                    ToDel.Text = string.Empty;
                    ToDel.Placeholder = "Enter a valid ID in number (i.e 1-10)";
                    Console.WriteLine(ex);
                }
            }
            else
            {
                ToDel.Text = string.Empty;
                ToDel.Placeholder = "Enter a valid ID";
            }


            
            llview.ItemsSource = App.Database.GetAll();
        }


        public void BtnR(object sender, EventArgs args)
        {
            ToDel.Text = "";
            Console.WriteLine("Reset Pressed");
            App.Database.FullDelete();
            Database database = new Database();
            llview.ItemsSource = App.Database.GetAll();
        }
        private void ButtonUpdate(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UpdateSQL());
        }
    }
        
}