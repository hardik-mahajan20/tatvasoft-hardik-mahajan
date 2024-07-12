using CRUD.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;

namespace CRUD.Service
{
    public class Employeeervice : IEmployeeervice
    {
        private readonly EmployeeDbContext _db;
        public Employeeervice(EmployeeDbContext db) {
            _db = db;   
        }
        public async Task<Employee?> AddEmployee(AddUpdateEmployee obj)
        {
            var addHero = new Employee()
            {
                Id = GetMaxId() + 1,
                FirstName = obj.FirstName,
                LastName = obj.LastName, 
                isActive = obj.isActive               
            };
            _db.Employee.Add(addHero);  
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addHero : null;
        }

        public async Task<bool> DeleteHerosById(int id)
        {
            var hero = await _db.Employee.FirstOrDefaultAsync(index => index.Id == id);   
            if (hero != null)
            {
                _db.Employee.Remove(hero);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
                
            }
            return false;  
        }

        public async Task<List<Employee>> GerAllHerosAsync(bool? isActive)
        {
            if(isActive != null) 
            {
                return await _db.Employee.Where(n => n.isActive==isActive).ToListAsync();
            }
            return await _db.Employee.ToListAsync();
        }

        public async Task<Employee?> GetHeroesById(int id)
        {
            return await  _db.Employee.FirstOrDefaultAsync(hero => hero.Id == id);
        }

        public async Task<Employee?> UpdateEmployee(int id, AddUpdateEmployee obj)
        {
            var hero = await _db.Employee.FirstOrDefaultAsync(index => index.Id == id);  
            if(hero != null)
            {
                hero.FirstName  = obj.FirstName;    
                hero.LastName = obj.LastName;   
                hero.isActive = obj.isActive;
                var result = await _db.SaveChangesAsync();  
                return result >= 0 ? hero : null;   
            }
            else
           
                return null;
      
        }
        public int GetMaxId()
        {
            return _db.Employee.Max(hero => hero.Id);
        }
    }
}
