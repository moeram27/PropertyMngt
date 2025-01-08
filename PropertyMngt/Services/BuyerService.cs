using PropertyMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMngt.Services
{
    public class BuyerService
    {
        public List<Buyer> buyers = new();

        public void CreateBuyer(string fullName, decimal credit)
        {
            var buyer = new Buyer(fullName, credit);
            buyers.Add(buyer);
        }


        public void PurchaseProperty(Buyer buyer, Property property)
        {
            var ownedProperties = buyer.Properties;

            if (ownedProperties.Contains(property))
            {
                Console.WriteLine("Property already owned");
                return;
            }

            if (buyer.Credit >= property.Price)
            {
                buyer.Credit -= property.Price;

                ownedProperties.Add(property);
                Console.WriteLine($"Buyer {buyer.FullName} has purchased property {property.Title},Credits remaining {buyer.Credit}$");
            }
            else
            {
                Console.WriteLine($"Buyer {buyer.FullName} does not have enough credit to purchase property {property.Title}, missing {property.Price - buyer.Credit}$");
            }
        }

        public void DisplayBuyers(List<Buyer> buyers)
        {
            foreach (var buyer in buyers)
            {
                Console.WriteLine($"Buyer {buyer.FullName}, owns {buyer.Properties.Count} properties, and has {buyer.Credit} credits remaining");
            }
        }
    }
}
