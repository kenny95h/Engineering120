using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    internal class SerialiserBinary : ISerialise
    {
        public void SerialiseToFile<T>(string filePath, T item)
        {
            // Stream or FileStream created and opened
            FileStream filestream = File.Create(filePath);
            // Create a BinaryFormatter object and use it to serialise the item to file
            BinaryFormatter writer = new BinaryFormatter();
            // Serialse
            writer.Serialize(filestream, item);
            filestream.Close();
        }

        public T DeserialiseFromFile<T>(string filePath)
        {
            // Create a stream object for reading
            Stream fileStream = File.OpenRead(filePath);
            BinaryFormatter reader = new BinaryFormatter();
            // Cast deserialised object to T
            var deserialisedItem = (T)reader.Deserialize(fileStream);
            fileStream.Close();
            return deserialisedItem;
        }
    }
}
