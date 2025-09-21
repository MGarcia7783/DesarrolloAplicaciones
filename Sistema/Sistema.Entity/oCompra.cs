using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entity
{
    public class oCompra
    {
        public  int idCompra { get; set; }
        public string numeroFactura { get; set; }
        public DateTime fechaCompra { get; set; }
        public string observacion { get; set; }
        public decimal subTotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal totalGeneral { get; set; }
        public int idUsuario { get; set; }
        public DataTable detalleCompra { get; set; }
    }
}

