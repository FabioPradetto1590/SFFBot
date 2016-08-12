using Sulakore.Habbo;
using Sulakore.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFFBot.Classes
{
    public class SHabboWalk
    {
        public int Index { get; }
        public HPoint Location { get; }
        public HPoint MovingTo { get; set; }
        public bool isOurHabbo { get; set; }

        public SHabboWalk(int index, HPoint location, HPoint movingTo)
        {
            Index = index;
            Location = location;
            MovingTo = movingTo;
        }

        public SHabboWalk(HMessage packet)
        {
            var walk = Parse(packet)[0];
            Index = walk.Index;
            Location = walk.Location;
            MovingTo = walk.MovingTo;
            isOurHabbo = walk.isOurHabbo;
        }

        public static List<SHabboWalk> Parse(HMessage packet)
        {
            var walks = new List<SHabboWalk>();

            int forr = packet.ReadInteger();
            
            for(int i = 0; i < forr; i++)
            {
                int Index = packet.ReadInteger();

                HPoint Location = new HPoint(packet.ReadInteger(), packet.ReadInteger());
                packet.ReadString();
                packet.ReadInteger();
                packet.ReadInteger();

                string movingData = packet.ReadString();

                if (movingData.StartsWith("/flatctrl "))
                    movingData = movingData.Substring(12);
                
                HPoint MovingTo = null;
                if (movingData.Contains("mv "))
                {
                    var MT = movingData.Substring(3).Split(',');
                    MovingTo = new HPoint(int.Parse(MT[0]), int.Parse(MT[1]));
                }
                walks.Add(new SHabboWalk(Index, Location, MovingTo));
            }
            return walks;
        }
    }
}
