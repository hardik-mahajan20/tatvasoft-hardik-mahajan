using Authentication.Entities;
using Authentication.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Authentication.Repository
{
    public class Mission : IMission
    {
        private readonly AuthContext _dbContext;

        public Mission(AuthContext dbContext)
        {
            _dbContext = dbContext;
        }
        //to add mission
        public async Task<MissionViewModel?> AddAndUpdateMission(MissionDto mission)
        {
            bool isSuccess = false;
            if (mission.MissionId > 0)
            {
                // Update existing Admin
                var existingMission = await _dbContext.Missions.FindAsync(mission.MissionId);

                if (existingMission != null)
                {
                    existingMission.Title = mission.Title;
                    existingMission.Description = mission.Description;
                    // Update other properties as needed

                    _dbContext.Missions.Update(existingMission);
                    isSuccess = await _dbContext.SaveChangesAsync() > 0;
                }
            }
            else
            {
                // Add new Admin with automatically generated ID
                int maxId = await _dbContext.Missions.MaxAsync(c => (int?)c.MissionId) ?? 0;
                mission.MissionId = maxId + 1;

                await _dbContext.Missions.AddAsync(mission);
                isSuccess = await _dbContext.SaveChangesAsync() > 0;
            }
            return null;
        }

        //to add mission
      

        public async Task<string> DeleteMission(int id)
        {
            var mission = await _dbContext.Missions.FindAsync(id);
            if (mission == null)
            {
                return $"Mission with ID {id} not found";
            }

            _dbContext.Missions.Remove(mission);
            await _dbContext.SaveChangesAsync();

            return $"Mission with ID {id} deleted successfully";
        }

        public async Task<MissionViewModel> GetMissionDetailsById(int missionId)
        {
            var mission = await _dbContext.Missions.FindAsync(missionId);
            if (mission == null)
            {
                return null; 
            }

            return new MissionViewModel
            {
                MissionId = mission.MissionId,
                MissionTitle = mission.Title,
                MissionDescription = mission.Description,
            };
        }

        public async Task<List<MissionViewModel>> GetMissionsWithDetails()
        {
            var missions = await _dbContext.Missions.ToListAsync();

            return missions.Select(mission => new MissionViewModel
            {
                MissionId      = mission.MissionId,
                MissionTitle = mission.Title,
                MissionDescription = mission.Description,
            }).ToList();
        }

        
    }
}
