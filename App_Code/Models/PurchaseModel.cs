using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// Summary description for PurchaseModel
    /// </summary>
    public class PurchaseModel
    {
        public string InsertPurchase(Purchase purchase)
        {
            try
            {
                GarageEntities db = new GarageEntities();
                db.Purchase.Add(purchase);
                db.SaveChanges();

                return purchase.Date + "was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public string UpdatePurchase(int id, Purchase purchase)
        {
            try
            {
                GarageEntities db = new GarageEntities();
                var toEdit = db.Purchase.FirstOrDefault(p => p.ID == id);
                toEdit.Amount = purchase.Amount;
                toEdit.Date = purchase.Date;
                toEdit.IsInCart = purchase.IsInCart;
                db.SaveChanges();

                return purchase.Date + "was succesfully updated.";
            }
            catch (Exception e )
            {
                return "Error" + e;
            }

        }

        public string DeletePurchase(int id)
        {
            try
            {
                GarageEntities db = new GarageEntities();
                var purchase = db.Purchase.Find(id);
                db.Purchase.Attach(purchase);
                db.SaveChanges();
                return purchase.Date + "was succesfully removed";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public IList<Purchase> GetOrdersInCart(string userID)
        {
            var context = new GarageEntities();

            var orders = context.Purchase.Where(p => p.UserId.Equals(userID) && p.IsInCart).ToList();

            return orders;
        }

        public int GetAmountOfOrders(string userId)
        {
            try
            {
                var context = new GarageEntities();

                return context.Purchase.Where(p => p.UserId.Equals(userId) && p.IsInCart).Select(p => p.Amount)
                    .Sum();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var context = new GarageEntities();

            var cart = context.Purchase.Find(id);
            cart.Amount = quantity;

            context.SaveChanges();
        }

        public void MarkOrderAsPaid(IList<Purchase> carts)
        {
            var context = new GarageEntities();

            foreach (var cart in carts)
            {
                var oldCart = context.Purchase.Find(cart.ID);
                oldCart.Date = DateTime.Now;
                oldCart.IsInCart = false;
            }

            context.SaveChanges();
        }

    }
}