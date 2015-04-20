using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHS.Models.Gestores
{

    public class Rootobject
    {
        public D d { get; set; }
    }

    public class D
    {
        public Result[] results { get; set; }
    }

    public class Result
    {
        public Colaborador_X0020_Formul_X00e1_R Colaborador_x0020_Formul_x00e1_r { get; set; }
    }

    public class Colaborador_X0020_Formul_X00e1_R
    {
        public __Metadata1 __metadata { get; set; }
        public string Title { get; set; }
    }

    public class __Metadata1
    {
        public string id { get; set; }
        public string type { get; set; }
    }

}
