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

        public void ItemsToPurchase(string items)
        {
            if (string.IsNullOrEmpty(items))
                throw new InvalidItemException("Items must not be null or empty");

            var identifiers = items.Split(",");
            
            if(identifiers.Any(x => x.Length != 1))
                throw new InvalidItemException("Items identifiers must have a length of 1 seperated by a comma");
            
            if(!identifiers.Any(x => inventory.Any(c => c.Identifier == x[0])))
                throw new InvalidItemException($"No Item identifier for product found");
                
            
            
            
            

        }
    }
}