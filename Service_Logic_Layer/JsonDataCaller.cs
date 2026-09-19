using System;
using System.Collections.Generic;
using Model_Layer;
using Data_Logic_Layer;
using Service_Logic_Layer;

namespace Business_Logic_Layer
{
    public class JsonDataCaller
    {
        private readonly IDataService _dataService;
        private readonly EmailService? _emailService;

        public JsonDataCaller(IDataService dataService, EmailService? emailService = null)
        {
            _dataService = dataService;
            _emailService = emailService;
        }

        public List<Models.Cards> cardlist => _dataService.cardlist;
        public List<Models.Carts> cartlist => _dataService.cartlist;

        // Card Methods
        public bool AddCard(int id, string name)
        {
            bool success = _dataService.AddCard(id, name);
            if (success)
            {
                _emailService?.SendNotification(
                    "Card Added",
                    $"A new card has been added to the system.\n\nCard ID: {id}\nCard Name: {name}\nTimestamp: {DateTime.Now}"
                );
            }
            return success;
        }

        public bool DeleteCard(int choice)
        {
            string cardName = (choice >= 1 && choice <= cardlist.Count) ? cardlist[choice - 1].Name : $"Index {choice}";
            bool success = _dataService.DeleteCard(choice);
            if (success)
            {
                _emailService?.SendNotification(
                    "Card Deleted",
                    $"Card '{cardName}' (at index {choice}) was deleted from the system.\nTimestamp: {DateTime.Now}"
                );
            }
            return success;
        }

        public bool UpdateCard(int choice, string newName, int newID)
        {
            bool success = _dataService.UpdateCard(choice, newName, newID);
            if (success)
            {
                _emailService?.SendNotification(
                    "Card Updated",
                    $"Card at index {choice} was updated.\n\nNew ID: {newID}\nNew Name: {newName}\nTimestamp: {DateTime.Now}"
                );
            }
            return success;
        }

        // Cart Methods
        public bool AddCart(string name, decimal price, int quantity)
        {
            bool success = _dataService.AddCart(name, price, quantity);
            if (success)
            {
                _emailService?.SendNotification(
                    "Cart Product Added",
                    $"A new product was added to the cart.\n\nProduct Name: {name}\nPrice: {price:C}\nQuantity: {quantity}\nTimestamp: {DateTime.Now}"
                );
            }
            return success;
        }

        public bool DeleteCart(int choice)
        {
            string itemName = (choice >= 1 && choice <= cartlist.Count) ? cartlist[choice - 1].Name : $"Index {choice}";
            bool success = _dataService.DeleteCart(choice);
            if (success)
            {
                _emailService?.SendNotification(
                    "Cart Product Deleted",
                    $"Product '{itemName}' (at index {choice}) was deleted from the cart.\nTimestamp: {DateTime.Now}"
                );
            }
            return success;
        }

        public bool UpdateCart(int choice, string newName, decimal newPrice, int newQuantity)
        {
            bool success = _dataService.UpdateCart(choice, newName, newPrice, newQuantity);
            if (success)
            {
                _emailService?.SendNotification(
                    "Cart Product Updated",
                    $"Cart product at index {choice} was updated.\n\nNew Name: {newName}\nNew Price: {newPrice:C}\nNew Quantity: {newQuantity}\nTimestamp: {DateTime.Now}"
                );
            }
            return success;
        }
    }
}