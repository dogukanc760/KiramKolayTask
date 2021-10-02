using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Core.Entities.ViewModel
{
    public class EquipmentByClinicViewModel
    {
        public Clinics Clinics { get; set; }
        public Equipment Equipment { get; set; }
    }
}
