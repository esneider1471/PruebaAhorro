using AccesoDatos.Socios;
using Entidades.Resultados;
using Entidades.Socios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Socios
{
    public class SociosLog
    {
        public ResultadosEnt InsertarSocio(SociosEnt sociosEnt) {
            ResultadosEnt resultadosEnt = new ResultadosEnt();
            SociosDat sociosDat = new SociosDat();
            resultadosEnt= sociosDat.InsertarSocio(sociosEnt);
            return resultadosEnt;

        }

        public ResultadosEnt EliminarSocio(SociosEnt sociosEnt)
        {
            ResultadosEnt resultadosEnt = new ResultadosEnt();
            SociosDat sociosDat = new SociosDat();
            resultadosEnt = sociosDat.EliminarSocio(sociosEnt);
            return resultadosEnt;

        }

        public ResultadosEnt ActualizarSocio(SociosEnt sociosEnt)
        {
            ResultadosEnt resultadosEnt = new ResultadosEnt();
            SociosDat sociosDat = new SociosDat();
            resultadosEnt = sociosDat.ActualizarSocio(sociosEnt);
            return resultadosEnt;

        }

        public List<SociosEnt> ListarSocios() {
            SociosDat sociosDat = new SociosDat();
            List<SociosEnt> sociosEnt = new List<SociosEnt>();
            sociosEnt = sociosDat.ListarSocios();
            return sociosEnt;

        }
    }

}
