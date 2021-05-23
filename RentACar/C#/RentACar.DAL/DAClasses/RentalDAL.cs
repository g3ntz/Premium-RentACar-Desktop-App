using System;
using System.Collections.Generic;
using System.Text;
using RentACar.BO.Entities;
using RentACar.BO.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace RentACar.DAL.DAClasses
{
    public class RentalDAL : IBaseCrud<Rental_Return>, IBaseConvert<Rental_Return>
    {
        public bool Add(Rental_Return model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Rentals_Insert",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("BookingID", model.BookingID);
                        command.Parameters.AddWithValue("IsRental", model.IsRental);
                        command.Parameters.AddWithValue("VehicleActualCondition", model.VehicleActualConditionRental_Return);
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
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Rental_GetByID", CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("RentalID", id);
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
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Rentals_GetAll", CommandType.StoredProcedure))
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
            throw new NotImplementedException();
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
            Rental_Return rental = new Rental_Return();
            rental.Booking = new Booking();
            rental.Fee = new Fee();

            rental.Rental_ReturnID = int.Parse(reader["Rental_ReturnID"].ToString());
            rental.BookingID = int.Parse(reader["BookingID"].ToString());
            rental.IsRental = bool.Parse(reader["IsRental"].ToString());
            rental.Date = DateTime.Parse(reader["Date"].ToString());
            rental.FuelAmount = decimal.Parse(reader["FuelAmount"].ToString());
            rental.VehicleActualConditionRental_Return = reader["VehicleActualConditionRental_Return"].ToString();
            rental.Mileage = reader["Mileage"].ToString();
            rental.IsClosed = bool.Parse(reader["IsClosed"].ToString());
            rental.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());

            rental.Booking.vehicleInfos = reader["Make"].ToString() + " " + reader["Model"].ToString();
            rental.Booking.clientInfos = reader["Name"].ToString() + " " + reader["Surname"].ToString();
            rental.Booking.ClientID = int.Parse(reader["ClientID"].ToString());
            rental.Booking.VehicleID = int.Parse(reader["VehicleID"].ToString());

            rental.init();

            return rental;
        }
    }
}
