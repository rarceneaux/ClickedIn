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
                Services = "Rapping",
                Interests = "Wallstreet"
            },
            new Clicker
            {
                Id = 2,
                HoodName = "C Black",
                Services = "Robbin",
                Interests = "Coding"
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

        public Clicker GetClickerById(int id)
        {
            return _clickers.FirstOrDefault(clickerObj => clickerObj.Id == id);
        }
    }
}
