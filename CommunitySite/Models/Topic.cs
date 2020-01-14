using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CommunitySite.Repositories;

namespace CommunitySite.Models
{
    public class Topic
    {
        public Topic()
        {
            PubDate = DateTime.Now;
        }
        private List<Message> comments = new List<Message>();
        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter a Title")]
        public string Title { get; set; }
        public int TopicID { get; set; }
        public DateTime PubDate { get; set; }

        public string Author { set;  get; }
        [Required(ErrorMessage = "No message. if you dont put one then whats the point")]
        public string Body { set; get; }

        public List<Message> Comments { 
            get { return comments; } 

            set { comments = value; }
        }
    }
}
