﻿using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Bll.Concrete
{
    public class PhoneBll:IPhoneBll
    {

      
        private IPhoneDal _phoneDal;

        public PhoneBll(IPhoneDal phoneDal)
        {
            _phoneDal = phoneDal;
        }
        public List<Phone> ListAllOfCompany(int compId)
        {
            return _phoneDal.AllList(x=>x.CompanyID==compId);
        }

        public Phone GetOne(string phoneNo,int compId)
        {
            return _phoneDal.GetOne(x=>x.phoneNumber==phoneNo&& x.CompanyID==compId);
        }

        public bool Add(Phone phone)
        {
            bool result = _phoneDal.Add(phone);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Phone phone)
        {
            bool result = _phoneDal.Update(phone);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            Phone phone = _phoneDal.GetOne(x => x.id == id);
            bool result = _phoneDal.Delete(phone);    
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