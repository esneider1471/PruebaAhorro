using Entidades.Resultados;
using Entidades.Socios;
using Logica.Socios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1.Interfaces
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Socio_R" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Socio_R.svc o Socio_R.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Socio_R : ISocio_R
    {
        public ResultadosEnt InsertarSocio(SociosEnt sociosEnt)
        {

            SociosLog socios = new SociosLog();
            ResultadosEnt resultados = new ResultadosEnt();
            try
            {
                return resultados = socios.InsertarSocio(sociosEnt);
            }
            catch (Exception ex)
            {
                resultados.Resultado = 0;
                return resultados;
            }

        }
    }
}
