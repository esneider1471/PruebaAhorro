using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Socios
{
  public  class SociosEnt
    {
        public int IdSocio { get; set; }
        public string NomSocio { get; set; }
	    public string Cedula { get; set; }
	    public int IdBarrio { get; set; }
        public string NomBarrio { get; set; }
	    public string ValAhorro { get; set; }
	    public string Direccion { get; set; }

    }
}
