using System;
using System.Collections.Generic;
using RentACar.BO.Entities;
using RentACar.BO.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace RentACar.DAL.DAClasses
{
    public class VehicleDAL : IBaseConvert<Vehicle>, IBaseCrud<Vehicle>
    {
        public bool Add(Vehicle model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Vehicles_Insert",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("VehicleMake", model.VehicleBrand.Make);
                        command.Parameters.AddWithValue("VehicleModel", model.VehicleBrand.Model);
                        command.Parameters.AddWithValue("VehicleCategory", model.VehicleBrand.Category);
                        command.Parameters.AddWithValue("RegistrationDate", model.VehicleRegistration.RegistrationDate);
                        command.Parameters.AddWithValue("Transmission", model.Transmission);
                        command.Parameters.AddWithValue("ProductionYear", model.ProductionYear);
                        command.Parameters.AddWithValue("DailyPrice", model.DailyPrice);
                        command.Parameters.AddWithValue("PlateNr", model.PlateNr);
                        command.Parameters.AddWithValue("SeatsNr", model.SeatsNr);
                        command.Parameters.AddWithValue("Mileage", model.Mileage);
                        command.Parameters.AddWithValue("OtherInfos", model.OtherInfos);
                        command.Parameters.AddWithValue("FuelType", model.FuelType);
                        command.Parameters.AddWithValue("FuelAmount", model.FuelAmount);
                        command.Parameters.AddWithValue("VehicleActualCondition", model.VehicleActualCondition);
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

        public Vehicle Get(int id)
        {
            try
            {
                Vehicle result = null;

                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Vehicles_GetByID", CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("VehicleID", id);

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

        public Vehicle Get(Vehicle model)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAll()
        {
            try
            {
                List<Vehicle> result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Vehicles_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = new List<Vehicle>();
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

        public bool Modify(Vehicle model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Vehicles_Modify",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("VehicleID", model.VehicleID);
                        command.Parameters.AddWithValue("VehicleMake", model.VehicleBrand.Make != null ? model.VehicleBrand.Make : (object)DBNull.Value );
                        command.Parameters.AddWithValue("VehicleModel", model.VehicleBrand.Model != null ? model.VehicleBrand.Model : (object)DBNull.Value);
                        command.Parameters.AddWithValue("VehicleCategory", model.VehicleBrand.Category != null ? model.VehicleBrand.Category : (object)DBNull.Value);
                        command.Parameters.AddWithValue("RegistrationDate", model.VehicleRegistration.RegistrationDate != DateTime.MinValue ? model.VehicleRegistration.RegistrationDate : (object)DBNull.Value);
                        command.Parameters.AddWithValue("Transmission", model.Transmission != null ? model.Transmission : (object)DBNull.Value);
                        command.Parameters.AddWithValue("ProductionYear", model.ProductionYear != 0 ? model.ProductionYear : (object)DBNull.Value);
                        command.Parameters.AddWithValue("DailyPrice", model.DailyPrice != 0.00M ? model.DailyPrice : (object)DBNull.Value);
                        command.Parameters.AddWithValue("PlateNr", model.PlateNr != null ? model.PlateNr : (object)DBNull.Value);
                        command.Parameters.AddWithValue("SeatsNr", model.SeatsNr != 0 ? model.SeatsNr : (object)DBNull.Value);
                        command.Parameters.AddWithValue("Mileage", model.Mileage != null ? model.Mileage : (object)DBNull.Value);
                        command.Parameters.AddWithValue("OtherInfos", model.OtherInfos != null ? model.OtherInfos : (object)DBNull.Value);
                        command.Parameters.AddWithValue("IsAvailable", model.IsAvailable);
                        command.Parameters.AddWithValue("FuelType", model.FuelType != null ? model.FuelType : (object)DBNull.Value);
                        command.Parameters.AddWithValue("FuelAmount", model.FuelAmount != 0.00M ? model.FuelAmount : (object)DBNull.Value);
                        command.Parameters.AddWithValue("VehicleActualCondition", model.VehicleActualCondition != null ? model.VehicleActualCondition : (object)DBNull.Value);
                        command.Parameters.AddWithValue("InGoodCondition", model.InGoodCondition == false ? (object)DBNull.Value : model.InGoodCondition);
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
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Vehicles_Remove",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("VehicleID", id);
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

        public bool Remove(Vehicle model)
        {
            throw new NotImplementedException();
        }

        public Vehicle ToObject(SqlDataReader reader)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleBrand = new VehicleBrand();
            vehicle.VehicleRegistration = new VehicleRegistration();

            vehicle.VehicleID = int.Parse(reader["VehicleID"].ToString());
            vehicle.VehicleBrandID = int.Parse(reader["VehicleBrandID"].ToString());
            vehicle.VehicleRegistrationID = int.Parse(reader["VehicleRegistrationID"].ToString());
            vehicle.Transmission = reader["Transmission"].ToString();
            vehicle.ProductionYear = int.Parse(reader["ProductionYear"].ToString());
            vehicle.DailyPrice = decimal.Parse(reader["DailyPrice"].ToString());
            vehicle.PlateNr = reader["PlateNr"].ToString();
            vehicle.SeatsNr = int.Parse(reader["SeatsNr"].ToString());
            vehicle.OtherInfos = reader["OtherInfos"].ToString();
            vehicle.IsAvailable = Boolean.Parse(reader["IsAvailable"].ToString());
            vehicle.FuelType = reader["FuelType"].ToString();
            vehicle.FuelAmount = decimal.Parse(reader["FuelAmount"].ToString());
            vehicle.VehicleActualCondition = (reader["VehicleActualCondition"].ToString());
            vehicle.InGoodCondition = Boolean.Parse(reader["InGoodCondition"].ToString());
            vehicle.Mileage = reader["Mileage"].ToString();

            vehicle.VehicleBrand.Make = reader["Make"].ToString();
            vehicle.VehicleBrand.Model = reader["Model"].ToString();
            vehicle.VehicleBrand.Category = reader["Category"].ToString();

            vehicle.VehicleRegistration.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"].ToString());
            vehicle.VehicleRegistration.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"].ToString());

            vehicle.init();

            return vehicle;
        }
    }
}
