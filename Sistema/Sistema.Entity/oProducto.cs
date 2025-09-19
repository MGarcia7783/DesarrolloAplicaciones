using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entity
{
    public class oProducto
    {
        public int idProducto { get; set; }
        public string codigo { get; set; }
        public string nombreProducto { get; set; }
        public int stock { get; set; }
        public int stockMinimo { get; set; }
        public decimal precioCompra { get; set; }
        public decimal precioVenta { get; set; }
        public string formatoCompra { get; set; }
        public string ventaConReceta { get; set; }
        public DateTime fecjaIngreso { get; set; }
        public Boolean tieneVencimiento { get; set; }
        public DateTime? fechaVencimiento { get; set; }
        public int idCategoria { get; set; }
        public int idLaboratorio { get; set; }
        public string impuesto { get; set; }
        public Boolean estado { get; set; }

    }
}
