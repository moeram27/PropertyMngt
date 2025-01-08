using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMngt.Models
{
    public class Shop :Property
    {

        public Shop(int area, string businessType, string title, string address)
            : base(title, address)
        {
            Area = area;
            BusinessType = businessType;
        }

        public int Area { get; set; }

        public string BusinessType { get; set; }

        public override decimal Price => Area > 50 ? 120_000m : 80_000m;

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Address: {Address}, Area: {Area}m^2 , Price: {Price}$";
        }
    }
}
