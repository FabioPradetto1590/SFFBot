using SFFBot.Classes;
using Sulakore.Habbo;
using Sulakore.Habbo.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFFBot.Utils
{
    public static class Tools
    {
        public static SPoisonFurni ToPoisonFurni(this string str)
        {
            string[] data = str.Split(new[] {"] : " }, 2, StringSplitOptions.None);
            return new SPoisonFurni(int.Parse(data[0].Substring(1)), data[1], false);
        }
    }
}
