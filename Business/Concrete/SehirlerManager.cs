using Business.Abstract;
using Business.Constants;

using Core.Utilities.Results;

using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

using Entities.Concrete;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SehirlerManager : ISehirlerService
    {
        private ISehirlerDal _sehirlerDal;
        public SehirlerManager(ISehirlerDal sehirlerDal)
        {
            _sehirlerDal = sehirlerDal;
        }
        public IResult Add(Sehirler sehirler)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                if (context.Sehirlers.ToList().Count() > 0)
                {
                    return new ErrorResult(message: "Proccess Failed");
                }
                var result = context.Database.ExecuteSqlRaw("Exec spYeniKayitEkleSehir",
                    parameters: new[] { (sehirler.sehir_adi) });
                return new SuccessResult(Messages.Added);
            }
          
        }

        public IResult Delete(Sehirler sehirler)
        {
            _sehirlerDal.Delete(sehirler);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Sehirler> GetById(int sehirId)
        {
            return new SuccessDataResult<Sehirler>(_sehirlerDal.Get(x=>x.id == sehirId));
        }

        public IDataResult<List<Sehirler>> GetList()
        {
            return new SuccessDataResult<List<Sehirler>>(_sehirlerDal.GetList().ToList());
        }

        public IDataResult<List<Sehirler>> GetListByRegion(int regionId)
        {
            return new SuccessDataResult<List<Sehirler>>(_sehirlerDal.GetList(x=>x.id == regionId).ToList());
        }

        public IResult Update(Sehirler sehirler)
        {
            _sehirlerDal.Update(sehirler);
            return new SuccessResult(Messages.Updated);
        }
    }
}
