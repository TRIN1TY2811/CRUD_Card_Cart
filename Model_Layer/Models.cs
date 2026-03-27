using System;
using System.Linq;
using System.Collections.Generic;
namespace Model_Layer
{
    public class Models
    {
        public class Cards
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        public class Carts
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }

        }
    }
}
