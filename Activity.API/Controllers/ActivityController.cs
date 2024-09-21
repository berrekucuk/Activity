using Activity.BLL;
using Activity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Activity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public ActivityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult AddActivity(CreateActivityRequestDto model)
        {
            Activity.DAL.ORM.Activity activity = new Activity.DAL.ORM.Activity();
            activity.Name = model.Name;
            activity.Description = model.Description;
            activity.CategoryId = model.CategoryId;
            _unitOfWork.ActivityRepository.Add(activity);
            _unitOfWork.Save();

            return Ok(activity.ID);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new List<GetAllActivitiesResponseDto>();

            var activities = _unitOfWork.ActivityRepository.GetAllWithIncludes("Category");

            foreach (var activity in activities)
            {
                var activityDto = new GetAllActivitiesResponseDto();
                activityDto.Id = activity.ID;
                activityDto.Name = activity.Name;
                activityDto.Description = activity.Description;
                activityDto.StartDate = activity.StartDate;
                activityDto.EndDate = activity.EndDate;
                activityDto.CategoryId = activity.CategoryId;
                activityDto.CategoryName = activity.Category?.Name;

                response.Add(activityDto);
            }

            return Ok(response);
        }
    }
}
