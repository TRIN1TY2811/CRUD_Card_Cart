using System;
using System.Collections.Generic;
using Model_Layer;

namespace Service_Logic_Layer
{
    public class CartService
    {
        public void CheckTotal(List<Models.Carts> cartlist)
        {
            Console.WriteLine("\nCart Total:");
            decimal grandTotal = 0;

            for (int i = 0; i < cartlist.Count; i++)
            {
                decimal itemTotal = cartlist[i].Price * cartlist[i].Quantity;
                Console.WriteLine($"{i + 1}. {cartlist[i].Name} | Price: {cartlist[i].Price} | Quantity: {cartlist[i].Quantity} | Total: {itemTotal}");
                grandTotal += itemTotal;
            }

            Console.WriteLine($"\nGrand Total: {grandTotal}");
            Console.WriteLine("------------------");
        }

        public void CheckDiscount(List<Models.Carts> cartlist)
        {
            decimal grandTotal = 0;

            foreach (var cart in cartlist)
            {
                grandTotal += cart.Price * cart.Quantity;
            }

            Console.WriteLine("\nProduct Summary:");
            Console.WriteLine($"Grand Total: {grandTotal}");

            if (grandTotal >= 10000)
            {
                decimal discount = grandTotal * 0.20m;
                decimal finalTotal = grandTotal - discount;
                Console.WriteLine($"You have reached 10,000 pesos worth of product! You get a 20% discount.");
                Console.WriteLine($"Discount Amount: {discount}");
                Console.WriteLine($"Final Total: {finalTotal}");
            }
            else if (grandTotal >= 5000)
            {
                decimal discount = grandTotal * 0.10m;
                decimal finalTotal = grandTotal - discount;
                Console.WriteLine($"You have reached 5,000 Pesos worth of product! You get a 10% discount.");
                Console.WriteLine($"Discount Amount: {discount}");
                Console.WriteLine($"Final Total: {finalTotal}");
            }
            else
            {
                decimal needMoreToSpend = 5000 - grandTotal;
                Console.WriteLine($"Spend at least {needMoreToSpend} more to get a 10% discount!");
            }
        }
    }
}