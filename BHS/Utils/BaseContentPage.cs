using BHS.Forms;
using BHS.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BHS.Utils
{
    public class BaseContentPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (!App.IsLoggedIn)
            //{
            //    Navigation.PushModalAsync(new LoginPage());
            //}
        }
    }
}
