using ClientApp.Models;
using System;

namespace ClientApp.Interface
{
    public interface IClientRepository
    {
         ICollection<Client> GetAllClients();
        Task<List<Client>> GetPersonsAsync(FilterClient filterParameters);
        Client GetClientById(int Id);
        bool IsClientExist(int Id);
        bool IsClientExist(string Email);

        bool CreateClient(Client client);
        bool UpdateClient(Client client);
        bool DeleteClient(Client client);
        bool Save();
    }
}
