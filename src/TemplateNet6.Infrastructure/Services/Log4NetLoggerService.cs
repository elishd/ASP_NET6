using log4net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using TemplateNet6.Application.InterfacesServices;
using TemplateNet6.Domain.Constants;

namespace TemplateNet6.Infrastructure.Services
{
    public class Log4NetLoggerService: ILoggerService
    {
        #region ATTRIBUTES
        private readonly ILog _log;
        #endregion

        #region CONSTRUCTOR
        public Log4NetLoggerService()
        {
            _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        #endregion

        #region METHODS
        public void ErrorObj<T>((string keyWord, string Description) keyWordSearch, T obj, Exception? exception = null)
        {
            _log.Error(Truncate($"[{keyWordSearch.keyWord.ToUpper()}] - {keyWordSearch.Description}:\n {SerializeObj(obj)}{exception}"));
        }

        public void Error((string keyWord, string Description) keyWordSearch, Exception? exception = null)
        {
            _log.Error(Truncate($"[{keyWordSearch.keyWord.ToUpper()}] - {keyWordSearch.Description}{exception}"));
        }

        public void Error(string keyWord, string message, Exception? exception = null)
        {
            _log.Error(Truncate($"[{keyWord.ToUpper()}] - {message}{exception}"));
        }

        public void Info(string keyWord, string message)
        {
            _log.Info(Truncate($"[{keyWord.ToUpper()}] - {message}"));
        }
        #endregion

        #region HELPER METHODS
        private string SerializeObj<T>(T obj)
        {
            string result = string.Empty;
            try
            {
                if (obj != null)
                {
                    var options = new JsonSerializerOptions
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                        WriteIndented = false // Opcional: Indenta el JSON para una mejor legibilidad
                    };

                    result = JsonSerializer.Serialize(obj, options);
                }
            }
            catch (Exception ex)
            {
                Error(LoggerConstant.ERROR_DESCONOCIDO, ex);
            }

            return result;
        }

        private static string Truncate(string input, int maxLength = 1200)
        {
            if (string.IsNullOrEmpty(input) || input.Length <= maxLength)
                return input;

            return input.Substring(0, maxLength);
        }
        #endregion
    }
}
