using ClientApp.Data;
using ClientApp.Interface;
using ClientApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

namespace ClientApp.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context )
        {
            _context = context;
        }


        public ICollection<Client> GetAllClients()
        {
            return _context.Clients.OrderBy(c => c.Id).ToList();
        }

        public Client GetClientById(int Id)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == Id);
        }


        public async Task<List<Client>> GetPersonsAsync( FilterClient filterParameters)
        {
            var query = _context.Clients.AsQueryable();

            // Apply filtering
            if (!string.IsNullOrEmpty(filterParameters.FirstName))
            {
                query = query.Where(p => p.FirstName.Contains(filterParameters.FirstName));
            }

            if (!string.IsNullOrEmpty(filterParameters.LastName))
            {
                query = query.Where(p => p.LastName.Contains(filterParameters.LastName));
            }

            if (!string.IsNullOrEmpty(filterParameters.Email))
            {
                query = query.Where(p => p.Email.Contains(filterParameters.Email));
            }

            if (!string.IsNullOrEmpty(filterParameters.Phone))
            {
                query = query.Where(p => p.Phone.Contains(filterParameters.Phone));
            }

            // Apply paging
            //var pagedQuery = query.Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
            //                      .Take(paginationParameters.PageSize);

            return await query.ToListAsync();
        }

        public bool IsClientExist(int Id)
        {
            return _context.Clients.Any(c => c.Id == Id);
        }
        public bool IsClientExist(string Email)
        {
            return _context.Clients.Any(c => c.Email == Email);
        }

        public bool CreateClient(Client client)
        {
            _context.Add(client);
            return Save();
        }

        public bool UpdateClient(Client client)
        {
            _context.Update(client);
            return Save();
        }

        public bool DeleteClient(Client client)
        {
            _context.Remove(client);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
