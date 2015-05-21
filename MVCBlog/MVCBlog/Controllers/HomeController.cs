using MVCBlog.Models;
using System.Web.Mvc;
using System.Linq;
using PagedList;
using System.Collections.Generic;
namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        private BlogDBContext db = new BlogDBContext();
        public ActionResult Index(string sortOrder,string currentFilter,string searchString,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var students = from s in db.Blogs
                           select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Title.Contains(searchString)
                                       || s.Content.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EntryDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EntryDate);
                    break;
                default:
                    students = students.OrderBy(s => s.Content);
                    break;
            }
            
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult CreatePost()
        {
            
            ViewBag.Message = "Create a post.";
            return View();
        }
    }
}