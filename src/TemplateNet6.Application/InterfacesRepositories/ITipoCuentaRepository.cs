using TemplateNet6.Domain.Entities.TipoCuenta;

namespace TemplateNet6.Application.InterfacesRepositories
{
    public interface ITipoCuentaRepository
    {
        Task<int> InsertAsync(TipoCuenta tipoCuenta);
        Task<int> UpdateAsync(TipoCuenta tipoCuenta);
        Task<int> DeleteAsync(TipoCuenta tipoCuenta);
        Task<List<TipoCuenta>> GetAllAsync();
        Task<TipoCuenta> GetByCodigoAsync(int codigo);
    }
}
