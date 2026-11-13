using CafeFlow.DTO.Category;
using CafeFlow.DTO.Product;

namespace CafeFlow.WebUI.Models
{
    public class MenuPageViewModel
    {
        public List<ProductListDto> Products { get; set; }
        public List<CategoryListDto> Categories { get; set; }
        public HashSet<int> FavoriteProductIds { get; set; }
    }
}
