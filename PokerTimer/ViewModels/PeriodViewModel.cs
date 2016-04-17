using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerTimer.DataModels;

namespace PokerTimer.ViewModels
{
    public class PeriodViewModel : Base.BaseViewModel
    {
        private string _label;
        private string _smallBlind;
        private string _largeBlind;
        private bool _isBreak;
        
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                NotifyPropertyChanged("Label");
            }
        }
        
        public string SmallBlind
        {
            get
            {
                return _smallBlind;
            }
            set
            {
                _smallBlind = value;
                NotifyPropertyChanged("SmallBlind");
            }
        }
        public string LargeBlind
        {
            get
            {
                return _largeBlind;
            }
            set
            {
                _largeBlind = value;
                NotifyPropertyChanged("LargeBlind");
            }
        }

        public bool IsBreak
        {
            get
            {
                return _isBreak;
            }
            set
            {
                _isBreak = value;
                NotifyPropertyChanged("IsBreak");
            }
        }
    }
}
