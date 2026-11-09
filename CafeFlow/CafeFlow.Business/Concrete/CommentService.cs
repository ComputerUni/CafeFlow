using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Comments;
using CafeFlow.DTO.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Concrete
{
    public class CommentService(ICommentRepository _commentRepository, IMapper _mapper) : ICommentService
    {
        public async Task<List<CommentListDto>> GetCommentsByProductId(int id)
        {
            var comments = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<List<CommentListDto>>(comments);
        }
    }
}
