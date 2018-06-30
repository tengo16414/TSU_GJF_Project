using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Domain.Entities
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("რეგიონი")]
        public string Name { get; set; }
    }
}
