using System.ComponentModel.DataAnnotations;

namespace TemplateNet6.WebApi.Models.Request.TipoCuenta
{
    public class TipoCuentaUpdateRequest
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(15, ErrorMessage = "La longitud máxima del {0} es 15.")]
        public string Nombre { get; set; }
    }
}
