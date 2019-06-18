using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;

namespace Blog.Controllers
{
    public class CommentsController : Controller
    {
        ///
        //  Get: Article/Create
        [Authorize]
        public ActionResult GetComments(Comment model)
        {
            using (var database = new BlogDbContext())
            {
                var comments = database.Comments
                    .Where(c => c.ArticleID == model.ArticleID)
                    .ToList();

                return PartialView("_GetComments", comments);
            }
        }
        //
        //  Post: Article/Create
        [HttpPost]
        [Authorize]
        public void Create(Comment model)
        {
            if (ModelState.IsValid)
            {
                //  Insert comment in DB
                using (var database = new BlogDbContext())
                {
                    //  Get author id
                    var authorId = database.Users
                        .Where(u => u.UserName == this.User.Identity.Name)
                        .First()
                        .Id;

                    //  Set articles author
                    var comment = new Comment(model.Comments, authorId, model.ArticleID);

                    //this.SetArticleTags(article, model, database);
                    //  Save article in DB
                    database.Comments.Add(comment);
                    database.SaveChanges();
                    //return RedirectToAction("Index");

                }
            }
            //return View(model);
        }
    }
}