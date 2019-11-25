using Mantici.Entities.Models;
using System.Collections.Generic;

namespace Mantici.Bll.Abstract
{
    public interface IserviceBll
    {
        List<service> defaultServiceList();
        bool addService(service service);
        service getOneWithId(int id);
        bool deleteService(int id);
        bool update(service service);
    }
}