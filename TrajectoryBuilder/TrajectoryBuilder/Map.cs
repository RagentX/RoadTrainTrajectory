using TrajectoryBuilder.ObjectsOnTheMap;
using RoadTrain.Classes;
using System.Drawing;

namespace TrajectoryBuilder
{
    public class Map
    {
        private List<LidarPoint> _lidarPoints;
        private RoadTrainModelOnTheMap _roadTrainModelOnTheMap;
        private double _ratio;

        public Map(double ratio = 30)
        {
            _lidarPoints = new List<LidarPoint>
            {
                new LidarPoint(1000, -2000),
                new LidarPoint(5000, -2000)
            };
            _roadTrainModelOnTheMap = new RoadTrainModelOnTheMap();
            _ratio = ratio;
        }
        public double Ratio
        {
            get
            {
                return _ratio;
            }
            set
            {
                _ratio = value;
            }
        }
        public RoadTrainModelOnTheMap RoadTrainModelOnTheMap
        {
            get
            {
                return _roadTrainModelOnTheMap;
            }
            set
            {
                _roadTrainModelOnTheMap = value;
            }
        }

        public List<LidarPoint> LidarPoints 
        {
            get
            {
                List<LidarPoint> points = new List<LidarPoint>();
                for (int i = 0; i < _lidarPoints.Count; i++)
                {
                    points.Add(new LidarPoint(_lidarPoints[i].X / _ratio, _lidarPoints[i].Y / _ratio));
                }
                return points;
            }
            set
            {
                _lidarPoints = value;
            }
        }
        public RoadTrainModelCoordinates RoadTrainModelCoordinates
        {
            get
            {

                (double X, double Y)[] truckCoordinates = _roadTrainModelOnTheMap.RoadTrainModel.Truck.Coordinates;
                (double X, double Y)[] trailerCoordinates = _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Coordinates;
                (double X, double Y) fiveWheelCoordinates = _roadTrainModelOnTheMap.RoadTrainModel.Truck.FiveWheelCoordinate;
                (double X, double Y) steeringAxleCoordinates = _roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxleCoordinate;
                /*
                (double X, double Y)[] calculatedTruckCoordinates = new (double X, double Y)[truckCoordinates.Length];
                (double X, double Y)[] calculatedTrailerCoordinates = new (double X, double Y)[trailerCoordinates.Length];
                
                for (int i = 0; i < truckCoordinates.Length; i++)
                {
                    calculatedTruckCoordinates[i] = (_roadTrainModelOnTheMap.X / _ratio + truckCoordinates[i].X / _ratio, _roadTrainModelOnTheMap.Y / _ratio + truckCoordinates[i].Y / _ratio);
                    calculatedTrailerCoordinates[i] = ((_roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[i].X) / _ratio, (_roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[i].Y) / _ratio);
                }
                */
                return new RoadTrainModelCoordinates
                    (
                    new (double X, double Y)[] 
                    {
                        ((_roadTrainModelOnTheMap.X + truckCoordinates[0].X) / _ratio, (-_roadTrainModelOnTheMap.Y + truckCoordinates[0].Y) / _ratio),
                        ((_roadTrainModelOnTheMap.X + truckCoordinates[1].X) / _ratio, (-_roadTrainModelOnTheMap.Y + truckCoordinates[1].Y) / _ratio),
                        ((_roadTrainModelOnTheMap.X + truckCoordinates[2].X) / _ratio, (-_roadTrainModelOnTheMap.Y + truckCoordinates[2].Y) / _ratio),
                        ((_roadTrainModelOnTheMap.X + truckCoordinates[3].X) / _ratio, (-_roadTrainModelOnTheMap.Y + truckCoordinates[3].Y) / _ratio)
                    },
                    new (double X, double Y)[]
                    {
                        ((_roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[0].X) / _ratio, (-_roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[0].Y) / _ratio),
                        ((_roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[1].X) / _ratio, (-_roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[1].Y) / _ratio),
                        ((_roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[2].X) / _ratio, (-_roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[2].Y) / _ratio),
                        ((_roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[3].X) / _ratio, (-_roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[3].Y) / _ratio)
                    },
                    new (double X, double Y)[] 
                    { 
                        ((_roadTrainModelOnTheMap.X + steeringAxleCoordinates.X + 800 * Math.Cos(_roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + _roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)) / _ratio,
                        (-_roadTrainModelOnTheMap.Y + steeringAxleCoordinates.Y + 800 * Math.Sin(_roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + _roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)) / _ratio),
                        ((_roadTrainModelOnTheMap.X + steeringAxleCoordinates.X - 800 * Math.Cos(_roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + _roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)) / _ratio,
                        (-_roadTrainModelOnTheMap.Y + steeringAxleCoordinates.Y - 800 * Math.Sin(_roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + _roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)) / _ratio)
                    }
                    );
            }
        }
        public RoadTrainModelCoordinates RoadTrainModelCoordinatesNoRatio
        {
            get
            {

                (double X, double Y)[] truckCoordinates = _roadTrainModelOnTheMap.RoadTrainModel.Truck.Coordinates;
                (double X, double Y)[] trailerCoordinates = _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Coordinates;
                (double X, double Y) fiveWheelCoordinates = _roadTrainModelOnTheMap.RoadTrainModel.Truck.FiveWheelCoordinate;
                (double X, double Y) steeringAxleCoordinates = _roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxleCoordinate;
                return new RoadTrainModelCoordinates
                    (
                    new (double X, double Y)[]
                    {
                        ((_roadTrainModelOnTheMap.X + truckCoordinates[0].X), (-_roadTrainModelOnTheMap.Y + truckCoordinates[0].Y)),
                        ((_roadTrainModelOnTheMap.X + truckCoordinates[1].X), (-_roadTrainModelOnTheMap.Y + truckCoordinates[1].Y)),
                        ((_roadTrainModelOnTheMap.X + truckCoordinates[2].X), (-_roadTrainModelOnTheMap.Y + truckCoordinates[2].Y)),
                        ((_roadTrainModelOnTheMap.X + truckCoordinates[3].X), (-_roadTrainModelOnTheMap.Y + truckCoordinates[3].Y))
                    },
                    new (double X, double Y)[]
                    {
                        ((_roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[0].X), (-_roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[0].Y)),
                        ((_roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[1].X), (-_roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[1].Y)),
                        ((_roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[2].X), (-_roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[2].Y)),
                        ((_roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[3].X), (-_roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[3].Y))
                    },
                    new (double X, double Y)[]
                    {
                        ((_roadTrainModelOnTheMap.X + steeringAxleCoordinates.X + 800 * Math.Cos(_roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + _roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)),
                        (-_roadTrainModelOnTheMap.Y + steeringAxleCoordinates.Y + 800 * Math.Sin(_roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + _roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation))),
                        ((_roadTrainModelOnTheMap.X + steeringAxleCoordinates.X - 800 * Math.Cos(_roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + _roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)),
                        (-_roadTrainModelOnTheMap.Y + steeringAxleCoordinates.Y - 800 * Math.Sin(_roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + _roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)))
                    }
                    );
            }
        }
        public void AddPoint(double x, double y)
        {
            _lidarPoints.Add(new LidarPoint(x, y));
        }

        public void RemovePoint(LidarPoint point)
        {
            _lidarPoints.Remove(point);
        }
        public double SearchNearestPoint()
        {
            RoadTrainModelCoordinates roadTrainModelCoordinates = RoadTrainModelCoordinatesNoRatio;
            (double X, double Y)[] truckCoordinates = roadTrainModelCoordinates.TruckCoordinates;
            (double X, double Y)[] trailerCoordinates = roadTrainModelCoordinates.TrailerCoordinates;
            double minLenghtMain = double.MaxValue;
            (double X, double Y) fiveWheelCoordinates = _roadTrainModelOnTheMap.RoadTrainModel.Truck.FiveWheelCoordinate;
            foreach (LidarPoint point in _lidarPoints)
            {
                //Расчет расстояния до точки по отношению к тягачу
                (double X, double Y) pointFrontTruck = ((truckCoordinates[0].X + truckCoordinates[1].X) / 2, (truckCoordinates[0].Y + truckCoordinates[1].Y) / 2);
                (double X, double Y) pointBackTruck = ((truckCoordinates[2].X + truckCoordinates[3].X) / 2, (truckCoordinates[2].Y + truckCoordinates[3].Y) / 2);
                (double X, double Y) pointRightSideTruck = ((truckCoordinates[0].X + truckCoordinates[3].X) / 2, (truckCoordinates[0].Y + truckCoordinates[3].Y) / 2);
                (double X, double Y) pointLeftSideTruck = ((truckCoordinates[1].X + truckCoordinates[2].X) / 2, (truckCoordinates[1].Y + truckCoordinates[2].Y) / 2);

                double fromFrontToPointTruckFlank = Math.Sqrt((pointFrontTruck.X - point.X) * (pointFrontTruck.X - point.X) + (pointFrontTruck.Y - point.Y) * (pointFrontTruck.Y - point.Y));
                double fromBackToPointTruckFlank = Math.Sqrt((pointBackTruck.X - point.X) * (pointBackTruck.X - point.X) + (pointBackTruck.Y - point.Y) * (pointBackTruck.Y - point.Y));

                double triangleHalfPerimeterTruckFlank = (fromFrontToPointTruckFlank + fromBackToPointTruckFlank + _roadTrainModelOnTheMap.RoadTrainModel.Truck.Lenght) / 2;
                double triangleAreaTruckFlank = Math.Sqrt(
                    triangleHalfPerimeterTruckFlank * 
                    (triangleHalfPerimeterTruckFlank - fromFrontToPointTruckFlank) * 
                    (triangleHalfPerimeterTruckFlank - fromBackToPointTruckFlank) * 
                    (triangleHalfPerimeterTruckFlank - _roadTrainModelOnTheMap.RoadTrainModel.Truck.Lenght));
                    
                double distanceToPointTruckFlank = (2 * triangleAreaTruckFlank / _roadTrainModelOnTheMap.RoadTrainModel.Truck.Lenght) - _roadTrainModelOnTheMap.RoadTrainModel.Truck.Width / 2;

                double fromRightSideToPointTruckFrontBack = Math.Sqrt((pointRightSideTruck.X - point.X) * (pointRightSideTruck.X - point.X) + (pointRightSideTruck.Y - point.Y) * (pointRightSideTruck.Y - point.Y));
                double fromLeftSideToPointTruckFrontBack = Math.Sqrt((pointLeftSideTruck.X - point.X) * (pointLeftSideTruck.X - point.X) + (pointLeftSideTruck.Y - point.Y) * (pointLeftSideTruck.Y - point.Y));

                double triangleHalfPerimeterTruckFrontBack = (fromRightSideToPointTruckFrontBack + fromLeftSideToPointTruckFrontBack + _roadTrainModelOnTheMap.RoadTrainModel.Truck.Width) / 2;
                double triangleAreaTruckFrontBack = Math.Sqrt(
                    triangleHalfPerimeterTruckFrontBack * 
                    (triangleHalfPerimeterTruckFrontBack - fromRightSideToPointTruckFrontBack) * 
                    (triangleHalfPerimeterTruckFrontBack - fromLeftSideToPointTruckFrontBack) * 
                    (triangleHalfPerimeterTruckFrontBack - _roadTrainModelOnTheMap.RoadTrainModel.Truck.Width));
                    
                double distanceToPointTruckFrontBack = (2 * triangleAreaTruckFrontBack / _roadTrainModelOnTheMap.RoadTrainModel.Truck.Width) - _roadTrainModelOnTheMap.RoadTrainModel.Truck.Lenght / 2;

                double minLenghtTruck = double.MaxValue;

                if (distanceToPointTruckFlank > 0 && distanceToPointTruckFrontBack > 0)
                {
                    double minLenght = double.MaxValue;
                    foreach ((double X, double Y) truckCoordinate in truckCoordinates)
                    {
                        double lenght = Math.Sqrt((truckCoordinate.X - point.X) * (truckCoordinate.X - point.X) + (truckCoordinate.Y - point.Y) * (truckCoordinate.Y - point.Y));
                        if (minLenght > lenght)
                        {
                            minLenght = lenght;
                        }
                    }
                    minLenghtTruck = minLenght;
                }
                else
                {
                    if (distanceToPointTruckFlank < 0)
                    {
                        minLenghtTruck = distanceToPointTruckFrontBack;
                    }
                    else
                    {
                        minLenghtTruck = distanceToPointTruckFlank;
                    }
                }


                //Расчет расстояния до точки по отношению к прицепу
                (double X, double Y) pointFrontTrailer = ((trailerCoordinates[0].X + trailerCoordinates[1].X) / 2, (trailerCoordinates[0].Y + trailerCoordinates[1].Y) / 2);
                (double X, double Y) pointBackTrailer = ((trailerCoordinates[2].X + trailerCoordinates[3].X) / 2, (trailerCoordinates[2].Y + trailerCoordinates[3].Y) / 2);
                (double X, double Y) pointRightSideTrailer = ((trailerCoordinates[0].X + trailerCoordinates[3].X) / 2, (trailerCoordinates[0].Y + trailerCoordinates[3].Y) / 2);
                (double X, double Y) pointLeftSideTrailer = ((trailerCoordinates[1].X + trailerCoordinates[2].X) / 2, (trailerCoordinates[1].Y + trailerCoordinates[2].Y) / 2);

                double fromFrontToPointTrailerFlank = Math.Sqrt((pointFrontTrailer.X - point.X) * (pointFrontTrailer.X - point.X) + (pointFrontTrailer.Y - point.Y) * (pointFrontTrailer.Y - point.Y));
                double fromBackToPointTrailerFlank = Math.Sqrt((pointBackTrailer.X - point.X) * (pointBackTrailer.X - point.X) + (pointBackTrailer.Y - point.Y) * (pointBackTrailer.Y - point.Y));

                double triangleHalfPerimeterTrailerFlank = (fromFrontToPointTrailerFlank + fromBackToPointTrailerFlank + _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Lenght) / 2;
                double triangleAreaTrailerFlank = Math.Sqrt(
                    triangleHalfPerimeterTrailerFlank *
                    (triangleHalfPerimeterTrailerFlank - fromFrontToPointTrailerFlank) *
                    (triangleHalfPerimeterTrailerFlank - fromBackToPointTrailerFlank) *
                    (triangleHalfPerimeterTrailerFlank - _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Lenght));

                double distanceToPointTrailerFlank = (2 * triangleAreaTrailerFlank / _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Lenght) - _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Width / 2;



                double fromRightSideToPointTrailerFrontBack = Math.Sqrt((pointRightSideTrailer.X - point.X) * (pointRightSideTrailer.X - point.X) + (pointRightSideTrailer.Y - point.Y) * (pointRightSideTrailer.Y - point.Y));
                double fromLeftSideToPointTrailerFrontBack = Math.Sqrt((pointLeftSideTrailer.X - point.X) * (pointLeftSideTrailer.X - point.X) + (pointLeftSideTrailer.Y - point.Y) * (pointLeftSideTrailer.Y - point.Y));

                double triangleHalfPerimeterTrailerFrontBack = (fromRightSideToPointTrailerFrontBack + fromLeftSideToPointTrailerFrontBack + _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Width) / 2;
                double triangleAreaTrailerFrontBack = Math.Sqrt(
                    triangleHalfPerimeterTrailerFrontBack *
                    (triangleHalfPerimeterTrailerFrontBack - fromRightSideToPointTrailerFrontBack) *
                    (triangleHalfPerimeterTrailerFrontBack - fromLeftSideToPointTrailerFrontBack) *
                    (triangleHalfPerimeterTrailerFrontBack - _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Width));

                double distanceToPointTrailerFrontBack = (2 * triangleAreaTrailerFrontBack / _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Width) - _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Lenght / 2;

                double minLenghtTrailer = double.MaxValue;
                if (distanceToPointTrailerFlank > 0 && distanceToPointTrailerFrontBack > 0)
                {
                    double minLenght = double.MaxValue;
                    foreach ((double X, double Y) trailerCoordinate in trailerCoordinates)
                    {
                        double lenght = Math.Sqrt((trailerCoordinate.X - point.X) * (trailerCoordinate.X - point.X) + (trailerCoordinate.Y - point.Y) * (trailerCoordinate.Y - point.Y));
                        if (minLenght > lenght)
                        {
                            minLenght = lenght;
                        }
                    }
                    minLenghtTrailer = minLenght;
                }
                else
                {
                    if (distanceToPointTrailerFlank < 0)
                    {
                        minLenghtTrailer = distanceToPointTrailerFrontBack;
                    }
                    else
                    {
                        minLenghtTrailer = distanceToPointTrailerFlank;
                    }
                }
                if (minLenghtMain > minLenghtTrailer)
                {
                    minLenghtMain = minLenghtTrailer;
                }
                if (minLenghtMain > minLenghtTruck)
                {
                    minLenghtMain = minLenghtTruck;
                }
            }
            return minLenghtMain;
        }
    }
}
