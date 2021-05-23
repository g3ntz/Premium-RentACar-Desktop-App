using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Interfaces
{
    public interface IBaseCrud<T>
    {
        //add -> bool, int, void
        bool Add(T model);
        bool Modify(T model);
        bool Remove(int id);
        bool Remove(T model);  //If foreign key is included

        List<T> GetAll();

        T Get(int id);
        T Get(T model); //If foreign key is included
    }
}
