using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFFBot
{
    public static class HeaderManager
    {
        public static ushort OutPlayerWalk { get; set; }
        public static ushort InPlayerWalk { get; set; }
        public static ushort InDropFurniture { get; set; }
        public static ushort InMoveFurniture { get; set; }
        public static ushort InEntitiesLoad { get; set; }
        public static ushort InShowNotification { get; set; }
    }
}
