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
    public class AuthorService : IAuthorService
    {

        private readonly AppDbContext _context;
        
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<object> CreateAuthor(AuthorRequest request)
        {
            var author = new Author();
            author.Id = Guid.NewGuid();
            author.Name = request.Name;
            author.Website = request.Website;
            author.CreatedDate = DateTime.Now;
            author.Status = Enums.Status.Active;

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAuthor(string Id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id.ToString() == Id);
            if (null == author)
                return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<object> GetAuthor()
        {
            var authors = await _context.Authors.ToListAsync();
            if (null == authors || 0 == authors.Count())
                return null;
            return authors;
        }

        public async Task<object> UpdateAuthor(AuthorRequest request)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == request.Id);
            if (null == author)
                return null;

            author.Name = request.Name;
            author.Website = request.Website;
            author.UpdatedDate = DateTime.Now;
            author.Status = request.Status;

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }
    }
}
