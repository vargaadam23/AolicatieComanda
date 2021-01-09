using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AolicatieComanda.Data;
using AolicatieComanda.Models;
using System.IO;
using System.Collections.Generic;
namespace AolicatieComanda
{
    public partial class App : Application
    {
        static ComenziDatabase database;
        public static int nrcomanda;
        public static List<Feluri> subcomenzi;
        public static ComenziDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   ComenziDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "RestaurantApp.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            subcomenzi = new List<Feluri>();
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
