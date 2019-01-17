﻿using SiphoningStrike;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketDumper
{
    class Program
    {
        [Flags]
        public enum ENetPacketFlags
        {
            Reliable = (1 << 7),
            Unsequenced = (1 << 6),
            ReliableUnsequenced = Reliable | Unsequenced,
            None = 0,
        }
        public class ENetPacket
        {
            public float Time { get; set; }
            public byte[] Bytes { get; set; }
            public byte Channel { get; set; }
            public ENetPacketFlags Flags { get; set; }
        }

        public class SerializedPacket
        {
            public int RawID { get; set; }
            public BasePacket Packet { get; set; }
            public float Time { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public ChannelID? ChannelID { get; set; }
            public byte RawChannel { get; set; }
        }

        public class BadPacket
        {
            public int RawID { get; set; }
            public byte[] Raw { get; set; }
            public byte RawChannel { get; set; }
            public string Error { get; set; }
        }

        public static void SerializeToFile(object what, string fileName)
        {
            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.TypeNameHandling = TypeNameHandling.Auto;
                serializer.Serialize(file, what);
            }
        }

        static void Main(string[] args)
        {
            var fileName = "test.rlp.json";
            var extraA = "";
            if (args.Length > 0)
                fileName = args[0];
            if (args.Length > 1)
                extraA = args[1];

            Console.Error.WriteLine("Reading file...");
            var json = File.ReadAllText(fileName);
            Console.Error.WriteLine("Parsing json...");
            var rawPackets = JsonConvert.DeserializeObject<List<ENetPacket>>(json);
            var serializedPackets = new List<SerializedPacket>();
            var hardBadPackets = new List<BadPacket>();
            var softBadPackets = new List<BadPacket>();
            Console.Error.WriteLine("Processing raw packets...");
            var goodIDs = new List<int>();
            foreach (var rPacket in rawPackets)
            {

                if (rPacket.Channel < 8)
                {
                    int rawID = rPacket.Bytes[0];
                    if (rawID == 254)
                    {
                        rawID = rPacket.Bytes[5] | rPacket.Bytes[6] << 8;
                    }
                    try
                    {
                        var packet = BasePacket.Create(rPacket.Bytes, (ChannelID)rPacket.Channel);
                        serializedPackets.Add(new SerializedPacket
                        {
                            RawID = rawID,
                            Packet = packet,
                            Time = rPacket.Time,
                            ChannelID = rPacket.Channel < 8 ? (ChannelID)rPacket.Channel : (ChannelID?)null,
                            RawChannel = rPacket.Channel,
                        });
                        if (rPacket.Channel > 0 && rPacket.Channel < 5 && rawID != 0 && packet.BytesLeft.Length > 0)
                        {
                            softBadPackets.Add(new BadPacket()
                            {
                                RawID = rawID,
                                Raw = rPacket.Bytes,
                                RawChannel = rPacket.Channel,
                                Error = $"Extra bytes: {Convert.ToBase64String(packet.BytesLeft)}",
                            });
                        }
                        else if(rPacket.Channel > 0 && rPacket.Channel < 5)
                        {
                            goodIDs.Add(rawID);
                        }

                    }
                    catch (Exception exception)
                    {
                        if(rawID != 0x4A /*&& rawID != 0xAB*/ && rawID != 0x4B)
                            hardBadPackets.Add(new BadPacket()
                            {
                                RawID = rawID,
                                Raw = rPacket.Bytes,
                                RawChannel = rPacket.Channel,
                                Error = exception.ToString(),
                            });
                    }
                }
            }

            if(extraA == "info")
            {
                var result = new Dictionary<string, List<int>>();
                result.Add("soft", softBadPackets.Select(x => x.RawID).Distinct().ToList());
                result.Add("hard", hardBadPackets.Select(x => x.RawID).ToList());
                result.Add("good", goodIDs.Distinct().ToList());
                Console.WriteLine(JsonConvert.SerializeObject(result));
                return;
            }


            Console.WriteLine($"Processed! Good: {serializedPackets.Count}, Soft Error: {softBadPackets.Count}, Hard Error: {hardBadPackets.Count}");
            Console.WriteLine($"Soft bad IDs:{string.Join(",", softBadPackets.Select(x => x.RawID.ToString()).Distinct())}");
            Console.WriteLine($"Hard bad IDs:{string.Join(",", hardBadPackets.Select(x => x.RawID.ToString()).Distinct())}");
            Console.WriteLine($"Good IDs:{string.Join(",", goodIDs.Select(x => x.ToString()).Distinct())}");

            if (extraA == "dry")
                return;

            Console.WriteLine("Writing hard bad to file .hardbad.json");
            SerializeToFile(hardBadPackets, fileName.Replace(".rlp.json", ".rlp.hardbad.json"));

            Console.WriteLine("Writing soft bad to file .softbad.json");
            SerializeToFile(softBadPackets, fileName.Replace(".rlp.json", ".rlp.softbad.json"));

            if(extraA != "bad")
            {
                Console.WriteLine("Writing serialized to .rlp.serialized.json...");
                SerializeToFile(serializedPackets, fileName.Replace(".rlp.json", ".rlp.serialized.json")); 
            }

            Console.WriteLine("Done!");
            return;
        }
    }
}