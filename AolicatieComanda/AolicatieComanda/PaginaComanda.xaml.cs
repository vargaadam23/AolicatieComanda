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
    public partial class PaginaComanda : ContentPage
    {
        public PaginaComanda()
        {
            InitializeComponent();
            
        }
        public void setTotal()
        {
            double suma = App.subcomenzi.Sum(item => item.Pret);
            total.Text = suma.ToString();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource =App.subcomenzi;
            setTotal();
        }
        async void OnDeleteButtonClick(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {

                Feluri fel = e.SelectedItem as Feluri;
                App.subcomenzi.Remove(fel);
                listView.ItemsSource = null;
                listView.ItemsSource = App.subcomenzi;
                setTotal();
                await DisplayAlert("Alert", "Ati sters produsul " + fel.Denumire, "OK");
                
            }
        }
        

        private void Button_Clicked(object sender, EventArgs e)
        { 
            if (String.IsNullOrEmpty(nume.Text)|| String.IsNullOrEmpty(adresa.Text))
            {
                DisplayAlert(" ", "Introduceti datele!", "OK");
            }
            else
            {
                if (App.subcomenzi.Count > 0)
                {
                    Comanda comanda = new Comanda();
                    comanda.Nume_client = nume.Text;
                    comanda.Adresa = adresa.Text;
                    comanda.Total = App.subcomenzi.Sum(item => item.Pret);
                    var rezultat=App.Database.SaveComandaAsync(comanda);
                    rezultat.Wait();
                    int idcomanda = App.Database.GetComanda();
                    Subcomanda sub;

                    foreach (Feluri subcomanda in App.subcomenzi)
                    {
                        sub = new Subcomanda();
                        sub.IdFel = subcomanda.ID;
                        sub.IdComanda = idcomanda;
                        App.Database.SaveSubcomandaAsync(sub);

                    }
                    DisplayAlert(" ", "Comanda a fost introdusa!", "OK");
                    nume.Text = "";
                    adresa.Text = "";
                }
                else
                {
                    DisplayAlert(" ", "Nu aveti produse selectate!", "OK");
                }
            }

            
        }
    }
}