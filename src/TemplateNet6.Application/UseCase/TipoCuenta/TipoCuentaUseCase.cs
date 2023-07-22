using TemplateNet6.Application.InterfacesRepositories;
using TemplateNet6.Domain.Entities.TipoCuenta;
using TemplateNet6.Domain.Exceptions.TipoCuenta;

namespace TemplateNet6.Application.UseCase
{
    public class TipoCuentaUseCase : ITipoCuentaUseCase
    {
        #region ATTRIBUTES
        private readonly ITipoCuentaRepository _tipoCuentaRepository;
        #endregion

        #region CONSTRUCTOR
        public TipoCuentaUseCase(ITipoCuentaRepository tipoCuentaRepository)
        {
            _tipoCuentaRepository = tipoCuentaRepository ?? throw new ArgumentNullException(nameof(tipoCuentaRepository));
        }
        #endregion

        #region METHODS
        public async Task<int> InsertAsync(TipoCuenta tipoCuenta)
        {
            return await _tipoCuentaRepository.InsertAsync(tipoCuenta);
        }
        public async Task<int> UpdateAsync(TipoCuenta tipoCuenta)
        {
            int filasActualizadas = await _tipoCuentaRepository.UpdateAsync(tipoCuenta);

            if (filasActualizadas == 0)
                throw new TipoCuentaNoEncontradaException("El tipo de cuenta no existe");

            return filasActualizadas;
        }
        public async Task<int> DeleteAsync(TipoCuenta tipoCuenta)
        {
            var datoExistente = await _tipoCuentaRepository.GetByCodigoAsync(tipoCuenta.Codigo);

            if (datoExistente == null)
                throw new TipoCuentaNoEncontradaException("El tipo de cuenta no existe");

            return await _tipoCuentaRepository.DeleteAsync(tipoCuenta);
        }
        public async Task<List<TipoCuenta>> GetAllAsync()
        {
            return await _tipoCuentaRepository.GetAllAsync();
        }
        public async Task<TipoCuenta> GetByCodigoAsync(int codigo)
        {
            return await _tipoCuentaRepository.GetByCodigoAsync(codigo);
        }
        #endregion
    }
}
