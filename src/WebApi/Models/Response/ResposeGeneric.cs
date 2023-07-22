namespace TemplateNet6.WebApi.Models.Response
{
    public class ResposeGeneric
    {
        public int Codigo { get; init; }
        public string Mensaje { get; init; }
        public object? Datos { get; init; }

        public ResposeGeneric(int codigo, string mensaje, object? datos = null)
        {
            this.Codigo = codigo;
            this.Mensaje = mensaje;
            this.Datos = datos;
        }
        public ResposeGeneric((int codigo, string mensaje) responseCode, object? datos = null)
        {
            this.Codigo = responseCode.codigo;
            this.Mensaje = responseCode.mensaje;
            this.Datos = datos;
        }
    }
}
