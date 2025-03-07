using Microsoft.AspNetCore.Mvc;
using PetFamily.Application.Volunteers.CreateVolunteer;
using PetFamily.Domain.Entities;

namespace PetFamily.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolunteersController : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateVolunteerDto dto)
        {
            var volunteerCreateResult = Volunteer.Create(VolunteerId.NewVolunteerId(),
                                                         dto.fullName,
                                                         dto.email,
                                                         dto.description,
                                                         dto.phoneNumber);

            if (volunteerCreateResult.IsFailure)
            {
                return BadRequest(new CreateVolunteerDtoResponse(volunteerCreateResult.Error));
            }
            return Ok();
        }
    }
}
