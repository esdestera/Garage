using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Models;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = Context.User.Identity;
        
        if (user.IsAuthenticated)
        {
            var model = new PurchaseModel();
            Login.Visible = false;
            Register.Visible = false;

            Logout.Visible = true;
            Status.Visible = true;

            var userId = HttpContext.Current.User.Identity.GetUserId();
            Status.Text = string.Format("{0}({1})", Context.User.Identity.Name, model.GetAmountOfOrders(userId));
        }
        else
        {
            Login.Visible = true;
            Register.Visible = true;

            Logout.Visible = false;
            Status.Visible = false;
        }
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut();

        Response.Redirect("~/Index.aspx");
    }
    
    protected void ImageButton1_OnClick(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("https://www.facebook.com/sharer/sharer.php? ");
    }
    protected void ImageButton2_OnClick(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("https://twitter.com/intent/tweet?");
    }
    protected void ImageButton3_OnClick(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("https://plus.google.com/share?");
    }
}
