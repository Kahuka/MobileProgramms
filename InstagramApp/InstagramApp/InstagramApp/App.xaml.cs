using InstagramApp.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramApp
{
    public partial class App : Application
    {
        static ApplicationDatabase _dbContext;
        public static ApplicationDatabase dbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new ApplicationDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3"));
                }
                return _dbContext;
            }
        }
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new LogInPage());
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
