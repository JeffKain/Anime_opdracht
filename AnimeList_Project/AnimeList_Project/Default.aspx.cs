using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Owin;
using Login = AnimeList_Project.Account.Login;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using AnimeList_Project.Models;

namespace AnimeList_Project
{
    public partial class _Default : Page
    {
        Login log = new Login();
        protected void Page_Load(object sender, EventArgs e)
        {
                this.Session["User"] = log.Session["MemberDetails"];
        }

    }
}