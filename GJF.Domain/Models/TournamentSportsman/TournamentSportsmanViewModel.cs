using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Domain.Models.TournamentSportsman
{
    public class TournamentSportsmanViewModel
    {
        public int Id { get; set; }

        public int TournamentId { get; set; }


        public int SportsmanId { get; set; }
        [DisplayName("განთესვა")]
        public bool Seeded { get; set; }

        public Entities.Tournament Tournament { get; set; }


        public Entities.Sportsman Sportsman { get; set; }
    }
}
