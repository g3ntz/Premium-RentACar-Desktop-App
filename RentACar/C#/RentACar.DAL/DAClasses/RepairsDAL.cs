using System;
using System.Collections.Generic;
using RentACar.BO.Entities;
using RentACar.BO.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace RentACar.DAL.DAClasses
{
    public class RepairsDAL : IBaseConvert<Repair>, IBaseCrud<Repair>
    {
        public bool Add(Repair model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Repairs_Insert",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("VehicleID", model.VehicleID != 0 ? model.VehicleID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("Rental_ReturnID", model.Rental_ReturnID != 0 ? model.Rental_ReturnID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("ResponsibleCompany", model.ResponsibleCompany != null ? model.ResponsibleCompany : (object)DBNull.Value);
                        command.Parameters.AddWithValue("StartDate", model.StartDate != DateTime.MinValue ? model.StartDate : (object)DBNull.Value);
                        command.Parameters.AddWithValue("ReturnDate", model.ReturnDate != DateTime.MinValue ? model.ReturnDate : (object)DBNull.Value);
                        command.Parameters.AddWithValue("Description", model.Description != null ? model.Description : (object)DBNull.Value);
                        command.Parameters.AddWithValue("Costs", model.Costs != 0.00M ? model.Costs : (object)DBNull.Value);
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

        public Repair Get(int id)
        {
            try
            {
                Repair result = null;

                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Repairs_GetByID", CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("RepairID", id);

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

        public Repair Get(Repair model)
        {
            throw new NotImplementedException();
        }

        public List<Repair> GetAll()
        {
            try
            {
                List<Repair> result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Repairs_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = new List<Repair>();
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

        public bool Modify(Repair model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Repairs_Modify",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("RepairID", model.RepairID != 0 ? model.RepairID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("VehicleID", model.VehicleID != 0 ? model.VehicleID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("Rental_ReturnID", model.Rental_ReturnID != 0 ? model.Rental_ReturnID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("ResponsibleCompany", model.ResponsibleCompany != null ? model.ResponsibleCompany : (object)DBNull.Value);
                        command.Parameters.AddWithValue("StartDate", model.StartDate != DateTime.MinValue ? model.StartDate : (object)DBNull.Value);
                        command.Parameters.AddWithValue("ReturnDate", model.ReturnDate != DateTime.MinValue ? model.ReturnDate : (object)DBNull.Value);
                        command.Parameters.AddWithValue("Description", model.Description != null ? model.Description : (object)DBNull.Value);
                        command.Parameters.AddWithValue("Costs", model.Costs != 0.00M ? model.Costs : (object)DBNull.Value);
                        command.Parameters.AddWithValue("IsRepaired", model.IsRepaired);
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

        public bool Remove(int id)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Repairs_Remove",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("RepairID", id);
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

        public bool Remove(Repair model)
        {
            throw new NotImplementedException();
        }

        public Repair ToObject(SqlDataReader reader)
        {
            Repair repair = new Repair();
            repair.Vehicle = new Vehicle();
            repair.Vehicle.VehicleBrand = new VehicleBrand();
            repair.RepairID = int.Parse(reader["RepairID"].ToString());
            repair.VehicleID = reader["VehicleID"] != DBNull.Value ? int.Parse(reader["VehicleID"].ToString()) : 0;
            repair.Rental_ReturnID = reader["Rental_ReturnID"] != DBNull.Value ? int.Parse(reader["Rental_ReturnID"].ToString()) : 0;
            repair.ResponsibleCompany = reader["ResponsibleCompany"].ToString();
            repair.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
            repair.ReturnDate = reader["ReturnDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReturnDate"].ToString()) : DateTime.MinValue;
            repair.IsRepaired = bool.Parse(reader["IsRepaired"].ToString());
            repair.Description = reader["Description"].ToString();
            if (reader["Costs"] != DBNull.Value)
                repair.Costs = Convert.ToDecimal(reader["Costs"].ToString());

            repair.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
            repair.LUD = DateTime.Parse(reader["LUD"].ToString());

            repair.Vehicle.VehicleBrand.Make = reader["Make"] != DBNull.Value ? reader["Make"].ToString() : null;
            repair.Vehicle.VehicleBrand.Model = reader["Model"] != DBNull.Value ? reader["Model"].ToString() : null;

            repair.init();

            return repair;
        }
    }
}
