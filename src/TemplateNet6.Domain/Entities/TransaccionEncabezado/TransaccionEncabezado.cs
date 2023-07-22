using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateNet6.Domain.Entities.TransaccionEncabezado
{
    public class TransaccionEncabezado
    {
        public long Codigo { get; set; }
        public int CodigoTipoTransaccion { get; set; }
        public decimal MontoTotal { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
