using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTimer.ViewModels
{
    public class PieSliceViewModel : Base.BaseViewModel
    {
        private double _value;

        public double Amount
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
    }
}
