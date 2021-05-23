using System;
using System.Collections.Generic;
using System.Text;
using RentACar.DAL.DAClasses;
using RentACar.BO.Interfaces;
using RentACar.BO.Entities;
using System.Data.SqlClient;

namespace RentACar.BLL
{
    public class RoleBLL : IBaseCrud<Role>
    {
        public static RoleDAL roleDAL;

        public RoleBLL()
        {
            roleDAL = new RoleDAL();
        }

        public bool Add(Role role)
        {
            return roleDAL.Add(role);
        }

        public bool Modify(Role role)
        {
            return roleDAL.Modify(role);
        }

        public bool Remove(int id)
        {
            return roleDAL.Remove(id);
        }

        public bool Remove(Role model)
        {
            return roleDAL.Remove(model);
        }

        public List<Role> GetAll()
        {
            return roleDAL.GetAll();
        }

        public Role Get(int id)
        {
            return roleDAL.Get(id);
        }

        public Role Get(Role role)
        {
            return roleDAL.Get(role);
        }
    }
}
