using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Domain.Entities
{
    public class Sportsman
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("პირადი ნომერი")]
        public string PersonalNumber { get; set; }
        [DisplayName("სახელი")]
        public string Name { get; set; }
        [DisplayName("გვარი")]
        public string Surname { get; set; }
        [DisplayName("დაბადების თარიღი")]
        public DateTime  BirthDate{ get; set; }


        [ForeignKey("Sex")]
        public int SexId { get; set; }

        [DisplayName("რანგი")]
        public int Rank { get; set; }
        [DisplayName("წონა")]
        public double Weight { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual Sex Sex { get; set; }
    }
}
