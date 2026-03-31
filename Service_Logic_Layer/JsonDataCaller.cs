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
        public string AddCard(int id, string name) => _dataService.AddCard(id, name);
        public string DeleteCard(int choice) => _dataService.DeleteCard(choice);
        public string UpdateCard(int choice, string newName, int newID) => _dataService.UpdateCard(choice, newName, newID);

        // Cart Methods
        public string AddCart(string name, decimal price, int quantity) => _dataService.AddCart(name, price, quantity);
        public string DeleteCart(int choice) => _dataService.DeleteCart(choice);
        public string UpdateCart(int choice, string newName, decimal newPrice, int newQuantity) => _dataService.UpdateCart(choice, newName, newPrice, newQuantity);
    }
}