using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTimer.DataModels
{
    public class Tournament
    {
        //list of periods
        //each period has a duration, label, 
        //period may be a break, or a round with small and big
        public List<Period> Periods;

        public static Tournament LoadData()
        {
            var data = new Tournament();
            data.Periods = new List<Period>();

            data.Periods.Add(new Round() { Label="Round 1", DurationMinutes = 10, SmallBlind = .25, BigBlind = .5 });
            data.Periods.Add(new Round() { Label = "Round 2", DurationMinutes = 10, SmallBlind = .5, BigBlind = 1 });
            data.Periods.Add(new Round() { Label = "Round 3", DurationMinutes = 10, SmallBlind = .75, BigBlind = 1.5 });
            data.Periods.Add(new Round() { Label = "Round 4", DurationMinutes = 10, SmallBlind = 1, BigBlind = 2 });
            data.Periods.Add(new Round() { Label = "Round 5", DurationMinutes = 10, SmallBlind = 1.5, BigBlind = 3 });
            data.Periods.Add(new Round() { Label = "Round 6", DurationMinutes = 10, SmallBlind = 2, BigBlind = 4 });
            data.Periods.Add(new Round() { Label = "Round 7", DurationMinutes = 9, SmallBlind = 2.5, BigBlind = 5 });
            data.Periods.Add(new Round() { Label = "Round 8", DurationMinutes = 9, SmallBlind = 3, BigBlind = 6 });
            data.Periods.Add(new Round() { Label = "Round 9", DurationMinutes = 8, SmallBlind = 4.0, BigBlind = 8.0 });
            data.Periods.Add(new Round() { Label = "Round 10", DurationMinutes = 8, SmallBlind = 5, BigBlind = 10 });
            data.Periods.Add(new Round() { Label = "Round 11", DurationMinutes = 8, SmallBlind = 6, BigBlind = 12 });
            data.Periods.Add(new Round() { Label = "Round 12", DurationMinutes = 8, SmallBlind = 7, BigBlind = 14 });
            data.Periods.Add(new Round() { Label = "Round 13", DurationMinutes = 8, SmallBlind = 8, BigBlind = 16 });

            return data;
        }
    }
}
