using CafeFlow.DTO.Table;

namespace CafeFlow.Business.Abstract
{
    public interface ITableService
    {
        Task<List<TableListDto>> GetAllAsync();
        Task<UpdateTableDto> GetByIdAsync(int id);
        Task CreateAsync(CreateTableDto dto);
        Task UpdateAsync(UpdateTableDto dto);
        Task DeleteAsync(int id);
    }
}
