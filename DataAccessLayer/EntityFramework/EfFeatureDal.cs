﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework {
    public class EfFeatureDal : GenericRepository<Feature>, IFeatureDal {
        public EfFeatureDal(Context context) : base(context) {
        }
    }
}
