using System;
using System.Collections.Generic;
using RentACar.BO.Entities;
using RentACar.BO.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace RentACar.DAL.DAClasses
{
    public class BookingsDAL : IBaseCrud<Booking>, IBaseConvert<Booking>
    {
        public bool Add(Booking model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Bookings_Insert",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("ClientID", model.ClientID);
                        command.Parameters.AddWithValue("VehicleID", model.VehicleID);
                        command.Parameters.AddWithValue("Price", model.TotalPrice);
                        command.Parameters.AddWithValue("RentalDate", model.RentalDate);
                        command.Parameters.AddWithValue("ReturnDate", model.ReturnDate);
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

        public Booking Get(int id)
        {
            try
            {
                Booking result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Bookings_GetByID", CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("BookingID", id);
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

        public Booking Get(Booking model)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAll()
        {
            try
            {
                List<Booking> result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Bookings_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = new List<Booking>();
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

        public bool Modify(Booking model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Bookings_Modify",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("BookingID", model.BookingID != 0 ? model.BookingID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("ClientID", model.ClientID != 0 ? model.ClientID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("VehicleID", model.VehicleID != 0 ? model.VehicleID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("BookingStatusID", model.BookingStatusID != 0 ? model.BookingStatusID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("TotalPrice", model.TotalPrice != 0.00M ? model.TotalPrice : (object)DBNull.Value);
                        command.Parameters.AddWithValue("RentalDate", model.RentalDate != DateTime.MinValue ? model.RentalDate : (object)DBNull.Value);
                        command.Parameters.AddWithValue("ReturnDate", model.ReturnDate != DateTime.MinValue ? model.ReturnDate : (object)DBNull.Value);
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
                    using (var command = SqlHelper.Command(connection, "dbo.usp_Bookings_Remove",CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("BookingID", id);
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

        public bool Remove(Booking model)
        {
            throw new NotImplementedException();
        }

        public Booking ToObject(SqlDataReader reader)
        {
            Booking booking = new Booking();
            booking.Client = new Client();
            booking.Vehicle = new Vehicle();
            booking.Vehicle.VehicleBrand = new VehicleBrand();
            booking.BookingStatus = new BookingStatus();

            booking.BookingID = int.Parse(reader["BookingID"].ToString());
            booking.ClientID = int.Parse(reader["ClientID"].ToString());
            booking.VehicleID = int.Parse(reader["VehicleID"].ToString());
            booking.Client.Name = reader["Name"].ToString();
            booking.Client.Surname = reader["Surname"].ToString();
            booking.Vehicle.VehicleBrand.Make = reader["Make"].ToString();
            booking.Vehicle.VehicleBrand.Model = reader["Model"].ToString();
            booking.BookingStatus.StatusName = reader["StatusName"].ToString();
            booking.BookingStatusID = int.Parse(reader["BookingStatusID"].ToString());

            booking.TotalPrice = decimal.Parse(reader["TotalPrice"].ToString());
            booking.RentalDate = Convert.ToDateTime(reader["RentalDate"].ToString());
            booking.ReturnDate = Convert.ToDateTime(reader["ReturnDate"].ToString());
            booking.BookingDate = Convert.ToDateTime(reader["BookingDate"].ToString());
            booking.InsertDate = Convert.ToDateTime(reader["InsertDate"].ToString());

            booking.init();

            return booking;
        }
    }
}
