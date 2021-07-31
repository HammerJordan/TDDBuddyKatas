using System.Collections.Generic;
using System.Linq;

namespace HeavyMetalBakeSale.Kata
{
    public class BakeSale
    {
        private readonly List<Item> inventory;

        public BakeSale(List<Item> inventory)
        {
            this.inventory = inventory;
        }

        public Transaction ItemsToPurchase(string items)
        {
            if (string.IsNullOrEmpty(items))
                throw new InvalidItemException("Items must not be null or empty");

            var identifiers = items
                .Split(",")
                .ToArray();

            ValidateItemIdentifiers(identifiers);

            var cart = GetItems(identifiers);
            var transaction = CalculateTransaction(cart);
            return transaction;
        }

        private Transaction CalculateTransaction(IEnumerable<Item> cart)
        {
            var cartArray = cart as Item[] ?? cart.ToArray();
            decimal cost = cartArray.Sum(x => x.Cost * x.Quantity);
            string message = GenerateTransactionInvoice(cartArray, cost);
            string products = CartToProductString(cartArray);
            return new Transaction(message, cost, products);
        }

        private static string CartToProductString(IEnumerable<Item> cartArray)
        {
            string products = "";
            foreach (var item in cartArray)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    products += item.Identifier + ',';
                }
            }

            return products;
        }

        private static string GenerateTransactionInvoice(IEnumerable<Item> cartArray, decimal cost)
        {
            string message = "Items to purchase:\n";
            foreach (var item in cartArray)
            {
                message += $"{item.Name}: {item.Cost:C} (X {item.Quantity}) - {item.Cost * item.Quantity:C}";
                message += '\n';
            }

            message += $"Total: {cost:C}";
            return message;
        }

        private void ValidateItemIdentifiers(string[] identifiers)
        {
            if (identifiers.Any(x => x.Length != 1))
                throw new InvalidItemException("Items identifiers must have a length of 1 seperated by a comma");

            if (!identifiers.Any(x => inventory.Any(c => c.Identifier == x.First())))
                throw new InvalidItemException($"No Item identifier for product found");
        }

        private IEnumerable<Item> GetItems(IEnumerable<string> identifiers)
        {
            var output = new List<Item>();

            foreach (char i in identifiers.Select(x => x.First()))
            {
                var item = inventory.First(x => x.Identifier == i);

                if (output.Any(x => x.Identifier == i))
                    output.First(x => x.Identifier == i).Quantity++;
                else
                {
                    var newItem = (Item) item.Clone();
                    newItem.Quantity = 1;
                    output.Add(newItem);
                }
            }

            return output;
        }

        public TransactionReceipt MakeTransaction(Transaction transaction, decimal amountPayed)
        {
            // if (amountPayed < transaction.Total)
            //     return new TransactionReceipt("Insufficient funds to make transaction",0);

            return new TransactionReceipt("something", amountPayed - transaction.Total);

        }
    }
}