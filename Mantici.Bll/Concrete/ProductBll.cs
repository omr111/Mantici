﻿using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Bll.Concrete
{
    public class ProductBll:IProductBll
    {

        private IProductDal _productDal;

        public ProductBll(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> ListAll(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.AllList();
        }

        public List<Product> listTatliMeze(int tatliId, int mezeId)
        {
            return _productDal.AllList(x => x.categoryID == tatliId || x.categoryID == mezeId);
        }
        public Product GetOne(int id)
        {
            return _productDal.GetOne(x=>x.id==id);
        }

        public bool Add(Product product)
        {
            bool result = _productDal.Add(product);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Product product)
        {
            bool result = _productDal.Update(product);
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
            Product product = _productDal.GetOne(x => x.id == id);
            bool result = _productDal.Delete(product);
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