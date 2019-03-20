using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class ProductModel
{
    public string InsertProduct(Product product)
    {
        try
        {
            GarageEntities db = new GarageEntities();
            db.Product.Add(product);
            db.SaveChanges();

            return product.Name + "was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }
    }

    public string UpdateProduct(int id, Product product)
    {
        try
        {
            GarageEntities db = new GarageEntities();
            var toEdit = db.Product.FirstOrDefault(p => p.ID == id);
            toEdit.Name = product.Name;
            toEdit.Description = product.Description;
            toEdit.Image = product.Image;
            toEdit.Price = product.Price;
            toEdit.TypeID = product.TypeID;
            db.Product.AddOrUpdate(toEdit);
            db.SaveChanges();

            return product.Name + "was succesfully updated.";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }
    }

    public string DeleteProduct(int id)
    {
        try
        {
            GarageEntities db = new GarageEntities();
            var prod = db.Product.Find(id);
            db.Product.Attach(prod);
            db.SaveChanges();
            return prod.Name + "was succesfully removed";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }
    }

    public Product GetProduct(int id)
    {
        try
        {
            using (var context = new GarageEntities())
            {
                var product = context.Product.Find(id);
                return product;
            }
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public IList<Product> GetAllProducts(string filter)
    {
        try
        {
            using (var context = new GarageEntities())
            {
                var products = new List<Product>();
                var list = context.Product.ToList();

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    list.Where(p => p.Name.Equals(filter));
                }

                products.AddRange(list);
                
                return products;
            }
        }
        catch (Exception e)
        {
            return new List<Product>();
        }
    }

    public IList<Product> GetProductsOfType(int typeId)
    {
        try
        {
            using (var context = new GarageEntities())
            {
                var products = new List<Product>();
                var list = context.Product.Where(p => p.ProductType.ID == typeId).ToList();
               
                products.AddRange(list);
                return products;
            }
        }
        catch (Exception e)
        {
            return new List<Product>();
        }
    }

    public IList<Product> GetSearchedForProducts(int typeId, string filter)
    {
        try
        {
            using (var context = new GarageEntities())
            {
                var products = new List<Product>();
                var list = context.Product.Where(p => p.ProductType.ID == typeId && p.Name.Contains(filter)).ToList();

                products.AddRange(list);
                return products;
            }
        }
        catch (Exception e)
        {
            return new List<Product>();
        }
    }
}