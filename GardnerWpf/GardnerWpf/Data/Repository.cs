using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace GardnerWpf
{
    public class Repository
    {
        internal static void ReadFile(string fileName, out ObservableCollection<Location> locations)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Location>));
            TextReader reader = new StreamReader(fileName);
            // Deserialize all the agents.
            locations = (ObservableCollection<Location>)serializer.Deserialize(reader);
            reader.Close();
        }

        internal static void SaveFile(string fileName, ObservableCollection<Location> locations)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Location>));
            TextWriter writer = new StreamWriter(fileName);
            // Serialize all the agents.
            serializer.Serialize(writer, locations);
            writer.Close();
        }
    }
}
