using BHS.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Xamarin.Forms;

namespace BHS
{
    public class App : Application
    {
        static RootPage MDPage;
        
        public static Page GetMainPage()
        {
            MDPage = new RootPage();
            return MDPage;
        }

        public static bool IsLoggedIn
        {
            get { return !string.IsNullOrWhiteSpace(_Token); }
        }

        public static string _Token { get; set; }

        public static string _UserName { get; set; }

        public static string _PictureUrl { get; set; }

        public static DateTime _DataSenhaExpira { get; set; }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    MDPage.Reload();
                    MDPage.Navigation.PopModalAsync();
                });
            }
        }

        public App()
        {
            // The root page of your application
            MainPage = GetMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
