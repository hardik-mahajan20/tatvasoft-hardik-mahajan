using CRUD.Model;

namespace CRUD.Service
{
    public interface IEmployeeervice
    {
        Task<List<Employee>> GerAllHerosAsync(bool? isActive);
        Task<Employee ?> GetHeroesById(int id);
        Task<Employee?> AddEmployee(AddUpdateEmployee obj);
        Task<Employee?> UpdateEmployee(int id, AddUpdateEmployee obj);
        Task<bool> DeleteHerosById(int id);

    }
}
