using System;
using System.Collections.Generic;
using Model_Layer;
using Data_Logic_Layer;

namespace Business_Logic_Layer
{
    public class JsonDataCaller
    {
        private IDataService _dataService;

        public JsonDataCaller(IDataService dataService)
        {
            _dataService = dataService;
        }

        public List<Models.Cards> cardlist => _dataService.cardlist;
        public List<Models.Carts> cartlist => _dataService.cartlist;


        // Card Methods
        public bool AddCard(int id, string name) => _dataService.AddCard(id, name);
        public bool DeleteCard(int choice) => _dataService.DeleteCard(choice);
        public bool UpdateCard(int choice, string newName, int newID) => _dataService.UpdateCard(choice, newName, newID);

        // Cart Methods
        public bool AddCart(string name, decimal price, int quantity) => _dataService.AddCart(name, price, quantity);
        public bool DeleteCart(int choice) => _dataService.DeleteCart(choice);
        public bool UpdateCart(int choice, string newName, decimal newPrice, int newQuantity) => _dataService.UpdateCart(choice, newName, newPrice, newQuantity);
    }
}