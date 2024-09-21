using Activity.BLL;
using Activity.BLL.Repository;
using Activity.DAL.ORM;
using Activity.DTO;
using Activity.DTO.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Activity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        IUnitOfWork _unitOfWork;

        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult AddBlog(CreateBlogRequestDto model)
        {
            Blog blog = new Blog();
            blog.Title = model.Title;
            blog.Content = model.Content;
            _unitOfWork.BlogRepository.Add(blog);
            _unitOfWork.Save();

            CreateBlogResponseDto response = new CreateBlogResponseDto();
            response.Id = blog.ID;
            response.Title = blog.Title;
            response.Content = blog.Content;

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllBlogs(int pageNumber, int pagesize)
        {
            var result = _unitOfWork.BlogRepository.GetAll(pageNumber, pagesize);

            var response = new List<GetAllBlogResponseDto>();

            foreach (var item in result)
            {
                GetAllBlogResponseDto dto = new GetAllBlogResponseDto();
                dto.Id = item.ID;
                dto.Title = item.Title;
                dto.Content = item.Content;
                response.Add(dto);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogBId(Guid id)
        {
            var result = _unitOfWork.BlogRepository.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(Guid id)
        {
            _unitOfWork.BlogRepository.Remove(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBlog(UpdateBlogRequestDto model)
        {
            Blog blog = new Blog();
            blog.ID = model.Id;
            blog.Title = model.Title;
            blog.Content = model.Content;
            _unitOfWork.BlogRepository.Update(blog);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
