using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class Person : IMovable
    {
        private readonly string _hairColour;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        //public int Age { get; set; }
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value < 0 ? throw new ArgumentException() : value; }
        }

        

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            
            
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person()
        {
        }

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString()
        {
            return $"{base.ToString()} Name: {FullName} Age: {Age}";
        }

        public string Move()
        {
            return "Walking along";
        }

        public string Move(int times)
        {
            return $"Walking along {times} times";
        }
    }
}
