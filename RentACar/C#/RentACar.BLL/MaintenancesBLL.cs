using System;
using System.Collections.Generic;
using System.Text;
using RentACar.BO.Interfaces;
using RentACar.BO.Entities;
using RentACar.DAL.DAClasses;

namespace RentACar.BLL
{
    public class MaintenancesBLL : IBaseCrud<Maintenance>
    {
        public static MaintenancesDAL dal = new MaintenancesDAL();

        public bool Add(Maintenance maintenance)
        {
            return dal.Add(maintenance);
        }

        public Maintenance Get(int id)
        {
            return dal.Get(id);
        }

        public Maintenance Get(Maintenance maintenance)
        {
            return dal.Get(maintenance);
        }

        public List<Maintenance> GetAll()
        {
            return dal.GetAll();
        }

        public bool Modify(Maintenance maintenance)
        {
            return dal.Modify(maintenance);
        }

        public bool Remove(int id)
        {
            return dal.Remove(id);
        }

        public bool Remove(Maintenance maintenance)
        {
            return dal.Remove(maintenance);
        }

        private void initVehicleInfos()
        {

        }
    }
}
