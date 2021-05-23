using System;
using System.Collections.Generic;
using RentACar.BO.Entities;
using RentACar.BO.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace RentACar.DAL.DAClasses
{
    public class MaintenancesDAL : IBaseConvert<Maintenance>, IBaseCrud<Maintenance>
    {
        public bool Add(Maintenance maintenance)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Maintenances_Insert",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("VehicleID", maintenance.VehicleID);
                        command.Parameters.AddWithValue("ResponsibleCompany", maintenance.ResponsibleCompany);
                        command.Parameters.AddWithValue("StartDate", maintenance.StartDate);
                        if(maintenance.ReturnDate.ToString() != DateTime.MinValue.ToString())
                            command.Parameters.AddWithValue("ReturnDate", maintenance.ReturnDate);
                        command.Parameters.AddWithValue("Description", maintenance.Description);
                        command.Parameters.AddWithValue("Costs", maintenance.Costs);
                        command.Parameters.AddWithValue("LoggedUser", maintenance.InsertBy);
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

        public Maintenance Get(int id)
        {
            try
            {
                Maintenance result = null;

                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Maintenances_GetByID", CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("MaintenanceID", id);

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

        public Maintenance Get(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }

        public List<Maintenance> GetAll()
        {
            try
            {
                List<Maintenance> result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Maintenances_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = new List<Maintenance>();
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

        public bool Modify(Maintenance maintenance)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Maintenances_Modify",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("MaintenanceID", maintenance.MaintenanceID);
                        command.Parameters.AddWithValue("VehicleID", maintenance.VehicleID != 0 ? maintenance.VehicleID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("Description", maintenance.Description != null ? maintenance.Description : (object)DBNull.Value);
                        command.Parameters.AddWithValue("ResponsibleCompany", maintenance.ResponsibleCompany != null ? maintenance.ResponsibleCompany : (object)DBNull.Value);
                        command.Parameters.AddWithValue("StartDate", maintenance.StartDate != DateTime.MinValue ? maintenance.StartDate : (object)DBNull.Value);
                        command.Parameters.AddWithValue("ReturnDate", maintenance.ReturnDate != DateTime.MinValue ? maintenance.ReturnDate : (object)DBNull.Value);
                        command.Parameters.AddWithValue("Costs", maintenance.Costs != 0.00M ? maintenance.Costs : (object)DBNull.Value);
                        command.Parameters.AddWithValue("IsReturned", maintenance.IsReturned);
                        command.Parameters.AddWithValue("LoggedUser", maintenance.InsertBy);
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
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Maintenances_Remove",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("MaintenanceID", id);
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

        public bool Remove(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }

        public Maintenance ToObject(SqlDataReader reader)
        {
            Maintenance maintenance = new Maintenance();
            maintenance.Vehicle = new Vehicle();
            maintenance.Vehicle.VehicleBrand = new VehicleBrand();
            maintenance.MaintenanceID = int.Parse(reader["MaintenanceID"].ToString());
            maintenance.VehicleID = reader["VehicleID"] != DBNull.Value ? int.Parse(reader["VehicleID"].ToString()) : 0;
            maintenance.ResponsibleCompany = reader["ResponsibleCompany"].ToString();
            maintenance.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
            maintenance.ReturnDate = reader["ReturnDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReturnDate"].ToString()) : DateTime.MinValue;
            maintenance.Description = reader["Description"].ToString();
            maintenance.Costs = Convert.ToDecimal(reader["Costs"].ToString());
            maintenance.IsReturned = bool.Parse(reader["IsReturned"].ToString());
            maintenance.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
            maintenance.LUD = DateTime.Parse(reader["LUD"].ToString());

            maintenance.Vehicle.VehicleBrand.Make = reader["Make"] != DBNull.Value ? reader["Make"].ToString() : null;
            maintenance.Vehicle.VehicleBrand.Model = reader["Model"] != DBNull.Value ? reader["Model"].ToString() : null;

            maintenance.init();

            return maintenance;
        }
    }
}
