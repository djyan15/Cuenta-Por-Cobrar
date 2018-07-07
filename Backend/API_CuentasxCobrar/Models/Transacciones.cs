using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CuentasxCobrar.Models
{
    
        public class Transacciones
        {
            public int? PageIndex { get; set; }
            public int? PageSize { get; set; }
            public string orderBy0 { get; set; }
            public byte orderByDirection0 { get; set; }


            public int? id_Transaccion { get; set; }
            public string TipoDeMovimiento { get; set; }
            public int? id_TipoDocumento { get; set; }
            public int NumeroDeDocumento { get; set; }
            public string Fecha { get; set; }
            public int? id_Cliente { get; set; }
            public decimal Monto { get; set; }
            public string Estado { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public int Linea { get; set; }
            public int Ultima_Linea { get; set; }
            public int Cantidad_Registros { get; set; }
            public string Fecha_Desde { get; set; }
            public string Fecha_Hasta { get; set; }
        }
    }
