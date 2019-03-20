using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Models;

public partial class Pages_Success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var carts = (List<Purchase>) Session[User.Identity.GetUserId()];
        var model = new PurchaseModel();
        model.MarkOrderAsPaid(carts);
        Session[User.Identity.GetUserId()] = null;
    }
}