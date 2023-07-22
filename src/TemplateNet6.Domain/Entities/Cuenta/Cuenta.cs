using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateNet6.Domain.Entities.Cuenta
{
    public class Cuenta
    {
        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoTipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public double Saldo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
