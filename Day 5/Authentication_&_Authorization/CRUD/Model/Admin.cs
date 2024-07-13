namespace CRUD.Model
{
    public class Admin
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public required string Adminname { get; set; }
        public string Password { get; set; } = string.Empty;    
        public bool isActive { get; set; }

    }
}
