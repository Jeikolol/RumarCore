using Core.Entities;
using Core.Security;
using Microsoft.EntityFrameworkCore;
using RumarApp.Data;
using RumarApp.Infraestructure;
using RumarApp.Models;
using RumarApp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Services
{
    public class ClientService : Service, IClientService
    {

        public ClientService(ApplicationDbContext database) : base(database)
        {
        }
       
        public async Task<ServiceResult<List<ClientViewModel>>> GetAllClients()
        {
            var result = ServiceResult<List<ClientViewModel>>.Create();

            var list = await Database.Clients
                .Include(x => x.Loans)
                .Include(x => x.Beneficiaries)
                .Where(x => !x.IsDeleted)
                .Select(x => new ClientViewModel
                {
                    Id = x.Id,
                    FisrtName = x.FisrtName,
                    LastName = x.LastName,
                    Identification = x.Identification,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    MobileNumber = x.MobileNumber,
                    //Beneficiaries = x.Beneficiaries.Select(b => new BeneficiaryModel
                    //{
                    //    FisrtName = b.FisrtName,
                    //    LastName = b.LastName,
                    //    Identification = b.Identification,
                    //    Address = b.Address,
                    //    PhoneNumber = b.PhoneNumber,
                    //    MobileNumber = b.MobileNumber,
                    //    RelationshipTypeId = b.RelationshipTypeId
                    //})
                    //.ToList(),
                    //Loans = x.Loans.Select(l => new LoanModel
                    //{

                    //}).ToList()
                })
                .ToListAsync();

            result.Data = list;

            return result;
        }

        public async Task<ServiceResult<ClientViewModel>> Create(ClientViewModel param)
        {
            var result = ServiceResult<ClientViewModel>.Create();

            var currentUser = ClaimsHelper.ClaimsIdentity.Name;
            List<Beneficiary> beneficiaryList = new List<Beneficiary>();
            List<Beneficiary> beneficiaries = new List<Beneficiary>();

            foreach (var item in param.Beneficiaries)
            {
                if (param.Beneficiaries.Any(x => x.FullName == ""))
                {
                    result.AddErrorMessage("Los campos no se han enviado correctamente.");

                    return result;
                }

                var beneficiary = new Beneficiary
                {
                    FisrtName = item.FisrtName,
                    LastName = item.LastName,
                    Identification = item.Identification,
                    Address = item.Address,
                    PhoneNumber = item.PhoneNumber,
                    MobileNumber = item.MobileNumber,
                    RelationshipTypeId = item.RelationshipTypeId,
                    CreationDateTime = DateTime.UtcNow,
                    CreatedBy = currentUser
                };

                beneficiaries.Add(beneficiary);
            }

            var client = new Client
            {
                FisrtName = param.FisrtName,
                LastName = param.LastName,
                Identification = param.Identification,
                Address = param.Address,
                PhoneNumber = param.PhoneNumber,
                MobileNumber = param.MobileNumber,
                Beneficiaries = beneficiaries,
                CreatedBy = currentUser,
                CreationDateTime = DateTime.UtcNow
            };

            Database.Add(client);
            await Database.SaveChangesAsync();

            foreach (var item in client.Beneficiaries)
            {
                var beneficiary = new Beneficiary
                {
                    FisrtName = item.FisrtName,
                    LastName = item.LastName,
                    Identification = item.Identification,
                    Address = item.Address,
                    PhoneNumber = item.PhoneNumber,
                    MobileNumber = item.MobileNumber,
                    RelationshipTypeId = item.RelationshipTypeId,
                    ClientId = client.Id
                };

                beneficiaryList.Add(beneficiary);
            }

            Database.AddRange(beneficiaryList);
            await Database.SaveChangesAsync();

            var clientDetail = await GetClientById(client.Id);

            result.Data = clientDetail.Data;

            return result;
        }


        public async Task<ServiceResult<ClientViewModel>> GetClientById(int id)
        {
            var result = ServiceResult<ClientViewModel>.Create();

            var client = await Database.Clients
                .Include(x => x.Loans)
                .Include(x => x.Beneficiaries)
                .Where(x => x.Id == id)
                .Select(x => new ClientViewModel
                {
                    Id = x.Id,
                    FisrtName = x.FisrtName,
                    LastName = x.LastName,
                    Identification = x.Identification,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    MobileNumber = x.MobileNumber,
                    Beneficiaries = x.Beneficiaries.Select(b => new BeneficiaryModel
                    {
                        FisrtName = b.FisrtName,
                        LastName = b.LastName,
                        Identification = b.Identification,
                        Address = b.Address,
                        PhoneNumber = b.PhoneNumber,
                        MobileNumber = b.MobileNumber,
                        RelationshipTypeId = b.RelationshipTypeId,
                        RelationshipType = b.RelationshipType.Description
                    })
                    .ToList(),
                    Loans = x.Loans.Select(l => new LoanModel
                    {
                        
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            result.Data = client;

            return result;
        }

        public async Task<ServiceResult<int>> EditClient(int clientId, ClientViewModel param)
        {
            var result = ServiceResult<int>.Create();

            var clientToUpdate = await Database.Clients
                .Include(x => x.Beneficiaries)
                .Where(x => x.Id == clientId)
                .FirstOrDefaultAsync();

            clientToUpdate.FisrtName = param.FisrtName;
            clientToUpdate.LastName = param.LastName;
            clientToUpdate.PhoneNumber = param.PhoneNumber;
            clientToUpdate.MobileNumber = param.MobileNumber;
            clientToUpdate.Address = param.Address;

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
        Task<ServiceResult<List<ClientViewModel>>> GetAllClients();
        Task<ServiceResult<ClientViewModel>> GetClientById(int id);
        Task<ServiceResult<ClientViewModel>> Create(ClientViewModel param);
        Task<ServiceResult<int>> EditClient(int clientId, ClientViewModel param);
        Task<ServiceResult> DeleteClient(int clientId);
    }
}
