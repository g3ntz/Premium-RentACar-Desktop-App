using System;
using System.Collections.Generic;
using System.Text;
using RentACar.BO.Interfaces;
using RentACar.BO.Entities;
using RentACar.DAL.DAClasses;

namespace RentACar.BLL
{
    public class VehicleBLL : IBaseCrud<Vehicle>
    {
        public static VehicleDAL dal = new VehicleDAL();

        public bool Add(Vehicle model)
        {
            return dal.Add(model);
        }

        public Vehicle Get(int id)
        {
            return dal.Get(id);
        }

        public Vehicle Get(Vehicle model)
        {
            return dal.Get(model);
        }

        public List<Vehicle> GetAll()
        {
            return dal.GetAll();
        }

        public bool Modify(Vehicle model)
        {
            return dal.Modify(model);
        }

        public bool Remove(int id)
        {
            return dal.Remove(id);
        }

        public bool Remove(Vehicle model)
        {
            return dal.Remove(model);
        }
    }
}
