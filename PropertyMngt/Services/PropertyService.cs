using Microsoft.VisualBasic;
using PropertyMngt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMngt.Services
{
    public class PropertyService
    {

        public List<Property> properties = new List<Property>();

        public void CreateApartment(string title, string address, int nbOfRooms)
        {
            var apartment = new Apartment(nbOfRooms, title, address);
            properties.Add(apartment);
        }

        public void CreateLand(string title, string address, int area, bool canBeFarmed)
        {
            var land = new Land(area, canBeFarmed, title, address);
            properties.Add(land);
        }

        public void CreateShop(string title, string address, int area, string businessType)
        {
            var shop = new Shop(area, businessType, title, address);
            properties.Add(shop);
        }


        public void DisplayProperties()
        {
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.GetType().Name} ID: {property.Id}, Title: {property.Title}, Price: {property.Price}");
            }
        }

        public void DisplayLandProperties()
        {

            foreach (var landprop in properties.OfType<Land>())
            {
                Console.WriteLine($"ID: {landprop.Id}, Title: {landprop.Title}, Price: {landprop.Price}");
            }
        }

        public void PropertyPricing()
        {
            Console.WriteLine("Properties with price between 45 and 100k are:");
            foreach (var property in properties.Where(p => p.Price >= 45_000 && p.Price <= 100_000))
            {
                Console.WriteLine("Title: {0}, Price: {1}", property.Title, property.Price);
            }
        }

        public void UpdateProperty(int id, string title, List<Property> properties)
        {
            var prop = properties.First(p => p.Id == id);
            prop.Title = title;
        }
    }
}
