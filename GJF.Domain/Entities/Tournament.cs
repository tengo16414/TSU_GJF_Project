using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Domain.Entities
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfContestants { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Sportsman> Sportsmen { get; set; } = new List<Sportsman>();

        public virtual ICollection<Wrestle> Wrestles { get; set; } = new List<Wrestle>();

    }
}
