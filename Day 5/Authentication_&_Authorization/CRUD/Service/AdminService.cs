using CRUD;
using CRUD.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUD.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppSettings _appSettings;
        private readonly OurCustomerDbContext db;

        public AdminService(IOptions<AppSettings> appSettings, OurCustomerDbContext _db)
        {
            _appSettings = appSettings.Value;
            db = _db;
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await db.Admins.ToListAsync();
        }

        public async Task<Admin?> GetById(int id)
        {
            return await db.Admins.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Admin?> AddAndUpdateAdmin(Admin AdminObj)
        {
            bool isSuccess = false;

            if (AdminObj.Id > 0)
            {
                // Update existing Admin
                var existingAdmin = await db.Admins.FindAsync(AdminObj.Id);

                if (existingAdmin != null)
                {
                    existingAdmin.FirstName = AdminObj.FirstName;
                    existingAdmin.LastName = AdminObj.LastName;
                    // Update other properties as needed

                    db.Admins.Update(existingAdmin);
                    isSuccess = await db.SaveChangesAsync() > 0;
                }
            }
            else
            {
                // Add new Admin with automatically generated ID
                int maxId = await db.Admins.MaxAsync(c => (int?)c.Id) ?? 0;
                AdminObj.Id = maxId + 1;

                await db.Admins.AddAsync(AdminObj);
                isSuccess = await db.SaveChangesAsync() > 0;
            }

            return isSuccess ? AdminObj : null;
        }


        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            var Admin = await db.Admins.SingleOrDefaultAsync(x => x.Adminname == model.Adminname && x.Password == model.Password);

            // return null if Admin not found
            if (Admin == null) return null;

            // authentication successful so generate jwt token
            var token = await generateJwtToken(Admin);

            return new AuthenticateResponse(Admin, token);

        }

        private async Task<string> generateJwtToken(Admin Admin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {

                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", Admin.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);

        }
    }
}
