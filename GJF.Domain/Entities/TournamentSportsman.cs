using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Domain.Entities
{
    public class TournamentSportsman
    {
        [Key]
        public int Id { get; set; }

        public int TournamentId { get; set; }

        
        public int SportsmanId { get; set; }

        public bool Seeded { get; set; }

        [ForeignKey("TournamentId")]
        public virtual Tournament Tournament { get; set; }

        [ForeignKey("SportsmanId")]
        public virtual Sportsman Sportsman { get; set; }
    }
}
