using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class UserFactory
    {
        public static User createUser(String email, String name, String password, String gender)
        {
            return new TokoBeDia.Model.User()
            {
                RoleID = 2,
                Email = email,
                Name = name,
                Password = password,
                Gender = gender,
                Status = "active"
            };
        }
    }
}