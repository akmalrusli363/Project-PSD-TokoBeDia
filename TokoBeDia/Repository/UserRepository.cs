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
        
        public static List<User> getAllUsers()
        {
            return db.Users.ToList();
        }

        public static User getUserByID(int id)
        {
            return db.Users.Where(user => user.ID == id).FirstOrDefault();
        }

        public static User createUser(String email, String name, String password, String gender) 
        {
            return UserFactory.createUser(email, name, password, gender);
        }

        public static void addUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public static User getUserFromEmailAndPassword(String email, String password)
        {
            return db.Users.Where(user => user.Email == email && user.Password == password).FirstOrDefault();
        }

        public static void updateUser(User user, string newEmail, string newName, string newGender)
        {
            user.Email = newEmail;
            user.Name = newName;
            user.Gender = newGender;
            db.SaveChanges();
        }

        public static void updatePassword(User u, string newPassword)
        {
            u.Password = newPassword;
            db.SaveChanges();
        }

        public static void setUserStatus(User u, string newStatus)
        {
            u.Status = newStatus;
            db.SaveChanges();
        }

        public static void updateUserRole(User u, bool admin)
        {
            u.RoleID = admin ? 1 : 2;
            db.SaveChanges();
        }

        public static bool verifyEmail(string email)
        {
            return (db.Users.Where(user => user.Email == email).FirstOrDefault() == null);
        }
    }
}