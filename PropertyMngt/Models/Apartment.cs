using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMngt.Models
{
    public class Apartment : Property
    {
        public Apartment(int nbOfRooms, string title, string address)
                : base(title, address)
        {
            NbOfRooms = nbOfRooms;
        }

        public int NbOfRooms { get; set; }

        public override decimal Price => NbOfRooms * 15000m;

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Address: {Address}, Number of Rooms: {NbOfRooms}, Price: {Price}$";
        }
    }
}

