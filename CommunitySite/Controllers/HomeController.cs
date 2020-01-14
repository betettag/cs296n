using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunitySite.Models;
using CommunitySite.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CommunitySite.Controllers
{
    public class HomeController : Controller
    {
        IUserRepo userRepo;
        IGuestRepo guestResponses;
        public HomeController(IUserRepo users, IGuestRepo guests)
        {
            userRepo = users;
            guestResponses = guests;
        }

        [ActivatorUtilitiesConstructor]
        public HomeController()
        {
            userRepo = new UserRepo();
            guestResponses = new GuestRepo();
        }

        public ViewResult Index()
        {
            ViewBag.memberCount = userRepo.Users.Count;
            ViewBag.memberNew = userRepo.Users.OrderByDescending(u => u.JoinDate).FirstOrDefault().UserName;
            return View("Index");
        }
        [HttpGet]
        public IActionResult CreateUser(User user)//create user redirect
        {
            if (ModelState.IsValid && userRepo.Exists(user.UserName))
            {
                Topic t = new Topic();
                t.Author = user.UserName;
                ModelState.AddModelError("ValidUser", "Hello " + user.UserName);
                return View("Index", user);
            }
            else
            {
                //there is a validation error
                ModelState.AddModelError("InputError", "Please Provide all the information");
                return View("CreateUser");
            }
        }

        public IActionResult Links()
        {
            return View();
        }
        public IActionResult Info() { 
            return View("Info");
        }
        public IActionResult Places()
        {
            PlacesRepo repo = new PlacesRepo();
            PlacesRepo.Places.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.Ordinal));
            //viewbag.mpnyhlyplace = Places[(int)DateTime.Now.Month];   
            return View("Places", PlacesRepo.Places);
        }
        public IActionResult People()
        {
            userRepo.Users.Sort((u1, u2) => string.Compare(u1.UserName, u2.UserName, StringComparison.Ordinal));
            return View("People", userRepo.Users);
        }

        public IActionResult Contact()
        {
            return View("Contact");
        }

        [HttpPost]
        public ViewResult Contact(Message guestResponse)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("SucessfulPost", "Your message has been successfully sent");
                guestResponses.AddResponse(guestResponse);
                return View("Contact");
            }
            else
            {
                //there is a validation error
                return View("Contact");
            }
        }
    }


}
