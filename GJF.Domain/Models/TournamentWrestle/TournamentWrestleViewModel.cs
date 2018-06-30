using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Domain.Models.TournamentWrestle
{
    public class TournamentWrestleViewModel
    {
        public int Id { get; set; }

        public int TournamentId { get; set; }


        public int WrestleId { get; set; }


        public Entities.Tournament Tournament { get; set; }


        public Entities.Wrestle Wrestle { get; set; }
    }
}
