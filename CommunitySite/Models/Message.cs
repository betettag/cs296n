using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CommunitySite.Repositories;

namespace CommunitySite.Models
{
    public class Message
    {
        public Message()
        {
            PubDate = DateTime.Now;
        }
        public int MessageID { get; set; }
        public User Author { get; set; }
        [Required(ErrorMessage = "Please enter your UserName/Name")]
        public string User { get; set; }
        [Required(ErrorMessage = "No message. if you dont put one then whats the point?")]
        public string Body { get; set; }
        [Required(ErrorMessage = "WE NEED TO KNOW WHERE YOU LIVE")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter a phone please. I pinky swear we wont call")]
        public string Phone { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please answer if you are a member")]
        public bool? MemberCheck { get; set; }
        public string TopicTitle { get; set; }
        public DateTime PubDate { get; set; }
        public bool Important {get; set;}
    }
}
