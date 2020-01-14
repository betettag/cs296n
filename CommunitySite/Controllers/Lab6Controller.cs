using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunitySite.Repositories;
using CommunitySite.Models;

namespace CommunitySite.Controllers
{
    public class Lab6Controller : Controller
    {
        public RedirectToActionResult User_Profile(User user)
        {
            if (user.Guest == false)
                return RedirectToAction("Profile",user);
            return RedirectToAction("Home/CreateUser");//return type redirect (to a view)
        }

        public RedirectResult GetStuckPart1()
        {
            return Redirect("GetStuckPart2");//return type redirect (to an action)
        }

        public string GetStuckPart2 ()//string method
        {
            string output = "Congratulations! You are now stuck";//return type string
            return output;
        }


        public ContentResult GetStucker()
        {
            string head =
                "<link href=\"https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css\" rel = \"stylesheet\" >" +
                "<link href=\"https://codepen.io/EasyCode/pen/VeQERr.css\" rel =\"stylesheet\">" +
                "<script type=\"text/javascript\" src =\"https://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.8.2/underscore-min.js\"></script>" +
                "<script type=\"text/javascript\" src =\"https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js\"></script>" +
                "<script type=\"text/javascript\" src =\"https://cdnjs.cloudflare.com/ajax/libs/gsap/1.18.0/TweenMax.min.js\"></script>" +
                "<script type=\"text/javascript\" src =\"https://codepen.io/EasyCode/pen/VeQERr.js\"></script>";
           string body = "<body><div class=\"congrats\"><h1> Congratulations!</h1></div><img src=\"/hiclipart.com.png\" style=\"text-align:center;\" class=\"mx-auto\" width=\"800\"></body>";

            return Content("<html><head>"+head+"</head>"+body+"</html>","text/html");//return type content
        }

        public ActionResult GetStucker2(bool flag)//returns ok or not found
        {
            if (flag)
                return Ok();//blank
            return NotFound();//404
        }

        public BadRequestResult GetStucker4TheStuckening()
        {
            return BadRequest();//error 400
        }

    }
}