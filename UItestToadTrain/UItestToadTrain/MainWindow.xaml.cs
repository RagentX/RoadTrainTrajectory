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
using RoadTrain.Classes;
namespace UItestToadTrain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 200, y = 300;
        RoadTrainModel roadTrainModel = new RoadTrainModel();
        Polygon truckBodyPolygon = new Polygon();

        public MainWindow()
        {
            InitializeComponent();
            truckBodyPolygon.Stroke = Brushes.Black;
            grid.Children.Add(truckBodyPolygon);
            RoadTrainDrawing();
        }

        private void RoadTrainMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                roadTrainModel.Truck.AngleRotation += Math.PI / 180;
            }
            RoadTrainDrawing();
        }

        private void RoadTrainDrawing()
        {
            (double X, double Y)[] truckCoordinates = roadTrainModel.Truck.Coordinates;
            truckBodyPolygon.Points = new PointCollection
            {
                new Point(x + truckCoordinates[0].X / 30, y - truckCoordinates[0].Y / 30),
                new Point(x + truckCoordinates[1].X / 30, y - truckCoordinates[1].Y / 30),
                new Point(x + truckCoordinates[2].X / 30, y - truckCoordinates[2].Y / 30),
                new Point(x + truckCoordinates[3].X / 30, y - truckCoordinates[3].Y / 30)
            };


        }
    }
}
