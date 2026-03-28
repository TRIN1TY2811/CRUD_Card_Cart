using System;
using System.Collections.Generic;
using Model_Layer;

namespace Data_Logic_Layer
{
    public class CardData
    {

        public string Add(List<Models.Cards> cardlist, int id, string name)
        {
            cardlist.Add(new Models.Cards { Name = name, ID = id });
            return "Card added successfully!";
        }

        public string Delete(List<Models.Cards> cardlist, int choice)
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

        public string Update(List<Models.Cards> cardlist, int choice, string newName, int newID)
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
    }

    public class CartData
    {
        public string Add(List<Models.Carts> cartlist, string name, decimal price, int quantity)
        {
            cartlist.Add(new Models.Carts { Name = name, Price = price, Quantity = quantity });
            return "Product added successfully!";
        }

        public string Delete(List<Models.Carts> cartlist, int choice)
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

        public string Update(List<Models.Carts> cartlist, int choice, string newName, decimal newPrice, int newQuantity)
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