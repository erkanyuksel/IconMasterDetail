using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHS.Models.Projetos
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
        public string ProjectName { get; set; }
        public int IDProjeto { get; set; }
    }


}
