using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMngt.Models
{
    public class Buyer
    {
        private static int _id;

        private Buyer()
        {
            Id = Interlocked.Increment(ref _id);
        }

        public Buyer(string fullName, decimal credit)
            : this()
        {
            FullName = fullName;
            Credit = credit;
        }

        public int Id { get; private set; }

        public string FullName { get; set; }

        public decimal Credit { get; set; }

        public List<Property> Properties { get; set; } = new List<Property>();

        public override string ToString()
        {
            return $"Id: {Id}, Full Name: {FullName}, Credit remaining: {Credit}";
        }

    }
}
