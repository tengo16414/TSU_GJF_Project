using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Domain.Models.Sportsman
{
    public class SportsmanViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("სახელი")]
        public string Name { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("გვარი")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("სქესი")]
        public int SexId { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("პირადი ნომერი")]
        public string PersonalNumber { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("დაბადების თარიღი")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("წონა")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("რანგი")]
        public int Rank { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("რეგიონი")]
        public int RegionId { get; set; }
        [DisplayName("რეგიონი")]
        public Entities.Region Region { get; set; }
        //[DisplayName("სქესი")]
        //    public Entities.Sex Sex { get; set; }
    }
}
