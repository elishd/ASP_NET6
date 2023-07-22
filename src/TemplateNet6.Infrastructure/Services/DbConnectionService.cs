using Microsoft.Extensions.Configuration;
using Polly;
using System.Data;
using System.Data.SqlClient;
using TemplateNet6.Application.InterfacesServices;
using TemplateNet6.Domain.Constants;

namespace TemplateNet6.Infrastructure.Services
{
    public class DbConnectionService: IDbConnectionService
    {
        #region ATTRIBUTES
        private readonly IConfiguration _configuration;
        private readonly ILoggerService _loggerService;
        #endregion

        #region CONSTRUCTOR
        public DbConnectionService(IConfiguration configuration, ILoggerService loggerService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }
        #endregion

        #region METHODS
        public IDbConnection? OpenConnection()
        {
            SqlConnection? connection = null;

            var _retryPolicy = Policy.Handle<Exception>()
                 .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(5), (ex, time) =>
                 {
                     _loggerService.Error(LoggerConstant.DATABASE.keyWord, $"Reintentar debido a {ex.Message}. Esperando {time} antes del próximo reintento.", ex);
                 });

            _retryPolicy.Execute(() =>
            {
                connection = new SqlConnection(_configuration["ConnectionStrings:SqlServerConnection"]);
                connection.Open();
                if (connection.State != ConnectionState.Open)
                    throw new Exception("No es posible abrir la Conexión a SQL");
            });

            return connection;
        }
        #endregion
    }
}
