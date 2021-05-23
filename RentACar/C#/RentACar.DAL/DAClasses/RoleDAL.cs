using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using RentACar.BO.Entities;
using RentACar.BO.Interfaces;

namespace RentACar.DAL.DAClasses
{
    public class RoleDAL : IBaseCrud<Role>, IBaseConvert<Role>
    {
        public bool Add(Role role)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Roles_Insert",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("Name", role.Name);
                        command.Parameters.AddWithValue("Description", role.Description);
                        command.Parameters.AddWithValue("LoggedUser", role.InsertBy);
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Modify(Role role)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Roles_Modify",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("RoleID", role.RoleID);
                        command.Parameters.AddWithValue("Name", role.Name);
                        command.Parameters.AddWithValue("Description", role.Description);
                        command.Parameters.AddWithValue("LoggedUser", role.InsertBy);
                        int result = command.ExecuteNonQuery();
                        return result > 0;

                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Roles_Remove",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("RoleID", id);
                        int result = command.ExecuteNonQuery();
                        return result > 0;

                    }
                }

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Remove(Role role)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            try
            {
                List<Role> result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "usp_Roles_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = new List<Role>();
                            while (reader.Read())
                            {
                                result.Add(ToObject(reader));
                            }
                        }

                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Role Get(int id)
        {
            try
            {
                Role result = null; 

                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Roles_GetByID", CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("RoleID", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = ToObject(reader);
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Role Get(Role role)
        {
            throw new NotImplementedException();
        }


        public Role ToObject(SqlDataReader reader)
        {
            Role role = new Role();
            role.RoleID = int.Parse(reader["RoleID"].ToString());
            role.Name = reader["Name"].ToString();
            role.Description = reader["Description"].ToString();
            role.init();
            return role;
        }
    }
}
