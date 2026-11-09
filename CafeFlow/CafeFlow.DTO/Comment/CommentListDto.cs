using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Comment
{
    public class CommentListDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? ProductId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }

    }
}
