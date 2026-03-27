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
                        cardData.Add(cardlist);
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
                                cardData.Add(cardlist);
                                break;
                            case 2:
                                cardData.Delete(cardlist);
                                break;
                            case 3:
                                cardData.Update(cardlist);
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
                        cartData.Add(cartlist);
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
                                cartData.Add(cartlist);
                                break;
                            case 2:
                                cartData.Delete(cartlist);
                                break;
                            case 3:
                                cartData.Update(cartlist);
                                break;
                            case 4:
                                cartService.CheckTotal(cartlist);
                                break;
                            case 5:
                                cartService.CheckDiscount(cartlist);
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