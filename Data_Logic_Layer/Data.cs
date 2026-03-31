using System;
using System.Collections.Generic;
using Model_Layer;
using System.Text.Json;

namespace Data_Logic_Layer
{
    public class Data : IDataService
    {
        //Card Data
        public List<Models.Cards> cardlist { get; set; } = new List<Models.Cards>
{
    new Models.Cards { Name = "James", ID = 1234 },
    new Models.Cards { Name = "John", ID = 12345 }
};

        public string AddCard(int id, string name)
        {
            cardlist.Add(new Models.Cards { Name = name, ID = id });
            return "Card added successfully!";
        }

        public string DeleteCard(int choice)
        {
            if (choice < 1 || choice > cardlist.Count)
            {
                return "Invalid selection.";
            }
            else
            {
                Models.Cards card = cardlist[choice - 1];
                cardlist.RemoveAt(choice - 1);
                return $"Card '{card.Name}' deleted successfully!";
            }
        }

        public string UpdateCard(int choice, string newName, int newID)
        {
            if (choice < 1 || choice > cardlist.Count)
            {
                return "Invalid selection.";
            }
            else
            {
                Models.Cards card = cardlist[choice - 1];
                card.Name = newName;
                card.ID = newID;
                return "Card updated successfully!";
            }
        }
        //Cart Data
        public List<Models.Carts> cartlist { get; set; } = new List<Models.Carts>
{
    new Models.Carts { Name = "Apple", Price = 15, Quantity = 5 },
    new Models.Carts { Name = "Chocolate", Price = 50, Quantity = 10 }
};

        public string AddCart(string name, decimal price, int quantity)
        {
            cartlist.Add(new Models.Carts { Name = name, Price = price, Quantity = quantity });
            return "Product added successfully!";
        }

        public string DeleteCart(int choice)
        {
            if (choice < 1 || choice > cartlist.Count)
            {
                return "Invalid selection.";
            }
            else
            {
                Models.Carts cart = cartlist[choice - 1];
                cartlist.RemoveAt(choice - 1);
                return $"Product '{cart.Name}' deleted successfully!";
            }
        }

        public string UpdateCart(int choice, string newName, decimal newPrice, int newQuantity)
        {
            if (choice < 1 || choice > cartlist.Count)
            {
                return "Invalid selection.";
            }
            else
            {
                Models.Carts cart = cartlist[choice - 1];
                cart.Name = newName;
                cart.Price = newPrice;
                cart.Quantity = newQuantity;
                return "Product updated successfully!";
            }
        }
    }


}