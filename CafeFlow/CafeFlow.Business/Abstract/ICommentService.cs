using CafeFlow.DTO.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Abstract
{
    public interface ICommentService 
    {
        Task<List<CommentListDto>> GetAllAsync();
        Task<UpdateCommentDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCommentDto dto);
        Task UpdateAsync(UpdateCommentDto dto);
        Task DeleteAsync(int id);
        Task<List<CommentListDto>> GetCommentsByProductId(int id);
    }
}
