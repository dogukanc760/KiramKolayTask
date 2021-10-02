using Core.Utilities.Results;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISehirlerHavaDurumuService
    {

        IResult GenerateSystemBase(SehirlerHavaDurumlari sehirlerHavaDurumlarii, Sehirler sehirler);

        IResult Add(SehirlerHavaDurumlari sehirlerHavaDurumlari);
        IResult Update(SehirlerHavaDurumlari sehirlerHavaDurumlari);
        IResult Delete(SehirlerHavaDurumlari sehirlerHavaDurumlari);

        IDataResult<SehirlerHavaDurumlari> GetWeatherByCity(int sehirId);
        IDataResult<List<SehirlerHavaDurumlari>> GetWeatherAll();
        IDataResult<List<SehirlerHavaDurumlari>> GetWeatherAllByRegion(int bolgeId);

    }
}
