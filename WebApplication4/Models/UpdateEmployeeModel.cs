namespace WebApplication4.Models
{
    public class UpdateEmployeeModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public long? Salary { get; set; }
        public DateTime date { get; set; }
        public string? dept { get; set; }
    }
}
