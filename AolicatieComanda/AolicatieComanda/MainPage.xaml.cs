using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AolicatieComanda.Models;
using AolicatieComanda.Data;

namespace AolicatieComanda
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            /*
            Feluri felq = new Feluri();
            felq.Pret = 5.5;
            felq.Denumire = "Cartofi prajiti";
            
            
            App.Database.SaveFeluriAsync(felq);*/
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetComenziAsync();
            subcomenziView.ItemsSource = await App.Database.GetSubcomenziAsync();
        }
        async void OnComandaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaComanda
            {
                
            });
        }
        async void OnProduseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaFeluri
            {
                BindingContext = new Feluri()
            });
        }
        async void OnAdaugaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaAdauga
            {
                
            });
        }
    }
}
