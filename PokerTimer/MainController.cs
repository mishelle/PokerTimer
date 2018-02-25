using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerTimer.DataModels;
using PokerTimer.ViewModels;
using Windows.UI.Xaml;

namespace PokerTimer
{
    public class MainController
    {
        //given a tournament, it will construct the viewmodels
        //must also react to events?

        private DispatcherTimer timer = new DispatcherTimer();
        private readonly MainViewModel main;
        private readonly Tournament _tournament;

        private int minutesLeft;
        private int secondsLeft;
        private int _roundIndex;
        private double _secondsInPeriod;

        public MainController(Tournament tournament)
        {
            timer.Tick += TimerTick;
            timer.Interval = new TimeSpan(00, 0, 1);
            _tournament = tournament;
            main = new MainViewModel();
        }

        public MainViewModel GetMain()
        {
            SetPeriod(0);

            //main.IsPaused = true;
            timer.Start();
        
            return main;
        }

        public void ResetTournament()
        {
            SetPeriod(0);
        }

        public void ResetPeriod()
        {
            var period = _tournament.Periods[_roundIndex];
            ResetTimeLeft(period);
        }

        public void AdvancePeriod()
        {
            SetPeriod(_roundIndex + 1);
        }

        internal void TogglePause()
        {
            main.IsPaused = !main.IsPaused;
        }

        private void SetPeriod(int roundIndex)
        {
            _roundIndex = Math.Min( roundIndex, _tournament.Periods.Count - 1);
            var nextRoundIndex = Math.Min(roundIndex + 1, _tournament.Periods.Count - 1);

            var period = _tournament.Periods[_roundIndex];
            main.CurrentPeriod = GetPeriod(period);
            main.NextPeriod = GetPeriod(_tournament.Periods[nextRoundIndex]);
            _secondsInPeriod = period.DurationMinutes * 60.0 + period.DurationSeconds;

            ResetTimeLeft(period);
        }

        private void ResetTimeLeft(Period period)
        {
            minutesLeft = period.DurationMinutes;
            secondsLeft = period.DurationSeconds;
            SetTimeLeft(minutesLeft, secondsLeft);
        }

        private void SetTimeLeft(int minutes, int seconds)
        {
            var amountLeft = minutes * 60.0 + seconds;
            main.PercentTimePassed = (_secondsInPeriod - amountLeft) / _secondsInPeriod;
            main.TimeLeft = FormatTime(minutes, seconds);

            main.TimePortions = null;
            main.TimePortions = new ObservableCollection<PieSliceViewModel>{
                new PieSliceViewModel { Amount = _secondsInPeriod - amountLeft },
                new PieSliceViewModel { Amount = amountLeft }
            };
        }

        private PeriodViewModel GetPeriod(Period period)
        {
            var vm = new PeriodViewModel();
            
            if (period is Break)
            {
                vm.IsBreak = true;
                vm.Label = "Break";
            }
            else
            {
                vm.IsBreak = false;
                vm.Label = period.Label;
                vm.SmallBlind = FormatMoney(((Round)period).SmallBlind);
                vm.LargeBlind = FormatMoney(((Round)period).BigBlind);
            }
            return vm;
        }

        private void TimerTick(object sender, object e)
        {
            if (!main.IsPaused)
            {
                if (secondsLeft > 0)
                {
                    SetTimeLeft(minutesLeft, --secondsLeft);
                }
                else if (minutesLeft > 0)
                {
                    secondsLeft = 59;
                    SetTimeLeft(--minutesLeft, secondsLeft);
                }
                else if (_roundIndex == _tournament.Periods.Count)
                {
                    //game is over
                    timer.Stop();
                    return;
                }
                else
                {
                    SetPeriod(++_roundIndex);
                }

                main.IsWarning = minutesLeft == 0 && secondsLeft <= 10;
            }
        }

        private string FormatMoney(double amt) {
            return string.Format("${0:0.00}", amt);
        }
        private string FormatTime(int minutes, int seconds)
        {
            return string.Format("{0}:{1:00}", minutes, seconds);
        }
    }
}
