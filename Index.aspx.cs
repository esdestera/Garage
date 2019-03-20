using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(SearchText.Text))
        {
            FillPage();
        }
        else
        {
            ShowFoundCategories();
        }
    }

    private void ShowFoundCategories()
    {
        var model = new ProductTypeModel();
        var productTypes = model.GetSearchedForCategory(SearchText.Text);

        if (productTypes.Any())
        {
            foreach (var product in productTypes)
            {
                var productPanel = new Panel();
                productPanel.CssClass = "ContentPlaceHolder1_pnlProducts";
                var imageButton = new ImageButton();
                var name = new Label();

                imageButton.ImageUrl = "~/Images/ProductTypes/" + product.Image;
                imageButton.CssClass = "productImage";
                imageButton.PostBackUrl = "~/ProductsByType.aspx?id=" + product.ID;

                name.Text = product.Name;
                name.CssClass = "productName";


                productPanel.Controls.Add(imageButton);
                productPanel.Controls.Add(new Literal { Text = "<br />" });

                productPanel.Controls.Add(name);
                productPanel.Controls.Add(new Literal { Text = "<br />" });

                pnlProducts.Controls.Add(productPanel);
            }
        }
        else
        {
            pnlProducts.Controls.Add(new Literal { Text = "No product types found" });
        }
    }

    private void FillPage()
    {
        var model = new ProductTypeModel();
        var productTypes = model.GetAllProductTypes();

        if (productTypes.Any())
        {
            foreach (var product in productTypes)
            {
                var productPanel = new Panel();
                productPanel.CssClass = "ContentPlaceHolder1_pnlProducts";
                var imageButton = new ImageButton();
                var name = new Label();

                imageButton.ImageUrl = "~/Images/ProductTypes/" + product.Image;
                imageButton.CssClass = "productImage";
                imageButton.PostBackUrl = "~/ProductsByType.aspx?id=" + product.ID;

                name.Text = product.Name;
                name.CssClass = "productName";
                

                productPanel.Controls.Add(imageButton);
                productPanel.Controls.Add(new Literal {Text = "<br />"});

                productPanel.Controls.Add(name);
                productPanel.Controls.Add(new Literal { Text = "<br />" });

                pnlProducts.Controls.Add(productPanel);
            }
        }
        else
        {
            pnlProducts.Controls.Add(new Literal {Text = "No product types found" });
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        pnlProducts = new Panel();
        ShowFoundCategories();
    }
}