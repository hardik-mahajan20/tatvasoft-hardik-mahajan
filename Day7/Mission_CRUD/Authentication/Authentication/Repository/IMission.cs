using Authentication.Entities;
using Authentication.Model;
using System.Threading.Tasks;

namespace Authentication.Repository
{
    public interface IMission
    {
        // Existing methods remain unchanged
        Task<List<MissionViewModel>> GetMissionsWithDetails();
        Task<MissionViewModel> GetMissionDetailsById(int missionId);
        Task<string> DeleteMission(int id);

        // Combined Add/Update method with clearer naming
       // Task<MissionViewModel> AddMissioin(MissionDto mission);
       // Task<MissionViewModel?> UpdateMission(MissionDto mission);
        Task<MissionViewModel> AddAndUpdateMission(MissionDto mission);
    }
}