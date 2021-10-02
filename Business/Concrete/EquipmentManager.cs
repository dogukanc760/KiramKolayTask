using Business.Abstract;
using Business.Constants;

using Core.Entities;
using Core.Entities.ViewModel;
using Core.Utilities.Results;

using DataAccess.Abstract;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EquipmentManager : IEquipmentService
    {
        private IEquipmentDal _equipmentService;
        private ISysLog _syslog;
        public EquipmentManager(IEquipmentDal equipmentService, ISysLog sysLog)
        {
            _equipmentService = equipmentService;
            _syslog = sysLog;
        }

        public IResult Add(Equipment equipment)
        {
            _equipmentService.Add(equipment);
            SysLog sysLogs = new SysLog { LogContent = equipment.Name + " named Equipment has created.", LogDate = DateTime.Now };
            _syslog.Add(sysLogs);
            return new SuccessResult(Messages.EquipmentAdded);
        }

        public IResult Delete(Equipment equipment)
        {
            _equipmentService.Add(equipment);
            SysLog sysLogs = new SysLog { LogContent = equipment.Name + " named Equipment has deleted.", LogDate = DateTime.Now };
            _syslog.Add(sysLogs);
            return new SuccessResult(Messages.EquipmentDeleted);
        }

        public IDataResult<Equipment> GetById(int equipmentId)
        {
            SysLog sysLogs = new SysLog { LogContent = equipmentId + " by list equipment", LogDate = DateTime.Now };
            _syslog.Add(sysLogs);
            return new SuccessDataResult<Equipment>(_equipmentService.Get(p => p.Id == equipmentId));
        }

        public IDataResult<List<Equipment>> GetList()
        {
            SysLog sysLogs = new SysLog { LogContent = "Some one has get list of all equipment", LogDate = DateTime.Now };
            _syslog.Add(sysLogs);
            return new SuccessDataResult<List<Equipment>>(_equipmentService.GetList().ToList());
        }

        public IDataResult<List<Equipment>> GetListByBetweenDates(DateTime startDate, DateTime finishDate)
        {
            return new SuccessDataResult<List<Equipment>>(_equipmentService.GetList(p => p.AvialabilityDate >= startDate && p.AvialabilityDate <= finishDate).ToList());
        }

        public IDataResult<List<Equipment>> GetListByBuyDate(DateTime buyDate)
        {
            return new SuccessDataResult<List<Equipment>>(_equipmentService.GetList(p => p.AvialabilityDate == buyDate).ToList());
        }

        public IDataResult<List<Equipment>> GetListByClinic(int clinicId)
        {
            return new SuccessDataResult<List<Equipment>>(_equipmentService.GetList(p => p.ClinicId == clinicId).ToList());
        }

        //viewmodel
        public IDataResult<List<EquipmentByClinicViewModel>> GetListByClinicDetail(int clinicId)
        {

            return new SuccessDataResult<List<EquipmentByClinicViewModel>>(_equipmentService.GetList(p => p.ClinicId == clinicId).ToList());
        }

        public IDataResult<List<Equipment>> GetListByOrd(bool ordType)
        {
            if (ordType.Equals(true))
            {
                return new SuccessDataResult<List<Equipment>>(_equipmentService.GetList().OrderByDescending(p => p.ClinicId).ToList());
            }
            return new SuccessDataResult<List<Equipment>>(_equipmentService.GetList().OrderBy(p => p.ClinicId).ToList());
        }

        public IDataResult<List<Equipment>> GetListByPage(int takeCount, int pageCount)
        {
            return new SuccessDataResult<List<Equipment>>(_equipmentService.GetList().Skip(takeCount).Take(pageCount).ToList());
        }

        public IResult Update(Equipment equipment)
        {
            _equipmentService.Update(equipment);
            SysLog sysLogs = new SysLog { LogContent = equipment.Name + " named Equipment has updated.", LogDate = DateTime.Now };
            _syslog.Add(sysLogs);
            return new SuccessResult(Messages.EquipmentUpdated);
        }
    }
}
