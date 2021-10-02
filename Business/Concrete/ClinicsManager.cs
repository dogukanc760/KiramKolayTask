using Business.Abstract;
using Business.Constants;

using Core.Entities;
using Core.Utilities.Results;

using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClinicsManager : IClinicsService
    {
        private IClinicsDal _clinicDal;
        private ISysLog _syslog;
        public ClinicsManager(IClinicsDal clinicsDal, ISysLog sysLog)
        {
            _clinicDal = clinicsDal;
            _syslog = sysLog;
        }

        public IResult Add(Clinics clinics)
        {
            _clinicDal.Add(clinics);
            SysLog sysLogs = new SysLog { LogContent = clinics.Name + " named Clinics has created.", LogDate = DateTime.Now };
            _syslog.Add(sysLogs);
            return new SuccessResult(Messages.ClinicAdded);
        }

        public IResult Delete(Clinics clinics)
        {
            _clinicDal.Delete(clinics);
            SysLog sysLogs = new SysLog { LogContent = clinics.Name + " named Clinics has removed.", LogDate = DateTime.Now };
            _syslog.Add(sysLogs);
            return new SuccessResult(Messages.ClinicDeleted);

        }

        public IDataResult<Clinics> GetById(int clinicId)
        {
            SysLog sysLogs = new SysLog { LogContent = clinicId + " has listed.", LogDate = DateTime.Now };
            _syslog.Add(sysLogs);
            return new SuccessDataResult<Clinics>(_clinicDal.Get(p => p.Id == clinicId));
        }

        public IDataResult<List<Clinics>> GetList()
        {
            SysLog sysLogs = new SysLog { LogContent = "All Clinics has Listed", LogDate = DateTime.Now };
            _syslog.Add(sysLogs);
            return new SuccessDataResult<List<Clinics>>(_clinicDal.GetList().ToList());
        }

        public IResult Update(Clinics clinics)
        {
            SysLog sysLogs = new SysLog { LogContent = clinics.Name + " named Clinics has updated.", LogDate = DateTime.Now };
            _syslog.Add(sysLogs);
            _clinicDal.Update(clinics);
            return new SuccessResult(Messages.ClinicUpdated);

        }
    }
}
