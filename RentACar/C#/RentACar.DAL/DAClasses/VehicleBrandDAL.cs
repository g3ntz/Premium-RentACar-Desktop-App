using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using RentACar.BO.Entities;
using RentACar.BO.Interfaces;

namespace RentACar.DAL.DAClasses
{
    public class VehicleBrandDAL : IBaseConvert<VehicleBrand>, IBaseCrud<VehicleBrand>
    {
        public bool Add(VehicleBrand model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_VehicleBrand_Insert",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("Make", model.Make);
                        command.Parameters.AddWithValue("Model", model.Model);
                        command.Parameters.AddWithValue("Category", model.Category);
                        command.Parameters.AddWithValue("LoggedUser", model.InsertBy);
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

        public VehicleBrand Get(int id)
        {
            throw new NotImplementedException();
        }

        public VehicleBrand Get(VehicleBrand model)
        {
            throw new NotImplementedException();
        }

        public List<VehicleBrand> GetAll()
        {
            try
            {
                List<VehicleBrand> result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_VehicleBrand_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = new List<VehicleBrand>();
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

        public bool Modify(VehicleBrand model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(VehicleBrand model)
        {
            throw new NotImplementedException();
        }

        public VehicleBrand ToObject(SqlDataReader reader)
        {
            VehicleBrand vehicleBrand = new VehicleBrand();

            vehicleBrand.VehicleBrandID = int.Parse(reader["VehicleBrandID"].ToString());
            vehicleBrand.Make = reader["Make"].ToString();
            vehicleBrand.Model = reader["Model"].ToString();
            vehicleBrand.Category = reader["Category"].ToString();

            return vehicleBrand;
        }

        public List<VehicleBrand> getModelAndCategory(string make)
        {
            try
            {
                List<VehicleBrand> result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_GetModelAndCategory_FromMake", CommandType.StoredProcedure))
                    {
                        SqlHelper.AddParameter(command, "Make", make);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = new List<VehicleBrand>();
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
    }
}
