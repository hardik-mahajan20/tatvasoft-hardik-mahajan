using CRUD.Model;
using CRUD.Helpers;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;

        public AdminController(IAdminService AdminService)
        {
            _adminService = AdminService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _adminService.GetAll());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] Admin AdminObj)
        {
            AdminObj.Id = 0;
            return Ok(await _adminService.AddAndUpdateAdmin(AdminObj));
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] Admin AdminObj)
        {
            AdminObj.Id = id;
            return Ok(await _adminService.AddAndUpdateAdmin(AdminObj));
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(AuthenticateRequest model)
        {
            var response = await _adminService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Adminname or password is incorrect" });

            return Ok(response);
        }

    }
}
