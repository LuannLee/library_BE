using library_BE.ViewModels.Requests;
using System.Threading.Tasks;

namespace library_BE.Interfaces
{
    public interface IBorrowService
    {
        Task<object> GetBorrow();
        Task<object> CreateBorrow(BorrowRequest request);
        Task<object> UpdateBorrow(BorrowRequest request);
        Task<bool> DeleteBorrow(string Id);
        Task<object> GetBorrowDetailByBorrow(BorrowRequest request);
        Task<object> GetCountBorrow();

        Task<object> GetBorrowbyStatus();
    }
}
