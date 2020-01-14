using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;

namespace CommunitySite.Repositories
{
    public class GuestRepo: IGuestRepo
    {
        private static List<Message> responses = new List<Message>();
        public GuestRepo()
        {
            //context = appDbContext;
        }
        
        public List<Message> Responses => responses;

        public void AddResponse(Message response)
        {
            response.PubDate = DateTime.Now;
            Responses.Add(response);
        }
    }
}
