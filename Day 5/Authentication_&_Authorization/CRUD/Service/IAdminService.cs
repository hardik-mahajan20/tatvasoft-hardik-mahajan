using CRUD.Model;

namespace CRUD.Services
{
    public interface IAdminService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<Admin>> GetAll();
        Task<Admin?> GetById(int id);
        Task<Admin?> AddAndUpdateAdmin(Admin AdminObj);

    }
}
