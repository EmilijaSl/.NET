namespace Attempt
{
    public interface IHttpRepository
    {
        Task<string> GetAsync();
        Task<string> GetAsyncWeather();
        Task<string> GetAsyncAllCars();
    }
}
