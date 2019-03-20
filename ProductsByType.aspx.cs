using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page, INotifyPropertyChanged
{
    private List<Product> _products;

    protected void Page_Load(object sender, EventArgs e)
    {
        Products= new List<Product>();
        if (string.IsNullOrWhiteSpace(SearchText.Text))
        {
            FillPage();
        }
        else
        {
            ShowSearchedProducts();
        }
    }

    public string Filter { get; set; }

    public List<Product> Products
    {
        get
        {
            return _products;
        }

        set
        {
            _products = value;
            OnPropertyChanged();
        }
    }

    private void FillPage()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);
            var model = new ProductModel();
            Products.AddRange(model.GetProductsOfType(id));

            if (Products.Any())
            {
                foreach (var product in Products)
                {
                    var productPanel = new Panel();
                    productPanel.CssClass = "ContentPlaceHolder1_pnlProducts";
                    var imageButton = new ImageButton();
                    var name = new Label();
                    var price = new Label();

                    imageButton.ImageUrl = "~/Images/Products/" + product.Image;
                    imageButton.CssClass = "productImage";
                    imageButton.PostBackUrl = "~/Pages/ProductDetails.aspx?id=" + product.ID;

                    name.Text = product.Name;
                    name.CssClass = "productName";

                    price.Text = product.Price.ToString();
                    price.CssClass = "productPrice";

                    productPanel.Controls.Add(imageButton);
                    productPanel.Controls.Add(new Literal {Text = "<br />"});

                    productPanel.Controls.Add(name);
                    productPanel.Controls.Add(new Literal {Text = "<br />"});

                    productPanel.Controls.Add(price);
                    productPanel.Controls.Add(new Literal {Text = "<br />"});

                    pnlProducts.Controls.Add(productPanel);
                }
            }
            else
            {
                pnlProducts.Controls.Add(new Literal {Text = "No products found"});
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        pnlProducts = new Panel();
        Products.Clear();
        ShowSearchedProducts();
    }

    private void ShowSearchedProducts()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);
            var model = new ProductModel();
            Products.AddRange(model.GetSearchedForProducts(id, SearchText.Text));

            if (Products.Any())
            {
                foreach (var product in Products)
                {
                    var productPanel = new Panel();
                    productPanel.CssClass = "ContentPlaceHolder1_pnlProducts";
                    var imageButton = new ImageButton();
                    var name = new Label();
                    var price = new Label();

                    imageButton.ImageUrl = "~/Images/Products/" + product.Image;
                    imageButton.CssClass = "productImage";
                    imageButton.PostBackUrl = "~/Pages/ProductDetails.aspx?id=" + product.ID;

                    name.Text = product.Name;
                    name.CssClass = "productName";

                    price.Text = product.Price.ToString();
                    price.CssClass = "productPrice";

                    productPanel.Controls.Add(imageButton);
                    productPanel.Controls.Add(new Literal { Text = "<br />" });

                    productPanel.Controls.Add(name);
                    productPanel.Controls.Add(new Literal { Text = "<br />" });

                    productPanel.Controls.Add(price);
                    productPanel.Controls.Add(new Literal { Text = "<br />" });

                    pnlProducts.Controls.Add(productPanel);
                }
            }
            else
            {
                pnlProducts.Controls.Add(new Literal { Text = "No products found" });
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}