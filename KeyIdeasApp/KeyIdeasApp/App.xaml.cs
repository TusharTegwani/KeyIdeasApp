using KeyIdeasApp.Datas;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyIdeasApp
{
    public partial class App : Application
    {

        private static Database database;
        public static Database Database
        {
            get {
              
                if(database == null) { database = new Database(); }
            return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
