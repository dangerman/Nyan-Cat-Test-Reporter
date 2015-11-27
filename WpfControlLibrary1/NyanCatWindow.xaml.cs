using System;
using System.ComponentModel;
using System.Windows;

namespace NyanCatDisplay
{
    /// <summary>
    /// Interaction logic for NyanCatWindow.xaml
    /// </summary>
    public partial class NyanCatWindow : Window, INotifyPropertyChanged
    {
        private int _passedCount;
        private int _failedCount;
        private int _otherCount;
        private int _maxDistance;
        private int _flyingSpeed;

        public NyanCatWindow(int flyingSpeed)
        {
            _flyingSpeed = flyingSpeed;
            PassedCount = 0;
            FailedCount = 0;
            OtherCount = 0;
            _maxDistance = Convert.ToInt32(SystemParameters.PrimaryScreenWidth);
            MakeWindowDraggable();

            InitializeComponent();
            OnPropertyChanged(string.Empty);
        }

        private void MakeWindowDraggable()
        {
            MouseLeftButtonDown += delegate { DragMove();};
        }

        public int PassedCount
        {
            get { return _passedCount; }
            set
            {
                _passedCount = value;
                OnPropertyChanged(string.Empty);
            }
        }
        public int FailedCount
        {
            get { return _failedCount; }
            set
            {
                _failedCount = value;
                OnPropertyChanged(string.Empty);
            }
        }
        public int OtherCount
        {
            get { return _otherCount; }
            set
            {
                _otherCount = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public int Distance
        {
            get
            {
                var totalRuns = PassedCount + FailedCount + OtherCount;
                var distance = totalRuns * _flyingSpeed;
                return (distance < _maxDistance) ? distance : _maxDistance;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(property));
        }
    }
}
