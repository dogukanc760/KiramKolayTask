using Core.Utilities.Results;
using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISehirlerService
    {

        IDataResult<Sehirler> GetById(int sehirId);
        IDataResult<List<Sehirler>> GetList();
        IDataResult<List<Sehirler>> GetListByRegion(int regionId);
        IResult Add(Sehirler sehirler);
        IResult Update(Sehirler sehirler);
        IResult Delete(Sehirler sehirler);

    }
}
