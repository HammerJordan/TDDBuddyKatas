using System.Collections.Generic;
using System.Linq;

namespace HeavyMetalBakeSale.Kata
{
    public class BakeSale
    {
        private List<Item> inventory;

        public BakeSale(List<Item> inventory)
        {
            this.inventory = inventory;
        }

        public Transaction ItemsToPurchase(string items)
        {
            if (string.IsNullOrEmpty(items))
                throw new InvalidItemException("Items must not be null or empty");

            var identifiers = items.Split(",");
            
            if(identifiers.Any(x => x.Length != 1))
                throw new InvalidItemException("Items identifiers must have a length of 1 seperated by a comma");
            
            if(!identifiers.Any(x => inventory.Any(c => c.Identifier == x[0])))
                throw new InvalidItemException($"No Item identifier for product found");

            var cart = GetItems(items);

            decimal cost = cart.Sum(x => x.Cost * x.Quantity);



            return new Transaction("Message", cost, items);
        }

        private IEnumerable<Item> GetItems(string items)
        {
            var output = new List<Item>();

            foreach (char i in items.Split(',').Select(x => x.First()))
            {
               var item = inventory.First(x => x.Identifier == i);
               
               if (output.Any(x => x.Identifier == i))
                   output.First(x => x.Identifier == i).Quantity++;
               else
               {
                   var newItem = (Item)item.Clone();
                   newItem.Quantity = 1;
                   output.Add(newItem);
               }

            }

            return output;
        }
    }
}