using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class UserHandler
    {
        private static readonly String[] USER_STATUS = { "active", "blocked" };

        public static List<User> getAllUsers()
        {
            return UserRepository.getAllUsers();
        }

        public static User getUserByID(int id)
        {
            return UserRepository.getUserByID(id);
        }

        public static void signUp(String email, String name, String password, String gender)
        {
            User u = UserRepository.createUser(email, name, password, gender);
            UserRepository.addUser(u);
        }

        public static User login(String email, String password)
        {
            User u = UserRepository.getUserFromEmailAndPassword(email, password);
            if (u == null)
            {
                throw new MemberAccessException("Wrong username or password!");
            }
            if (u.Status.Equals("blocked"))
            {
                throw new MemberAccessException("User blocked! Please contact admin to unlock your user!");
            }

            return u;
        }

        public static void updateUser(int id, string email, string name, string gender)
        {
            User u = UserRepository.getUserByID(id);
            UserRepository.updateUser(u, email, name, gender);
        }

        public static void updatePassword(int id, string password)
        {
            User u = UserRepository.getUserByID(id);
            UserRepository.updatePassword(u, password);
        }

        public static void updateUserRole(int id, bool admin)
        {
            User u = UserRepository.getUserByID(id);
            UserRepository.updateUserRole(u, admin);
        }

        public static string getUserStatus(int level)
        {
            return USER_STATUS[level];
        }

        public static void setUserStatus(int id, bool blocked)
        {
            User u = UserRepository.getUserByID(id);
            string status = blocked ? USER_STATUS[1] : USER_STATUS[0];
            UserRepository.setUserStatus(u, status);
        }
        
        public static bool isAdmin(int id)
        {
            User u = UserRepository.getUserByID(id);
            if (u == null)
            {
                return false;
            }

            try
            {
                return (u != null && u.Role.ID == 1);
            }
            catch (NullReferenceException e)
            {
                return false;
            }
        }

        public static bool verifyEmail(string email)
        {
            return UserRepository.verifyEmail(email);
        }

    }
}