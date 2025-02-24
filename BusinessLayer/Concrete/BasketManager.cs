﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class BasketManager : IBasketService {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal) {
            _basketDal = basketDal;
        }

        public void TAdd(Basket entity) {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity) {
            _basketDal.Delete(entity);
        }

        public List<Basket> TGetBasketByCafeTableNumber(int cafeTableNumber) {
            return _basketDal.GetBasketByCafeTableNumber(cafeTableNumber);
        }

        public Basket TGetById(int id) {
            return _basketDal.GetById(id);
        }

        public List<Basket> TGetListAll() {
            throw new NotImplementedException();
        }

        public void TUpdate(Basket entity) {
            throw new NotImplementedException();
        }
    }
}
