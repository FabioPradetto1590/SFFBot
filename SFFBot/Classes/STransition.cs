using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace SFFBot.Classes
{
    public static class STransition
    {
        public static void Run(int time, params TArgument[] transitions)
        {
            var a = new Transition(new TransitionType_Linear(time));

            foreach (var trans in transitions)
                a.add(trans.Target, trans.PropertyName, trans.DestinationValue);
            a.run();
        }

        public static void RunTransition(this Control ctrl, int time, string propertyName, object destinationValue)
        {
            var a = new Transition(new TransitionType_Linear(time));
            a.add(ctrl, propertyName, destinationValue);
            a.run();
        }

        public static void RunTransition(this List<Control> ctrls, int time, string prop, int destValue, bool plus)
        {
            var a = new Transition(new TransitionType_Linear(time));
            ctrls.ForEach(c => a.add(c, prop, plus ? c.Location.Y + destValue :
                                                     c.Location.Y - destValue));
            a.run();
        }
    }

    public class TArgument
    {
        public object Target { get; set; }
        public string PropertyName { get; set; }
        public object DestinationValue { get; set; }

        public TArgument(object target, string propertyName, object destinationValue)
        {
            Target = target;
            PropertyName = propertyName;
            DestinationValue = destinationValue;
        }
    }
}
