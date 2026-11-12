using AutoMapper;
using CafeFlow.DTO.Category;
using CafeFlow.DTO.Comment;
using CafeFlow.DTO.Customer;
using CafeFlow.DTO.Order;
using CafeFlow.DTO.OrderDetail;
using CafeFlow.DTO.OrderStatusHistory;
using CafeFlow.DTO.Product;
using CafeFlow.DTO.ProductDetail;
using CafeFlow.DTO.Table;
using CafeFlow.Entity;

namespace CafeFlow.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryListDto>()
                .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products != null ? src.Products.Count(p => !p.IsDeleted && p.IsActive) : 0))
                .ForMember(dest => dest.OrderCount, opt => opt.MapFrom(src => src.Products != null ? src.Products.Where(p => p.OrderDetails != null).SelectMany(p => p.OrderDetails).Select(od => od.OrderId).Distinct().Count() : 0));
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<CreateCategoryDto, Category>();

            CreateMap<Order, OrderConfirmationDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Customer.Phone))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer.Address))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<Order, AdminOrderDetailDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.FullName : "Misafir Müşteri"))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.Phone : "Telefon Yok"))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderDetails))
                .ForMember(dest => dest.StatusHistories, opt => opt.MapFrom(src => src.OrderStatusHistories));

            CreateMap<OrderDetail, AdminOrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : "Silinmiş Ürün"))
                .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom(src => src.Product != null ? src.Product.ImageUrl : null));

            CreateMap<OrderStatusHistory, AdminOrderStatusHistoryDto>()
                .ForMember(dest => dest.ChangedAt, opt => opt.MapFrom(src => src.CreatedAt));


            CreateMap<OrderDetail, OrderDetailConfirmDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : "Lezzetli Ürün"))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));

            CreateMap<Product, ProductListDto>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<UpdateProductDto, Product>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, ResultProductDetailDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();

            CreateMap<Order, OrderListDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Customer.Phone));

            CreateMap<UpdateOrderDto, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateOrderDto, Order>();

            CreateMap<OrderDetail, OrderDetailListDto>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
            CreateMap<UpdateOrderDetailDto, OrderDetail>();
            CreateMap<CreateOrderDetailDto, OrderDetail>();

            CreateMap<Customer, CustomerListDto>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<CreateCustomerDto, Customer>();

            CreateMap<Table, TableListDto>();
            CreateMap<UpdateTableDto, Table>().ReverseMap();
            CreateMap<CreateTableDto, Table>();

            CreateMap<OrderStatusHistory, OrderStatusHistoryListDto>();

            CreateMap<Comment, CommentListDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt));
            CreateMap<UpdateCommentDto, Comment>();
            CreateMap<CreateCommentDto, Comment>();


        }
    }
}
