using API_CuentasxCobrar.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace API_CuentasxCobrar.Controllers
{
    public class TransaccionesController : ApiController
    {
        private readonly CXCEntitie db = new CXCEntitie();

        
        [Route("cxc/GetTransaciones")]
        public JsonResult<List<Transacciones>> GetTransacciones([FromUri]Transacciones t)
        {

            List<SqlParameter> parametros = new List<SqlParameter>{
                new SqlParameter("PageIndex", t.PageIndex),
                new SqlParameter("PageSize", t.PageSize),
                 new SqlParameter("orderBy0", t.orderBy0 ?? "" ),
                new SqlParameter("orderByDirection0", Convert.ToInt32(t.orderByDirection0)),
                new SqlParameter("TipoDeMovimiento", t.TipoDeMovimiento ?? ""),
                new SqlParameter("id_TipoDocumento", Convert.ToInt32(t.id_TipoDocumento)),
                 new SqlParameter("Fecha_Desde", t.Fecha_Desde ?? ""),
                  new SqlParameter("Fecha_Hasta",t.Fecha_Hasta ?? "")

            };
            var Transacciones = db.Database.SqlQuery<Transacciones>("Transaciones_Paging_Consulta @PageIndex, @PageSize, @orderBy0, @orderByDirection0, @TipoDeMovimiento, @id_TipoDocumento, @Fecha_Desde, @Fecha_Hasta", parametros.ToArray()).ToList();
         
            return Json(Transacciones);
        }
        [Route("cxc/GetTransId")]
        public JsonResult<List<Transacciones>> GetTransId(int id_Transaccion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_Transaccion", id_Transaccion),
            };
            var Transacciones = db.Database.SqlQuery<Transacciones>("Transacciones_Consulta @id_Transaccion", parametros.ToArray()).ToList();

            return Json(Transacciones);
        }
        [Route("cxc/SetTrans")]
        [HttpPost]
        public JsonResult<Transacciones> SetTrans(Transacciones t)
        {
            Transacciones Transaciones = new Transacciones();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                
                new SqlParameter("TipoDeMovimiento", t.TipoDeMovimiento ),
                new SqlParameter("id_TipoDocumento", Convert.ToInt32(t.id_TipoDocumento)),
                new SqlParameter("NumeroDeDocumento", Convert.ToInt32(t.NumeroDeDocumento)),
                new SqlParameter("id_Cliente", Convert.ToInt32(t.id_Cliente)),
                new SqlParameter("Monto", Convert.ToInt32(t.Monto)),
                     new SqlParameter("Fecha", t.Fecha )


            };
            //try
            //{
                Transaciones = db.Database.SqlQuery<Transacciones>("Transacciones_insertar  @TipoDeMovimiento, @id_TipoDocumento, @NumeroDeDocumento, @id_Cliente, @Monto, @Fecha", parametros.ToArray()).SingleOrDefault();
 

          //  }
            //catch (Exception ex)
            //{
            //    return Json(new Transacciones());
            //}
            return Json(Transaciones);
        }
        [Route("cxc/EditTrans")]
        [HttpPut]
        public JsonResult<List<Transacciones>> EditTrans([FromBody]Transacciones t)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("id_Transaccion", t.id_Transaccion),
                  new SqlParameter("TipoDeMovimiento", t.TipoDeMovimiento ?? "" ),
                new SqlParameter("id_TipoDocumento", Convert.ToInt32(t.id_TipoDocumento)),
                new SqlParameter("NumeroDeDocumento", Convert.ToInt32(t.NumeroDeDocumento)),
                new SqlParameter("id_Cliente", Convert.ToInt32(t.id_Cliente)),
                new SqlParameter("Monto", Convert.ToInt32(t.Monto)),
                     new SqlParameter("Fecha", t.Fecha  )
            };
            var Transaciones = db.Database.SqlQuery<Transacciones>("Transacciones_Edita @id_Transaccion, @TipoDeMovimiento, @id_TipoDocumento, @NumeroDeDocumento, @id_Cliente, @Monto, @Fecha", parametros.ToArray()).ToList();
            return Json(Transaciones);
        }
        [Route("cxc/DeleteTrans")]
        public JsonResult<List<Transacciones>> DeleteTrans(int id_Transaccion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_Transaccion", id_Transaccion)
            };
            var Transaciones = db.Database.SqlQuery<Transacciones>("Transacciones_Elimina @id_Transaccion", parametros.ToArray()).ToList();

            return Json(Transaciones);
        }


    }
}
