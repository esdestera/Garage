using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Models;

namespace Pages
{
    public partial class PagesShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userID = User.Identity.GetUserId();

            GetPurchasesInCarts(userID);
        }

        private void GetPurchasesInCarts(string userID)
        {
            var cartModel = new PurchaseModel();
            double subTotal;
            IList<Purchase> purchases = cartModel.GetOrdersInCart(userID);
            CreateShopTable(purchases, out subTotal);

            var vat = subTotal * 0.21;
            var totalAmount = subTotal + vat + 15;

            Total.Text = subTotal + "£";
            Vat.Text = vat + "£";
            TotalAmount.Text = totalAmount + "£";
        }

        private void CreateShopTable(IList<Purchase> purchases, out double subTotal)
        {
            subTotal = 0;
            var model = new ProductModel();
            foreach (var purchase in purchases)
            {
                var product = model.GetProduct(purchase.ProductID);

                var btnImage = new ImageButton
                {
                    ImageUrl = "~/Images/Products/" + product.Image,
                    PostBackUrl = "~/Pages/ProductDetails.aspx?id=" + product.ID
                };

                var delete = new LinkButton
                {
                    PostBackUrl = string.Format("~/Pages/ShoppingCart.aspx?productId={0}", purchase.ID),
                    Text = "Delete item",
                    ID = "del" + purchase.ID
                };

                delete.Click += Delete_Click; ;

                var amount = Enumerable.Range(1, 20).ToList();

                var Amount = new DropDownList
                {
                    DataSource = amount,
                    AppendDataBoundItems = true,
                    AutoPostBack = true,
                    ID = purchase.ID.ToString()
                };

                Amount.DataBind();
                Amount.SelectedValue = purchase.Amount.ToString();
                Amount.SelectedIndexChanged += Amount_SelectedIndexChanged;

                var table = new Table
                {
                    CssClass = "cartTable"
                };

                var a = new TableRow();
                var b = new TableRow();

                var a1 = new TableCell
                {
                    RowSpan = 2,
                    Width = 50
                };
                var a2 = new TableCell
                {
                    Text = string.Format("<h4>{0}</h4><br>{1}<br>In stock", product.Name, "Item no." + product.ID),
                    HorizontalAlign = HorizontalAlign.Left,
                    Width = 350

                };
                var a3 = new TableCell
                {
                    Text = "Unit price<hr/>"
                };
                var a4 = new TableCell
                {
                    Text = "Quantity <hr/>"
                };
                var a5 = new TableCell
                {
                    Text= "Item total <hr/>"
                };
                var a6 = new TableCell
                {

                };

                var b1 = new TableCell
                {

                };
                var b2 = new TableCell
                {
                    Text = product.Price + "£"
                };
                var b3 = new TableCell { };
                var b4 = new TableCell
                {
                    Text= "£" + Math.Round((purchase.Amount * product.Price), 2)
                };
                var b5 = new TableCell { };
                var b6 = new TableCell { };

                a1.Controls.Add(btnImage);
                a6.Controls.Add(delete);
                b3.Controls.Add(Amount);

                a.Cells.Add(a1);
                a.Cells.Add(a2);
                a.Cells.Add(a3);
                a.Cells.Add(a4);
                a.Cells.Add(a5);
                a.Cells.Add(a6);

                b.Cells.Add(b1);
                b.Cells.Add(b2);
                b.Cells.Add(b3);
                b.Cells.Add(b4);
                b.Cells.Add(b5);
                b.Cells.Add(b6);

                table.Rows.Add(a);
                table.Rows.Add(b);

                ShoppingCart.Controls.Add(table);

                subTotal += (double) (purchase.Amount * product.Price);
                Session[User.Identity.GetUserId()] = purchases;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var selectedLink = sender as LinkButton;
            if (selectedLink != null)
            {
                var link = selectedLink.ID.Replace("del", "");

                var cartId = Convert.ToInt32(link);
                var model = new PurchaseModel();
                model.DeletePurchase(cartId);
            }

            Response.Redirect("~/Pages/ShoppingCart.aspx");
        }

        private void Amount_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedList = sender as DropDownList;

            var quantity = Convert.ToInt32(selectedList.SelectedValue);
            var cartId = Convert.ToInt32(selectedList.ID);

            var model = new PurchaseModel();
            model.UpdateQuantity(cartId, quantity);
            Response.Redirect("~/Pages/ShoppingCart.aspx");
        }
    }
}