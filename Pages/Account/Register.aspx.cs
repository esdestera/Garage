using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Models;

public partial class Pages_Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Register_Click(object sender, EventArgs e)
    {
        var userStore = new UserStore<IdentityUser>();
        userStore.Context.Database.Connection.ConnectionString = "data source=PC-ITSIX61;initial catalog=Garage;integrated security=True;";
        var manager = new UserManager<IdentityUser>(userStore);

        var user = new IdentityUser();
        user.UserName = UserNameTB.Text;

        if (PasswordTB.Text.Equals(ConfirmPasswordTB.Text))
        {
            try
            {
                var result = manager.Create(user, PasswordTB.Text);

                if (result.Succeeded)
                {

                    var userInfo = new UserInformation();
                    userInfo.FirstName = FirstName.Text;
                    userInfo.LastName = LastName.Text;
                    userInfo.Address = Address.Text;
                    userInfo.GUID = user.Id;
                    userInfo.PostalCode = Convert.ToInt32(PostalCode.Text);
                    var userModel = new UserInformationModel();
                    userModel.InsertUserInformation(userInfo);
                    var autenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    autenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    Status.Text = result.Errors.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Status.Text = ex.ToString();
            }
        }
        else
        {
            Status.Text = "Password and Confirm password must match";
        }

    }
}