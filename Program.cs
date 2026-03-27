using System;
using System.Collections.Generic;
using Model_Layer;
using Data_Logic_Layer;
using Service_Logic_Layer;

namespace CRUD_Card_Cart
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CardData cardData = new CardData();
            CartData cartData = new CartData();
            CartService cartService = new CartService();

            List<Models.Cards> cardlist = new List<Models.Cards>();
            List<Models.Carts> cartlist = new List<Models.Carts>();

            cardlist.Add(new Models.Cards { Name = "James", ID = 1234 });
            cardlist.Add(new Models.Cards { Name = "John", ID = 12345 });

            cartlist.Add(new Models.Carts { Name = "Apple", Price = 15, Quantity = 5 });
            cartlist.Add(new Models.Carts { Name = "Chocolate", Price = 50, Quantity = 10 });

            Console.WriteLine("Welcome! \n Would you like to access your Cart or Card? \n 1. Card \n 2. Cart");
            int choice1 = Convert.ToInt32(Console.ReadLine());

            if (choice1 == 1)
            {
                bool SystemRun = true;
                while (SystemRun)
                {
                    Console.WriteLine("\nCard Management:");

                    if (cardlist.Count == 0)
                    {
                        Console.WriteLine("Your Card list is empty!");
                        Console.Write("Enter Card ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Card Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine(cardData.Add(cardlist, id, name));
                    }
                    else
                    {
                        Console.WriteLine("Here are your available cards:");
                        for (int i = 0; i < cardlist.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Name: {cardlist[i].Name}, ID: {cardlist[i].ID}");
                        }

                        Console.WriteLine("\n1. Add");
                        Console.WriteLine("2. Delete");
                        Console.WriteLine("3. Update");
                        Console.WriteLine("4. Exit");
                        int ChoiceCard = Convert.ToInt32(Console.ReadLine());

                        switch (ChoiceCard)
                        {
                            case 1:
                                Console.Write("Enter Card ID: ");
                                int newId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter Card Name: ");
                                string newName = Console.ReadLine();
                                Console.WriteLine(cardData.Add(cardlist, newId, newName));
                                break;

                            case 2:
                                Console.WriteLine("Select the number of the card you want to delete: ");
                                for (int i = 0; i < cardlist.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. Name: {cardlist[i].Name}, ID: {cardlist[i].ID}");
                                }
                                int deleteChoice = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(cardData.Delete(cardlist, deleteChoice));
                                break;

                            case 3:
                                Console.WriteLine("Select the number of the card you want to update: ");
                                for (int i = 0; i < cardlist.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. Name: {cardlist[i].Name}, ID: {cardlist[i].ID}");
                                }
                                int updateChoice = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter new Name: ");
                                string updatedName = Console.ReadLine();
                                Console.Write("Enter new ID: ");
                                int updatedID = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(cardData.Update(cardlist, updateChoice, updatedName, updatedID));
                                break;

                            case 4:
                                SystemRun = false;
                                break;

                            default:
                                Console.WriteLine("Invalid Input!");
                                break;
                        }
                    }
                }
            }

            else if (choice1 == 2)
            {
                bool SystemRun2 = true;
                while (SystemRun2)
                {
                    Console.WriteLine("\nCart Management:");

                    if (cartlist.Count == 0)
                    {
                        Console.WriteLine("Your Cart list is empty!");
                        Console.Write("Enter Product: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        decimal price = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(cartData.Add(cartlist, name, price, quantity));
                    }
                    else
                    {
                        Console.WriteLine("Here are your available products:");
                        for (int i = 0; i < cartlist.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Product Name: {cartlist[i].Name}, Price: {cartlist[i].Price}, Quantity: {cartlist[i].Quantity}");
                        }

                        Console.WriteLine("\n1. Add");
                        Console.WriteLine("2. Delete");
                        Console.WriteLine("3. Update");
                        Console.WriteLine("4. Check Total");
                        Console.WriteLine("5. Check Discount");
                        Console.WriteLine("6. Exit");
                        int ChoiceCart = Convert.ToInt32(Console.ReadLine());

                        switch (ChoiceCart)
                        {
                            case 1:
                                Console.Write("Enter Product: ");
                                string newName = Console.ReadLine();
                                Console.Write("Enter Price: ");
                                decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter Quantity: ");
                                int newQuantity = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(cartData.Add(cartlist, newName, newPrice, newQuantity));
                                break;

                            case 2:
                                Console.WriteLine("Select the number of the product you want to delete: ");
                                for (int i = 0; i < cartlist.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. Name: {cartlist[i].Name}, Price: {cartlist[i].Price}, Quantity: {cartlist[i].Quantity}");
                                }
                                int deleteChoice = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(cartData.Delete(cartlist, deleteChoice));
                                break;

                            case 3:
                                Console.WriteLine("Select the number of the product you want to update: ");
                                for (int i = 0; i < cartlist.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. Name: {cartlist[i].Name}, Price: {cartlist[i].Price}, Quantity: {cartlist[i].Quantity}");
                                }
                                int updateChoice = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter new Name: ");
                                string updatedName = Console.ReadLine();
                                Console.Write("Enter new Price: ");
                                decimal updatedPrice = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter new Quantity: ");
                                int updatedQuantity = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(cartData.Update(cartlist, updateChoice, updatedName, updatedPrice, updatedQuantity));
                                break;

                            case 4:
                                Console.WriteLine(cartService.CheckTotal(cartlist));
                                break;

                            case 5:
                                Console.WriteLine(cartService.CheckDiscount(cartlist));
                                break;

                            case 6:
                                SystemRun2 = false;
                                break;

                            default:
                                Console.WriteLine("Invalid Input!");
                                break;
                        }
                    }
                }
            }
        }
    }
}