using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CommunitySite.Repositories;
using CommunitySite.Models;
using System.Linq;
using CommunitySite.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace CommunitySiteTests
{
    public class HomeControllerTests
    {
        IGuestRepo guestResponses= new FakeGuestRepo();
        IUserRepo userRepo = new FakeUserRepo();
        [Fact]
        public void IndexTest()
        {
            //Arrange
            var controller = new HomeController();
            //Act
            var index = controller.Index() as ViewResult;
            //testing viewbag which one can retrieve with viewdata
            //really dont know why this works

            //Act
            Assert.Equal(5, index.ViewData["memberCount"]);
            Assert.Equal("nonadmin", index.ViewData["memberNew"]);
        }



        [Fact]
        public void PlacesTest()
        {
            //Arrange
            PlacesRepo repo = new PlacesRepo();
            string firstPlace = PlacesRepo.Places.First().Name;
            HomeController homeController = new HomeController();
            //Act
            homeController.Places();
            //Assert
            Assert.False(PlacesRepo.Places.First().Name == firstPlace);
        }
        [Fact]
        public void PeopleTest()
        {
            //Arrange
            User user = new User();
            user.UserName = "Jave";
            user.Img = "https://www.bootdey.com/img/Content/avatar/avatar3.png";
            user.Info = "old man. likes yelling at kids";
            user.Admin = false;
            user.Phone = "123-123 1234";
            user.Email = "test@email.com";
            user.Address = "Eugene, Oregon";
            userRepo.Users.Add(user);
            string first = userRepo.Users[0].UserName;
            User user2 = new User();
            user2.UserName = "Dave";
            user2.Img = "https://www.bootdey.com/img/Content/avatar/avatar3.png";
            user2.Info = "old man. likes yelling at kids";
            user2.Admin = false;
            user2.Phone = "123-123 1234";
            user2.Email = "test@email.com";
            user2.Address = "Eugene, Oregon";
            userRepo.Users.Add(user2);
            HomeController homeController = new HomeController(userRepo,guestResponses);
            //Act
            homeController.People();
            //Assert
            //Assert.False(PlacesRepo.Places.GetHashCode().ToString() == prevValue);
            Assert.False(userRepo.Users.First().UserName == first);
        }
        [Fact]
        public void ContactTest()
        {
            //Arrange
            HomeController homeController = new HomeController(userRepo, guestResponses);
            Message testResponse = new Message();
/*            Message passResponse = new Message()
            {
                Address = "123 Test",
                Phone = "123123",
                Email = "email@email.com",
                MemberCheck = true,
                Body = "test Body",
                User = "nonadmin"
            };*/
            var prevValue = guestResponses.Responses.Count();
            //Act
            var passResult = homeController.Contact(testResponse);
            //Assert
            Assert.False(prevValue == guestResponses.Responses.Count());
            Assert.Equal(guestResponses.Responses[0],testResponse);
        }
    }
}
