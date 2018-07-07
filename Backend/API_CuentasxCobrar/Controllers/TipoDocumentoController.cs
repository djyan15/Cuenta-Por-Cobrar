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
    public class TipoDocumentoController : ApiController
    {
        private readonly CXCEntitie db = new CXCEntitie();

        [Route("TipDoc/GetTipDoc")]
        public JsonResult<List<TipoDocumentos>> GetTipoDocumentos([FromUri]TipoDocumentos TD)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("PageIndex", TD.PageIndex),
                new SqlParameter("PageSize", TD.PageSize),
                new SqlParameter("orderBy0", TD.orderBy0 ?? ""),
                new SqlParameter("orderByDirection0", Convert.ToInt32(TD.orderByDirection0)),
                new SqlParameter("id_TipoDocumento", Convert.ToInt32(TD.id_TipoDocumento)),
                new SqlParameter("Descripcion", TD.Descripcion ?? ""),
                new SqlParameter("CuentaContable", TD.CuentaContable ?? "")
            };
            var TipoDocumentos = db.Database.SqlQuery<TipoDocumentos>
            ("TipoDocumentos_Paging @PageIndex, @PageSize, @orderBy0, @orderByDirection0, @id_TipoDocumento, @Descripcion, @CuentaContable", parametros.ToArray()).ToList();

            return Json(TipoDocumentos);
        }
        [HttpGet]
        [Route("TipDoc/GetTipDocId")]
        public JsonResult<List<TipoDocumentos>> GetTipDocId(int id_TipoDocumento)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_TipoDocumento", id_TipoDocumento),
            };
            var TipDoc = db.Database.SqlQuery<TipoDocumentos>(" TipoDocumentos_Consulta @id_TipoDocumento", parametros.ToArray()).ToList();

            return Json(TipDoc);
        }
        [Route("TipDoc/SetTipDoc")]
        [HttpPost]
        public JsonResult<TipoDocumentos> SetTipDoc(TipoDocumentos TD)
        {
            TipoDocumentos TipDocs = new TipoDocumentos();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Descripcion", TD.Descripcion),
                new SqlParameter("@CuentaContable", TD.CuentaContable)
            };
            try
            {
                TipDocs = db.Database.SqlQuery<TipoDocumentos>("TipoDocumentos_Inserta @Descripcion, @CuentaContable", parametros.ToArray()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                return Json(new TipoDocumentos());
            }

            return Json(TipDocs);
        }
        [Route("TipDoc/EditTipDoc")]
        [HttpPut]
        public JsonResult<List<TipoDocumentos>> EditTipDoc([FromBody]TipoDocumentos TD)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_TipoDocumento", Convert.ToInt32(TD.id_TipoDocumento)),
                new SqlParameter("@Descripcion", TD.Descripcion ?? ""),
                new SqlParameter("@CuentaContable", TD.CuentaContable ?? "")
            };
            var TipDocs = db.Database.SqlQuery<TipoDocumentos>("TipoDocumentos_edita @id_TipoDocumento, @Descripcion, @CuentaContable", parametros.ToArray()).ToList();
            return Json(TipDocs);
        }
        [Route("TipDoc/DeleteTipDoc")]
        public JsonResult<List<TipoDocumentos>> DeleteTipDoc(int id_TipoDocumento)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_TipoDocumento", id_TipoDocumento)
            };
            var TipDocs = db.Database.SqlQuery<TipoDocumentos>("TipoDocumentos_elimina @id_TipoDocumento", parametros.ToArray()).ToList();

            return Json(TipDocs);
        }
      
    }
}
