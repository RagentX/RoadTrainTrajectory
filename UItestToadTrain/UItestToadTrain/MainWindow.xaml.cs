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
using RoadTrain.Interfaces;
using TrajectoryBuilder;
using TrajectoryBuilder.ObjectsOnTheMap;

namespace UItestToadTrain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 400;
        int y = 500;
        TrajectoryBuilder.Map map = new Map();
        RoadTrainModel roadTrainModel = new RoadTrainModel();
        Polygon truckBodyPolygon = new Polygon();
        Polygon trailerBodyPolygon = new Polygon();
        Line wheelLine = new Line();
        List<Ellipse> lidarPointEllipses = new List<Ellipse>();

        public MainWindow()
        {
            InitializeComponent();
            truckBodyPolygon.Stroke = Brushes.Black;
            grid.Children.Add(truckBodyPolygon);
            trailerBodyPolygon.Stroke = Brushes.Red;
            grid.Children.Add(trailerBodyPolygon);
            wheelLine.Stroke = Brushes.Blue;
            grid.Children.Add(wheelLine);
            DrawRoadTrain();
            DrawLidarPoints();
        }

        private void RoadTrainMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                map.RoadTrainModelOnTheMap.RidingForward();
            }
            if (e.Key == Key.S)
            {
                map.RoadTrainModelOnTheMap.RidingBackward();
            }
            if (e.Key == Key.A)
            {
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation -= Math.PI / 180;
            }
            if (e.Key == Key.D)
            {
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation += Math.PI / 180;
            }
            if (e.Key == Key.R)
            {
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation = 0;
                map.RoadTrainModelOnTheMap.X = 0;
                map.RoadTrainModelOnTheMap.Y = 0;
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation = 0;
                map.RoadTrainModelOnTheMap.RoadTrainModel.Trailer.AngleRotation = 0;
            }
            if (e.Key == Key.Q)
            {
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation = 0;
                map.RoadTrainModelOnTheMap.X = 0;
                map.RoadTrainModelOnTheMap.Y = 0;
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation = 0;
                map.RoadTrainModelOnTheMap.RoadTrainModel.Trailer.AngleRotation = Math.PI / 4;
            }
            if (e.Key == Key.E)
            {
                map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation = 0;
            }
            DrawRoadTrain();
            pointTextBox.Text = map.SearchNearestPoint().ToString();
        }

        private void DrawRoadTrain()
        {
            RoadTrainModelCoordinates roadTrainModelCoordinates = map.RoadTrainModelCoordinates;
            (double X, double Y)[] truckBodyCoordinates = map.RoadTrainModelOnTheMap.RoadTrainModel.Truck.Coordinates;
            truckBodyPolygon.Points = new PointCollection
            {
                new Point(x + map.RoadTrainModelCoordinates.TruckCoordinates[0].X, y + map.RoadTrainModelCoordinates.TruckCoordinates[0].Y),
                new Point(x + map.RoadTrainModelCoordinates.TruckCoordinates[1].X, y + map.RoadTrainModelCoordinates.TruckCoordinates[1].Y),
                new Point(x + map.RoadTrainModelCoordinates.TruckCoordinates[2].X, y + map.RoadTrainModelCoordinates.TruckCoordinates[2].Y),
                new Point(x + map.RoadTrainModelCoordinates.TruckCoordinates[3].X, y + map.RoadTrainModelCoordinates.TruckCoordinates[3].Y)
            };
            trailerBodyPolygon.Points = new PointCollection
            {
                new Point(x + map.RoadTrainModelCoordinates.TrailerCoordinates[0].X, y + map.RoadTrainModelCoordinates.TrailerCoordinates[0].Y),
                new Point(x + map.RoadTrainModelCoordinates.TrailerCoordinates[1].X, y + map.RoadTrainModelCoordinates.TrailerCoordinates[1].Y),
                new Point(x + map.RoadTrainModelCoordinates.TrailerCoordinates[2].X, y + map.RoadTrainModelCoordinates.TrailerCoordinates[2].Y),
                new Point(x + map.RoadTrainModelCoordinates.TrailerCoordinates[3].X, y + map.RoadTrainModelCoordinates.TrailerCoordinates[3].Y)
            };
            wheelLine.X1 = x + map.RoadTrainModelCoordinates.TruckSteeringAxleCoordinates[0].X;
            wheelLine.Y1 = y + map.RoadTrainModelCoordinates.TruckSteeringAxleCoordinates[0].Y;
            wheelLine.X2 = x + map.RoadTrainModelCoordinates.TruckSteeringAxleCoordinates[1].X;
            wheelLine.Y2 = y + map.RoadTrainModelCoordinates.TruckSteeringAxleCoordinates[1].Y;
        }
        private void DrawLidarPoints()
        {
            List<LidarPoint> lidarPoints = map.LidarPoints;
            foreach(LidarPoint lidarPoint in lidarPoints)
            {
                lidarPointEllipses.Add(new Ellipse());
                lidarPointEllipses[lidarPointEllipses.Count - 1].Stroke = Brushes.Green;
                lidarPointEllipses[lidarPointEllipses.Count - 1].HorizontalAlignment = HorizontalAlignment.Left;
                lidarPointEllipses[lidarPointEllipses.Count - 1].VerticalAlignment = VerticalAlignment.Top;
                lidarPointEllipses[lidarPointEllipses.Count - 1].Margin = new Thickness(x + lidarPoint.X - 5, y + lidarPoint.Y - 5, 0, 0);
                lidarPointEllipses[lidarPointEllipses.Count - 1].Width = 10;
                lidarPointEllipses[lidarPointEllipses.Count - 1].Height = 10;
                grid.Children.Add(lidarPointEllipses[lidarPointEllipses.Count - 1]);

            }
        }
    }
}
