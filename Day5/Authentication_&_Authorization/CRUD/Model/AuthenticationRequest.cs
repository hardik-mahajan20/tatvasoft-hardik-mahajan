namespace CRUD.Model
{
    public class AuthenticateRequest
    {
        public required string Adminname { get; set; }
        public required string Password { get; set; }
    }
}
