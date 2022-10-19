using Java.IO;
using KeyIdeasApp.Models;
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
    public partial class UpdateSQL : ContentPage
    {
        public UpdateSQL()
        {
            InitializeComponent();
        }

        private async void BtnSub(object sender,EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Uid.Text))
            {
                System.Console.WriteLine("ID taken successfully");
                int val = Int16.Parse(Uid.Text);
                if(val>0 && val < 11)
                {
                    int c = 0;
                    OneCallSQL oneCallSQL = App.Database.Get(val);
                    if (!string.IsNullOrWhiteSpace(Uname.Text)) { oneCallSQL.name = Uname.Text;c += 1; }
                    if (!string.IsNullOrWhiteSpace(Uusername.Text)) { oneCallSQL.username = Uusername.Text;c += 1; }
                    if (!string.IsNullOrWhiteSpace(Uemail.Text)) { oneCallSQL.email = Uemail.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Ustreet.Text)) { oneCallSQL.street = Ustreet.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Usuite.Text)) { oneCallSQL.suite = Usuite.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Ucity.Text)) { oneCallSQL.city = Ucity.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Uzc.Text)) { oneCallSQL.zipcode = Uzc.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Ulat.Text)) { oneCallSQL.lat = Ulat.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Ulng.Text)) { oneCallSQL.lng = Ulng.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Uphone.Text)) { oneCallSQL.phone = Uphone.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Uwebsite.Text)) { oneCallSQL.website = Uwebsite.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Ucname.Text)) { oneCallSQL.cname = Ucname.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Ucp.Text)) { oneCallSQL.catchPhrase = Ucp.Text; c += 1; }
                    if (!string.IsNullOrWhiteSpace(Ubs.Text)) { oneCallSQL.bs = Ubs.Text; c += 1; }

                    if (App.Database.Update(oneCallSQL) == c)
                    {
                        await DisplayAlert("Status","User's Data Updated Successfully","OK");
                        Navigation.PushAsync(new UserPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please Enter Data Carefully", "OK");
                        System.Console.WriteLine("Some Error Occured");
                        Navigation.PushAsync(new UpdateSQL());
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Please Enter Correct User Id", "OK");
                    System.Console.WriteLine("Enter Correct Id");
                    Navigation.PushAsync(new UpdateSQL());
                }


            }
            else
            {
                await DisplayAlert("Error", "Please Enter Details Carefully", "OK");
                System.Console.WriteLine("Error! Please enter details correctly");
            }
        }
    }
}