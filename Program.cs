using System;
using System.Collections.Generic;
using Model_Layer;
using Data_Logic_Layer;
using Service_Logic_Layer;
using Business_Logic_Layer;

namespace CRUD_Card_Cart
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IDataService dataService = new JsonData();
            JsonDataCaller data = new JsonDataCaller(dataService);

            Console.WriteLine("Welcome! \n Would you like to access your Cart or Card? \n 1. Card \n 2. Cart");
            int choice1 = Convert.ToInt32(Console.ReadLine());

            if (choice1 == 1)
            {
                bool SystemRun = true;
                while (SystemRun)
                {
                    Console.WriteLine("\nCard Management:");

                    if (data.cardlist.Count == 0)
                    {
                        Console.WriteLine("Your Card list is empty!");
                        Console.Write("Enter Card ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Card Name: ");
                        string name = Console.ReadLine();
                        if (data.AddCard(id, name))
                            Console.WriteLine("Card added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Here are your available cards:");
                        for (int i = 0; i < data.cardlist.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Name: {data.cardlist[i].Name}, ID: {data.cardlist[i].ID}");
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
                                if (data.AddCard(newId, newName))
                                    Console.WriteLine("Card added successfully!");
                                break;

                            case 2:
                                Console.WriteLine("Select the number of the card you want to delete: ");
                                for (int i = 0; i < data.cardlist.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. Name: {data.cardlist[i].Name}, ID: {data.cardlist[i].ID}");
                                }
                                int deleteChoice = Convert.ToInt32(Console.ReadLine());
                                if (data.DeleteCard(deleteChoice))
                                    Console.WriteLine("Card deleted successfully!");
                                else
                                    Console.WriteLine("Invalid selection.");
                                break;

                            case 3:
                                Console.WriteLine("Select the number of the card you want to update: ");
                                for (int i = 0; i < data.cardlist.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. Name: {data.cardlist[i].Name}, ID: {data.cardlist[i].ID}");
                                }
                                int updateChoice = Convert.ToInt32(Console.ReadLine());

                                string updatedName = data.cardlist[updateChoice - 1].Name;
                                int updatedID = data.cardlist[updateChoice - 1].ID;

                                char changeName;
                                while (true)
                                {
                                    Console.Write("Would you like to change the Name? y or n: ");
                                    changeName = Convert.ToChar(Console.ReadLine());
                                    if (changeName == 'y' || changeName == 'n') break;
                                    Console.WriteLine("Invalid input. Please type y or n.");
                                }
                                if (changeName == 'y')
                                {
                                    Console.Write("Enter new Name: ");
                                    updatedName = Console.ReadLine();
                                }

                                char changeID;
                                while (true)
                                {
                                    Console.Write("Would you like to change the ID? y or n: ");
                                    changeID = Convert.ToChar(Console.ReadLine());
                                    if (changeID == 'y' || changeID == 'n') break;
                                    Console.WriteLine("Invalid input. Please type y or n.");
                                }
                                if (changeID == 'y')
                                {
                                    Console.Write("Enter new ID: ");
                                    updatedID = Convert.ToInt32(Console.ReadLine());
                                }

                                if (data.UpdateCard(updateChoice, updatedName, updatedID))
                                    Console.WriteLine("Card updated successfully!");
                                else
                                    Console.WriteLine("Invalid selection.");
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
                CartService cartService = new CartService();
                bool SystemRun2 = true;
                while (SystemRun2)
                {
                    Console.WriteLine("\nCart Management:");

                    if (data.cartlist.Count == 0)
                    {
                        Console.WriteLine("Your Cart list is empty!");
                        Console.Write("Enter Product: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        decimal price = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        if (data.AddCart(name, price, quantity))
                            Console.WriteLine("Product added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Here are your available products:");
                        for (int i = 0; i < data.cartlist.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Product Name: {data.cartlist[i].Name}, Price: {data.cartlist[i].Price}, Quantity: {data.cartlist[i].Quantity}");
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
                                if (data.AddCart(newName, newPrice, newQuantity))
                                    Console.WriteLine("Product added successfully!");
                                break;

                            case 2:
                                Console.WriteLine("Select the number of the product you want to delete: ");
                                for (int i = 0; i < data.cartlist.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. Name: {data.cartlist[i].Name}, Price: {data.cartlist[i].Price}, Quantity: {data.cartlist[i].Quantity}");
                                }
                                int deleteChoice = Convert.ToInt32(Console.ReadLine());
                                if (data.DeleteCart(deleteChoice))
                                    Console.WriteLine("Product deleted successfully!");
                                else
                                    Console.WriteLine("Invalid selection.");
                                break;

                            case 3:
                                Console.WriteLine("Select the number of the product you want to update: ");
                                for (int i = 0; i < data.cartlist.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. Name: {data.cartlist[i].Name}, Price: {data.cartlist[i].Price}, Quantity: {data.cartlist[i].Quantity}");
                                }
                                int updateChoice = Convert.ToInt32(Console.ReadLine());

                                string updatedName = data.cartlist[updateChoice - 1].Name;
                                decimal updatedPrice = data.cartlist[updateChoice - 1].Price;
                                int updatedQuantity = data.cartlist[updateChoice - 1].Quantity;

                                char changeName;
                                while (true)
                                {
                                    Console.Write("Would you like to change the Name? y or n: ");
                                    changeName = Convert.ToChar(Console.ReadLine());
                                    if (changeName == 'y' || changeName == 'n') break;
                                    Console.WriteLine("Invalid input. Please type y or n.");
                                }
                                if (changeName == 'y')
                                {
                                    Console.Write("Enter new Name: ");
                                    updatedName = Console.ReadLine();
                                }

                                char changePrice;
                                while (true)
                                {
                                    Console.Write("Would you like to change the Price? y or n: ");
                                    changePrice = Convert.ToChar(Console.ReadLine());
                                    if (changePrice == 'y' || changePrice == 'n') break;
                                    Console.WriteLine("Invalid input. Please type y or n.");
                                }
                                if (changePrice == 'y')
                                {
                                    Console.Write("Enter new Price: ");
                                    updatedPrice = Convert.ToDecimal(Console.ReadLine());
                                }

                                char changeQuantity;
                                while (true)
                                {
                                    Console.Write("Would you like to change the Quantity? y or n: ");
                                    changeQuantity = Convert.ToChar(Console.ReadLine());
                                    if (changeQuantity == 'y' || changeQuantity == 'n') break;
                                    Console.WriteLine("Invalid input. Please type y or n.");
                                }
                                if (changeQuantity == 'y')
                                {
                                    Console.Write("Enter new Quantity: ");
                                    updatedQuantity = Convert.ToInt32(Console.ReadLine());
                                }

                                if (data.UpdateCart(updateChoice, updatedName, updatedPrice, updatedQuantity))
                                    Console.WriteLine("Product updated successfully!");
                                else
                                    Console.WriteLine("Invalid selection.");
                                break;

                            case 4:
                                Console.WriteLine(cartService.CheckTotal(data.cartlist));
                                break;

                            case 5:
                                Console.WriteLine(cartService.CheckDiscount(data.cartlist));
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