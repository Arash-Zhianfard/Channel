using Service.Model;


namespace Service.Interfaces
{
    public interface IApiCaller
    {
        Task<T> GetAsync<T>(RequestOption requestOption);
        Task<T> PutAsync<T>(RequestOption requestOption);
    }
}
