using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;

namespace CommunitySite.ViewModels
{
    public class ForumIndexViewModel
    {
        public AppUser user { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
