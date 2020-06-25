using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityService : IActivityService
    {
        private IActivityRepository _activityRepo;

        public ActivityService(IActivityRepository activityRepo)
        {
            _activityRepo = activityRepo;
        }

        public Activity Add(Activity activity)
        {
            // TODO: implement add
            _activityRepo.Add(activity);
            return activity;
        }

        public Activity Get(int id)
        {
            // TODO: return the specified Author using Find()
            return _activityRepo.Get(id);
        }

        public IEnumerable<Activity> GetAll()
        {
            // TODO: return all Authors using ToList()
            return _activityRepo.GetAll();
        }

        public Activity Update(Activity updatedActivity)
        {
            // update the todo and save
            var activity = _activityRepo.Update(updatedActivity);
            return activity;
        }

        public void Remove(Activity activity)
        {
            // TODO: remove the author
            _activityRepo.Remove(activity);
        }
    }
}
