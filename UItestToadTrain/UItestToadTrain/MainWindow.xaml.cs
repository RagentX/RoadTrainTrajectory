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
using TrajectoryBuilder;
namespace UItestToadTrain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 400;
        int y = 200;
        TrajectoryBuilder.Map map = new Map();
        RoadTrainModel roadTrainModel = new RoadTrainModel();
        Polygon truckBodyPolygon = new Polygon();
        Polygon trailerBodyPolygon = new Polygon();

        public MainWindow()
        {
            InitializeComponent();
            truckBodyPolygon.Stroke = Brushes.Black;
            grid.Children.Add(truckBodyPolygon);
            trailerBodyPolygon.Stroke = Brushes.Red;
            grid.Children.Add(trailerBodyPolygon);
            RoadTrainDrawing();
        }

        private void RoadTrainMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                map.RoadTrainModelOnTheMap.RidingForward();
            }
            if (e.Key == Key.A)
            {
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation += Math.PI / 180;
            }
            if (e.Key == Key.D)
            {
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation -= Math.PI / 180;
            }
            if (e.Key == Key.R)
            {
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation = 0;
                map.RoadTrainModelOnTheMap.X = 0;
                map.RoadTrainModelOnTheMap.Y = 0;
            }
            if (e.Key == Key.E)
            {
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation = 0;
            }
            RoadTrainDrawing();
        }

        private void RoadTrainDrawing()
        {
            (double X, double Y)[] truckBodyCoordinates =  map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.Coordinates;
            truckBodyPolygon.Points = new PointCollection
            {
                new Point(x + map.RoadTrainModelOnTheMap.X / 30 + truckBodyCoordinates[0].X / 30, y - map.RoadTrainModelOnTheMap.Y / 30 + truckBodyCoordinates[0].Y / 30),
                new Point(x + map.RoadTrainModelOnTheMap.X / 30 + truckBodyCoordinates[1].X / 30, y - map.RoadTrainModelOnTheMap.Y / 30 + truckBodyCoordinates[1].Y / 30),
                new Point(x + map.RoadTrainModelOnTheMap.X / 30 + truckBodyCoordinates[2].X / 30, y - map.RoadTrainModelOnTheMap.Y / 30 + truckBodyCoordinates[2].Y / 30),
                new Point(x + map.RoadTrainModelOnTheMap.X / 30 + truckBodyCoordinates[3].X / 30, y - map.RoadTrainModelOnTheMap.Y / 30 + truckBodyCoordinates[3].Y / 30)
            };
            (double X, double Y) fiveWheelCoordinates = map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.FiveWheelCoordinate;
            (double X, double Y)[] trailerBodyCoordinates = map.RoadTrainModelOnTheMap.RoadTrainModel.Trailer.Coordinates;
            trailerBodyPolygon.Points = new PointCollection
            {
                new Point(x + map.RoadTrainModelOnTheMap.X / 30 + (fiveWheelCoordinates.X + trailerBodyCoordinates[0].X) / 30, y - map.RoadTrainModelOnTheMap.Y / 30 + (fiveWheelCoordinates.Y + trailerBodyCoordinates[0].Y) / 30),
                new Point(x + map.RoadTrainModelOnTheMap.X / 30 + (fiveWheelCoordinates.X + trailerBodyCoordinates[1].X) / 30, y - map.RoadTrainModelOnTheMap.Y / 30 + (fiveWheelCoordinates.Y + trailerBodyCoordinates[1].Y) / 30),
                new Point(x + map.RoadTrainModelOnTheMap.X / 30 + (fiveWheelCoordinates.X + trailerBodyCoordinates[2].X) / 30, y - map.RoadTrainModelOnTheMap.Y / 30 + (fiveWheelCoordinates.Y + trailerBodyCoordinates[2].Y) / 30),
                new Point(x + map.RoadTrainModelOnTheMap.X / 30 + (fiveWheelCoordinates.X + trailerBodyCoordinates[3].X) / 30, y - map.RoadTrainModelOnTheMap.Y / 30 + (fiveWheelCoordinates.Y + trailerBodyCoordinates[3].Y) / 30)
            };
        }
    }
}
