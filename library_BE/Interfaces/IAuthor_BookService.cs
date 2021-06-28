using library_BE.ViewModels.Requests;
using System.Threading.Tasks;

namespace library_BE.Interfaces
{
    public interface IAuthor_BookService
    {
        Task<object> GetAuthor_Book();
        Task<object> CreateAuthor_Book(Author_BookRequest request);
        Task<bool> DeleteAuthor_Book(string authorId, string bookId);
    }
}
