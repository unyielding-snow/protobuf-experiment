using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using ProtoBuf;
using Newtonsoft.Json;

namespace protobuff_parser
{
    internal class to_binary
    {
        static void Main()
        {
            // Read in JSON
            string json = File.ReadAllText(@"C:\Users\justi\OneDrive - Umich\Desktop\Projects\personal_learning\protobuff-parser\test.json");
            System.Diagnostics.Debug.WriteLine(json);

            // Deserialize JSON using protobuf

            // Serialize string stream (only)
            // ProtoSerialize<>(
        }

        //private static byte[] ProtoSerialize<T>(T record) where T : class
        //{
        //    using var stream = new MemoryStream();
        //    Serializer.Serialize(stream, record);
        //    return stream.ToArray();
        //}
    }
}
