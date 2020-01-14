using System;
using System.Collections.Generic;
using CommunitySite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using CommunitySite.Repositories;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace CommunitySite.Controllers
{
    public class ForumController : Controller
    {
        IUserRepo userRepo;
        ITopicRepo topics;
        IGuestRepo guestRepo;
        [ActivatorUtilitiesConstructor]
        public ForumController()
        {
            userRepo = new UserRepo();
            topics = new TopicRepo();
            guestRepo = new GuestRepo();
        }

        public ForumController(IUserRepo u, ITopicRepo t, IGuestRepo g)
        {
            userRepo = u;
            topics = t;
            guestRepo = g;
        }
        public ViewResult Index()
        {
            topics.Topics.Sort((t1, t2) => (t1.PubDate).CompareTo(t1.PubDate)); //1b from lab3
            for (int i = 0; i < topics.Topics.Count(); i++)
            {
                topics.Topics[i].Comments = 
                    (topics.Topics[i].Comments.OrderBy(m=>m.Important).ToList());
                //t.Comments = t.Comments.OrderBy(m => m.Important ? true : false).ToList();
            }
            return View(topics.Topics);
        }
        public IActionResult Admin()
        {
            return View("Admin");
        }
        [HttpPost]
        public IActionResult Admin(User user)
        {
            //for seeing messages from the contact page
            if (ModelState.IsValid && userRepo.IsAdmin(user.UserName))
            {
                
                return View("AdminMsgs", guestRepo.Responses);
            }
            else
            {
                //there is a validation error
                ModelState.AddModelError("LoginError", "Wrong username or not an admin try(admin,pass)");
                return View("CheckUser");
            }
        }
        [HttpPost]
        public IActionResult NewTopic(Topic t)
        {
            if (ModelState.IsValid && t.Title != null) {
                topics.AddTopic(t);

                //getuser from topic in some way
                return RedirectToAction("Index");//return user
            }
            else
                return View("NewTopic",t);
        }

        public IActionResult Login()
        {
            return View("CheckUser");
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            //for seeing messages from the contact page
            if (ModelState.IsValid && userRepo.Exists(user.UserName))
            {
                Topic t = new Topic();
                t.Author = user.UserName;
                
                ModelState.AddModelError("ValidUser", "Hello "+user.UserName);
                return View("NewTopic",t);
            }
            else
            {
                //there is a validation error
                ModelState.AddModelError("LoginError", "Wrong username or pass");
                return View("CheckUser");
            }
        }
        public IActionResult NewMessage(string title)  //1a from lab3
        {//addming a msg to a topic
            Message m = new Message();
            m.TopicTitle=HttpUtility.HtmlDecode(title);
            try
            {
                Topic topic = topics.GetTopicByTitle(title);
            }

            catch
            {
                throw new Exception();
            }

            return View("NewMessage", m);
        }
        [HttpPost]
        public IActionResult NewMessage(Message comment)
        {
            if (ModelState.IsValid && userRepo.Exists(comment.User))
            {
                Topic topic = topics.GetTopicByTitle(comment.TopicTitle);
                if (userRepo.IsAdmin(comment.User))
                    comment.Important = true;
                topics.AddComment(topic, comment);
                return RedirectToAction("Index");
            }
            else
            {
                //there is a validation error
                ModelState.AddModelError("LoginError", "Wrong username try(Dave)");
                return View("NewMessage", comment);
            }
        }



    }
}