using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace RentACar.BO.Interfaces
{
    public interface IBaseConvert<T>
    {
        T ToObject(SqlDataReader reader);
    }
}
