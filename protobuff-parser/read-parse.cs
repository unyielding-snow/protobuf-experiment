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
using System.Reflection.Emit;


namespace protobuff_parser
{ 
    internal class read_parse
    {
        static void Main()
        {
            Person john = new Person
            {
                Id = 123,
                Name = "John",
                Email = "joe@example.com",

                // Phone uses enum see defined specs
                Phones = { new Person.Types.PhoneNumber { Number = "555-4321", Type = Person.Types.PhoneType.Home } }
            };

            Person james = new Person { };

            // TESTING: Input & Output Streams 
            // CodedOutputStream = output, converts to byte[]
            using (var output = File.Create("john.dat"))
            {
                john.WriteTo(output);
            }

            using (var input = File.OpenRead("john.dat"))
            {
                james = Person.Parser.ParseFrom(input);
            }

            using (var output = File.Create("james.dat"))
            {
                james.WriteTo(output);
            }

            // TESTING: Setting variables
            Person justin = new Person { };
            justin.Id = 3;
            justin.Name = "Justin";
            justin.Email = "oops.gmail";


            // TESTING: Byte arrays
            byte[] bytes = justin.ToByteArray();
            //System.Diagnostics.Debug.WriteLine(bytes);
            using (var stream = File.Create("byte.txt"))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            Person copy = Person.Parser.ParseFrom(bytes);

            // TESTING: Arrays of Person (AddressBook)
            AddressBook book = new AddressBook
            {
                People =
                {
                    copy, 
                    justin,
                    james
                }
            };
            bytes = book.ToByteArray();
            AddressBook restored = AddressBook.Parser.ParseFrom(bytes);

            if(restored.People.Count == 3)
            {
                System.Diagnostics.Debug.WriteLine("correct number of people!");
            }

        }
    }
}

