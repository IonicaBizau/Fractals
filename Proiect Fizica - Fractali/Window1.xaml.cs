using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApplication1;
namespace Project
{
    public partial class BinaryTree : Window
    {
        private int II = 0;
        private int i = 0;

        public BinaryTree()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            i = 0;
            II = 1;
            CompositionTarget.Rendering += StartAnimation; // se porneste animatia
        }

        private void StartAnimation(object sender, EventArgs e) //aici este animatia
        {
            i += 1;
            if (i % 10 == 0)
            {
                DrawBinaryTree(canvas1, II,
                new Point(canvas1.Width / 2,
                0.99 * canvas1.Height),
                0.2 * canvas1.Width, -Math.PI / 2);
                II.ToString();
                II += 1;
                if (II > 10) // de cate ori sa adauge noi elemente
                {
                    CompositionTarget.Rendering -=
                    StartAnimation;
                }
            }
        }

        private double lengthScale = 0.75;
        private double deltaTheta = Math.PI / 5;

        private void DrawBinaryTree(Canvas canvas, int depth, Point pt, double length, double theta) // animatia cu arborele
        {
            double x1 = pt.X + length * Math.Cos(theta); //theta este unghiul
            double y1 = pt.Y + length * Math.Sin(theta);
            Line line = new Line();
            line.Stroke = Brushes.Blue;
            line.X1 = pt.X;
            line.Y1 = pt.Y;
            line.X2 = x1;
            line.Y2 = y1;
            canvas.Children.Add(line);

            if (depth > 1) //depth = de cate ori sa adauge ramuri noi
            {
                DrawBinaryTree(canvas, depth - 1,
                new Point(x1, y1),
                length * lengthScale, theta + deltaTheta);
                DrawBinaryTree(canvas, depth - 1,
                new Point(x1, y1),
                length * lengthScale, theta - deltaTheta);
            }
            else
                return;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Program realizat de Ionică Bizău.");
        }
    }
}
