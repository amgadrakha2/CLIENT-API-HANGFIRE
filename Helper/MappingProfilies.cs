using AutoMapper;
using ClientApp.Dto;
using ClientApp.Models;
using ClientApp.Data;

namespace ClientApp.Helper
{
    public class MappingProfilies : Profile
    {
        public MappingProfilies()
        {
            //CreateMap<StockData, ResponseDto>();
            CreateMap<Result, StockData>();
            CreateMap<ClientDto, Client>();
            CreateMap<Client, ClientDto>();
            
        }
    }
}
