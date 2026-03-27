using System;
using System.Collections.Generic;
using Model_Layer;

namespace Service_Logic_Layer
{
    public class CartService
    {
        public string CheckTotal(List<Models.Carts> cartlist)
        {
            string result = "\nCart Total:\n";
            decimal grandTotal = 0;
            for (int i = 0; i < cartlist.Count; i++)
            {
                decimal itemTotal = cartlist[i].Price * cartlist[i].Quantity;
                result += $"{i + 1}. {cartlist[i].Name} | Price: {cartlist[i].Price} | Quantity: {cartlist[i].Quantity} | Total: {itemTotal}\n";
                grandTotal += itemTotal;
            }
            result += $"\nGrand Total: {grandTotal}\n";
            result += "------------------";
            return result;
        }

        public string CheckDiscount(List<Models.Carts> cartlist)
        {
            decimal grandTotal = 0;
            foreach (var cart in cartlist)
            {
                grandTotal += cart.Price * cart.Quantity;
            }

            string result = "\nProduct Summary:\n";
            result += $"Grand Total: {grandTotal}\n";

            if (grandTotal >= 10000)
            {
                decimal discount = grandTotal * 0.20m;
                decimal finalTotal = grandTotal - discount;
                result += $"You have reached 10,000 pesos worth of product! You get a 20% discount.\n";
                result += $"Discount Amount: {discount}\n";
                result += $"Final Total: {finalTotal}";
            }
            else if (grandTotal >= 5000)
            {
                decimal discount = grandTotal * 0.10m;
                decimal finalTotal = grandTotal - discount;
                result += $"You have reached 5,000 Pesos worth of product! You get a 10% discount.\n";
                result += $"Discount Amount: {discount}\n";
                result += $"Final Total: {finalTotal}";
            }
            else
            {
                decimal needMoreToSpend = 5000 - grandTotal;
                result += $"Spend at least {needMoreToSpend} more to get a 10% discount!";
            }

            return result;
        }
    }
}