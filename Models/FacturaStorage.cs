using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public static class FacturaStorage
    {
        // Lista estática para almacenar todas las facturas generadas
        public static List<Factura> HistorialFacturas { get; set; } = new List<Factura>();
    }
}
