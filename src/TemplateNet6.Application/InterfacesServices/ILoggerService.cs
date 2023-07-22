namespace TemplateNet6.Application.InterfacesServices
{
    public interface ILoggerService
    {
        void ErrorObj<T>((string keyWord, string Description) keyWordSearch, T obj, Exception? exception = null);
        void Error((string keyWord, string Description) keyWordSearch, Exception? exception = null);
        void Error(string keyWord, string message, Exception? exception = null);
        void Info(string keyWord, string message);
    }
}
