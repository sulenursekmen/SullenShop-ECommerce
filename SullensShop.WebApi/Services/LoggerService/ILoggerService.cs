namespace SullensShop.WebApi.Services.LoggerService
{
    public interface ILoggerService<T>
    {
        Task LogInfo(string message);
        Task LogError(string message, Exception ex);
    }
}
