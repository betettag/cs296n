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
        public User(bool flag)
        {
            if (flag)
                Admin = flag;
            JoinDate = DateTime.Now;
        }
        public User()
        {
            JoinDate = DateTime.Now;
        }
        public int UserID { get; set; }
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
        public string ReplyingTo { get; set; }

    }
}
