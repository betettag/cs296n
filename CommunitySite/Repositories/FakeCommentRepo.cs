using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;

namespace CommunitySite.Repositories
{
    public class FakeCommentRepo : ICommentRepo
    {
        private static List<Message> comments = new List<Message>();
        public FakeCommentRepo()
        {
            //context = appDbContext;
        }
        public List<Message> Comments => comments;

        public void AddComment(Message response)
        {
            response.PubDate = DateTime.Now;
            Comments.Add(response);
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