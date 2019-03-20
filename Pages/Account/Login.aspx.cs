using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

public partial class Pages_Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        var userStore = new UserStore<IdentityUser>();
        userStore.Context.Database.Connection.ConnectionString = "data source=PC-ITSIX61;initial catalog=Garage;integrated security=True;";
        var manager = new UserManager<IdentityUser>(userStore);

        var user = manager.Find(Username.Text, Password.Text);

        if (user != null)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            authenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, userIdentity);

            Response.Redirect("~/Index.aspx");
        }
        else
        {
            Status.Text = "Invalid username or password.";
        }
    }
}