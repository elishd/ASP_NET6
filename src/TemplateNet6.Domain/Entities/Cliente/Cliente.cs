using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateNet6.Domain.Entities.Cliente
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string TipoPersona { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
