using System;
using System.Collections.Generic;
using Model_Layer;

namespace Data_Logic_Layer
{
    public class CardData
    {
        public void Add(List<Models.Cards> cardlist)
        {
            Console.Write("Enter Card ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Card Name: ");
            string name = Console.ReadLine();

            cardlist.Add(new Models.Cards { Name = name, ID = id });
            Console.WriteLine("Card added successfully!");
        }

        public void Delete(List<Models.Cards> cardlist)
        {
            Console.WriteLine("Select the number of the card you want to delete: ");
            for (int i = 0; i < cardlist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {cardlist[i].Name}, ID: {cardlist[i].ID}");
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 1 || choice > cardlist.Count)
            {
                Console.WriteLine("Invalid selection.");
            }
            else
            {
                Models.Cards card = cardlist[choice - 1];
                cardlist.RemoveAt(choice - 1);
                Console.WriteLine($"Card '{card.Name}' deleted successfully!");
            }
        }

        public void Update(List<Models.Cards> cardlist)
        {
            Console.WriteLine("Select the number of the card you want to update: ");
            for (int i = 0; i < cardlist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {cardlist[i].Name}, ID: {cardlist[i].ID}");
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 1 || choice > cardlist.Count)
            {
                Console.WriteLine("Invalid selection.");
            }
            else
            {
                Models.Cards card = cardlist[choice - 1];

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
                    card.Name = Console.ReadLine();
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
                    card.ID = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Card updated successfully!");
            }
        }
    }

    public class CartData
    {
        public void Add(List<Models.Carts> cartlist)
        {
            Console.Write("Enter Product: ");
            string name = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            cartlist.Add(new Models.Carts { Name = name, Price = price, Quantity = quantity });
            Console.WriteLine("Product added successfully!");
        }

        public void Delete(List<Models.Carts> cartlist)
        {
            Console.WriteLine("Select the number of the product you want to delete: ");
            for (int i = 0; i < cartlist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {cartlist[i].Name}, Price: {cartlist[i].Price}, Quantity: {cartlist[i].Quantity}");
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 1 || choice > cartlist.Count)
            {
                Console.WriteLine("Invalid selection.");
            }
            else
            {
                Models.Carts cart = cartlist[choice - 1];
                cartlist.RemoveAt(choice - 1);
                Console.WriteLine($"Product '{cart.Name}' deleted successfully!");
            }
        }

        public void Update(List<Models.Carts> cartlist)
        {
            Console.WriteLine("Select the number of the product you want to update: ");
            for (int i = 0; i < cartlist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {cartlist[i].Name}, Price: {cartlist[i].Price}, Quantity: {cartlist[i].Quantity}");
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 1 || choice > cartlist.Count)
            {
                Console.WriteLine("Invalid selection.");
            }
            else
            {
                Models.Carts cart = cartlist[choice - 1];

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
                    cart.Name = Console.ReadLine();
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
                    cart.Price = Convert.ToDecimal(Console.ReadLine());
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
                    cart.Quantity = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Product updated successfully!");
            }
        }
    }
}