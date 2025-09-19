using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entity
{
    public class oPedido
    {
        public int idPedido { get; set; }
        public int idUsuario { get; set; }
        public int idCaja { get; set; }
        public string numeroPedido { get; set; }
        public decimal subTotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal totalGeneral { get; set; }
        public decimal montoEfectivo { get; set; }
        public decimal montoTarjeta { get; set; }
        public decimal cambio { get; set; }
        public Boolean estado { get; set; }
        public DataTable detalles { get; set; }
    }
}
