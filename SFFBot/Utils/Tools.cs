using SFFBot.Classes;
using Sulakore.Habbo;
using Sulakore.Habbo.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFFBot.Utils
{
    public static class Tools
    {
        public static SFurni ToPoisonFurni(this string str)
        {
            string[] data = str.Split("] ".ToCharArray(), 2, StringSplitOptions.None);
            return new SFurni(int.Parse(data[0].Substring(1)), data[1], false);
        }
        public static bool IsSame(this HPoint loc1, HPoint loc2)
            => (loc1?.X == loc2?.X && loc1?.Y == loc2?.Y);
    }
}
