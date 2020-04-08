using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickedIn.Models
{
   public enum Services
    {
        Sewing,
        Coding,
        Legal
    }
    
    public enum Interests
    {
        Writing,
        Reading,
        Freedom
    }

    public class Clicker
    {
        public int Id { get; set; }
        public string HoodName { get; set; }
        public Services ServiceType { get; set; }
        public Interests Interests { get; set; }
    }
   
}
    
