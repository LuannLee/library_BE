using library_BE.ViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Interfaces
{
    public interface IPayService
    {
        Task<object> GetPay();
        Task<object> CreatePay(PayRequest request);
        Task<object> UpdatePay(PayRequest request);
        Task<bool> DeletePay(string Id);
    }
}
