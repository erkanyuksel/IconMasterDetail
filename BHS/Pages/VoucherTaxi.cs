using BHS.Models;
using BHS.Utils;
using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BHS.Pages
{
    public class VoucherTaxi : BaseContentPage
    {
        public static List<string> listaGerentes { get; set; }

        public static List<string> listaProjetos { get; set; }

        public VoucherTaxi()
        {

            listaGerentes = new List<string>()
            {

            };
            listaProjetos = new List<string>()
            {

            };



            executeService();
            CriarTela();

        }

        public void CriarTela()
        {
            if (listaGerentes.Count > 0 && listaProjetos.Count > 0)
            {
                TableView tbv = new TableView
                {
                    Intent = TableIntent.Form,
                    Root = new TableRoot { 
                        new TableSection{
                            Components.createList(listaGerentes,"Gerentes - Selecione"),
                            Components.createList(listaProjetos,"Projetos - Selecione")
                        }
                    }
                };

                this.Padding = new Thickness(5, 15);


                Content = tbv;
            }
        }

        /// <summary>
        /// Método que popula o Picker de Gerentes
        /// </summary>
        public void executeService()
        {
            try
            {
                Service1Client client = new Service1Client(
               new BasicHttpBinding(),
               new EndpointAddress("http://www.rm.eti.br/serviceSP/Service1.svc"));

                // Call the proxy - this should use the async versions
                client.GetGestoresCompleted += GetGestoresCompletedImp;
                client.GetGestoresAsync();

                client.GetProjetosCompleted += GetProjetosCompletedImp;
                client.GetProjetosAsync();


            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                if (e.InnerException != null)
                    Debug.WriteLine(e.InnerException.Message);
                throw;
            }

        }

        private void GetProjetosCompletedImp(object sender, GetProjetosCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string error = null;
                if (e.Error != null)
                    error = e.Error.Message;
                else if (e.Cancelled)
                    error = "Cancelled";

                if (!string.IsNullOrEmpty(error))
                {
                    await DisplayAlert("Error", error, "OK", "Cancel");
                }
                else
                {
                    popularProjetos(e.Result);
                }
            });
        }

        private void popularProjetos(string stringJson)
        {
            try
            {

                var obj = Newtonsoft.Json.Linq.JObject.Parse(stringJson);

                var teste = Newtonsoft.Json.JsonConvert.DeserializeObject<BHS.Models.Projetos.Rootobject>(obj.ToString());

                foreach (var item in teste.d.results)
                {
                    listaProjetos.Add(item.ProjectName);
                }
                CriarTela();

            }
            catch (Exception e)
            {

                throw;
            }
        }

        private void GetGestoresCompletedImp(object sender, GetGestoresCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string error = null;
                if (e.Error != null)
                    error = e.Error.Message;
                else if (e.Cancelled)
                    error = "Cancelled";

                if (!string.IsNullOrEmpty(error))
                {
                    await DisplayAlert("Error", error, "OK", "Cancel");
                }
                else
                {
                    popularGerente(e.Result);
                }
            });
        }

        private void popularGerente(string stringJson)
        {
            try
            {

                var obj = Newtonsoft.Json.Linq.JObject.Parse(stringJson);

                var teste = Newtonsoft.Json.JsonConvert.DeserializeObject<BHS.Models.Gestores.Rootobject>(obj.ToString());

                foreach (var item in teste.d.results)
                {
                    listaGerentes.Add(item.Colaborador_x0020_Formul_x00e1_r.Title);
                }
                CriarTela();

            }
            catch (Exception e)
            {

                throw;
            }
        }
        static string _FormatBasicAuth(string domain, string user, string password)
        {
            const string format0 = @"{0}\{1}";
            const string format1 = @"{0}:{1}";
            string userName = string.Format(format0, domain, user);

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(

                           string.Format(format1, userName, password)));

        }
        private static readonly TaskScheduler UIScheduler = TaskScheduler.FromCurrentSynchronizationContext();

    }
}
