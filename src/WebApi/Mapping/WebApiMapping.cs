using AutoMapper;
using TemplateNet6.Domain.Entities.TipoCuenta;
using TemplateNet6.WebApi.Models.Request.TipoCuenta;

namespace TemplateNet6.WebApi.Mapping
{
    public class WebApiMapping : Profile
    {
        #region CONSTRUCTOR
        public WebApiMapping()
        {
            CreateMap<TipoCuentaDeleteRequest, TipoCuenta>();
            CreateMap<TipoCuentaInsertRequest, TipoCuenta>();
            CreateMap<TipoCuentaUpdateRequest, TipoCuenta>();
            CreateMap<TipoCuentaSelectRequest, TipoCuenta>().ReverseMap();
        }
        #endregion
    }
}
