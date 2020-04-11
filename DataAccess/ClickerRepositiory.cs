using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickedIn.Models;

namespace ClickedIn.DataAccess
{
    public class ClickerRepositiory
    {
        //This will eventually come from a databasw
        static List<Clicker> _clickers = new List<Clicker>()
        { 
            //Will we also have to put some dummy data in this file
            // or will we have a method that grabs this information
            new Clicker
            {
                Id = 1,
                HoodName = "Big Pat",
                ServiceType = Services.Robbin,
                Interest = new List<Interest>()
                {
                    new Interest
                    {
                        Name = "Beats"
                    },
                    new Interest
                    {
                        Name = "Robbin"
                    }
                },
                Homies = new List<Clicker>(),
                Enemies = new List<Clicker>() 
            },
            new Clicker
            {
                Id = 2,
                HoodName = "C Black",
                ServiceType = Services.Snitch,
                Interest = new List<Interest>()
                {
                    new Interest
                    {
                        Name = "Traveling"
                    },
                    new Interest
                    {
                        Name = "Stocks"
                    }
                },
                Homies = new List<Clicker>(),
                Enemies = new List<Clicker>()
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

        public List<Clicker> GetClickersByInterest(string interestString)
        {
            List<Clicker> filteredList = new List<Clicker>();

            foreach (var clicker in _clickers)
            {
                var commonInterests = clicker.Interest.Any(interest => interest.Name
                == interestString);
                if(commonInterests)
                {
                    filteredList.Add(clicker);
                }
            }
            return filteredList;
        }

        public List<Clicker> GetClickersByService(string serviceString)
        {
            //What is Ln87 doing???
            Services serviceValue;

            List<Clicker> emptyList = new List<Clicker>();

            if (Enum.TryParse(serviceString, true, out serviceValue))
            {
                return _clickers.Where(clicker => clicker.ServiceType == serviceValue).ToList(); // could be empty
            }
            else return emptyList;
        }

        public Clicker GetClickerById(int id)
        {
            return _clickers.FirstOrDefault(clickerObj => clickerObj.Id == id);
        }

        public Clicker AddHomies(int ClickerId, int homieId)
        {
            var clicker = GetClickerById(ClickerId);
            var homie = GetClickerById(homieId);
            clicker.Homies.Add(homie);
            return clicker;
        }

        public Clicker AddEnemy(int ClickerId, int enemyId)
        {
            var clicker = GetClickerById(ClickerId);
            var enemy = GetClickerById(enemyId);
            clicker.Enemies.Add(enemy);
            return clicker;
        }

    }
}
