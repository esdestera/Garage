using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_ManageProductTypes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetImages();
    }

    private void GetImages()
    {
        try
        {
            var images = Directory.GetFiles(Server.MapPath("~/Images/ProductTypes/"));

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
            LabelResults.Text = e.ToString();
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var model = new ProductTypeModel();
        var productType = CreateProductType();

        LabelResults.Text = model.InsertProductType(productType);
    }

    private ProductType CreateProductType()
    {
        var productType = new ProductType();
        productType.Name = Name.Text;
        return productType;
    }
}