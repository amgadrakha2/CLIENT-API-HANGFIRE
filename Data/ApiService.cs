using AutoMapper;
using ClientApp.Dto;
using ClientApp.Interface;
using ClientApp.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace ClientApp.Data
{
    public class ApiService: IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ApiService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task <List<StockData>> GetDataFromApi()
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {"yMegrAwVvFcHCZQLwsrXTiqmcrTXGnOj"}");

            var response =  _httpClient.GetAsync("https://api.polygon.io/v3/reference/tickers/types?asset_class=stocks&apiKey=yMegrAwVvFcHCZQLwsrXTiqmcrTXGnOj").Result;

            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();
               ApiResponse apiResponse =  JsonConvert.DeserializeObject<ApiResponse>(content);         
                var data = _mapper.Map<List<Result>,List<StockData>>(apiResponse.Results);
                return data;
            }
            return null;


        }
    }

}
