using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AolicatieComanda.Models;
using AolicatieComanda.Data;

namespace AolicatieComanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaAdauga : ContentPage
    {
        public PaginaAdauga()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(denumire.Text) || String.IsNullOrEmpty(pret.Text))
            {
                DisplayAlert(" ", "Introduceti datele!", "OK");
            }
            else
            {
                    double price;
                    bool isDouble = Double.TryParse(pret.Text, out price);
                if (isDouble)
                {
                        Feluri fel = new Feluri();
                    fel.Denumire = denumire.Text;
                    fel.Pret = price;
                        App.Database.SaveFelAsync(fel);
                   
                        DisplayAlert(" ", "Produsul a fost introdus!", "OK");
                    denumire.Text = "";
                    pret.Text = "";
                }
                else
                {
                    DisplayAlert(" ", "Introduceti un numar valid!", "OK");
                }
            }
            
               
            
        }
    }
}