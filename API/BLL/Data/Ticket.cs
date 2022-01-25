using HotChocolate.AspNetCore.Authorization;

namespace BLL.Data
{
    [Authorize(Roles = new[] { "Staff" })]
    public class Ticket : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string? Question { get; set; }
        public Guid? AssignedTo { get; set; }
        public bool CaseClosed { get; set; }

    }
}
