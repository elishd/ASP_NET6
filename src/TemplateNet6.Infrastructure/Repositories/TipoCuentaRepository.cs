using Dapper;
using TemplateNet6.Application.InterfacesRepositories;
using TemplateNet6.Application.InterfacesServices;
using TemplateNet6.Domain.Entities.TipoCuenta;

namespace TemplateNet6.Infrastructure.Repositories
{
    public class TipoCuentaRepository: ITipoCuentaRepository
    {
        #region ATTRIBUTES
        private readonly IDbConnectionService _dbConnectionService;
        #endregion

        #region CONSTRUCTOR
        public TipoCuentaRepository(IDbConnectionService dbConnectionService)
        {
            _dbConnectionService = dbConnectionService ?? throw new ArgumentNullException(nameof(dbConnectionService));
        }
        #endregion

        #region METHODS
        public async Task<int> InsertAsync(TipoCuenta tipoCuenta)
        {
            using var connection = _dbConnectionService.OpenConnection();
            var query = @"INSERT INTO TipoCuenta (Nombre) OUTPUT INSERTED.[Codigo] VALUES(@Nombre)";

            return await connection.QueryFirstAsync<int>(query, tipoCuenta);
        }
        public async Task<int> UpdateAsync(TipoCuenta tipoCuenta)
        {
            using var connection = _dbConnectionService.OpenConnection();
            var query = @"UPDATE TipoCuenta SET Nombre=@Nombre WHERE Codigo=@Codigo";

            return await connection.ExecuteAsync(query, tipoCuenta);
        }
        public async Task<int> DeleteAsync(TipoCuenta tipoCuenta)
        {
            using var connection = _dbConnectionService.OpenConnection();
            var query = @"DELETE TipoCuenta WHERE Codigo=@Codigo";

            return await connection.ExecuteAsync(query, tipoCuenta);
        }
        public async Task<List<TipoCuenta>> GetAllAsync()
        {
            using var connection = _dbConnectionService.OpenConnection();
            var query = @"SELECT Nombre FROM TipoCuenta";

            return (await connection.QueryAsync<TipoCuenta>(query)).ToList();
        }
        public async Task<TipoCuenta> GetByCodigoAsync(int codigo)
        {
            using var connection = _dbConnectionService.OpenConnection();
            var query = @"SELECT Nombre FROM TipoCuenta WHERE Codigo=@Codigo";

            return await connection.QueryFirstOrDefaultAsync<TipoCuenta>(query, new {Codigo = codigo});
        }
        #endregion
    }
}
