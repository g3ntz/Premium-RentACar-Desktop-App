using System;
using System.Collections.Generic;
using System.Text;
using RentACar.BO.Entities;
using RentACar.BO.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace RentACar.DAL.DAClasses
{
    public class FeeDAL : IBaseCrud<Fee>, IBaseConvert<Fee>
    {
        public bool Add(Fee model)
        {
            try
            {
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_FeeLate_Insert",
                        CommandType.StoredProcedure))
                    {
                        command.Parameters.AddWithValue("RentalID", model.returnID);
                        command.Parameters.AddWithValue("Reason", model.Reason);
                        command.Parameters.AddWithValue("Costs", model.Costs);
                        command.Parameters.AddWithValue("IsPaid", model.IsPaid);
                        command.Parameters.AddWithValue("ReturnDate", model.returnDate);
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

        public Fee Get(int id)
        {
            throw new NotImplementedException();
        }

        public Fee Get(Fee model)
        {
            throw new NotImplementedException();
        }

        public List<Fee> GetAll()
        {
            try
            {
                List<Fee> result = null;
                using (var connection = SqlHelper.GetConnection())
                {
                    using (var command = SqlHelper.Command(connection, "dbo.usp_FeeLate_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = new List<Fee>();
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

        public bool Modify(Fee model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Fee model)
        {
            throw new NotImplementedException();
        }

        public Fee ToObject(SqlDataReader reader)
        {
            Fee fee = new Fee();
            fee.returnID = int.Parse(reader["Rental_ReturnID"].ToString());
            fee.Reason = reader["Reason"].ToString();
            fee.Costs = reader["Costs"] != DBNull.Value ? decimal.Parse(reader["Costs"].ToString()) : 0;
            fee.IsPaid = bool.Parse(reader["IsPaid"].ToString());
            fee.returnDate = reader["ReturnDate"] != DBNull.Value ? DateTime.Parse(reader["ReturnDate"].ToString()) : DateTime.MinValue;
            fee.IsLate = bool.Parse(reader["IsLate"].ToString());
            fee.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
            fee.LUD = DateTime.Parse(reader["LUD"].ToString());

            return fee;
        }
    }
}
