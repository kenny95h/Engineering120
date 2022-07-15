namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nish = new Person("Nish", "Mandal");
            //var david = nish;
            var tom = new Person("Nish", "Mandal");
            //Console.WriteLine(nish.GetHashCode());
            ////Console.WriteLine(david.GetHashCode());
            //Console.WriteLine(tom.GetHashCode());
            var bob = new Person("Bob", "Builder") { Age = 25 };
            var people = new List<Person>
            {
                new Person("Cath", "Cookson"),
                new Person("Bob", "Builder"){Age = 25},
                new Person("Dan", "Dare"),
                new Person("Amy", "Andrews"){Age = 32},
            };

            //Console.WriteLine(people.Contains(bob));
            //foreach (Person p in people)
            //{
            //    Console.WriteLine(p.GetFullName());
            //}
            //people.Sort();
            //foreach (Person p in people)
            //{
            //    Console.WriteLine(p.GetFullName());
            //}

            var peopleSet = new HashSet<Person>()
            {
                nish, bob, new Person("Dylan", "Cole")
            };

            //Console.WriteLine("Hash Set");
            //foreach(var entry in peopleSet)
            //{
            //    Console.WriteLine(entry.GetFullName());
            //    Console.WriteLine(entry.GetHashCode());
            //}

            var success = peopleSet.Add(new Person("Tom", "Smith"));
            var successTwo = peopleSet.Add(tom);
            //Console.WriteLine(success);
            //Console.WriteLine(successTwo);

            var morePeople = new HashSet<Person> { new Person("Cathy", "Hall"), new Person("Jasmine", "Smith"), new Person("Tom", "Smith") };

            //peopleSet.IntersectWith(morePeople);

            //foreach (var entry in peopleSet)
            //{
            //    Console.WriteLine(entry.GetFullName());
            //}

            //foreach (var entry in morePeople)
            //{
            //    Console.WriteLine(entry.GetFullName());
            //}

            var peoples = new Dictionary<string, Person>
            {
                {"Tom", tom },
                {"Helen", new Person("Helen", "Smith") }
            };

            string input = "The cat in the hat comes back";
            input = input.Trim().ToLower();
            var countDict = new Dictionary<char, int>();

            foreach(char c in input)
            {
                if(countDict.ContainsKey(c))
                { 
                    countDict[c]++; 
                } else
                {
                    countDict.Add(c, 1);
                }
            }
            
            foreach(var entry in countDict)
            {
                Console.WriteLine(entry.Value);
            }
        }
    }

    public class Person : IEquatable<Person?>, IComparable<Person?>

    {
        private string _firstName;
        private string _lastName;
        private int _age;
        public Person() { }
        public Person(string fName, string lName)
        {
            _firstName = fName;
            _lastName = lName;
        }

        public int Age
        {
            get { return _age; }
            set { if (value >= 0) _age = value; }
        }

        public int CompareTo(Person? other)
        {
            if (other == null) return 1;
            if (this._lastName != other._lastName)
            {
                return this._lastName.CompareTo(other._lastName);
            }
            else if (this._firstName != other._firstName)
            {
                return this._firstName.CompareTo(other._firstName);
            }
            else
            {
                return this._age.CompareTo(other._age);
            }
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person? other)
        {
            return other is not null &&
                   _firstName == other._firstName &&
                   _lastName == other._lastName &&
                   _age == other._age;
        }

        public string GetFullName()
        {
            return $"{_firstName} {_lastName}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_firstName, _lastName, _age);
        }

        public static bool operator ==(Person? left, Person? right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person? left, Person? right)
        {
            return !(left == right);
        }
    }


}