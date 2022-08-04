using RumarApp.Infraestructure;
using RumarApp.Models;
using RumarApp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Security;
using DatabaseMigrations.Data;
using Microsoft.EntityFrameworkCore;

namespace RumarApp.Services
{
    public class BeneficiaryService : Service, IBeneficiaryService
    {

        public BeneficiaryService(ApplicationDbContext database) : base(database)
        {
        }

        public async Task<ServiceResult<BeneficiaryModel>> Create(BeneficiaryModel param)
        {
            var result = ServiceResult<BeneficiaryModel>.Create();

            try
            {
                var currentUser = ClaimsHelper.ClaimsIdentity?.Name;

                if (param.FullName == "")
                {
                    result.AddErrorMessage("Los campos no se han enviado correctamente.");

                    return result;
                }

                var beneficiary = new Beneficiary
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
                    CreatedBy = currentUser,
                    Nacionality = param.Nacionality,
                    CreatedOn = DateTime.UtcNow
                };

                Database.Add(beneficiary);

                await Database.SaveChangesAsync();

                result = await GetDetailsById(beneficiary.Id);

                return result;
            }
            catch (Exception e)
            {
                result.AddErrorMessage($"{e.InnerException}");
                return result;
            }
        }

        public async Task<ServiceResult<BeneficiaryModel>> GetDetailsById(int id)
        {
            var result = ServiceResult<BeneficiaryModel>.Create();

            var client = await Database.Beneficiaries
                .Where(x => x.Id == id)
                .Select(x => new BeneficiaryModel
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

        public async Task<ServiceResult<List<BeneficiaryModel>>> GetAll()
        {

            var result = ServiceResult<List<BeneficiaryModel>>.Create();

            var beneficiarios = await Database.Beneficiaries
                .Select(x => new BeneficiaryModel
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
                .ToListAsync();

            result.Data = beneficiarios;

            return result;
        }

        public async Task<ServiceResult<int>> Edit(BeneficiaryModel param)
        {
            var result = ServiceResult<int>.Create();

            var beneficiaryToUpdate = await Database.Beneficiaries
                .Where(x => x.Id == param.Id)
                .FirstOrDefaultAsync();

            beneficiaryToUpdate.FirstName = param.FirstName;
            beneficiaryToUpdate.LastName = param.LastName;
            beneficiaryToUpdate.PhoneNumber = param.PhoneNumber;
            beneficiaryToUpdate.MobileNumber = param.MobileNumber;
            beneficiaryToUpdate.Address = param.Address;
            beneficiaryToUpdate.CountryId = param.CountryId;
            beneficiaryToUpdate.City = param.City;
            beneficiaryToUpdate.PostalAddress = param.PostalAddress;
            beneficiaryToUpdate.Nacionality = param.Nacionality;

            Database.Update(beneficiaryToUpdate);

            await Database.SaveChangesAsync();

            result.Data = beneficiaryToUpdate.Id;

            return result;
        }
    }

    public interface IBeneficiaryService : IService
    {
        Task<ServiceResult<BeneficiaryModel>> Create(BeneficiaryModel param);
        Task<ServiceResult<List<BeneficiaryModel>>> GetAll();
        Task<ServiceResult<BeneficiaryModel>> GetDetailsById(int id);
        Task<ServiceResult<int>> Edit(BeneficiaryModel param);
    }
}
