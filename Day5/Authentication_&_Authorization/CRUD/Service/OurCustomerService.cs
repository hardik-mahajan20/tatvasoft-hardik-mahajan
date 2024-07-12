using CRUD;
using CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services
{
    public class OurCustomerService : IOurCustomerService
    {
        private readonly OurCustomerDbContext _db;
        public OurCustomerService(OurCustomerDbContext db)
        {
            _db = db;
        }
        public async Task<List<OurCustomer>> GetAllAdmins(bool? isActive)
        {
            if (isActive != null)
            {
                return await _db.OurCustomers.Where(m => m.IsActive == isActive).ToListAsync();
            }
            return await _db.OurCustomers.ToListAsync();
        }

        public async Task<OurCustomer?> GetAdminsByID(int id)
        {
            return await _db.OurCustomers.FirstOrDefaultAsync(Admin => Admin.Id == id);
        }

        public async Task<OurCustomer?> AddOurCustomer(AddUpdateOurCustomer obj)
        {
            int maxId = await _db.OurCustomers.MaxAsync(c => (int?)c.Id) ?? 0;

            var addAdmin = new OurCustomer()
            {
                Id = maxId + 1,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                IsActive = obj.isActive,
            };

            _db.OurCustomers.Add(addAdmin);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addAdmin : null;
        }


        public async Task<OurCustomer?> UpdateOurCustomer(int id, AddUpdateOurCustomer obj)
        {
            var Admin = await _db.OurCustomers.FirstOrDefaultAsync(index => index.Id == id);
            if (Admin != null)
            {
                Admin.FirstName = obj.FirstName;
                Admin.LastName = obj.LastName;
                Admin.IsActive = obj.isActive;

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? Admin : null;
            }
            return null;
        }

        public async Task<bool> DeleteAdminsByID(int id)
        {
            var Admin = await _db.OurCustomers.FirstOrDefaultAsync(index => index.Id == id);
            if (Admin != null)
            {
                _db.OurCustomers.Remove(Admin);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

    }
}
