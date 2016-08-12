using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFFBot.Utils
{
    public class SStatus
    {
        public Color TextColor { get; set; }
        public int ScrollTime { get; set; }
        public string Message { get; set; }
        public bool IsShowed { get; set; }
        public int TypeID { get; set; }
        public int Times { get; set; }
        public int Time { get; set; }

        public SStatus(int typeID, int time, int scrollTime, string message, Color color)
        {
            TypeID = typeID;
            Time = time;
            ScrollTime = scrollTime;
            Message = message;
            TextColor = color;
            IsShowed = false;
            Times = 1;
        }
    }
}
