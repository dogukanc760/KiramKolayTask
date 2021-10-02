using Business.Abstract;
using Business.Constants;

using Core.Entities;
using Core.Utilities.Results;

using DataAccess.Abstract;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SysLogManager : ISysLog
    {
        private ISysLogDal _syslog;
        public SysLogManager(ISysLogDal sysLog)
        {
            _syslog = sysLog;
        }

        public IResult Add(SysLog sysLog)
        {
            _syslog.Add(sysLog);
            return new SuccessResult(Messages.AddedLog);
        }

        public IDataResult<List<SysLog>> GetList()
        {
            return new SuccessDataResult<List<SysLog>>(_syslog.GetList().ToList());
        }
    }
}
