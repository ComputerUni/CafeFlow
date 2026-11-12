namespace CafeFlow.DTO.Comment
{
    public class CommentListDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
