using System;

namespace HeavyMetalBakeSale.Kata
{
    public class Item : ICloneable
    {
        public string Name { get; set; }
        public char Identifier { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public object Clone()
        {
            return new Item()
            {
                Name = this.Name,
                Cost = Cost,
                Identifier = Identifier,
                Quantity = Quantity
            };
        }
    }
}