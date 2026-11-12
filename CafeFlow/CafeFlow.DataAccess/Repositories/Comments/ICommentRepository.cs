using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.DTO.Comment;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Comments
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetCommentsByProductId(int id);
        Task<List<Comment>> GetAllWithDetailsAsync();
    }
}
