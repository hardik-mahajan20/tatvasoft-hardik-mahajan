namespace CRUD.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; } = string.Empty;
        public Boolean isActive { get; set; } = true;
    }
}
