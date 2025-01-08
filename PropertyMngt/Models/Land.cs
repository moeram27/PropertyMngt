using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMngt.Models
{
    public class Land : Property
    {
        public Land(int area, bool canBeFarmed, string title, string address)
                            : base(title, address)
        {
            Area = area;
            CanBeFarmed = canBeFarmed;
        }

        public int Area { get; set; }

        public bool CanBeFarmed { get; set; }

        public override decimal Price => Area * 3000m;

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Address: {Address}, Area: {Area}m^2, Can be farmed: {CanBeFarmed} , Price: {Price}$";
        }
    }
}
