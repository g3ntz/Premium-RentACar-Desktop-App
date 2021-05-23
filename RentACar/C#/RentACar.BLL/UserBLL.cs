using System;
using System.Collections.Generic;
using System.Text;
using RentACar.DAL.DAClasses;
using RentACar.BO.Entities;

namespace RentACar.BLL
{
    public class UserBLL
    {
        public static UserDAL userDAL = new UserDAL();

        public static User Login(string username, string password,string role)
        {
            return userDAL.Login(username, password,role);
        }

        public static bool ChangePassword(string username,string actualPassword, string newPassword)
        {
            return userDAL.ChangePassword(username,actualPassword,newPassword);
        }

        public List<User> GetAll()
        {
            List<User> users = userDAL.GetAll();            
            return users;
        }

        public bool Add(User user)
        {
            return userDAL.Add(user);
        }

        public bool Modify(User user)
        {
            return userDAL.Modify(user);
        }

        public bool Remove(int id)
        {
            return userDAL.Remove(id);
        }

        public bool Remove(User user)
        {
            return userDAL.Remove(user);
        }

        public User Get(int id)
        {
            return userDAL.Get(id);
        }

        public User Get(User model)
        {
            return userDAL.Get(model);
        }
    }
}
