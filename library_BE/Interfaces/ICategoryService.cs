using library_BE.ViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Interfaces
{
    public interface ICategoryService
    {
        Task<object> GetCategory();
        Task<object> CreateCategory(CategoryRequest request);
        Task<object> UpdateCategory(CategoryRequest request);
        Task<bool> DeleteCategory(string Id);
    }
}
