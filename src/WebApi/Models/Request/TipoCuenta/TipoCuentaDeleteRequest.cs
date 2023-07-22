using System.ComponentModel.DataAnnotations;

namespace TemplateNet6.WebApi.Models.Request.TipoCuenta
{
    public class TipoCuentaDeleteRequest
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Codigo { get; set; }
    }
}
