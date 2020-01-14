using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CommunitySite.Models
{
    public class User
    {
        //private List<Topic> topics = new List<Topic>();
        //private List<Message> comments = new List<Message>();
        public User(bool flag)
        {
            if (flag)
                Admin = flag;
            JoinDate = DateTime.Now;
        }
        public int UserID { get; set; }
        public User() {
            JoinDate = DateTime.Now;
            Guest = true;
        }
        public string Email { get; set; }
        public bool Guest { get; set; }
        public DateTime JoinDate { get; set; }
        public bool Admin { set; get; }
        [Required(ErrorMessage = "Please enter your Username")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Pass { set; get; }
        public string Img { get; set; }
        public string Info { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        //finds user messages from string
        //public ICollection<Message> Replies { get { return MessageRepo.UserMsgs(Name); } }
        //public ICollection<Message> Msg { get { return comments; } }

    }
}
