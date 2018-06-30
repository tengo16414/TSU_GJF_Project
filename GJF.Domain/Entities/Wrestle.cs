using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GJF.Domain.Entities
{
    public class Wrestle
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SportsmanOne")]
        public int SportsmanOneId { get; set; }

        [ForeignKey("SportsmanTwo")]
        public int SportsmanTwoId { get; set; }

        public int SporstmanOneWazariPoint { get; set; }

        public int SporstmanTwoWazariPoint { get; set; }

        public bool SporstmanOneIppon { get; set; }

        public bool SporstmanTwoIppon { get; set; }

        public int SportmanOneFine { get; set; }

        public int SportmanTwoFine { get; set; }

        public int WinnerSportsmanId { get; set; }

        public virtual Sportsman SportsmanOne { get; set; }

        public virtual Sportsman SportsmanTwo { get; set; }

    }
}
