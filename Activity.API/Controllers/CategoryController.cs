using Activity.BLL.Repository;
using Activity.DAL.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Activity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        GenericRepository<Category> _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new GenericRepository<Category>();
        }

        [HttpPost]
        public IActionResult AddCategory(string name, string description)
        {
            Category category = new Category();
            category.Name = name;
            category.Description = description;
            _categoryRepository.Add(category);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var response = _categoryRepository.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(Guid id)
        {
            var result = _categoryRepository.GetById(id);
            return Ok(result);
        }
    }
}
