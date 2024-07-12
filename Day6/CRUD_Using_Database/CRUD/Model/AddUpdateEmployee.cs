namespace CRUD.Model
{
    public class AddUpdateEmployee 
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; } = string.Empty;
        public Boolean isActive { get; set; } = true;
    }
}
