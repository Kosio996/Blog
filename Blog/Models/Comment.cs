using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Comment
    {
        public Comment(string comment, string authorID, int articleID)
        {
            this.Comments = comment;
            this.AuthorID = authorID;
            this.ArticleID = articleID;
        }

        public Comment()
        {

        }
        

        [Key]
        public int Id { get; set; }
        
        public string Comments { get; set; }

        public string AuthorID { get; set; }

        public int ArticleID { get; set; }
    }
}