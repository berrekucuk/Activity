using Activity.BLL.Repository;
using Activity.DAL.ORM;
using Activity.DTO;
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
        public IActionResult AddCategory(CreateCategoryRequestDto model)
        {
            Category category = new Category();
            category.Name = model.Name;
            category.Description = model.Description;
            _categoryRepository.Add(category);

            CreateCategoryResponseDto response = new CreateCategoryResponseDto();
            response.Id = category.ID;
            response.Name = category.Name;
            response.Description = category.Description;

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var result = _categoryRepository.GetAll();

            var response = new List<GetAllCategoriesResponseDto>();

            foreach (var item in result)
            {
                GetAllCategoriesResponseDto dto = new GetAllCategoriesResponseDto();
                dto.Id = item.ID;
                dto.Name = item.Name;
                dto.Description = item.Description;
                response.Add(dto);
            }

            //result.Select(x => new GetAllCategoriesResponseDto
            //{
            //    Id = x.ID,
            //    Name = x.Name,
            //    Description = x.Description,
            //}).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(Guid id)
        {
            var result = _categoryRepository.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            _categoryRepository.Remove(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryRequestDto model)
        {
            Category category = new Category();
            category.ID = model.Id;
            category.Name = model.Name;
            category.Description = model.Description;
            _categoryRepository.Update(category);
            return Ok();
        }
    }
}
