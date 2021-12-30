using System;
using System.Collections.Generic;
using System.IO;
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

namespace UserControlsAndEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            tcGreen.ValueChanged += OnValueChanged;
            tcHigh.ValueChanged += OnValueChanged;
            tcBLue.ValueChanged += OnValueChanged;
            eqlOragne.ValueChanged += OnValueChanged;
            eqlRed.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(object? sender, ValueChangeEventArg e)
        {
            tcGreen.Val = e.newValue;
            tcHigh.Val = e.newValue;
            tcBLue.Val = e.newValue;
            eqlOragne.Val = e.newValue;
            eqlRed.Val = e.newValue;
            lblValue.Content = e.newValue;
            pbValueBar.Value = e.newValue;
            if (e.newValue > e.oldValue)
            {
                imageArrow.Source = new BitmapImage(new Uri(@"C:\Users\timst\Desktop\Schule\4. Klasse\POS1\UserControlsAndEvents\UserControlsAndEvents\arrow_up.png"));
                pbValueBar.Foreground = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                imageArrow.Source = new BitmapImage(new Uri(@"C:\Users\timst\Desktop\Schule\4. Klasse\POS1\UserControlsAndEvents\UserControlsAndEvents\arrow_down.png"));
                pbValueBar.Foreground = new SolidColorBrush(Colors.Red);
            }
            
        }
    }
}