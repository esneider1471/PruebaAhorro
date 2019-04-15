using AccesoDatos.Barrios;
using Entidades.Barrios;
using Entidades.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Barrios
{
  public  class BarriosLog
    {
        public ResultadosEnt CrearBarrio(BarriosEnt barriosEnt) {

            ResultadosEnt Respuesta = new ResultadosEnt();
            BarriosDat barriosDat = new BarriosDat();
            Respuesta = barriosDat.CrearBarrio(barriosEnt);
            return Respuesta;

        }

        public List<BarriosEnt> ListarBarrios() {
            List<BarriosEnt> listaBarrios = new List<BarriosEnt>();
            BarriosDat barriosDat = new BarriosDat();
            listaBarrios = barriosDat.ListarBarrios();
            return listaBarrios;

        }
       
    }
}
