using AutoMapper;
using CafeFlow.DTO.Category;
using CafeFlow.DTO.Customer;
using CafeFlow.DTO.Order;
using CafeFlow.DTO.OrderDetail;
using CafeFlow.DTO.OrderStatusHistory;
using CafeFlow.DTO.Product;
using CafeFlow.DTO.Table;
using CafeFlow.Entity;

namespace CafeFlow.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryListDto>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<CreateCategoryDto, Category>();

            CreateMap<Product, ProductListDto>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<UpdateProductDto, Product>();
            CreateMap<CreateProductDto, Product>();

            CreateMap<Order, OrderListDto>().ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName));
            CreateMap<UpdateOrderDto, Order>();
            CreateMap<CreateOrderDto, Order>();

            CreateMap<OrderDetail, OrderDetailListDto>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
            CreateMap<UpdateOrderDetailDto, OrderDetail>();
            CreateMap<CreateOrderDetailDto, OrderDetail>();

            CreateMap<Customer, CustomerListDto>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<CreateCustomerDto, Customer>();

            CreateMap<Table, TableListDto>();
            CreateMap<UpdateTableDto, Table>();
            CreateMap<CreateTableDto, Table>();

            CreateMap<OrderStatusHistory, OrderStatusHistoryListDto>();
        }
    }
}
