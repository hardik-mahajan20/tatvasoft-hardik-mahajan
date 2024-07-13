using CRUD.Model;

namespace CRUD.Services
{
    public interface IOurCustomerService
    {
        Task<List<OurCustomer>> GetAllAdmins(bool? isActive);
        Task<OurCustomer?> GetAdminsByID(int id);
        Task<OurCustomer?> AddOurCustomer(AddUpdateOurCustomer obj);
        Task<OurCustomer?> UpdateOurCustomer(int id, AddUpdateOurCustomer obj);
        Task<bool> DeleteAdminsByID(int id);
    }
}
