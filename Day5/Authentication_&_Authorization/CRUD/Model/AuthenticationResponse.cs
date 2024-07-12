using CRUD.Model;

namespace CRUD.Model
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adminname { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Admin Admin, string token)
        {
            Id = Admin.Id;
            FirstName = Admin.FirstName;
            LastName = Admin.LastName;
            Adminname = Admin.Adminname;
            Token = token;
        }

    }
}
