using Microsoft.AspNet.SignalR;
using GJF.BLL.Abstract;
using GJF.Domain.Entities;

namespace GJF.Hubs
{
    public class BoardHub : Hub
    {
        private readonly IWrestleBll _wrestleBll;

        public BoardHub(IWrestleBll wrestleBll)
        {
            _wrestleBll = wrestleBll;
        }

        public void AddClientToWrestle(string id)
        {
            Groups.Add(Context.ConnectionId, "wrestle" + id);
        }
        // sportsman one
        public void AddSportsmanOneIpponPoint(int message, int id)
        {
            var wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
            wrestle.SporstmanOneIppon = true;
            wrestle.WinnerSportsmanId = wrestle.SportsmanOneId;
            Clients.Group("wrestle" + id.ToString()).autoWinSportsmanOne();
            int? updatedId = _wrestleBll.Update(wrestle);
            if (updatedId == id)
                Clients.Group("wrestle" + id.ToString()).addSportsmanOneIpponPoint(1);
        }

        public void RemoveSportsmanOneIpponPoint(string message, int id)
        {
            var wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
            wrestle.SporstmanOneIppon = false;
            int? updatedId = _wrestleBll.Update(wrestle);
            if (updatedId == id)
                Clients.Group("wrestle" + id.ToString()).removeSportsmanOneIpponPoint(0);
        }


        public void AddSportsmanOneWazariPoint(int time, int message, int id)
        {
            int value = message + 1;
            Wrestle wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
            wrestle.SporstmanOneWazariPoint = value;
            if (time < 0) {
                wrestle.WinnerSportsmanId = wrestle.SportsmanOneId;
                Clients.Group("wrestle" + id.ToString()).autoWinSportsmanOne();
            }
            int? updatedId = _wrestleBll.Update(wrestle);
            if (updatedId == id)
                Clients.Group("wrestle" + id.ToString()).addSportsmanOneWazariPoint(value);
        }

        public void RemoveSportsmanOneWazariPoint(int message, int id)
        {
            if (message > 0)
            {
                int value = message - 1;
                Wrestle wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
                wrestle.SporstmanOneWazariPoint = value;
                int? updatedId = _wrestleBll.Update(wrestle);
                if (updatedId == id)
                    Clients.Group("wrestle" + id.ToString()).addSportsmanOneWazariPoint(value);
            }
        }

        public void AddSportsmanOneFinePoint(int message, int id)
        {
            if (message < 3)
            {
                int value = message + 1;
                Wrestle wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
                wrestle.SportmanOneFine = value;
                if (value == 3) {
                    wrestle.WinnerSportsmanId = wrestle.SportsmanTwoId;
                    Clients.Group("wrestle" + id.ToString()).autoWinSportsmanTwo();
                }
                
                int? updatedId = _wrestleBll.Update(wrestle);
                if (updatedId == id)
                    Clients.Group("wrestle" + id.ToString()).addSportsmanOneFinePoint(value);
            }
        }

        public void RemoveSportsmanOneFinePoint(int message, int id)
        {
            if (message > 0)
            {
                int value = message - 1;
                Wrestle wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
                wrestle.SportmanOneFine = value;
                int? updatedId = _wrestleBll.Update(wrestle);
                if (updatedId == id)
                    Clients.Group("wrestle" + id.ToString()).addSportsmanOneFinePoint(value);
            }
        }

        public void AddSportsmanTwoFinePoint(int message, int id)
        {
            if (message < 3)
            {
                int value = message + 1;
                Wrestle wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
                wrestle.SportmanTwoFine = value;
                if (value == 3) {
                    wrestle.WinnerSportsmanId = wrestle.SportsmanOneId;
                    Clients.Group("wrestle" + id.ToString()).autoWinSportsmanOne();
                }
                   
                int? updatedId = _wrestleBll.Update(wrestle);
                if (updatedId == id)
                    Clients.Group("wrestle" + id.ToString()).addSportsmanTwoFinePoint(value);
            }
        }

        public void AutoWinSportsmanOne(int id)
        {     
                Wrestle wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
                    wrestle.WinnerSportsmanId = wrestle.SportsmanOneId;
                int? updatedId = _wrestleBll.Update(wrestle);
                if (updatedId == id)
                    Clients.Group("wrestle" + id.ToString()).autoWinSportsmanOne();
            
        }

        public void RemoveSportsmanTwoFinePoint(int message, int id)
        {
            if (message > 0)
            {
                int value = message - 1;
                Wrestle wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
                wrestle.SportmanTwoFine = value;
                int? updatedId = _wrestleBll.Update(wrestle);
                if (updatedId == id)
                    Clients.Group("wrestle" + id.ToString()).addSportsmanTwoFinePoint(value);
            }
        }
        // sportsman two
        public void AddSportsmanTwoIpponPoint(int message, int id)
        {
            var wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
            wrestle.SporstmanTwoIppon = true;
            wrestle.WinnerSportsmanId = wrestle.SportsmanTwoId;
            Clients.Group("wrestle" + id.ToString()).autoWinSportsmanTwo();
            int? updatedId = _wrestleBll.Update(wrestle);
            if (updatedId == id)
                Clients.Group("wrestle" + id.ToString()).addSportsmanTwoIpponPoint(1);
        }

        public void RemoveSportsmanTwoIpponPoint(string message, int id)
        {
            var wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
            wrestle.SporstmanTwoIppon = false;
            int? updatedId = _wrestleBll.Update(wrestle);
            if (updatedId == id)
                Clients.Group("wrestle" + id.ToString()).removeSportsmanTwoIpponPoint(0);
        }


        public void AddSportsmanTwoWazariPoint(int time, int message, int id)
        {
            int value = message + 1;
            Wrestle wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
            wrestle.SporstmanTwoWazariPoint = value;
            if (time < 0)
            {
                wrestle.WinnerSportsmanId = wrestle.SportsmanTwoId;
                Clients.Group("wrestle" + id.ToString()).autoWinSportsmanTwo();
            }
            int? updatedId = _wrestleBll.Update(wrestle);
            if (updatedId == id)
                Clients.Group("wrestle" + id.ToString()).addSportsmanTwoWazariPoint(value);
        }

        public void RemoveSportsmanTwoWazariPoint(int message, int id)
        {
            if (message > 0)
            {
                int value = message - 1;
                Wrestle wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
                wrestle.SporstmanTwoWazariPoint = value;
                int? updatedId = _wrestleBll.Update(wrestle);
                if (updatedId == id)
                    Clients.Group("wrestle" + id.ToString()).addSportsmanTwoWazariPoint(value);
            }
        }

        public void AutoWinSportsmanTwo(int id)
        {
            Wrestle wrestle = _wrestleBll.GetSingle(wr => wr.Id == id);
            wrestle.WinnerSportsmanId = wrestle.SportsmanTwoId;
            int? updatedId = _wrestleBll.Update(wrestle);
            if (updatedId == id)
                Clients.Group("wrestle" + id.ToString()).autoWinSportsmanTwo();

        }

        ///////timer//////////////
        public void Timer(string message, int id)
        {
                string value = message;
                Clients.Group("wrestle" + id.ToString()).timer(value);
            }   
    }
}