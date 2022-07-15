using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public abstract class Weapon : IShootable
    {
        private string _brand;

        public Weapon(string brand)
        {
            _brand = brand;
        }
        public virtual string Shoot()
        {
            return $"{_brand} fired!";
        }

        public override string ToString()
        {
            return $"{base.ToString()} Weapon brand: {_brand}";
        }

    }
}
