namespace BLL.Data
{
    public class User : BaseEntity
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserEnumType UserType { get; set; }
    }

    public enum UserEnumType
    {
        Unknown,
        Customer,
        Staff
    }
}
