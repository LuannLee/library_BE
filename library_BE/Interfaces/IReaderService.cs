using library_BE.ViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Interfaces
{
    public interface IReaderService
    {
        Task<object> GetReader();
        Task<object> CreateReader(ReaderRequest request);
        Task<object> UpdateReader(ReaderRequest request);
        Task<bool> DeleteReader(string Id);
    }
}
