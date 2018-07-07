using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CuentasxCobrar.Models
{
    public class Clientes
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public string orderBy0 { get; set; }
        public byte orderByDirection0 { get; set; }


        public int? id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public decimal LimiteDeCredito { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }

        public int Linea { get; set; }
        public int Ultima_Linea { get; set; }
        public int Cantidad_Registros { get; set; }

    }
}