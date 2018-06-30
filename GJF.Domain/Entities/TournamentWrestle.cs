using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Domain.Entities
{
    public class TournamentWrestle
    {
        [Key]
        public int Id { get; set; }

        public int TournamentId { get; set; }

        
        public int WrestleId { get; set; }

        [ForeignKey("TournamentId")]
        public virtual Tournament Tournament { get; set; }

        [ForeignKey("WrestleId")]
        public virtual Wrestle Wrestle { get; set; }

    }
}
