﻿using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class ActivityMappingExtenstions
    {

        public static ActivityModel ToApiModel(this Activity activity)
        {
            return new ActivityModel
            {
                Id = activity.Id,
                Date = activity.Date,
                ActivityTypeId = activity.ActivityTypeId,
                ActivityType = activity.ActivityType.Name,
                Duration = activity.Duration,
                Distance = activity.Distance,
                UserId = activity.UserId,
                User = activity.User.Name,
                Notes = activity.Notes

                // TODO: fill in property mappings
                // TODO: the ActivityType property should contain the name of the activity type
                // TODO: the User property should contain the user's name
            };
        }

        public static Activity ToDomainModel(this ActivityModel activityModel)
        {
            return new Activity
            {
                Id = activityModel.Id,
                Date = activityModel.Date,
                ActivityTypeId = activityModel.ActivityTypeId,
                Duration = activityModel.Duration,
                Distance = activityModel.Distance,
                UserId = activityModel.UserId,
                Notes = activityModel.Notes
                // TODO: fill in property mappings
                // TODO: leave User and ActivityType null
            };
        }

        public static IEnumerable<ActivityModel> ToApiModels(this IEnumerable<Activity> activities)
        {
            return activities.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Activity> ToDomainModels(this IEnumerable<ActivityModel> activityModels)
        {
            return activityModels.Select(a => a.ToDomainModel());
        }
    }
}
