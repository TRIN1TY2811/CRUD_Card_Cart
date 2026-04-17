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

        bool AddCard(int id, string name);
        bool DeleteCard(int choice);
        bool UpdateCard(int choice, string newName, int newID);
        bool AddCart(string name, decimal price, int quantity);
        bool DeleteCart(int choice);
        
        bool UpdateCart(int choice, string newName, decimal newPrice, int newQuantity);

    }
}
