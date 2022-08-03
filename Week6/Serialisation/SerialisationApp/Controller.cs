using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    public enum serialiseMethods
    {
        XMLSERIAL, JSONSERIAL, BINARYSERIAL
    }
    public class Controller : SerialiserFactory
    {
        private static readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\");
        private string serialPath;
        public override ISerialise GetSerialiser(int serialiser)
        {
            serialiser--;
            switch (serialiser)
            {
                case (int)serialiseMethods.XMLSERIAL:
                    serialPath = "xml";
                    return new SerialiserXML();
                case (int)serialiseMethods.JSONSERIAL:
                    serialPath = "json";
                    return new SerialiserJSON();
                case (int)serialiseMethods.BINARYSERIAL:
                    serialPath = "bin";
                    return new SerialiserBinary();
                default:
                    throw new ArgumentException();
            }
        }

        public void Serialise<T>(T item, int serialMethod)
        {
            GetSerialiser(serialMethod).SerialiseToFile($"{_path}/SerialFile.{serialPath}", item);
        }

        public T Deserialise<T>(int serialMethod)
        {
            return GetSerialiser(serialMethod).DeserialiseFromFile<T>($"{_path}/SerialFile.{serialPath}");
        }
    }
}
