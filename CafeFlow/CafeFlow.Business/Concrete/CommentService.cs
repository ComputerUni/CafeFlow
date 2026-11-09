using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Comments;
using CafeFlow.DTO.Comment;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Concrete
{
    public class CommentService(ICommentRepository _commentRepository, IMapper _mapper) : ICommentService
    {
        public async Task CreateAsync(CreateCommentDto dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            await _commentRepository.CreateAsync(comment);
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            await _commentRepository.DeleteAsync(comment);
        }

        public async Task<List<CommentListDto>> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            return _mapper.Map<List<CommentListDto>>(comments);
        }

        public async Task<UpdateCommentDto> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateCommentDto>(comment);
        }

        public async Task<List<CommentListDto>> GetCommentsByProductId(int id)
        {
            var comments = await _commentRepository.GetCommentsByProductId(id);
            return _mapper.Map<List<CommentListDto>>(comments);
        }

        public async Task UpdateAsync(UpdateCommentDto dto)
        {
            var comment = await _commentRepository.GetByIdAsync(dto.Id);
            _mapper.Map(dto, comment);
            await _commentRepository.UpdateAsync(comment);
        }
    }
}
