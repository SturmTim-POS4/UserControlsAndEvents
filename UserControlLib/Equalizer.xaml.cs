using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrackControl;

namespace Equalizer
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    [DefaultEvent(nameof(ValueChanged))]
    public partial class Equalizer : UserControl
    {

        private int _val;
        
        private Brush _barForeground;
        
        private Brush _barBackground;
        
        public event EventHandler<ValueChangeEventArg> ValueChanged;

        [Category("Data"), Description("Value of the Bar")]
        public int Val
        {
            get { return _val; }
            set
            {
                _val = value;
                pbOne.Value = value % 10;
                lblOne.Content = value % 10;
                
                pbTen.Value = value/10 % 10;
                lblTen.Content = value/10 % 10;
                
                pbHundret.Value = value/100 % 10;
                lblHundret.Content = value/100 % 10;
            }
        }
        [Category("Data"), Description("Foreground Color of the Bar")]
        public Brush BarForeground
        {
            get { return _barForeground; }
            set
            {
                _barForeground = value;
                pbHundret.Foreground = _barForeground;
                pbTen.Foreground = _barForeground;
                pbOne.Foreground = _barForeground;
            }
        }
        [Category("Data"), Description("Background Color of the Bar")]
        public Brush BarBackground
        {
            get { return _barBackground; }
            set
            {
                _barBackground = value;
                pbHundret.Background = _barBackground;
                pbTen.Background = _barBackground;
                pbOne.Background = _barBackground; 
            }
        }
        
        public Equalizer()
        {
            InitializeComponent();
        }

        private void Bar_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var oldValue = Val;
            var bar = sender as ProgressBar;
            double i = bar.Maximum - (e.GetPosition(bar).Y / bar.ActualHeight * 10);
            if (bar.Name.Equals(pbOne.Name))
            {
                pbOne.Value = i;
            }
            else if(bar.Name.Equals(pbTen.Name))
            {
                pbTen.Value = i;
            }
            else
            {
                pbHundret.Value = i;
            }
            Val = (int)pbHundret.Value * 100 + (int) pbTen.Value * 10 + (int) pbOne.Value;
            ValueChanged?.Invoke(this, new ValueChangeEventArg() {newValue = Val,oldValue = oldValue});
        }
    }
}