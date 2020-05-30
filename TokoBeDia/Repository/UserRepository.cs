using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class UserRepository
    {
        private static DatabaseEntities db = TokoBeDia.Singleton.DBSingleton.getInstance();

        private static readonly String[] USER_STATUS = { "active", "blocked" };

        public static String getUserStatus(int level)
        {
            return USER_STATUS[level];
        }

        public static void signUp(String email, String name, String password, String gender) 
        {
            User u = UserFactory.createUser(email, name, password, gender);
            db.Users.Add(u);
            db.SaveChanges();
        }

        public static User login(String email, String password)
        {
            User u = db.Users.Where(user => user.Email == email && user.Password == password).FirstOrDefault();
            if (u == null) {
                throw new MemberAccessException("Wrong username or password!");
            }
            if (u.Status.Equals("blocked")) {
                throw new MemberAccessException("User blocked! Please contact admin to unlock your user!");
            }
            
            return u;
        }

        public static List<User> getAllUsers()
        {
            return db.Users.ToList();
        }

        public static User getUserByID(int id)
        {
            return db.Users.Where(user => user.ID == id).FirstOrDefault();
        }

        public static void updateUser(int id, String email, String name, String gender)
        {
            User u = db.Users.Where(user => user.ID == id).FirstOrDefault();
            u.Email = email;
            u.Name = name;
            u.Gender = gender;
            db.SaveChanges();
        }

        public static void updatePassword(int id, String password)
        {
            User u = db.Users.Where(user => user.ID == id).FirstOrDefault();
            u.Password = password;
            db.SaveChanges();
        }

        public static void setUserStatus(int id, bool blocked)
        {
            User u = getUserByID(id);
            u.Status = blocked ? USER_STATUS[1] : USER_STATUS[0];
            db.SaveChanges();
        }

        public static void updateUserRole(int id, bool admin)
        {
            User u = getUserByID(id);
            u.RoleID = admin ? 1 : 2;
            db.SaveChanges();
        }

        public static bool verifyEmail(String email)
        {
            return (db.Users.Where(user => user.Email == email).FirstOrDefault() == null);
        }

        public static bool isAdmin(int id)
        {
            User u = getUserByID(id);
            return (u != null && u.Role.ID == 1);
        }
    }
}