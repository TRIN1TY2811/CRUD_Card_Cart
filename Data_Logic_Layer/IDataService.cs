using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace Data_Logic_Layer
{
    public interface IDataService
    {
        List<Models.Cards> cardlist { get; }
        List<Models.Carts> cartlist { get; }

        string AddCard(int id, string name);
        string DeleteCard(int choice);
        string UpdateCard(int choice, string newName, int newID);
        string AddCart(string name, decimal price, int quantity);
        string DeleteCart(int choice);
        
        string UpdateCart(int choice, string newName, decimal newPrice, int newQuantity);

    }
}
