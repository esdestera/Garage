using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_Management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Products_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = Product.Rows[e.NewEditIndex];

        ///Get Id of the product.
        int rowId = Convert.ToInt32(row.Cells[1].Text);

        ///Redirect user to Manage products along with the selected rowid
        Response.Redirect(string.Format("~/Pages/Management/ManageProducts.aspx?id={0}", rowId));
    }
}