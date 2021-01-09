using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AolicatieComanda.Models;

namespace AolicatieComanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaFeluri : ContentPage
    {
        public PaginaFeluri()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetFeluriAsync();
        }
        
       
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {

                Feluri fel = e.SelectedItem as Feluri;
                App.subcomenzi.Add(fel);                
                await DisplayAlert(" ","Ati adaugat produsul "+fel.Denumire+" la comanda", "OK");
            }
        }
    }
}