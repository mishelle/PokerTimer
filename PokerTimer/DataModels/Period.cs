using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTimer.DataModels
{
    public abstract class Period
    {
        public string Label;
        public int DurationMinutes;
        public int DurationSeconds;
    }

    public class Round : Period
    {
        public double SmallBlind;
        public double BigBlind;
    }

    public class Break : Period
    {

    }
}
