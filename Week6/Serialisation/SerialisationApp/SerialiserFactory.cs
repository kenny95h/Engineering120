using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    public abstract class SerialiserFactory
    {
        public abstract ISerialise GetSerialiser(int serialiser);
    }
}
