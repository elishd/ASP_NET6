namespace TemplateNet6.WebApi.Models.Response
{
    public class ResponseCodeConstant
    {
        public static readonly (int Codigo, string Mensaje) EXITO = (0, "Exitoso.");
        public static readonly (int Codigo, string Mensaje) ERROR = (1, "Ha ocurrido un error en el sistema.");
    }
}
