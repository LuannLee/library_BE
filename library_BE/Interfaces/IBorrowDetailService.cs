using library_BE.ViewModels.Requests;
using System.Threading.Tasks;

namespace library_BE.Interfaces
{
    public interface IBorrowDetailService
    {
        Task<object> GetBorrowDetail();
        Task<object> CreateBorrowDetail(BorrowDetailRequest request);
        Task<object> UpdateBorrowDetail(BorrowDetailRequest request);
        Task<bool> DeleteBorrowDetail(string Id);
    }
}
