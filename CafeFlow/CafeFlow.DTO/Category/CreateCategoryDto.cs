using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
