using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityTypeRepository
    {
        ActivityType Add(ActivityType todo);
        // Read
        ActivityType Get(int id);
        // Update
        ActivityType Update(ActivityType todo);
        // Delete
        void Remove(ActivityType todo);
        // List
        IEnumerable<ActivityType> GetAll();
    }
}
