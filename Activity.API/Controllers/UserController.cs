using Activity.BLL;
using Activity.BLL.Repository;
using Activity.DAL.ORM;
using Activity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Activity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post([FromForm] CreateUserRequestDto createUserRequestDto, IFormFile formFile)
        {
            var user = new User()
            {
                Email = createUserRequestDto.Email,
                Password = createUserRequestDto.Password
            };

            if(formFile != null)
            {
                var ext = Path.GetExtension(formFile.FileName);

                if(ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                {
                    return BadRequest("File type is not valid");
                }

                var fileName = Guid.NewGuid() + ext;

                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images", formFile.FileName);
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }

                user.ProfileImage = fileName;

            }

            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();

            return Ok(user.ID);
           
        }
    }
}
