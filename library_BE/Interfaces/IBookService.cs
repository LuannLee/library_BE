using library_BE.ViewModels.Requests;
using System;
using System.Threading.Tasks;

namespace library_BE.Interfaces
{
    public interface IBookService
    {
        Task<object> GetBook();
        Task<object> CreateBook(BookRequest request);
        Task<object> UpdateBook(BookRequest request);
        Task<bool> DeleteBook(string id);
    }
}
