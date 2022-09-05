using Core.Entities;
using Core.Security;
using Microsoft.EntityFrameworkCore;
using RumarApp.Infraestructure;
using RumarApp.Models;
using RumarApp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseMigrations.Data;

namespace RumarApp.Services
{
    public class ClientService : Service, IClientService
    {
        public ClientService(ApplicationDbContext database) : base(database)
        {
        }
       
        public async Task<ServiceResult<List<ClientViewModel>>> GetAll()
        {
            var result = ServiceResult<List<ClientViewModel>>.Create();

            var list = await Database.Clients
                .Where(x => !x.IsDeleted)
                .Select(x => new ClientViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Identification = x.Identification,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    MobileNumber = x.MobileNumber
                })
                .ToListAsync();

            result.Data = list;

            return result;
        }

        public async Task<ServiceResult<ClientViewModel>> Create(ClientViewModel param)
        {
            var result = ServiceResult<ClientViewModel>.Create();

            try
            {
                var client = new Client
                {
                    FirstName = param.FirstName,
                    LastName = param.LastName,
                    Identification = param.Identification,
                    Address = param.Address,
                    PostalAddress = param.PostalAddress,
                    PhoneNumber = param.PhoneNumber,
                    CountryId = param.CountryId,
                    City = param.City,
                    MobileNumber = param.MobileNumber,
                    Nacionality = param.Nacionality,
                    CreatedById = Database.CurrentUser.UserId,
                    CreatedOn = DateTime.UtcNow
                };

                Database.Add(client);

                await Database.SaveChangesAsync();

                var data = await GetClientById(client.Id);

                result.Data = data.Data;

                return result;
            }
            catch (Exception e)
            {
                result.AddErrorMessage($"{e.InnerException}");
                return result;
            }
        }

        public async Task<ServiceResult<ClientViewModel>> GetClientById(int id)
        {
            var result = ServiceResult<ClientViewModel>.Create();

            var client = await Database.Clients
                .Where(x => x.Id == id)
                .Select(x => new ClientViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Identification = x.Identification,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    MobileNumber = x.MobileNumber,
                    City = x.City,
                    CountryId = x.CountryId,
                    Country = x.Country.Description,
                    PostalAddress = x.PostalAddress,
                    Nacionality = x.Nacionality
                })
                .FirstOrDefaultAsync();

            result.Data = client;

            return result;
        }

        public async Task<ServiceResult<int>> EditClient(ClientViewModel param)
        {
            var result = ServiceResult<int>.Create();

            var clientToUpdate = await Database.Clients
                .Where(x => x.Id == param.Id)
                .FirstOrDefaultAsync();

            clientToUpdate.FirstName = param.FirstName;
            clientToUpdate.LastName = param.LastName;
            clientToUpdate.PhoneNumber = param.PhoneNumber;
            clientToUpdate.MobileNumber = param.MobileNumber;
            clientToUpdate.Address = param.Address;
            clientToUpdate.CountryId = param.CountryId;
            clientToUpdate.City = param.City;
            clientToUpdate.PostalAddress = param.PostalAddress;
            clientToUpdate.Nacionality = param.Nacionality;

            Database.Update(clientToUpdate);

            await Database.SaveChangesAsync();

            result.Data = clientToUpdate.Id;

            return result;
        }

        public async Task<ServiceResult> DeleteClient(int clientId)
        {
            var result = ServiceResult.Create();

            var userToDelete = await Database.Clients
                .Where(x => x.Id == clientId)
                .FirstOrDefaultAsync();

            Database.Remove(userToDelete);
            await Database.SaveChangesAsync();

            return result;
        }
    }

    public interface IClientService : IService
    {
        Task<ServiceResult<List<ClientViewModel>>> GetAll();
        Task<ServiceResult<ClientViewModel>> GetClientById(int id);
        Task<ServiceResult<ClientViewModel>> Create(ClientViewModel param);
        Task<ServiceResult<int>> EditClient(ClientViewModel param);
        Task<ServiceResult> DeleteClient(int clientId);
    }
}
