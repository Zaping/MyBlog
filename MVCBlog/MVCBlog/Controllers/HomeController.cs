using MVCBlog.Models;
using System.Web.Mvc;
using System.Linq;
namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        private BlogDBContext db = new BlogDBContext();
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
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