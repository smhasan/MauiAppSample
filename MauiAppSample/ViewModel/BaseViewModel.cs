using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppSample.ViewModel
{ 
    public partial class BaseViewModel : ObservableObject 
    {
        private DateTime _dateTime;
        private readonly Timer _timer;
        public DateTime DateTimeClock
        {
            get => _dateTime;
            set
            {
                if (_dateTime != value)
                {
                    _dateTime = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }
        public BaseViewModel()
        {
            this.DateTimeClock = DateTime.Now;

            // Update the DateTime property every second.
            _timer = new Timer(new TimerCallback((s) => this.DateTimeClock = DateTime.Now),
                               null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }
        ~BaseViewModel() =>
            _timer.Dispose();
    }
}