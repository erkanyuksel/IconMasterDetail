using BHS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BHS.Pages
{
    public partial class Home : BaseContentPage
    {
        public Home()
        {
            InitializeComponent();
            TableView tbv = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot { 
                    new TableSection{
                        Components.createImageView(App._PictureUrl),
                        Components.createEntry(App._UserName),
                        Components.createEntry(App._Token)
                        }
                }
            };

            this.Padding = new Thickness(5, 15);


            Content = tbv;

            DisplayAlert("Alerta", string.Format("Sua senha expira em {0}", App._DataSenhaExpira), "OK");

        }

       

    }
}

