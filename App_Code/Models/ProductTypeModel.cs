using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeModel
/// </summary>
public class ProductTypeModel
{
    public string InsertProductType(ProductType productType)
    {
        try
        {
            GarageEntities db = new GarageEntities();
            db.ProductType.Add(productType);
            db.SaveChanges();

            return productType.Name + "was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }
    }

    public string UpdateProductType(int id, ProductType productType)
    {
        try
        {
            GarageEntities db = new GarageEntities();
            var toEdit = db.ProductType.FirstOrDefault(p => p.ID == id);
            toEdit.Name = productType.Name;
            db.SaveChanges();

            return productType.Name + "was succesfully updated.";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }
    }

    public string DeleteProductType(int id)
    {
        try
        {
            GarageEntities db = new GarageEntities();
            var prod = db.ProductType.Find(id);
            db.ProductType.Attach(prod);
            db.SaveChanges();
            return prod.Name + "was succesfully removed";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }
    }

    public IList<ProductType> GetAllProductTypes()
    {
        var context = new GarageEntities();

        return context.ProductType.ToList();
    }

    public IList<ProductType> GetSearchedForCategory(string searchText)
    {
        var context = new GarageEntities();

        return context.ProductType.Where(p => p.Name.Contains(searchText)).ToList();
    }
}