using library_BE.ViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Interfaces
{
    public interface IAuthorService
    {
        Task<object> GetAuthor();
        Task<object> CreateAuthor(AuthorRequest request);
        Task<object> UpdateAuthor(AuthorRequest request);
        Task<bool> DeleteAuthor(string Id);
    }
}
