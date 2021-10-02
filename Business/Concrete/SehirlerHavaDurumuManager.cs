using Business.Abstract;
using Business.Constants;

using Core.Utilities.Results;

using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

using Entities.Concrete;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SehirlerHavaDurumuManager : ISehirlerHavaDurumuService
    {
        private ISehirlerHavaDurumlariDal _sehirlerHavaDurumuDal;
        public SehirlerHavaDurumuManager(ISehirlerHavaDurumlariDal sehirlerHavaDurumlariDal)
        {
            _sehirlerHavaDurumuDal = sehirlerHavaDurumlariDal;
        }


        public IResult GenerateSystemBase(SehirlerHavaDurumlari sehirlerHavaDurumlari, Sehirler sehirler)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                if (context.SehirlerHavaDurumlari.ToList().Count() > 0)
                {
                    return new ErrorResult(message: "Proccess Failed");
                }
                var result = context.Database.ExecuteSqlRaw("Exec spYeniKayitEkle @sehir_id, @tarih, @durum, @mak, @kayit_tarihi",
                    parameters: new[] { (sehirlerHavaDurumlari.sehir_id, sehirlerHavaDurumlari.tarih, sehirlerHavaDurumlari.durum, sehirlerHavaDurumlari.Mak, sehirlerHavaDurumlari.kayit_tarihi) });
                var resultCity  = context.Database.ExecuteSqlRaw("Exec spYeniKayitEkleSehir",
                    parameters: new[] { (sehirler.sehir_adi) });
                return new SuccessResult(Messages.Added);
            }
        }

        public IResult Add(SehirlerHavaDurumlari sehirlerHavaDurumlari)
        {
            //Normal olarak bu alt yapı ile ef core range modülleri ile ekleme yapmak yerine -dal- katmanı üzerine override gibi düşünebiliriz direkt string sorgu ile hallediyor işimizi
            using (NorthwindContext context = new NorthwindContext())
            {
                if (context.SehirlerHavaDurumlari.ToList().Count() > 0)
                {
                    return new ErrorResult(message: "Proccess Failed");
                }
                var result = context.Database.ExecuteSqlRaw("Exec spYeniKayitEkle @sehir_id, @tarih, @durum, @mak, @kayit_tarihi",
                    parameters: new[] { (sehirlerHavaDurumlari.sehir_id, sehirlerHavaDurumlari.tarih, sehirlerHavaDurumlari.durum, sehirlerHavaDurumlari.Mak, sehirlerHavaDurumlari.kayit_tarihi) });
                return new SuccessResult(Messages.Added);
            }



        }

        public IResult Delete(SehirlerHavaDurumlari sehirlerHavaDurumlari)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Her gün api bu kısımda veritabanını önce temizleyip daha sonra veri yazacak
                if (context.SehirlerHavaDurumlari.ToList().Count() < 1)
                {
                    return new ErrorResult(message: "Proccess Failed");
                }
                var result = context.Database.ExecuteSqlRaw("Exec spHavaDurumuSifirlama");
                return new SuccessResult(Messages.Added);
            }
        }


        public IDataResult<List<SehirlerHavaDurumlari>> GetWeatherAll()
        {
            return new SuccessDataResult<List<SehirlerHavaDurumlari>>(_sehirlerHavaDurumuDal.GetList().ToList());
        }

        public IDataResult<List<SehirlerHavaDurumlari>> GetWeatherAllByRegion(int bolgeId)
        {
            return new SuccessDataResult<List<SehirlerHavaDurumlari>>(_sehirlerHavaDurumuDal.GetList(x=>x.sehir_id == bolgeId).ToList());
        }

        public IDataResult<SehirlerHavaDurumlari> GetWeatherByCity(int sehirId)
        {
            return new SuccessDataResult<SehirlerHavaDurumlari>(_sehirlerHavaDurumuDal.Get(x=>x.sehir_id == sehirId));
        }

        public IResult Update(SehirlerHavaDurumlari sehirlerHavaDurumlari)
        {
            throw new NotImplementedException();
        }
    }
}
