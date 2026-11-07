using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Tables;
using CafeFlow.DTO.Table;
using CafeFlow.Entity;

namespace CafeFlow.Business.Concrete
{
    public class TableService(ITableRepository _tableRepository, IMapper _mapper) : ITableService
    {
        public async Task CreateAsync(CreateTableDto dto)
        {
            var table = _mapper.Map<Table>(dto);
            await _tableRepository.CreateAsync(table);
        }

        public async Task DeleteAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            await _tableRepository.DeleteAsync(table);
        }

        public async Task<List<TableListDto>> GetAllAsync()
        {
            var tables = await _tableRepository.GetAllAsync();
            return _mapper.Map<List<TableListDto>>(tables);
        }

        public async Task<UpdateTableDto> GetByIdAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateTableDto>(table);
        }

        public async Task UpdateAsync(UpdateTableDto dto)
        {
            var table = await _tableRepository.GetByIdAsync(dto.Id);
            _mapper.Map(dto, table);
            await _tableRepository.UpdateAsync(table);
        }
    }
}
