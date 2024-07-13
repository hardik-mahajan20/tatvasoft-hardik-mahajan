using Authentication.Entities;
using Authentication.Model;
using Authentication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

//THis is api for mission manipulation

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class MissionController : ControllerBase
    {
        private readonly IMission _missionRepository;

        public MissionController(IMission missionRepository)
        {
            _missionRepository = missionRepository;
        }

        [HttpGet("GetMissions")]
        public async Task<IActionResult> GetMissionWithDetails()
        {
            var missionWithDetails = await _missionRepository.GetMissionsWithDetails();
            return Ok(missionWithDetails);
        }

        [HttpGet("GetMissionById/{MissionId}")]
        public async Task<IActionResult> GetMissionWithDetailsById(int MissionId)
        {
            var missionWithDetails = await _missionRepository.GetMissionDetailsById(MissionId);
            return Ok(missionWithDetails);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var result = await _missionRepository.DeleteMission(id);

            if (result == "Mission not found")
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MissionDto mission)
        {
            var result = await _missionRepository.AddAndUpdateMission(mission);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MissionDto mission)
        {
          //  if (id != mission.MissionId)
          //  {   //validation
          //      return BadRequest("Mission ID in the URL and body don't match");
          //  }

            var result = await _missionRepository.AddAndUpdateMission(mission);
            return Ok(result);
        }


    }
}
