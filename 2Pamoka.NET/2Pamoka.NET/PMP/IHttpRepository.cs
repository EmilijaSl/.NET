namespace _2Pamoka.NET.PMP
{
    public interface IHttpRepository
    {
        Task<string> GetAsync();
        Task<string> GetAsyncWeather();
    }
}
