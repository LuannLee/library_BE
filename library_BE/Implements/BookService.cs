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
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> CreateBook(BookRequest request)
        {
            var company = _context.PublishCompanies.FirstOrDefault(x => x.Id == request.PublishCompanyId && (int)x.Status == 1);
            if (null == company)
                return null;

            var book = new Book();
            book.Id = Guid.NewGuid();
            book.Name = request.Name;
            book.PublishCompanyId = request.PublishCompanyId;
            book.PublishYear = request.PublishYear;
            book.Quantity = request.Quantity;
            book.CreatedDate = request.CreatedDate;
            book.Status = Enums.Status.Active;

            for (int i = 0; i < request.AuthorId.Count(); i++)
            {
                var author_book = new Author_Book();
                author_book.BookId = book.Id;
                author_book.AuthorId = request.AuthorId[i];

                _context.Author_Books.Add(author_book);
            }

            for (int i = 0; i < request.CategoryId.Count(); i++)
            {
                var category_book = new Category_Book();
                category_book.BookId = book.Id;
                category_book.CategoryId = request.CategoryId[i];

                _context.Category_Books.Add(category_book);
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;

        }

        public async Task<bool> DeleteBook(string id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id.ToString() == id);
            if (null == book)
                return false;

            var author_book = _context.Author_Books.Where(x => x.BookId.ToString() == id);
            _context.Author_Books.RemoveRange(author_book);

            var category_book = _context.Category_Books.Where(x => x.BookId.ToString() == id);
            _context.Category_Books.RemoveRange(category_book);

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<object> GetBook()
        {
            var books = await _context.Books.ToListAsync();
            var bookViewModels = new List<BookRequest>();

            foreach (var item in books)
            {
                var bookViewModel = new BookRequest();
                bookViewModel.Id = item.Id;
                bookViewModel.Name = item.Name;
                bookViewModel.PublishYear = item.PublishYear;
                bookViewModel.Quantity = item.Quantity;
                bookViewModel.CreatedDate = item.CreatedDate;
                bookViewModel.UpdatedDate = item.UpdatedDate;
                bookViewModel.Status = item.Status;
                bookViewModel.PublishCompanyId = item.PublishCompanyId;
                bookViewModel.PublishCompanyName = (await _context.PublishCompanies.FirstOrDefaultAsync(x => x.Id == item.PublishCompanyId)).Name;

                var author_books = _context.Author_Books.Where(x => x.BookId == item.Id).Include(x => x.Author).ToList();

                string authorNames = "";
                List<Guid> authorId = new List<Guid>();

                for (int i = 0; i < author_books.Count(); i++)
                {
                    if (i == author_books.Count() - 1)
                    {
                        authorNames += author_books[i].Author.Name;
                        authorId.Add(author_books[i].AuthorId);
                    }
                    else
                    {
                        authorNames += author_books[i].Author.Name + ", ";
                        authorId.Add(author_books[i].AuthorId);
                    }
                }

                bookViewModel.AuthorNames = authorNames;
                bookViewModel.AuthorId = authorId;

                var category_books = _context.Category_Books.Where(x => x.BookId == item.Id).Include(x => x.Category).ToList();

                string categoryName = "";
                List<Guid> categoryId = new List<Guid>();


                for (int i = 0; i < category_books.Count(); i++)
                {
                    if(i == category_books.Count() - 1)
                    {
                        categoryName += category_books[i].Category.Name;
                        categoryId.Add(category_books[i].CategoryId);
                    }
                    else
                    {
                        categoryName += category_books[i].Category.Name + ", ";
                        categoryId.Add(category_books[i].CategoryId);
                    }

                }

                bookViewModel.CategoryNames = categoryName;
                bookViewModel.CategoryId = categoryId;

                bookViewModels.Add(bookViewModel);
            }

            if (null == bookViewModels || 0 == bookViewModels.Count())
                return null;
            return bookViewModels;
        }



        public async Task<object> UpdateBook(BookRequest request)
        {

            var book = _context.Books.FirstOrDefault(x => x.Id == request.Id);
            var company = _context.PublishCompanies.FirstOrDefault(x => x.Id == request.PublishCompanyId && (int)x.Status == 1);
            if (null == book || null == company)
                return null;


            book.Name = request.Name;
            book.PublishCompanyId = request.PublishCompanyId;
            book.PublishYear = request.PublishYear;
            book.Quantity = request.Quantity;
            book.UpdatedDate = request.UpdatedDate;
            book.Status = request.Status;

            var delete_author = _context.Author_Books.Where(x => x.BookId == book.Id);
            _context.Author_Books.RemoveRange(delete_author);

            var delete_category = _context.Category_Books.Where(x => x.BookId == book.Id);
            _context.Category_Books.RemoveRange(delete_category);

            _context.SaveChanges();

            for (int i = 0; i < request.AuthorId.Count(); i++)
            {
                var author_book = new Author_Book();
                author_book.BookId = book.Id;
                author_book.AuthorId = request.AuthorId[i];

                _context.Author_Books.Add(author_book);
            }

            for (int i = 0; i < request.CategoryId.Count(); i++)
            {
                var category_book = new Category_Book();
                category_book.BookId = book.Id;
                category_book.CategoryId = request.CategoryId[i];

                _context.Category_Books.Add(category_book);
            }

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return book;
        }
    }
}
