using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunitySite.Repositories
{
    public class CommentRepo: ICommentRepo
    {
        private AppDbContext context;
        public CommentRepo(AppDbContext appDbContext)
        {
            context = appDbContext;
        }
        
        public List<Message> Comments => context.Comments.Include(c=>c.Author).Where(c=>c.Author.Guest==true).ToList();

        public void AddComment(Message comment)
        {
            comment.PubDate = DateTime.Now;
            context.Comments.Add(comment);
            context.SaveChanges();
        }
    }
}
