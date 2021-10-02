using Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Sehirler: IEntity
    {

        [Key]
        public int id { get; set; }

        [Required]
        [MinLength(5), MaxLength(50)]
        public string sehir_adi { get; set; }

    }
}
