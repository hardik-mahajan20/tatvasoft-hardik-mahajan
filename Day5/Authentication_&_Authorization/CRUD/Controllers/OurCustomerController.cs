using CRUD.Helpers;
using CRUD.Model;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")] //    /api/OurCustomer
    [ApiController]
    [Authorize]
    public class OurCustomerController : ControllerBase
    {
        private readonly IOurCustomerService _adminService;
        public OurCustomerController(IOurCustomerService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool? isActive = null)
        {
            var Admins = await _adminService.GetAllAdmins(isActive);
            return Ok(Admins);
        }

        [HttpGet("{id}")]
        //[Route("{id}")] // /api/OurCustomer/:id
        public async Task<IActionResult> Get(int id)
        {
            var Admin = await _adminService.GetAdminsByID(id);
            if (Admin == null)
            {
                return NotFound();
            }
            return Ok(Admin);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUpdateOurCustomer AdminObject)
        {
            var Admin = await _adminService.AddOurCustomer(AdminObject);

            if (Admin == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Customer Created Successfully!!!",
                id = Admin!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AddUpdateOurCustomer AdminObject)
        {
            var Admin = await _adminService.UpdateOurCustomer(id, AdminObject);
            if (Admin == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Customer Updated Successfully!!!",
                id = Admin!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _adminService.DeleteAdminsByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Customer Deleted Successfully!!!",
                id = id
            });
        }
    }
}
