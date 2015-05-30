using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCBlog.Models
{
    [ValidateInput(false)]
    public class Blog
    {
         public Blog()
        {
          EntryDate=DateTime.Now;
        }
        [Key]
        public int ID { get; set; }
        public string Title { get; set;  }
        public string Url { get; set; }
        public string Content { get; set; }
        public DateTime EntryDate { get; set; }
        //[DataType(DataType.Upload)]
        //public HttpPostedFileBase Image { get; set; }

    }
    public class BlogDBContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
  
}