using System;
using System.Collections.Generic;
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

namespace DialControlLibrary
{
    /// <summary>
    /// Regulator.xaml 的交互逻辑
    /// </summary>
    public partial class Regulator : UserControl
    {
        public Regulator()
        {
            InitializeComponent();
            DefaultSet();
        }
        public int MaxInput
        {
            get { return (int)GetValue(MaxInputProperty); }
            set { SetValue(MaxInputProperty, value); }
        }

        public static readonly DependencyProperty MaxInputProperty =
            DependencyProperty.Register
            ("MaxInput", typeof(int), typeof(Regulator),
                new PropertyMetadata(50));



        public int MinInput
        {
            get { return (int)GetValue(MinInputProperty); }
            set { SetValue(MinInputProperty, value); }
        }

        public static readonly DependencyProperty MinInputProperty =
            DependencyProperty.Register
            ("MinInput", typeof(int), typeof(Regulator),
                new PropertyMetadata(-20));



        public int NumOutput
        {
            get { return (int)GetValue(NumOutputProperty); }
            set { SetValue(NumOutputProperty, value); }
        }

        public static readonly DependencyProperty NumOutputProperty =
            DependencyProperty.Register
            ("NumOutput", typeof(int), typeof(Regulator),
                new PropertyMetadata(15));

        private void DefaultSet()
        {
            MaxInput = 50;
            MinInput = -20;
            NumOutput = 15;
        }
    }
}
