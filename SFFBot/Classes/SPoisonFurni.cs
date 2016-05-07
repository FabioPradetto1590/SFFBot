using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFFBot.Classes
{
    public class SPoisonFurni
    {
        public int FurniId { get; set; }
        public string Name { get; set; }
        public bool IsPoisoned { get; set; }

        public SPoisonFurni(int furniId, string name, bool isPoisoned)
        {
            FurniId = furniId;
            Name = name;
            IsPoisoned = isPoisoned;
        }

        public override string ToString() => $"[{FurniId}] : {Name}";
    }
}
