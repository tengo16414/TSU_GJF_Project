namespace GJF.Domain.Models.Wrestle
{
    public class WrestleViewModel
    {
        public int Id { get; set; }

        public int SportsmanOneId { get; set; }

        public int SportsmanTwoId { get; set; }

        public int SporstmanOneWazariPoint { get; set; }

        public int SporstmanTwoWazariPoint { get; set; }

        public bool SporstmanOneIppon { get; set; }

        public bool SporstmanTwoIppon { get; set; }

        public int SportmanOneFine { get; set; }

        public int SportmanTwoFine { get; set; }

        public int WinnerSportsmanId { get; set; }

        public Entities.Sportsman SportsmanOne { get; set; }

        public Entities.Sportsman SportsmanTwo { get; set; }
    }
}
