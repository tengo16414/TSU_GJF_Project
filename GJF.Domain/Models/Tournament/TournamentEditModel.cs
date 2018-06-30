using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Domain.Models.Tournament
{
    public class TournamentEditModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("დასახელება")]
        public string Name { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("აღწერა")]
        public string Description { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("მონაწილეების რაოდენობა")]
        public int NumberOfContestants { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("თარიღი")]
        public DateTime Date { get; set; }
        [DisplayName("სპორცმენი")]
        public List<Entities.Sportsman> Sportsmen { get; set; } = new List<Entities.Sportsman>();
        [DisplayName("შეხვედრა")]
        public List<Entities.Wrestle> Wrestles { get; set; } = new List<Entities.Wrestle>();
    }
}
