using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models
{
    public class Inventario
    {
        public string CodCia { get; set; }
        public string CompaniaVenta3 { get; set; }
        public string AlmacenVenta { get; set; }
        public string TipoMovimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string CodItem2 { get; set; }
        public string Proveedor { get; set; }
        public string AlmacenDestino { get; set; }
        public int? Cantidad { get; set; }
        public string? DocRef1 { get; set; }
        public string? DocRef2 { get; set; }
        public string? DocRef3 { get; set; }
        public string? DocRef4 { get; set; }
        public string? DocRef5 { get; set; }
        public DateTime? FechaTransaccion { get; set; }
    }
}
