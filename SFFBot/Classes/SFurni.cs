using Sulakore.Habbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFFBot.Classes
{
    public class SFurni
    {
        public int UniqueId { get; set; }
        public HPoint Location { get; set; }
        public int DistanceFromUs { get; set; }
        public bool Selected { get; set; }

        public int TypeId { get; set; }
        public string Name { get; set; }
        public bool IsPoisoned { get; set; }

        public SFurni() { }
        public SFurni(int furniId, string name, bool isPoisoned)
        {
            TypeId = furniId;
            Name = name;
            IsPoisoned = isPoisoned;
        }
        public SFurni(int uniqueId, int typeId, HPoint currLoc, bool selected)
        {
            UniqueId = uniqueId;
            TypeId = typeId;
            Location = currLoc;
            Selected = selected;
            IsPoisoned = false;
        }

        public override string ToString() => $"[{TypeId}] {Name}";
    }
}
