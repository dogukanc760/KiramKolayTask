﻿using Core.DataAccess.EntityFramework;
using Core.Entities;

using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSysLogDal : EfEntityRepositoryBase<SysLog, NorthwindContext>, ISysLogDal
    {
    }
}
