using System;
using System.Collections.Generic;
using Model_Layer;
using System.Text.Json;
using System.IO;

namespace Data_Logic_Layer
{
    public class JsonData : IDataService
    {
        private string cardFile = "cards.json";
        private string cartFile = "carts.json";

        public List<Models.Cards> cardlist
        {
            get
            {
                if (!File.Exists(cardFile)) return new List<Models.Cards>();
                string json = File.ReadAllText(cardFile);
                return JsonSerializer.Deserialize<List<Models.Cards>>(json);
            }
        }

        public List<Models.Carts> cartlist
        {
            get
            {
                if (!File.Exists(cartFile)) return new List<Models.Carts>();
                string json = File.ReadAllText(cartFile);
                return JsonSerializer.Deserialize<List<Models.Carts>>(json);
            }
        }

        private void SaveCards(List<Models.Cards> list)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(cardFile, json);
        }

        private void SaveCarts(List<Models.Carts> list)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(cartFile, json);
        }

        // Card Methods
        public string AddCard(int id, string name)
        {
            List<Models.Cards> list = cardlist;
            list.Add(new Models.Cards { Name = name, ID = id });
            SaveCards(list);
            return "Card added successfully!";
        }

        public string DeleteCard(int choice)
        {
            List<Models.Cards> list = cardlist;
            if (choice < 1 || choice > list.Count)
            {
                return "Invalid selection.";
            }
            else
            {
                Models.Cards card = list[choice - 1];
                list.RemoveAt(choice - 1);
                SaveCards(list);
                return $"Card '{card.Name}' deleted successfully!";
            }
        }

        public string UpdateCard(int choice, string newName, int newID)
        {
            List<Models.Cards> list = cardlist;
            if (choice < 1 || choice > list.Count)
            {
                return "Invalid selection.";
            }
            else
            {
                Models.Cards card = list[choice - 1];
                card.Name = newName;
                card.ID = newID;
                SaveCards(list);
                return "Card updated successfully!";
            }
        }

        // Cart Methods
        public string AddCart(string name, decimal price, int quantity)
        {
            List<Models.Carts> list = cartlist;
            list.Add(new Models.Carts { Name = name, Price = price, Quantity = quantity });
            SaveCarts(list);
            return "Product added successfully!";
        }

        public string DeleteCart(int choice)
        {
            List<Models.Carts> list = cartlist;
            if (choice < 1 || choice > list.Count)
            {
                return "Invalid selection.";
            }
            else
            {
                Models.Carts cart = list[choice - 1];
                list.RemoveAt(choice - 1);
                SaveCarts(list);
                return $"Product '{cart.Name}' deleted successfully!";
            }
        }

        public string UpdateCart(int choice, string newName, decimal newPrice, int newQuantity)
        {
            List<Models.Carts> list = cartlist;
            if (choice < 1 || choice > list.Count)
            {
                return "Invalid selection.";
            }
            else
            {
                Models.Carts cart = list[choice - 1];
                cart.Name = newName;
                cart.Price = newPrice;
                cart.Quantity = newQuantity;
                SaveCarts(list);
                return "Product updated successfully!";
            }
        }
    }
}