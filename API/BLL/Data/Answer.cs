namespace BLL.Data
{
    public class Answer : BaseEntity
    {
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public string? Text { get; set; }
    }
}
