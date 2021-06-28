using library_BE.ViewModels.Requests;
using System.Threading.Tasks;

namespace library_BE.Interfaces
{
    public interface ICategory_BookService
    {
        Task<object> GetCategory_Book();
        Task<object> CreateCategory_Book(Category_BookRequest request);
        Task<bool> DeleteCategory_Book(string categoryId, string bookId);
    }
}
