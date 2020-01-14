using System;
using Xunit;
using CommunitySite.Repositories;
using CommunitySite.Models;
using Moq;
using System.Linq;

namespace CommunitySiteTests
{
    public class CommentRepoTest
    {

        [Fact]
        public void AddResponsesTest()
        {
            //Arrange
            User testUser = new User(false)
            {
                UserName = "Guest",
                Guest = true,
                Pass = "pass",
                Phone = "123-123 1234",
                Email = "test@email.com",
                Address = "Eugene, Oregon",
                Img = "https://www.bootdey.com/img/Content/avatar/avatar4.png",
                Admin = false
            };
            User a = new User(false)
            {
                UserName = "userTest",
                Guest = false,
                Pass = "passTest",
                Phone = "123-123 1234",
                Email = "test@email.com",
                Address = "Eugene, Oregon",
                Img = "https://www.bootdey.com/img/Content/avatar/avatar4.png",
                Admin = true
            };
            var initialItems = new[]
            {
                new Message {User = "Test1", Address="69 Street",Email="email@email.com",
                    Phone="1111111",Body="test1message", MemberCheck=true, PubDate= DateTime.Now,Author=a },
                new Message {User = "Test2", Address="96 Street",Email="email2@email.com",
                    Phone="2222222",Body="test2message", MemberCheck=false, PubDate= DateTime.Now, Author=testUser}

            };
            ICommentRepo commentRepo = new FakeCommentRepo();
            int prevValue = commentRepo.Comments.Count();

            //Act
            commentRepo.AddComment(initialItems[0]);
            commentRepo.AddComment(initialItems[1]);

            //Assert
            Assert.Contains(commentRepo.Comments[0].User, initialItems[0].User);
            Assert.Contains(commentRepo.Comments[0].Author.Pass, initialItems[0].Author.Pass);
            Assert.Contains(commentRepo.Comments[1].User, initialItems[1].User);
            Assert.Contains(commentRepo.Comments[1].Author.Pass, initialItems[1].Author.Pass);



        }
    }
}
