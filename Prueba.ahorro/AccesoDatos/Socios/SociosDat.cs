using Entidades.Resultados;
using Entidades.Socios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Socios
{
    public class SociosDat
    {
        public ResultadosEnt InsertarSocio(SociosEnt SociosEnt) {
            ResultadosEnt resultadosEnt = new ResultadosEnt();
            Conexion dbconexion = new Conexion();
            try {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("NomSocio", SociosEnt.NomSocio);
                parametros.Add("Cedula", SociosEnt.Cedula);
                parametros.Add("IdBarrio", SociosEnt.IdBarrio);
                parametros.Add("ValAhorro", SociosEnt.ValAhorro);
                parametros.Add("Direccion", SociosEnt.Direccion);
                dbconexion.EjecutarStoredProcedure("InsertarSocio",parametros);
                resultadosEnt.Resultado = 1;
                return resultadosEnt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ResultadosEnt EliminarSocio(SociosEnt SociosEnt)
        {
            ResultadosEnt resultadosEnt = new ResultadosEnt();
            Conexion dbconexion = new Conexion();
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("IdSocio", SociosEnt.IdSocio);
                dbconexion.EjecutarStoredProcedure("EliminarSocio", parametros);
                resultadosEnt.Resultado = 1;
                return resultadosEnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResultadosEnt ActualizarSocio(SociosEnt SociosEnt)
        {
            ResultadosEnt resultadosEnt = new ResultadosEnt();
            Conexion dbconexion = new Conexion();
            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("IdSocio", SociosEnt.IdSocio);
                parametros.Add("NomSocio", SociosEnt.NomSocio);
                parametros.Add("Cedula", SociosEnt.Cedula);
                parametros.Add("IdBarrio", SociosEnt.IdBarrio);
                parametros.Add("ValAhorro", SociosEnt.ValAhorro);
                parametros.Add("Direccion", SociosEnt.Direccion);
                dbconexion.EjecutarStoredProcedure("ActualizarSocio", parametros);
                resultadosEnt.Resultado = 1;
                return resultadosEnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SociosEnt> ListarSocios()
        {

            List<SociosEnt> sociosEnt = new List<SociosEnt>();
            Conexion dbconexion = new Conexion();
            try
            {
                using (DataTable dato = dbconexion.EjecutarStoredProcedureDT("ConsultarSocio", null))
                {
                    if (dato.Rows.Count > 0) {
                        sociosEnt = (from item in dato.AsEnumerable()
                                     select new SociosEnt
                                     {
                                         IdSocio = (int)item["ISocio"],
                                         NomSocio = item["NomSocio"].ToString().Trim(),
                                         Cedula = item["Cedula"].ToString().Trim(),
                                         NomBarrio = item["NomBarrio"].ToString().Trim(),
                                         ValAhorro = item["valAhorro"].ToString().Trim(),
                                         Direccion = item["Direccion"].ToString().Trim()

                                     }).ToList();
                    }
                }
                           
            } catch (Exception ex) 
                {
                 throw ex;
                }
                return sociosEnt;
            
        }
    }
}
