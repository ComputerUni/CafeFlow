using CafeFlow.DTO.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Abstract
{
    public interface ICommentService 
    {
        Task<List<CommentListDto>> GetCommentsByProductId(int id);
    }
}
