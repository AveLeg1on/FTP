using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace FTP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer timer;


        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// высчитываеит периметр и площадь предварительно найдя стороны
        /// </summary>
        /// <param name="array">множество значения</param>
        /// <returns> Возвращает туже самую коллекцию</returns>
        public List<int> CalculatePAndS(List<int> array)
        {
            int i;
            int z;

            i = array[2] - array[0];
            z = array[3] - array[1];
            array.Add(Math.Abs((i * z) * 2));
            array.Add(Math.Abs(i * z));
            LB.Items.Add("X1: " + array[0] + " Y1: " + array[1] + " X2: " + array[2] + "Y2: " + array[3] + " Pirimetr=" + array[4] + " Square=" + array[5]);
            return array;

        }

        List<int> list = new List<int>();
        private void CreateANDCounted_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int.TryParse(X1txt.Text, out int tmp);
                list.Add(tmp);
                int.TryParse(Y1txt.Text, out tmp);
                list.Add(tmp);
                int.TryParse(X2txt.Text, out tmp);
                list.Add(tmp);
                int.TryParse(Y2txt.Text, out tmp);
                list.Add(tmp);

                CalculatePAndS(list);

                
                list.Clear();

            }
            catch
            {
                LB.Items.Add("Вы явно ввели неправильные значения".ToUpper());
                X1txt.Clear();
                X2txt.Clear();
                Y1txt.Clear();
                Y2txt.Clear();

            }
        }



        private void transformationToKiloButes_Click(object sender, RoutedEventArgs e)
        {
            if (uint.TryParse(BytesTo.Text, out uint a))
            {
                Answer.Content = Transformation(a);
            }
            else
            {
                MessageBox.Show("Вы не ввели данные или они не корректны");
            }

        }

        private void BytesTo_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Answer.Content = null;
        }
        /// <summary>
        /// Делит байты на 1024 составляющую 1 Киллобайт
        /// </summary>
        /// <param name="a" >количество байт</param>
        /// <returns name="txt">текстовая сторка</returns>
        public string Transformation(uint a)
        {
            string txt = $"{a / 1024}" + " KB";
            return txt ;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
           if(e.ChangedButton==MouseButton.Left) this.DragMove();    

        }
        private void ChangeWindowsState()
        {
            if (WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                Window_Edge.Visibility=Visibility.Collapsed;

            }
            else
            {
                if(WindowState == WindowState.Maximized) { this.WindowState = WindowState.Normal; Window_Edge.Visibility = Visibility.Visible; }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount==2) 
            {ChangeWindowsState();}
            

        }

        private void Deleter(object sender, RoutedEventArgs e)
        {
            LB.Items.Clear();   
            X1txt.Clear();  
            X2txt.Clear();
            Y1txt.Clear();  
            Y2txt.Clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         timer=new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Start();

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateTime d=DateTime.Now;
            DT.Content= d;
        }

        private void Help_Clik(object sender, RoutedEventArgs e)
        {
            FL.Content += " Разработал:Денисов Олег Андреевич ";
            MessageBox.Show("Задание: Даны координаты двух противоположных вершин прямоугольника: (x1, y1), (x2, \r\ny2). Стороны прямоугольника параллельны осям координат. Найти периметр и \r\nплощадь данного прямоугольника.\r\n• Дан размер файла в байтах. Используя операцию деления нацело, найти количество \r\nполных килобайтов, которые занимает данный файл  ");

        }
    }
}
