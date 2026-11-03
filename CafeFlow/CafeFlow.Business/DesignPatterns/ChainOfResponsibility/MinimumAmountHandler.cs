using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;

namespace CafeFlow.Business.DesignPatterns.ChainOfResponsibility
{
    public class MinimumAmountHandler : OrderValidationHandler
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public MinimumAmountHandler(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public override async Task Validate(OrderValidationRequest request)
        {
            if(request.TotalAmount < 100)
            {
                throw new Exception("Minimum sipariş tutarınız en az 100 TL olmalıdır.");
            }
        }
    }
}
