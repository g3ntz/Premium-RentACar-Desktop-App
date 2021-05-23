using System;
using System.Collections.Generic;
using System.Text;
using RentACar.BO.Interfaces;
using RentACar.BO.Entities;
using RentACar.DAL.DAClasses;

namespace RentACar.BLL
{
    public class ReturnBLL : IBaseCrud<Rental_Return>
    {
        public static ReturnDAL dal = new ReturnDAL();

        public bool Add(Rental_Return model)
        {
            return dal.Add(model);
        }

        public Rental_Return Get(int id)
        {
            return dal.Get(id);
        }

        public Rental_Return Get(Rental_Return model)
        {
            return dal.Get(model);
        }

        public List<Rental_Return> GetAll()
        {
            return dal.GetAll();
        }

        public bool Modify(Rental_Return model)
        {
            return dal.Modify(model);
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Rental_Return model)
        {
            throw new NotImplementedException();
        }
    }
}
