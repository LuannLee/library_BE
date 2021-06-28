using library_BE.ViewModels.Requests;
using System.Threading.Tasks;

namespace library_BE.Interfaces
{
    public interface IPublishCompanyService
    {
        Task<object> GetPublishCompany();
        Task<object> CreatePublishCompany(PublishCompanyRequest request);
        Task<object> UpdatePublishCompany(PublishCompanyRequest request);
        Task<bool> DeletePublishCompany(string Id);
    }
}
