using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace software_lab10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = 0;
            try
            {
                n = Convert.ToInt32(FigureCount.Text);
            }
            catch (Exception)
            {
                this.Title = "Только целое число!";
            }
            GenerateShapes(n);
        }

        private void GenerateShapes(int n)
        {
            Random rnd = new Random();

            MainCanvas.Children.Clear();

            for (int i = 0; i < n; i++)
            {
                Shape currentShape;
                int shapeType = rnd.Next(2);
                if (shapeType == 0)
                {
                    currentShape = new Ellipse();
                }
                else
                {
                    currentShape = new Rectangle();
                }

                int shapeStyle = rnd.Next(4) + 1;
                String styleName = "Style" + shapeStyle.ToString();
                Style currentStyle = (Style)this.FindResource(styleName);
                currentShape.Style = currentStyle;

                currentShape.Width = rnd.Next(10, 150);
                currentShape.Height = rnd.Next(10, 150);

                MainCanvas.Children.Add(currentShape);
                Canvas.SetLeft(currentShape, rnd.Next(20, 620));
                Canvas.SetTop(currentShape, rnd.Next(20, 250));
            }
        }

    }
}
