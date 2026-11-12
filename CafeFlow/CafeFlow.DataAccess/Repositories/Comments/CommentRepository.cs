using CafeFlow.DataAccess.Context;
using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.DTO.Comment;
using CafeFlow.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Comments
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<Comment>> GetAllWithDetailsAsync()
        {
            return _context.Comments.Include(x => x.Customer).Include(x => x.Product).ToListAsync();
        }

        public Task<List<Comment>> GetCommentsByProductId(int id)
        {
            return _context.Comments.Include(x => x.Customer).Include(x => x.Product).Where(x => x.ProductId == id && x.IsApproved).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }
    }
}
