using System;
using System.Collections.Generic;
using System.Text;
using RentACar.BO.Interfaces;
using RentACar.BO.Entities;
using RentACar.DAL.DAClasses;

namespace RentACar.BLL
{
    public class ClientBLL : IBaseCrud<Client>
    {
        public static ClientDAL dal = new ClientDAL();

        public bool Add(Client client)
        {
            return dal.Add(client);
        }

        public Client Get(int id)
        {
            return dal.Get(id);
        }

        public Client Get(Client client)
        {
            return dal.Get(client);
        }

        public List<Client> GetAll()
        {
            return dal.GetAll();
        }

        public bool Modify(Client client)
        {
            return dal.Modify(client);
        }

        public bool Remove(int id)
        {
            return dal.Remove(id);
        }

        public bool Remove(Client client)
        {
            return dal.Remove(client);
        }
    }
}
