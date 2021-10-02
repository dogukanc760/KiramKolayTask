using Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SehirlerHavaDurumlari : IEntity
    {

        [Key]
        public int id { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int sehir_id { get; set; }

        [Required]
        public DateTime tarih { get; set; }

        [Required]
        [MinLength(5), MaxLength(250)]
        public string durum { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Mak { get; set; }

        [Required]
        public DateTime kayit_tarihi { get; set; }
    }
}
