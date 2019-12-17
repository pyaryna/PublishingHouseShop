using AutoMapper;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.DAL;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.BLL.Services
{
    public class CommentService: ICommentService
    {
        private readonly IPublishingHouseUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(
            IPublishingHouseUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> GetAllCommentsForBookAsync(int bookId)
        {
            IEnumerable<Comment> comments = await _unitOfWork.Comments.GetAllCommentsByBookIdAsync(bookId);

            return comments.Select(_mapper.Map<Comment, CommentDto>)
                .ToArray();
        }

        public async Task AddCommentAsync(AddCommentDto addComment)
        {
            var comment = _unitOfWork.Comments.Add(_mapper.Map<AddCommentDto, Comment>(addComment));
            comment.DateTime = DateTime.Now;

            await _unitOfWork.CommitAsync();
        }
        public async Task RemoveCommentByIdAsync(int id)
        {
            var comment = await _unitOfWork.Comments.FindAsync(id);

            _unitOfWork.Comments.Remove(comment);

            await _unitOfWork.CommitAsync();
        }
    }
}
