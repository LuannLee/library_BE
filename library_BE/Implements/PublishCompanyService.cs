using library_BE.Interfaces;
using library_BE.Models;
using library_BE.ViewModels.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Implements
{

    public class PublishCompanyService : IPublishCompanyService
    {
        private readonly AppDbContext _context;

        public PublishCompanyService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<object> CreatePublishCompany(PublishCompanyRequest request)
        {
            var company = new PublishCompany();
            company.Id = Guid.NewGuid();
            company.Name = request.Name;
            company.Address = request.Address;
            company.Email = request.Email;
            company.CreatedDate = DateTime.Now;
            company.Status = Enums.Status.Active;
          

            _context.PublishCompanies.Add(company);
            await _context.SaveChangesAsync();

            return company;
        }

        public async Task<bool> DeletePublishCompany(string Id)
        {
            var company = _context.PublishCompanies.FirstOrDefault(x => x.Id.ToString() == Id);
            if (null == company)
                return false;

            _context.PublishCompanies.Remove(company);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<object> GetPublishCompany()
        {
            var companies = await _context.PublishCompanies.ToListAsync();
            if (null == companies || 0 == companies.Count())
                return null;
            return companies;
        }

        public async Task<object> UpdatePublishCompany(PublishCompanyRequest request)
        {
            var company = _context.PublishCompanies.FirstOrDefault(x => x.Id == request.Id);
            if (null == company)
                return null;

            company.Name = request.Name;
            company.Address = request.Address;
            company.Email = request.Email;
            company.UpdatedDate = DateTime.Now;
            company.Status = request.Status;

            _context.PublishCompanies.Update(company);
            await _context.SaveChangesAsync();

            return company;
        }
    }
}
