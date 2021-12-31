using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrackControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    [DefaultEvent(nameof(ValueChanged))]
    public partial class TrackControl : UserControl
    {
        private double _min;
        
        private double _max;
        
        private int _val;
        
        private int _delta;
        
        private Brush _textboxBackground;

        private string _title;
        
        public event EventHandler<ValueChangeEventArg> ValueChanged;
        
        [Category("Data"), Description("Minimum Value")]
        public double Min
        {
            get { return _min;}
            set
            {
                _min = value;
                lblMin.Content = _min;
                sldValue.Minimum = _min;
            }
        }
        [Category("Data"), Description("Maximum Value")]
        public double Max
        {
            get { return _max;}
            set
            {
                _max = value;
                lblMax.Content = _max;
                sldValue.Maximum = _max;
            }
        }
        [Category("Data"), Description("Value of the Slider")]
        public int Val
        {
            get { return _val;}
            set
            {
                _val = value;
                sldValue.Value = _val;
                lblCurrent.Content = _val;
                lblValue.Content = _val;
            }
        }
        [Category("Data"), Description("Steps")]
        public int Delta
        {
            get { return _delta;}
            set
            {
                _delta = value;
                sldValue.TickFrequency = _delta;
            }
        }
        [Category("Data"), Description("Background Color of the Slider Box")]
        public Brush TextboxBackground
        {
            get { return _textboxBackground;}
            set
            {
                _textboxBackground = value;
                lblValue.Background = _textboxBackground;
            }
        }
        [Category("Data"), Description("Title of the Slider")]
        public string Title
        {
            get { return _title;}
            set
            {
                _title = value;
                gbTrack.Header = _title;
            }
        }
        
        public TrackControl()
        {
            InitializeComponent();
        }

        private void SldValue_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Val = (int) e.NewValue;
            ValueChanged?.Invoke(this, new ValueChangeEventArg() {newValue = Val, oldValue = (int) e.OldValue});
        }
    }
}