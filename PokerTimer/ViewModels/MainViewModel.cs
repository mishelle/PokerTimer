using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PokerTimer.DataModels;

namespace PokerTimer.ViewModels
{
    public class MainViewModel : Base.BaseViewModel
    {
        private bool _isPaused = true;
        private string _timeLeft;
        private PeriodViewModel _current;
        private PeriodViewModel _next;
        private bool _isWarning;

        public PeriodViewModel CurrentPeriod 
        { 
            get { return _current; } 
            set{
                _current = value;
                NotifyPropertyChanged("CurrentPeriod");
            }
        }
        public PeriodViewModel NextPeriod
        {
            get { return _next; }
            set
            {
                _next = value;
                NotifyPropertyChanged("NextPeriod");
            }
        }
        public string TimeLeft
        {
            get { return _timeLeft; }
            set
            {
                _timeLeft = value;
                NotifyPropertyChanged("TimeLeft");
            }
        }

        public bool IsPaused
        {
            get
            {
                return _isPaused;
            }
            set
            {
                _isPaused = value;
                NotifyPropertyChanged("IsPaused");
                NotifyPropertyChanged("IsWarningNotPaused");
            }
        }

        public bool IsWarning
        {
            get
            {
                return _isWarning;
            }
            set
            {
                _isWarning = value;
                NotifyPropertyChanged("IsWarning");
                NotifyPropertyChanged("IsWarningNotPaused");
            }
        }

        public bool IsWarningNotPaused
        {
            get
            {
                return _isWarning && !_isPaused;
            }
            set
            {

            }
        }
    }
}

