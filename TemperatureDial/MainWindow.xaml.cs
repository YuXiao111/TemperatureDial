using DialControlLibrary;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TemperatureDial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.SetBinding();
            DefaultSet();
        }

        //重写OnMouseLeftButtonDown()方法，调用DragMove()方法，使窗口能够响应式按住鼠标进行拖动的事件
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private int max;
        private int min;
        private int showValue;
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Max
        {
            get { return this.max; }
            set
            {
                this.max = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Max"));
            }
        }

        public int Min
        {
            get { return this.min; }
            set
            {
                this.min = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Min"));
            }
        }

        public int ShowValue
        {
            get { return this.showValue; }
            set
            {
                this.showValue = value;
                if (this.PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ShowValue"));
            }
        }

        private void DefaultSet()
        {
            Max = 50;
            Min = -20;
            ShowValue = 20;
        }

        private void SetBinding()
        {
            this.Reg.SetBinding(Regulator.MaxInputProperty, new Binding("Max") { Mode = BindingMode.TwoWay });
            this.Reg.SetBinding(Regulator.MinInputProperty, new Binding("Min") { Mode = BindingMode.TwoWay });
            this.Reg.SetBinding(Regulator.NumOutputProperty, new Binding("ShowValue") { Mode = BindingMode.TwoWay });
        }
    }
}