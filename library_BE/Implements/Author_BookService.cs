using library_BE.Interfaces;
using library_BE.Models;
using library_BE.ViewModels.Requests;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Implements
{
    public class Author_BookService : IAuthor_BookService
    {

        private readonly AppDbContext _context;

        public Author_BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<object> CreateAuthor_Book(Author_BookRequest request)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == request.AuthorId);
            var book = _context.Books.FirstOrDefault(x => x.Id == request.BookId);

            if (null == author || null == book)
                return null;

            var author_book = new Author_Book();
            author_book.AuthorId = request.AuthorId;
            author_book.BookId = request.BookId;

            _context.Author_Books.Add(author_book);
            await _context.SaveChangesAsync();

            return author_book;
        }

        public async Task<bool> DeleteAuthor_Book(string authorId, string bookId)
        {
            var author_book = _context.Author_Books.FirstOrDefault(x => x.AuthorId.ToString() == authorId && x.BookId.ToString() == bookId);
            if (null == author_book)
                return false;

            _context.Author_Books.Remove(author_book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<object> GetAuthor_Book()
        {
            var author_book = await _context.Author_Books.ToListAsync();
            if (null == author_book || 0 == author_book.Count())
                return null;
            return author_book;
        }

    }
}
