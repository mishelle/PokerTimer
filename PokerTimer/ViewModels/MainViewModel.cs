
using System.Collections.ObjectModel;

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
            set { SetProperty(ref _current, value); }
        }
        public PeriodViewModel NextPeriod
        {
            get { return _next; }
            set { SetProperty(ref _next, value); }
        }
        public string TimeLeft
        {
            get { return _timeLeft; }
            set { SetProperty(ref _timeLeft, value); }
        }
        public double PercentTimePassed
        {
            get { return _percentTimePassed; }
            set { SetProperty(ref _percentTimePassed, value); }
        }
        public ObservableCollection<PieSliceViewModel> TimePortions = new ObservableCollection<PieSliceViewModel>
                { new PieSliceViewModel(), new PieSliceViewModel() };
        private double _percentTimePassed;

        public bool IsPaused
        {
            get { return _isPaused; }
            set
            {
                SetProperty(ref _isPaused, value);
                NotifyPropertyChanged("IsWarningNotPaused");
            }
        }

        public bool IsWarning
        {
            get { return _isWarning; }
            set
            {
                SetProperty(ref _isWarning, value);
                NotifyPropertyChanged("IsWarningNotPaused");
            }
        }

        public bool IsWarningNotPaused
        {
            get
            {
                return _isWarning && !_isPaused;
            }
        }
    }
}

