using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace GJF.Domain.Models.Tournament
{
    public class TournamentViewModel
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
        [DisplayName("სპორცმენი")]
        public List<Entities.Sportsman> Sportsmen { get; set; } = new List<Entities.Sportsman>();
        [DisplayName("შეხვედრა")]
        public List<Entities.Wrestle> Wrestles { get; set; } = new List<Entities.Wrestle>();
    }
}
