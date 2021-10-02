using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SysLog : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string LogContent { get; set; }

        [Required]
        public DateTime LogDate { get; set; }
    }
}
