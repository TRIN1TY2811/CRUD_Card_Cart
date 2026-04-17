using System;
using System.Collections.Generic;
using Model_Layer;
using System.Text.Json;

namespace Data_Logic_Layer
{
    public class Data : IDataService
    {
        public List<Models.Cards> cardlist { get; set; } = new List<Models.Cards>
        {
            new Models.Cards { Name = "James", ID = 1234 },
            new Models.Cards { Name = "John", ID = 12345 }
        };

        public bool AddCard(int id, string name)
        {
            cardlist.Add(new Models.Cards { Name = name, ID = id });
            return true;
        }

        public bool DeleteCard(int choice)
        {
            if (choice < 1 || choice > cardlist.Count)
                return false;
            else
            {
                cardlist.RemoveAt(choice - 1);
                return true;
            }
        }

        public bool UpdateCard(int choice, string newName, int newID)
        {
            if (choice < 1 || choice > cardlist.Count)
                return false;
            else
            {
                Models.Cards card = cardlist[choice - 1];
                card.Name = newName;
                card.ID = newID;
                return true;
            }
        }

        public List<Models.Carts> cartlist { get; set; } = new List<Models.Carts>
        {
            new Models.Carts { Name = "Apple", Price = 15, Quantity = 5 },
            new Models.Carts { Name = "Chocolate", Price = 50, Quantity = 10 }
        };

        public bool AddCart(string name, decimal price, int quantity)
        {
            cartlist.Add(new Models.Carts { Name = name, Price = price, Quantity = quantity });
            return true;
        }

        public bool DeleteCart(int choice)
        {
            if (choice < 1 || choice > cartlist.Count)
                return false;
            else
            {
                cartlist.RemoveAt(choice - 1);
                return true;
            }
        }

        public bool UpdateCart(int choice, string newName, decimal newPrice, int newQuantity)
        {
            if (choice < 1 || choice > cartlist.Count)
                return false;
            else
            {
                Models.Carts cart = cartlist[choice - 1];
                cart.Name = newName;
                cart.Price = newPrice;
                cart.Quantity = newQuantity;
                return true;
            }
        }
    }
}