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
        ICommentRepo commentRepo;
        public HomeController(IUserRepo users, ICommentRepo guests)
        {
            userRepo = users;
            commentRepo = guests;
        }

        public ViewResult Index(string message)
        {

            AppUser user = userRepo.Users[4];
            ViewBag.memberCount = userRepo.Users.Count();
            userRepo.Users.Sort((u1, u2) => (u1.JoinDate).CompareTo(u1.JoinDate));
            ViewBag.memberNew = userRepo.Users.First().UserName;
            if (message !=null)
                ModelState.AddModelError("SucessfulPost", message);
            return View("Index",user);
        }
        [HttpGet]
        public IActionResult CreateUser(AppUser user)//create user redirect
        {
            if (ModelState.IsValid && userRepo.Exists(user.UserName))
            {
                Topic t = new Topic();
                t.Author = user;
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

        public IActionResult Links(AppUser user)
        {
            if (user.Id == "0")
                user = userRepo.Users[4];
            return View(user);
        }
        public IActionResult Info(AppUser user) {
            if (user.Id == "0")
                user = userRepo.Users[4];
            return View("Info",user);
        }
        public IActionResult Places(AppUser user)
        {
            if (user.Id == "0")
                user = userRepo.Users[4];
            PlacesRepo repo = new PlacesRepo();
            PlacesRepo.Places.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.Ordinal));
            //viewbag.mpnyhlyplace = Places[(int)DateTime.Now.Month];   
            return View("Places", PlacesRepo.Places);
        }
        public IActionResult People(AppUser user)
        {
            if (user.Id == "0")
                user = userRepo.Users[4];
            userRepo.Users.Sort((u1, u2) => string.Compare(u1.UserName, u2.UserName, StringComparison.Ordinal));
            return View("People", userRepo.Users);
        }

        public IActionResult Contact(AppUser user)
        {
            if (user.Id == "0")
                user = userRepo.Users.Find(u => u.Guest == true);
            Message guestComment = new Message();
            guestComment.Author = user;
            return View("Contact",guestComment);
        }

        [HttpPost]
        public RedirectToActionResult Contact(Message guestComment)
        {
            if (ModelState.IsValid)
            {
                
                if (guestComment.Author == null)
                    guestComment.Author = userRepo.Users.Find(u => u.Guest == true);
                commentRepo.AddComment(guestComment);
                return RedirectToAction("Index", "Home",new { message = "Your message has been successfully sent" });
            }
            else
            {
                //there is a validation error
                return RedirectToAction("Contact");
            }
        }
    }


}
