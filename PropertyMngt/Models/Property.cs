using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMngt.Models
{
    public abstract class Property
    {
        private static int _id;

        private Property()
        {
            Id = Interlocked.Increment(ref _id);
        }

        public Property(string title, string address)
            : this()
        {
            Title = title;
            Address = address;
        }

        public int Id { get; private set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public abstract decimal Price { get;}

        public Buyer Owner { get; set; }



    }
}
