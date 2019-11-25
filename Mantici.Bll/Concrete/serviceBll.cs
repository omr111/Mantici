using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System.Collections.Generic;

namespace Mantici.Bll.Concrete
{
    public class serviceBll :IserviceBll
    {
        private IserviceDal _serviceDal;

        public serviceBll(IserviceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public List<service> defaultServiceList()
        {
            return _serviceDal.AllList();
        }
        public bool addService(service service)
        {
            bool resultAdd = _serviceDal.Add(service);
            if (resultAdd)
            {
                return true;
            }

            return false;
        }

        public  service getOneWithId(int id)
        {
            return _serviceDal.GetOne(x => x.id == id);
        }
        public bool update(service service)
        {
            bool result = _serviceDal.Update(service);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteService(int id)
        {
            service service = _serviceDal.GetOne(x => x.id == id);
            bool result = _serviceDal.Delete(service);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}