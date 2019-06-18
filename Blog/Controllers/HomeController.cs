using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using Microsoft.AspNet.Identity.Owin;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ListCategories()
        {
            using (var database = new BlogDbContext())
            {
                var categories = database.Categories
                    .Include(c => c.Articles)
                    .OrderBy(c => c.Name)
                    .ToList();

                return View(categories);
            }
        }
        //
        public ActionResult ListArticles(int? categoryId)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                var articles = database.Articles
                    .Where(a => a.CategoryId == categoryId)
                    .Include(a => a.Author)
                    .Include(a => a.Tags)
                    .ToList();

                return View(articles);
            }
        }

        public ActionResult Index()
        {
            return RedirectToAction("ListCategories");
        }

        public FileContentResult UserPhotos()
        {

            using (var database = new BlogDbContext())
            {
                String userId = User.Identity.GetUserId();

                //Get user
                var user = database.Users.FirstOrDefault(u => u.Id == userId);

                if (user.UserPhoto == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Content/images/photo_not_available.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, "image/png");
                }

                return new FileContentResult(user.UserPhoto, "image/jpeg");
            }

        }

    }
}