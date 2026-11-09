using CafeFlow.DTO.Comment;
using CafeFlow.DTO.ProductDetail;

namespace CafeFlow.WebUI.Models
{
    public class ProductDetailPageViewModel
    {
        public ResultProductDetailDto Product { get; set; }
        public List<CommentListDto> Comments { get; set; }
        public double AverageCount => Comments.Any() ? Math.Round(Comments.Average(c => c.Rating), 1) : 0.0;
        public int TotalComments => Comments.Count;
    }
}
