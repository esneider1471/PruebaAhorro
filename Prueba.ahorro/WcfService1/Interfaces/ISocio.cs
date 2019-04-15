using Entidades.Resultados;
using Entidades.Socios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1.Interfaces
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISocio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISocio
    {
        [OperationContract]
        ResultadosEnt InsertarSocio(SociosEnt sociosEnt);

       
    }
}
