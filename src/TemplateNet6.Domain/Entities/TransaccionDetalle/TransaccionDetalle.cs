using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateNet6.Domain.Entities.TransaccionDetalle
{
    public class TransaccionDetalle
    {
        public long Codigo { get; set; }
        public long CodigoTransaccion { get; set; }
        public int Cuenta { get; set; }
        public decimal Cargo { get; set; }
        public decimal Abono { get; set; }
    }
}
