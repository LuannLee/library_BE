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
    public class Category_BookService : ICategory_BookService
    {

        private readonly AppDbContext _context;

        public Category_BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> CreateCategory_Book(Category_BookRequest request)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == request.CategoryId);
            var book = _context.Books.FirstOrDefault(x => x.Id == request.BookId);

            if (null == category || null == book)
                return null;

            var category_book = new Category_Book();
            category_book.CategoryId = request.CategoryId;
            category_book.BookId = request.BookId;

            _context.Category_Books.Add(category_book);
            await _context.SaveChangesAsync();

            return category_book;
        }

        public async Task<bool> DeleteCategory_Book(string categoryId, string bookId)
        {
            var category_book = _context.Category_Books.FirstOrDefault(x => x.CategoryId.ToString() == categoryId && x.BookId.ToString() == bookId);
            if (null == category_book)
                return false;

            _context.Category_Books.Remove(category_book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<object> GetCategory_Book()
        {
            var category_book = await _context.Category_Books.ToListAsync();
            if (null == category_book || 0 == category_book.Count())
                return null;
            return category_book;
        }
    }
}
