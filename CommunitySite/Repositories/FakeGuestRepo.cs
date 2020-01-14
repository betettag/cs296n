using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;

namespace CommunitySite.Repositories
{
    public class FakeGuestRepo : IGuestRepo
    {
        private static List<Message> responses = new List<Message>();
        public FakeGuestRepo()
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

            //var initialItems = new[]
            //{
            //    new GuestResponse {Name = "Test1", Address="69 Street",Email="email@email.com",
            //        Phone="1111111",Message="test1message", MemberCheck=true, PubDate= DateTime.Now },
            //    new GuestResponse {Name = "Test2", Address="96 Street",Email="email2@email.com",
            //        Phone="2222222",Message="test2message", MemberCheck=false, PubDate= DateTime.Now }

            //};