using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_CuentasxCobrar.Models;
using System.Web.Http.Results;
using System.Data.SqlClient;

namespace API_CuentasxCobrar.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly CXCEntitie db = new CXCEntitie();
      [HttpGet]
        [Route("login/user")]
        public JsonResult<List<Usuario>> Login([FromUri]Usuario u)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@username", u.username),
                new SqlParameter("@contrasena", u.contrasena)


            };
            var usuario = db.Database.SqlQuery<Usuario>("Usuario_Login @username, @contrasena", parametros.ToArray()).ToList();

            return Json(usuario);
        }
        [Route("CXC/GetCXC")]
        public JsonResult<List<Clientes>> GetClientes([FromUri]Clientes c)
        {
            List<SqlParameter> parametros = new List<SqlParameter>{
                new SqlParameter("PageIndex", c.PageIndex),
                new SqlParameter("PageSize", c.PageSize),
                new SqlParameter("orderBy0", c.orderBy0 ?? ""),
                new SqlParameter("orderByDirection0", Convert.ToInt32(c.orderByDirection0)),
                new SqlParameter("id_Cliente", Convert.ToInt32(c.id_Cliente)),
                new SqlParameter("Nombre", c.Nombre ?? ""),
                new SqlParameter("Cedula", c.Cedula ?? "")
               
            };
            var Clientes = 
           db.Database.SqlQuery<Clientes>("Clientes_pagging @PageIndex, @PageSize, @orderBy0, @orderByDirection0, @id_Cliente, @Nombre, @Cedula", parametros.ToArray()).ToList();


            return Json(Clientes);
        }
        [Route("CXC/GetCXCId")]
        public JsonResult<List<Clientes>> GetCXCId(int id_Cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_Cliente", id_Cliente),
            };
            var Clientes = db.Database.SqlQuery<Clientes>("Clientes_consulta @id_Cliente", parametros.ToArray()).ToList();

            return Json(Clientes);
        }
        [Route("Clientes/SetClientes")]
        [HttpPost]
        public JsonResult<Clientes> SetClientes(Clientes c)
        {
            Clientes clientes = new Clientes();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Nombre", c.Nombre),
                new SqlParameter("@Cedula", c.Cedula ?? ""),
                new SqlParameter("@LimiteDeCredito", c.LimiteDeCredito)
            };
            try
            {
                clientes = db.Database.SqlQuery<Clientes>("Clientes_insertar @Nombre, @Cedula, @LimiteDeCredito", parametros.ToArray()).SingleOrDefault();

            }
            catch(Exception ex)
            {
                return Json(new Clientes());
            }
            return Json(clientes);
        }
        [Route("Clientes/EditClientes")]
        [HttpPut]
        public JsonResult<List<Clientes>> EditClientes([FromBody]Clientes c)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
               new SqlParameter("id_Cliente", Convert.ToInt32(c.id_Cliente)),
               new SqlParameter("@Nombre", c.Nombre ?? ""),
               new SqlParameter("@Cedula", c.Cedula ?? ""),
               new SqlParameter("LimiteDeCredito", c.LimiteDeCredito)
            };
            var cliente = db.Database.SqlQuery<Clientes>("Clientes_Edita @id_Cliente, @Nombre, @Cedula, @LimiteDeCredito", parametros.ToArray()).ToList();
            return Json(cliente);
        }
        [Route("Clientes/DeleteCliente")]
        public JsonResult<List<Clientes>> DeleteCliente(int id_Cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_Cliente", id_Cliente)
            };
            var clientes = db.Database.SqlQuery<Clientes>("Clientes_elimina @id_Cliente", parametros.ToArray()).ToList();

            return Json(clientes);
        }

        
    }
}
