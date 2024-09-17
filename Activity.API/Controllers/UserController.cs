using Activity.BLL.Repository;
using Activity.DAL.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Activity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        GenericRepository<User> _userRepository;

        public UserController()
        {
            _userRepository = new GenericRepository<User>();
        }

        [HttpPost]
        public IActionResult AddUser(string email, string password)
        {
            User user = new User();
            user.Email = email;
            user.Password = password;
            _userRepository.Add(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var response = _userRepository.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var result = _userRepository.GetById(id);
            return Ok(result);
        }
    }
}
