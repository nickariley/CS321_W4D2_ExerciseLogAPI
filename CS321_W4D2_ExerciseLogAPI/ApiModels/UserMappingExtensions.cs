﻿using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class UserMappingExtenstions
    {

        public static UserModel ToApiModel(this User User)
        {
            return new UserModel
            {
                Id = User.Id,
                Name = User.Name,
                // TODO: fill in property mappings

            };
        }

        public static User ToDomainModel(this UserModel UserModel)
        {
            return new User
            {
                Id = UserModel.Id,
                Name = UserModel.Name
                // TODO: fill in property mappings
            };
        }

        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<User> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
