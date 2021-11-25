using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCampApp.API.Services
{
    public class Subscriber
    {
        readonly string _name;
        public Subscriber(string name)
        {
            _name = name;

        }

        public void Update()
        {
            Console.WriteLine($"Message received by {_name}");
        }
    }
}
