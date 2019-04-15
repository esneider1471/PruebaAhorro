using Entidades.Resultados;
using Entidades.Socios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1.Interfaces
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISocio_R" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISocio_R
    {

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        ResultadosEnt InsertarSocio(SociosEnt sociosEnt);
    }
}
