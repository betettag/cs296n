using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunitySite.Models
{
    public class Place
    {
        public int PlaceID { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public DateTime DateAdded { get; set; }
        public string Img { get; set; }
        public string Info { get; set; }
        public string Location { get; set; }
    }
}
