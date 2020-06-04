using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Handler;
using System.Text.RegularExpressions;

namespace TokoBeDia.Controller
{
    public class UserController
    {
        public static List<User> getAllUsers()
        {
            return UserHandler.getAllUsers();
        }

        public static User getUserByID(int id)
        {
            return UserHandler.getUserByID(id);
        }

        public static string signUp(string email, string username, string password, string confirmPassword, string gender)
        {
            if (!Regex.Match(email, "^[a-zA-Z0-9._-]+@[a-zA-Z0-9]+\\.[a-zA-Z]+$").Success)
            {
                return "Invalid email!";
            }
            else if (!Regex.Match(username, "[a-zA-Z0-9\\s]+").Success)
            {
                return "Invalid username!";
            }
            else if (!password.Equals(confirmPassword))
            {
                return "Password and confirm password must be same!";
            }
            else if (!(gender.Equals("Male") || gender.Equals("Female")))
            {
                return "You must select a gender (unless you're nonbinary gender, hotline: 1500-LGBT)!";
            }
            else if (!UserHandler.verifyEmail(email))
            {
                return "Email is already registered by another user!";
            }

            try
            {
                UserHandler.signUp(email, username, password, gender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            } return "";
        }

        public static User login(string email, string password)
        {
            User login;

            try
            {
                login = UserHandler.login(email, password);
            }
            catch (MemberAccessException ex)
            {
                throw new MemberAccessException(ex.Message);
            }
            catch (Exception)
            {
                throw new MemberAccessException("Failed to login! (Invalid username/password!)");
            }

            return login;
        }

        public static string updateUserStatus(User user, bool isAdmin, bool isBlocked)
        {
            try
            {
                UserHandler.updateUserRole(user.ID, isAdmin);
                UserHandler.setUserStatus(user.ID, isBlocked);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            }
            return "";
        }

        public static string updateUserProfile(User user, string email, string username, string gender)
        {
            if (!Regex.Match(email, "^[a-zA-Z0-9._-]+@[a-zA-Z0-9]+\\.[a-zA-Z]+$").Success)
            {
                return "Invalid email!";
            }
            else if (!Regex.Match(username, "[a-zA-Z0-9\\s]+").Success)
            {
                return "Invalid username!";
            }
            else if (!(gender.Equals("Male") || gender.Equals("Female")))
            {
                return "You must select a gender!";
            }
            else if (!email.Equals(user.Email) && !UserHandler.verifyEmail(email))
            {
                return "Your new email is already registered by another user! Please refresh to revert the changes!";
            }

            try
            {
                UserHandler.updateUser(user.ID, email, username, gender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            } return "";
        }

        public static bool isAdmin(int id)
        {
            return UserHandler.isAdmin(id);
        }
    }
}