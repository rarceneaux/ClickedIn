using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickedIn.Models;

namespace ClickedIn.DataAccess
{
    public class ClickerRepositiory
    {
        static List<Clicker> _clickers = new List<Clicker>()
        {
            new Clicker
            {
                Id = 1,
                HoodName = "Big Pat",
                ServiceType = Services.Coding,
                Interests = Interests.Writing
            }
        };

        public void AddClicker(Clicker clicker)
        {
            clicker.Id = _clickers.Max(inmate => inmate.Id) + 1;
            _clickers.Add(clicker);
        }

        //Being called in ClickrContoller
        public List<Clicker> GetClickers()
        {
            return _clickers;
        }
        //Still a lil grey 
        public List<Clicker> GetClickerByInterest(string Interest)
        {
            Interests interest;

            if (Enum.TryParse(Interest, true, out interest))
            {
                if (Enum.IsDefined(typeof(Interests), interest) | interest.ToString().Contains(","))
                {
                    var filteredClickers = _clickers.Where(clicker => clicker.Interests == interest);
                }
            }
            return "Test";
        }
    }
}
