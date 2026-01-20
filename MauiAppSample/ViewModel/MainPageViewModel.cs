using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace MauiAppSample.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private const string _correctPin = "1234";

        private string? _enteredPin;

        public string? EnteredPin
        {
            get => _enteredPin;
            set => SetProperty(ref _enteredPin, value);
        }

        // Replace [ObservableProperty] field with a partial property for AOT compatibility
        private string? _pinDisplay = "Volume must be equal or less than wallet";
        public string? PinDisplay
        {
            get => _pinDisplay;
            set => SetProperty(ref _pinDisplay, value);
        }

        public ICommand? DigitCommand { get; }
        public ICommand? ClearCommand { get; }
        public ICommand? EnterCommand { get; }

        public MainPageViewModel()
        {
            DigitCommand = new RelayCommand<string>(OnDigitClicked);
            ClearCommand = new RelayCommand(OnClearClicked);
            EnterCommand = new RelayCommand(OnEnterClicked);
        }

        private void OnDigitClicked(string? digit)
        {
            EnteredPin += digit;
            // PinDisplay = new string('*', EnteredPin.Length); this is for hiding the pin
        }
        private void OnClearClicked()
        {
            EnteredPin = "";
            PinDisplay = "Enter Volume";
        }

        private void OnEnterClicked()
        {
            if (EnteredPin == _correctPin)
            {
                PinDisplay = "✅ Access Granted";
            }
            else
            {
                PinDisplay = "❌ Incorrect Volume";
                EnteredPin = "";
            }
        }
    }
}