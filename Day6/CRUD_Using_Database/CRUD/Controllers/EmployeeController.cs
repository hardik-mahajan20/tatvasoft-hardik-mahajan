using CRUD.Model;
using CRUD.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//This is api for CRUD opperation

namespace CRUD.Controllers
{
    [Route("api/[controller]")]  //api/Employee
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeervice _heroService;
        public EmployeeController(IEmployeeervice heroService)
        {
            _heroService = heroService; 
        }
        [HttpGet]   
        public async Task<IActionResult> Get([FromQuery]  bool ? isActive =null)
        {
            var heros =await _heroService.GerAllHerosAsync(isActive);
            return Ok(heros);   
        }
        [HttpGet("{id}")]
        //[Route("{id}")] //api/Employee/:id
        public async Task<IActionResult> Get(int id)
        {
            var hero = await _heroService.GetHeroesById(id);  
            if(hero == null)
            {
                return NotFound();  
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUpdateEmployee heroObject)
        {
            var hero = await  _heroService.AddEmployee(heroObject); 
            if(hero == null)
            {
                return BadRequest();    
            }
            return Ok(new
            {
                message = hero.FirstName + " Created Succesfully!!!",
                id = hero!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id,[FromBody] AddUpdateEmployee heroObject)
        {
            var hero = await _heroService.UpdateEmployee(id,heroObject);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = hero.FirstName + " Updated Succesfully!!!",
                id = hero!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _heroService.DeleteHerosById(id))
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Id = " + id +  " Deleted Succesfully!!!",
                id = id
            });
        }
    }
}

