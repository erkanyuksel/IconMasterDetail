using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BHS.Pages
{
    public class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            var menuPage = new MenuPage();

            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as Utils.MenuItem, sender as ListView);


            Master = menuPage;
            Detail = new NavigationPage(new Home());

        }

        public void Reload()
        {
            var menuPage = new MenuPage();

            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as Utils.MenuItem, sender as ListView);


            Master = menuPage;
            Detail = new NavigationPage(new Home());
        }

        void NavigateTo(Utils.MenuItem menu, ListView sender)
        {
            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            Detail = new NavigationPage(displayPage);

            IsPresented = false;

            //var x = sender.Cell
            //    x.Back


        }
    }
}
