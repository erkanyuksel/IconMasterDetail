using BHS.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHS.Utils
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            this.Add(new MenuItem()
            {
                Title = "",
                IconSource = "drawable/home.png",
                TargetType = typeof(Home)
            });

            this.Add(new MenuItem()
            {
                Title = "Contatos",
                IconSource = "drawable/agent.png",
                TargetType = typeof(Contatos)
            });

            this.Add(new MenuItem() {
                Title = "Voucher Taxi",
                IconSource = "drawable/tag.png",
                TargetType = typeof(VoucherTaxi)
            });
        }
    }
}
