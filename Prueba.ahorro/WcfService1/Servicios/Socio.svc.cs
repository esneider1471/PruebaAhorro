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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Socio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Socio.svc o Socio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Socio : ISocio
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
