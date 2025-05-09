using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using ProtoBuf;
using Newtonsoft.Json;
using Google.Protobuf.Examples.AddressBook;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace protobuff_parser
{
    internal class to_binary
    {
        static void Main()
        {
            // Read in JSON
            //string json = File.ReadAllText(@"C:\Users\justi\OneDrive - Umich\Desktop\Projects\personal_learning\protobuff-parser\test.json");
            string json = "{\"name\":\"John\",\"id\":123,\"email\":\"john@example.com\"}";

            System.Diagnostics.Debug.WriteLine(json);

            // Deserialize JSON using protobuf
            // Requires a stream!
            PersonJson personObject = JsonConvert.DeserializeObject<PersonJson>(json);

            System.Diagnostics.Debug.WriteLine("TEST JSON READING");
            System.Diagnostics.Debug.WriteLine(personObject.name);


            var Person = new Person()
            {
                Name = personObject.name,
                Id = personObject.id,
                Email = personObject.email
            };

            System.Diagnostics.Debug.WriteLine($"Name: {Person.Name}, ID: {Person.Id}, Email: {Person.Email}");

            using (var output = File.Create("jsonPersonConvert.dat"))
            {
                Person.WriteTo(output);
            }

            //using (var output = File.Create("newOutput.dat"))
            //{
            //    newPerson.WriteTo(output);
            //}

            //using (var input = File.OpenRead("test.json"))
            //{
            //    james = Serializer.Deserialize<Person>(input);
            //}
        }

        //private static byte[] ProtoSerialize<T>(T record) where T : class
        //{
        //    using var stream = new MemoryStream();
        //    Serializer.Serialize(stream, record);
        //    return stream.ToArray();
        //}

        class PersonJson
        {
            public string name { get; set; }
            public int id { get; set; }
            public string email { get; set; }

        }
    }
}
