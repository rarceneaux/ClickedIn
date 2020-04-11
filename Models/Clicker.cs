using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickedIn.Models
{
    public enum Services
    {
        Robbin,
        HitMan,
        Escapee,
        Barber,
        Snitch,
        DieBold
    }
    public class Interest 
    {
        public string Name { get; set; }
    }
    public class Clicker
    {
        public int Id { get; set; }
        public string HoodName { get; set; }
        public Services ServiceType { get; set; }
        public List<Interest> Interest { get; set; }
        public List <Clicker> Homies { get; set; }
        public List <Clicker> Enemies { get; set; }
        
    }
   
}
    
