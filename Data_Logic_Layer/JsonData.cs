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
                if (!File.Exists(cardFile))
                {
                    List<Models.Cards> defaultCards = new List<Models.Cards>
                    {
                        new Models.Cards { Name = "James", ID = 1234 },
                        new Models.Cards { Name = "John", ID = 12345 }
                    };
                    SaveCards(defaultCards);
                    return defaultCards;
                }
                string json = File.ReadAllText(cardFile);
                return JsonSerializer.Deserialize<List<Models.Cards>>(json);
            }
        }

        public List<Models.Carts> cartlist
        {
            get
            {
                if (!File.Exists(cartFile))
                {
                    List<Models.Carts> defaultCarts = new List<Models.Carts>
                    {
                        new Models.Carts { Name = "Apple", Price = 15, Quantity = 5 },
                        new Models.Carts { Name = "Chocolate", Price = 50, Quantity = 10 }
                    };
                    SaveCarts(defaultCarts);
                    return defaultCarts;
                }
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

        public bool AddCard(int id, string name)
        {
            List<Models.Cards> list = cardlist;
            list.Add(new Models.Cards { Name = name, ID = id });
            SaveCards(list);
            return true;
        }

        public bool DeleteCard(int choice)
        {
            List<Models.Cards> list = cardlist;
            if (choice < 1 || choice > list.Count)
                return false;
            else
            {
                list.RemoveAt(choice - 1);
                SaveCards(list);
                return true;
            }
        }

        public bool UpdateCard(int choice, string newName, int newID)
        {
            List<Models.Cards> list = cardlist;
            if (choice < 1 || choice > list.Count)
                return false;
            else
            {
                Models.Cards card = list[choice - 1];
                card.Name = newName;
                card.ID = newID;
                SaveCards(list);
                return true;
            }
        }

        public bool AddCart(string name, decimal price, int quantity)
        {
            List<Models.Carts> list = cartlist;
            list.Add(new Models.Carts { Name = name, Price = price, Quantity = quantity });
            SaveCarts(list);
            return true;
        }

        public bool DeleteCart(int choice)
        {
            List<Models.Carts> list = cartlist;
            if (choice < 1 || choice > list.Count)
                return false;
            else
            {
                list.RemoveAt(choice - 1);
                SaveCarts(list);
                return true;
            }
        }

        public bool UpdateCart(int choice, string newName, decimal newPrice, int newQuantity)
        {
            List<Models.Carts> list = cartlist;
            if (choice < 1 || choice > list.Count)
                return false;
            else
            {
                Models.Carts cart = list[choice - 1];
                cart.Name = newName;
                cart.Price = newPrice;
                cart.Quantity = newQuantity;
                SaveCarts(list);
                return true;
            }
        }
    }
}