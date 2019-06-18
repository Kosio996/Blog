using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Blog.Models;

namespace Blog.Models
{
    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; }

        public string Password { get; set; }

        [DisplayName("ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }

        public IList<Role> Roles { get; set; }
        
        [System.ComponentModel.DataAnnotations.Display(Name = "UserPhoto")]
        public byte[] UserPhoto { get; set; }



    }
}
