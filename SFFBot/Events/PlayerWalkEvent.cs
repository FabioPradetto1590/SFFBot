using Sulakore.Communication;
using Sulakore.Protocol;
using System;
using System.Threading.Tasks;

namespace SFFBot.Events
{
    public class PlayerWalkEvent : DataInterceptedEventArgs
    {
        public int Index { get; }
        public int X { get; }
        public int Y { get; }
        public string thestringthingyxd { get; }

        public PlayerWalkEvent(HMessage packet, int step, Func<Task> continuation)
            : base (packet, step, continuation)
        {
            Index = packet.ReadInteger();
            packet.ReadInteger();
            X = packet.ReadInteger();
            Y = packet.ReadInteger();
            packet.ReadString();
            packet.ReadInteger();
            packet.ReadInteger();
            thestringthingyxd = packet.ReadString();
        }
    }
}
