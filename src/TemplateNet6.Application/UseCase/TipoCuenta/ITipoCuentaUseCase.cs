using TemplateNet6.Domain.Entities.TipoCuenta;

namespace TemplateNet6.Application.UseCase
{
    public interface ITipoCuentaUseCase
    {
        Task<int> InsertAsync(TipoCuenta tipoCuenta);
        Task<int> UpdateAsync(TipoCuenta tipoCuenta);
        Task<int> DeleteAsync(TipoCuenta tipoCuenta);
        Task<List<TipoCuenta>> GetAllAsync();
        Task<TipoCuenta> GetByCodigoAsync(int codigo);
    }
}
