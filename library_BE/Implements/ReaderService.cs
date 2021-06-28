
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
    public class ReaderService : IReaderService
    {

        private readonly AppDbContext _context;
  
        public ReaderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> CreateReader(ReaderRequest request)
        {
            var reader = new Reader();
            reader.Id = Guid.NewGuid();
            reader.Name = request.Name;
            reader.Address = request.Address;
            reader.CreatedDate = DateTime.Now;
            reader.Status = Enums.Status.Active;

            _context.Readers.Add(reader);
            await _context.SaveChangesAsync();

            return reader;
        }

        public async Task<bool> DeleteReader(string Id)
        {
            var reader = _context.Readers.FirstOrDefault(x => x.Id.ToString() == Id);
            if (null == reader)
                return false;

            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<object> GetReader()
        {
            var readers = await _context.Readers.ToListAsync();
            if (null == readers || 0 == readers.Count())
                return null;
            return readers;
        }


        public async Task<object> UpdateReader(ReaderRequest request)
        {
            var reader = _context.Readers.FirstOrDefault(x => x.Id == request.Id);
            if (null == reader)
                return null;

            reader.Name = request.Name;
            reader.Address = request.Address;
            reader.UpdatedDate = DateTime.Now;
            reader.Status = request.Status;

            _context.Readers.Update(reader);
            await _context.SaveChangesAsync();

            return reader;
        }
    }
}
