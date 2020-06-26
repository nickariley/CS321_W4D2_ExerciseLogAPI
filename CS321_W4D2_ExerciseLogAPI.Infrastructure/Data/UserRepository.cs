using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public User Add(User user)
        {
            _appDbContext.Users.Add(user);

            _appDbContext.SaveChanges();

            return user;
        }

        public User Get(int id)
        {
            return _appDbContext.Users.Include(u => u.Id).SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _appDbContext.Users.Include(u => u.Activities).ToList();
        }

        public User Update(User updatedUser)
        {
            // get the ToDo object in the current list with this id 
            var currentUser = _appDbContext.Users.Find(updatedUser.Id);

            // return null if todo to update isn't found
            if (currentUser == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _appDbContext.Entry(currentUser).CurrentValues.SetValues(updatedUser);
            // update the todo and save
            _appDbContext.Users.Update(currentUser);

            _appDbContext.SaveChanges();

            return currentUser;
        }

        public void Remove(User user)
        {
            _appDbContext.Users.Remove(user);

            _appDbContext.SaveChanges();
        }
    }
}
