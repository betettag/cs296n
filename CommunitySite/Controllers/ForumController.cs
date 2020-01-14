using System;
using System.Collections.Generic;
using CommunitySite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using CommunitySite.Repositories;
using CommunitySite.ViewModels;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace CommunitySite.Controllers
{
    public class ForumController : Controller
    {
        IUserRepo userRepo;
        ITopicRepo topicRepo;
        ICommentRepo commentRepo;
        //[ActivatorUtilitiesConstructor]


        public ForumController(IUserRepo u, ITopicRepo t, ICommentRepo g)
        {
            userRepo = u;
            topicRepo = t;
            commentRepo = g;
        }
        public ViewResult Index(User user)
        {
            if (user.UserID == 0)
                user = userRepo.Users[4];
            topicRepo.Topics.Sort((t1, t2) => (t1.PubDate).CompareTo(t1.PubDate)); //1b from lab3
            for (int i = 0; i < topicRepo.Topics.Count(); i++)
            {
                topicRepo.Topics[i] = topicRepo.GetComments(topicRepo.Topics[i].TopicID);
                    //(topicRepo.Topics[i].Comments.OrderBy(m=>m.Important).ToList());
            }
            var viewModel = new ForumIndexViewModel();
            viewModel.Topics = topicRepo.Topics;
            viewModel.user = user;
            return View(viewModel);
        }
        public IActionResult Admin(User user)
        {
            if (user.UserID == 0)
                user = userRepo.Users[4];
            if (user.Admin ==true)
                return View("AdminMsgs", commentRepo.Comments);
            return View("Admin");
        }
        [HttpPost]
        public IActionResult AdminLogin(User user)
        {
            //for seeing messages from the contact page
            if (ModelState.IsValid && userRepo.IsAdmin(user.UserName))
            {
                
                return View("AdminMsgs", commentRepo.Comments);
            }
            else
            {
                //there is a validation error
                ModelState.AddModelError("LoginError", "Wrong username or not an admin try(admin,pass)");
                return View("CheckUser");
            }
        }


        public IActionResult NewTopicLogin(User user)
        {
            if (user.UserID == 0)
                user = userRepo.Users[4];
            if (user.Guest == true)
                return View("CheckUser");
            else
            {
                Topic t = new Topic();
                t.Author = user;
                return View("NewTopic", t);
            }
                
        }

        [HttpPost]
        public IActionResult NewTopicValidation(User user)
        {
            //for seeing messages from the contact page
            if (ModelState.IsValid && userRepo.Exists(user.UserName))
            {
                Topic t = new Topic();
                t.Author = user;
                
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
        [HttpPost]
        public IActionResult NewTopic(Topic t)
        {
            if (t.Title != null && t.Body!=null)
            {
                t.Author = userRepo.FindByUserName(t.UserName);
                topicRepo.AddTopic(t);
                return RedirectToAction("Index", new User());//return user
            }
            else
                return View("NewTopic", t);
        }
        [HttpPost]
        public IActionResult NewMsgValidation(User user)
        {
            ModelState.Remove("PageCount");
            //for seeing messages from the contact page
            if (ModelState.IsValid && userRepo.Exists(user.UserName))
            {
                Message m = new Message();
                string ReplyingTo = user.ReplyingTo;
                user = userRepo.FindByUserName(user.UserName);
                m.Author = user;//doesnt work, come back null in post
                m.TopicTitle = ReplyingTo;//topic title to referece on database
                m.User = user.UserID.ToString();//name to reference on database

                ModelState.AddModelError("ValidUser", "Hello " + user.UserName);
                return View("NewMessage", m);
            }
            else
            {
                //there is a validation error
                ModelState.AddModelError("LoginError", "Wrong username or pass");
                return View("CheckUser",user);
            }
        }
        public ViewResult NewMessage(User user)  //1a from lab3
        {//addming a msg to a topic
            if (user.UserID == 0)
                user = userRepo.Users[4];
            //User user = userRepo.Users[4];
            //title = HttpUtility.HtmlEncode(title);
            if (user.Guest != true)
            {
                Message m = new Message();
                m.TopicTitle = user.ReplyingTo;
                m.User = user.UserID.ToString();
                m.Author = user;
                return View("NewMessage", m);
            }
            //user.ReplyingTo = title;
            return View("CheckUser2",user);
        }
        [HttpPost]
        public IActionResult NewMessage(Message comment)
        {
            if (userRepo.Users.Exists(u => u.UserID == Int32.Parse(comment.User)) )
            {
                comment.Author = userRepo.Users.Find(u => u.UserID == Int32.Parse(comment.User));
                commentRepo.AddComment(comment);
                return RedirectToAction("Index", comment.Author);
            }
            else
            {
                //there is a validation error
                ModelState.AddModelError("LoginError", "Wrong username try(admin or Dave)");
                return View("NewMessage", comment);
            }
        }



    }
}