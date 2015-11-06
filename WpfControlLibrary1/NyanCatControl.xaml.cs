using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace NyanCatDisplay
{
    /// <summary>
    /// Interaction logic for NyanCatControl.xaml
    /// </summary>
    public partial class NyanCatControl : UserControl
    {
        public NyanCatControl()
        {
            InitializeComponent();
        }

        public int DistanceTravelled
        {
            get { return (int)GetValue(DistanceTravelledProperty); }
            set
            {
                SetValue(DistanceTravelledProperty, value);
                OnPropertyChanged(string.Empty);
            }
        }

        public static readonly DependencyProperty DistanceTravelledProperty =
            DependencyProperty.Register("DistanceTravelled", typeof(int), typeof(NyanCatControl),
                                        new PropertyMetadata(0));

        public Thickness RainbowMargin
        {
            get
            {
                var halfNyanCatWidth = (int)(NyanCat.ActualWidth / 2);
                return new Thickness(0, 0, halfNyanCatWidth, 0);
            }
        }

        public Thickness DistanceTravelledMargin
        {
            get
            {
                return new Thickness(DistanceTravelled, 0, 0, 0);
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
