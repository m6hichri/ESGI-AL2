using System.Collections.Generic;
using System.Linq;

namespace _05.ESGI.DesignPattern.Strategy
{
    public interface IPayement
    {
        string Pay(int amount);
    }

    public class CreditCard : IPayement
    {
        public string Pay(int amount)
        {
            return $"{amount} has been charged to my credit card";
        }
    }

    public class Paypal : IPayement
    {
        public string Pay(int amount)
        {
            return $"{amount} has been charged to my paypal account";
        }
    }

    public class ShoppingCard
    {
        private List<(string, int)> items;

        public ShoppingCard()
        {
            items = new List<(string, int)>();
        }

        public void AddItem(string item, int price)
        {
            items.Add((item, price));
        }

        public string Pay(IPayement payementStrategie)
        {
            var total = items.Select(i => i.Item2).Sum();

            return payementStrategie.Pay(total);
        }
    }

}
