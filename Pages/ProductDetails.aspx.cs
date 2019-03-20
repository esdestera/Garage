using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Models;

namespace Pages
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var model = new ProductModel();
                var product = model.GetProduct(id);

                Price.Text = "Price per unit: <br/>$ " + product.Price;
                Description.Text = product.Description;
                ItemNumber.Text = id.ToString();
                ProductImage.ImageUrl = "~/Images/Products/" + product.Image;
                Name.Text = product.Name;

                var amount = Enumerable.Range(1, 20).ToList();
                Amount.DataSource = amount;
                Amount.AppendDataBoundItems = true;
                Amount.DataBind();
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                var clientId = Context.User.Identity.GetUserId();

                if (clientId == null)
                {
                    Results.Text = "Please login to order items";
                    return;
                }

                var id = Convert.ToInt32(Request.QueryString["id"]);
                var amount = Convert.ToInt32(Amount.SelectedValue);

                var cart = new Purchase()
                {
                    Amount = amount,
                    UserId = clientId,
                    Date = DateTime.Now,
                    IsInCart = true,
                    ProductID = id,
                    CustomerID = 1
                

                };

                var cartModule = new PurchaseModel();
               
                Results.Text = cartModule.InsertPurchase(cart);
            }
        }
    }
}