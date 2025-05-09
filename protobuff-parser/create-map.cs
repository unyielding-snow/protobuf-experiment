using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using ProtoBuf;
using Newtonsoft.Json;
using Google.Protobuf.Map;
using System.Reflection.Emit;
using Google.Protobuf.Examples.AddressBook;
using System.Security.Cryptography;


namespace protobuff_parser
{
    internal class CreateMap
    {
        static void Main()
        {
            Map yay = new Map {
                Mapdata = {
                    "..........................................................\r\n",
                    "..........................................................\r\n",
                    "..........................................................\r\n",
                    "...........m..............................................\r\n",
                    "..........................................................\r\n",
                    "..........................................................\r\n",
                    "........m..........eeeeeeeeee.............................\r\n",
                    "...........m.....e..........ee............................\r\n",
                    ".......m......eeee..........eee...........................\r\n",
                    "..............e........s.c....ee..........................\r\n",
                    "................eeeee.........e...........................\r\n",
                    "....................eee..eee..e...........................\r\n",
                    "...........................eeee....q......................\r\n",
                    "..........................................................\r\n",
                    ".....................q....................................\r\n",
                    "..........................................................\r\n",
                    "..................................................d.......\r\n",
                    "..........................................................\r\n",
                    "..........................................................\r\n"
                },
                Rows = 1,
            };

       

            // TESTING: Input & Output Streams 
            // CodedOutputStream = output, converts to byte[]
            using (var output = File.Create("mapdata.dat"))
            {
                yay.WriteTo(output);
            }
            using (var input = File.OpenRead("mapdata.dat"))
            {
                yay = Map.Parser.ParseFrom(input);
            }

            using (var output = File.Create("map-read.dat"))
            {
                yay.WriteTo(output);
            }
        }
    }
}

