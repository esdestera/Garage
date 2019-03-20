
using System;
using System.Collections.Generic;
using System.IO;

public partial class Pages_Management_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetImages();

            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                FillPage(id);
            }
        }
    }

    private void GetImages()
    {
        try
        {
            var images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

            var imageList = new List<string>();
            foreach (var image in images)
            {
                var imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imageList.Add(imageName);
            }

            ImageDropdown.DataSource = imageList;
            ImageDropdown.AppendDataBoundItems = true;
            ImageDropdown.DataBind();
        }
        catch (Exception e)
        {
            Results.Text = e.ToString();
        }
    }

    public int TypeId { get; set; }

    private Product CreateProduct()
    {
        ////Aici am ramas 
        var product = new Product();
        product.Description = Description.Text;
        product.Name = Name.Text;
        product.Price = Convert.ToDecimal(Price.Text);
        product.Image = ImageDropdown.SelectedValue;
        product.TypeID = Convert.ToInt32(TypeDropdown.SelectedValue);
        return product;
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        var productModel = new ProductModel();
        var product = CreateProduct();

        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);
            Results.Text = productModel.UpdateProduct(id, product);
        }
        else
        {
            Results.Text = productModel.InsertProduct(product);
        }
    }

    private void FillPage(int id)
    {
        var model = new ProductModel();
        var product = model.GetProduct(id);

        Description.Text = product.Description;
        Name.Text = product.Name;
        Price.Text = product.Price.ToString();

        ImageDropdown.SelectedValue = product.Image;
        TypeDropdown.SelectedValue = product.TypeID.ToString();

    }
}