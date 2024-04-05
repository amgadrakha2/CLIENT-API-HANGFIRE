using ClientApp.Dto;
using ClientApp.Models;

namespace ClientApp.Interface
{
    public interface IApiService
    {
        Task<List<StockData>> GetDataFromApi();
    }
}
