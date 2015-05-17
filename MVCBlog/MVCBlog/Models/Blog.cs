using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class Blog
    {
         public Blog()
        {
          EntryDate=DateTime.Now;
        }
        public int ID { get; set; }
        public string Title { get; set;  }
        public string Content { get; set; }
        public DateTime EntryDate { get; set; }
       
    }
    public class BlogDBContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
}