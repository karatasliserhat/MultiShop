using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[Controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentDbContext _context;
        private readonly IMapper _mapper;

        public CommentsController(CommentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            return Ok(_mapper.Map<List<ResultCommentDto>>(await _context.UserComments.ToListAsync()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.CreatedDate = DateTime.Now;
            createCommentDto.Status = true;
            await _context.UserComments.AddAsync(_mapper.Map<UserComment>(createCommentDto));
            await _context.SaveChangesAsync();
            return Ok("Yorum Başarıyla Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {

            return Ok(_mapper.Map<GetByIdCommentDto>(await _context.UserComments.FirstAsync(x => x.UserCommentId == id)));
        }
        [HttpGet("[Action]/{productId}")]
        public async Task<IActionResult> GetCommentByProductId(string productId)
        {

            return Ok(_mapper.Map<List<ResultCommentDto>>(await _context.UserComments.AsNoTracking().
                Where(x => x.ProductId == productId).
                ToListAsync()));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            _context.UserComments.Update(_mapper.Map<UserComment>(updateCommentDto));
            await _context.SaveChangesAsync();
            return Ok("Yorum Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            _context.UserComments.Remove(await _context.UserComments.FirstAsync(x => x.UserCommentId == id));
            await _context.SaveChangesAsync();
            return Ok("Yorum Başarıyla Silindi");
        }
    }
}
