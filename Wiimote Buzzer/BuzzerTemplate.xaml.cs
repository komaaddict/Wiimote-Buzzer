﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

namespace Wiimote_Buzzer
{
    /// <summary>
    /// Interaction logic for BuzzerTemplate.xaml
    /// </summary>
    public partial class BuzzerTemplate : UserControl, INotifyPropertyChanged
    {
        private int _Points = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public BuzzerTemplate()
        {
            InitializeComponent();
        }

        public int Points
        {
            get { return _Points; }
            set
            {
                _Points = value;
                OnPropertyChanged("Points");
            }
        }

        private void GroupName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GroupName.Visibility = Visibility.Hidden;
            GroupNameEditor.Visibility = Visibility.Visible;
            e.Handled = true;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GroupNameEditor.Visibility = Visibility.Hidden;
            GroupName.Visibility = Visibility.Visible;

        }

        protected void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler Handler = PropertyChanged;
            if (Handler != null)
            {
                Handler(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        private void MinusClick(object sender, RoutedEventArgs e)
        {
            Points = Math.Max(0, Points - 1);
        }
        private void PlusClick(object sender, RoutedEventArgs e)
        {
            Points++;
        }
    }

    public class BuzzerColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Color Color = (Color)values[0];
            int Number = System.Convert.ToInt32(values[1]);

            float Alpha = 1f;

            switch(Number)
            {
                case 0:
                    Alpha = 0.2f;
                    break;
                case 1:
                    Alpha = 0.6f;
                    break;
                default:
                    Alpha = 0.4f;
                    break;
            }

            Color.ScA = Alpha;

            return Color;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
