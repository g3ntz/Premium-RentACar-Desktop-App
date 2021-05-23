using System;
using System.Collections.Generic;
using System.Text;
using RentACar.BO.Interfaces;
using RentACar.BO.Entities;
using RentACar.DAL.DAClasses;

namespace RentACar.BLL
{
    public class BookingsBLL : IBaseCrud<Booking>
    {
        public static BookingsDAL dal = new BookingsDAL();

        public bool Add(Booking model)
        {
            return dal.Add(model);
        }

        public Booking Get(int id)
        {
            return dal.Get(id);
        }

        public Booking Get(Booking model)
        {
            return dal.Get(model);
        }

        public List<Booking> GetAll()
        {
            return dal.GetAll();
        }

        public bool Modify(Booking model)
        {
            return dal.Modify(model);
        }

        public bool Remove(int id)
        {
            return dal.Remove(id);
        }

        public bool Remove(Booking model)
        {
            return dal.Remove(model);
        }
    }
}
