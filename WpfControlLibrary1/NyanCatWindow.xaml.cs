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

        public NyanCatWindow()
        {
            PassedCount = 0;
            FailedCount = 0;
            OtherCount = 0;
            _maxDistance = Convert.ToInt32(SystemParameters.VirtualScreenWidth);
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

        public Thickness DistanceTravelledMargin
        {
            get
            {
                var totalRuns = PassedCount + FailedCount + OtherCount;
                var distance = totalRuns * 200;
                return new Thickness(distance, 0, 0, 0);
            }
        }

        public Thickness RainbowMargin
        {
            get
            {
                var halfNyanCatWidth = (int)(NyanCat.ActualWidth/2);
                return new Thickness(0, 0, halfNyanCatWidth, 0);
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
