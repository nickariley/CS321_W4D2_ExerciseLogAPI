using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private IActivityTypeRepository _activityTypeRepo;

        public ActivityTypeService(IActivityTypeRepository activityTypeRepo)
        {
            _activityTypeRepo = activityTypeRepo;
        }

        public ActivityType Add(ActivityType activityType)
        {
            // TODO: implement add
            _activityTypeRepo.Add(activityType);
            return activityType;
        }

        public ActivityType Get(int id)
        {
            // TODO: return the specified Author using Find()
            return _activityTypeRepo.Get(id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            // TODO: return all Authors using ToList()
            return _activityTypeRepo.GetAll();
        }

        public ActivityType Update(ActivityType updatedActivityType)
        {
            // update the todo and save
            var activityType = _activityTypeRepo.Update(updatedActivityType);
            return activityType;
        }

        public void Remove(ActivityType activityType)
        {
            // TODO: remove the author
            _activityTypeRepo.Remove(activityType);
        }
    }
}
