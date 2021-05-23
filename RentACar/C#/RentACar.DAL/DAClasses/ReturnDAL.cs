using System;
using System.Collections.Generic;
using System.Text;
using RentACar.BO.Entities;
using RentACar.BO.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace RentACar.DAL.DAClasses
{
    public class ReturnDAL : IBaseCrud<Rental_Return>, IBaseConvert<Rental_Return>
    {
        public bool Add(Rental_Return model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Returns_Insert",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("BookingID", model.BookingID);
                        command.Parameters.AddWithValue("Date", model.Date);
                        command.Parameters.AddWithValue("VehicleActualCondition", model.VehicleActualConditionRental_Return);
                        command.Parameters.AddWithValue("FuelAmount", model.FuelAmount);
                        command.Parameters.AddWithValue("Mileage", model.Mileage);
                        command.Parameters.AddWithValue("ReturnedDate", model.Fee.returnDate != DateTime.MinValue ? model.Fee.returnDate : (object) DBNull.Value);
                        command.Parameters.AddWithValue("Damages", model.Fee.Reason != null ? model.Fee.Reason : (object) DBNull.Value );
                        command.Parameters.AddWithValue("IsLatePaid", model.Fee.IsPaid);
                        command.Parameters.AddWithValue("IsLate", model.Fee.IsLate);
                        command.Parameters.AddWithValue("Costs", model.Fee.Costs != 0.00M ? model.Fee.Costs : (object) DBNull.Value );
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

        public Rental_Return Get(int id)
        {
            try
            {
                Rental_Return result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Returns_GetByID", CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("ReturnID", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
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

        public Rental_Return Get(Rental_Return model)
        {
            throw new NotImplementedException();
        }

        public List<Rental_Return> GetAll()
        {
            try
            {
                List<Rental_Return> result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Returns_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = new List<Rental_Return>();
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

        public bool Modify(Rental_Return model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Returns_Modify",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("ReturnID", model.Rental_ReturnID);
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
            throw new NotImplementedException();
        }

        public bool Remove(Rental_Return model)
        {
            throw new NotImplementedException();
        }

        public Rental_Return ToObject(SqlDataReader reader)
        {
            Rental_Return Return = new Rental_Return();
            Return.Booking = new Booking();
            Return.Fee = new Fee();

            Return.Rental_ReturnID = int.Parse(reader["Rental_ReturnID"].ToString());
            Return.BookingID = int.Parse(reader["BookingID"].ToString());
            Return.IsRental = bool.Parse(reader["IsRental"].ToString());
            Return.Date = DateTime.Parse(reader["Date"].ToString());
            Return.FuelAmount = decimal.Parse(reader["FuelAmount"].ToString());
            Return.VehicleActualConditionRental_Return = reader["VehicleActualConditionRental_Return"].ToString();
            Return.Mileage = reader["Mileage"].ToString();
            Return.IsClosed = bool.Parse(reader["IsClosed"].ToString());

            Return.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
            Return.LUD = DateTime.Parse(reader["LUD"].ToString());
            Return.Booking.vehicleInfos = reader["Make"].ToString() + " " + reader["Model"].ToString();
            Return.Booking.clientInfos = reader["Name"].ToString() + " " + reader["Surname"].ToString();
            Return.Booking.VehicleID = int.Parse(reader["VehicleID"].ToString());
            Return.Booking.ClientID = int.Parse(reader["ClientID"].ToString());

            Return.init();

            return Return;
        }
    }
}
