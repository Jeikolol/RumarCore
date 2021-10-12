using Core.Entities;
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
       
        public async Task<List<ClientViewModel>> GetAllClients()
        {
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

            return list;
        }

        public async Task<ClientViewModel> GetClientById(int id)
        {
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

            return client;
        }

        public async Task<ClientViewModel> Create(ClientViewModel param)
        {
            List<Beneficiary> beneficiaryList = new List<Beneficiary>();
            List<Beneficiary> beneficiaries = new List<Beneficiary>();

            foreach (var item in param.Beneficiaries)
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
                Beneficiaries = beneficiaries
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

            
            return await GetClientById(client.Id);
        }

        public async Task DeleteClient(int userId)
        {
            var userToDelete = await Database.Clients
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

            Database.Remove(userToDelete);
            await Database.SaveChangesAsync();
        }
    }

    public interface IClientService : IService
    {
        Task<List<ClientViewModel>> GetAllClients();
        Task<ClientViewModel> GetClientById(int id);
        Task<ClientViewModel> Create(ClientViewModel param);
        Task DeleteClient(int userId);
    }
}
