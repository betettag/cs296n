using System;
using Xunit;
using CommunitySite.Repositories;
using CommunitySite.Models;
using Moq;
using System.Linq;

namespace CommunitySiteTests
{
    public class GuesRepoTest
    {

        [Fact]
        public void AddResponsesTest()
        {
            //Arrange
            var initialItems = new[]
            {
                new Message {User = "Test1", Address="69 Street",Email="email@email.com",
                    Phone="1111111",Body="test1message", MemberCheck=true, PubDate= DateTime.Now },
                new Message {User = "Test2", Address="96 Street",Email="email2@email.com",
                    Phone="2222222",Body="test2message", MemberCheck=false, PubDate= DateTime.Now }

            };
            IGuestRepo repository = new FakeGuestRepo();
            int prevValue = repository.Responses.Count();

            //Act
            repository.AddResponse(initialItems[0]);
            repository.AddResponse(initialItems[1]);

            //Assert
            Assert.Contains(repository.Responses[0].User, initialItems[0].User);
            Assert.Contains(repository.Responses[0].Address, initialItems[0].Address);
            Assert.Contains(repository.Responses[0].Email, initialItems[0].Email);
            Assert.Contains(repository.Responses[0].Phone, initialItems[0].Phone);
            Assert.Contains(repository.Responses[0].Body, initialItems[0].Body);
            Assert.Contains(repository.Responses[0].MemberCheck.ToString(), initialItems[0].MemberCheck.ToString());
            Assert.Contains(repository.Responses[0].PubDate.ToString(), initialItems[0].PubDate.ToString());

            Assert.Contains(repository.Responses[1].User, initialItems[1].User);
            Assert.Contains(repository.Responses[1].Address, initialItems[1].Address);
            Assert.Contains(repository.Responses[1].Email, initialItems[1].Email);
            Assert.Contains(repository.Responses[1].Phone, initialItems[1].Phone);
            Assert.Contains(repository.Responses[1].Body, initialItems[1].Body);
            Assert.Contains(repository.Responses[1].MemberCheck.ToString(), initialItems[1].MemberCheck.ToString());
            Assert.Contains(repository.Responses[1].PubDate.ToString(), initialItems[1].PubDate.ToString());

            Assert.False(repository.Responses[1].GetHashCode() == repository.Responses[0].GetHashCode());
            Assert.True(repository.Responses[1].GetHashCode() == initialItems[1].GetHashCode());
            Assert.True(repository.Responses[0].GetHashCode() == initialItems[0].GetHashCode());
            
        }
    }
}
