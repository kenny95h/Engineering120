using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class Vehicle : IMovable
    {
        private int _capacity;
        private int _numPassengers;

        public int NumPassengers
        {
            get { return _numPassengers; }
            set { _numPassengers = value < 0 ? throw new ArgumentOutOfRangeException("Must be a non-negative integer")
                    : _capacity < value ? throw new ArgumentOutOfRangeException($"Not enough space in the vehicle. Capacity: {_capacity}")
                    : value; }
        }

        public int Position { get; private set; }
        public int Speed { get; init; }

        public Vehicle ()
        {
            Speed = 10;
        }

        public Vehicle(int capacity, int speed = 10)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException("Capacity must be a non-negative integer");
            _capacity = capacity;
            Speed = speed;
        }

        public virtual string Move()
        {
            checked
            {
                Position += Speed;
            }
                return "Moving along";
            
        }

        public virtual string Move(int times)
        {
            if (times < 0) throw new ArgumentOutOfRangeException("Times must be a non-negative integer");
            checked
            {
                Position += Speed * times;
            }
            return $"Moving along {times} times";
        }

        public override string ToString()
        {
            return $"{base.ToString()} capacity: {_capacity} passengers: {NumPassengers} " +
                $"speed: {Speed} position: {Position}";
        }

    }
}
