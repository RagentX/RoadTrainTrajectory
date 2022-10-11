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
                
                //Расчет расстояния от точки до борта тягача
                double fromFrontToPointTruckFlank = calculateDistance(pointFrontTruck, (point.X, point.Y));
                double fromBackToPointTruckFlank = calculateDistance(pointBackTruck, (point.X, point.Y));

                double distanceToPointTruckFlank =
                    calculateHeightOfTriangle(
                        sideA: _roadTrainModelOnTheMap.RoadTrainModel.Truck.Lenght,
                        sideB: fromFrontToPointTruckFlank,
                        sideC: fromBackToPointTruckFlank) -
                    _roadTrainModelOnTheMap.RoadTrainModel.Truck.Width / 2;

                //Расчет расстояния от точки до передней или задней части тягача
                double fromRightSideToPointTruckFrontBack = calculateDistance(pointRightSideTruck, (point.X, point.Y));
                double fromLeftSideToPointTruckFrontBack = calculateDistance(pointLeftSideTruck, (point.X, point.Y));

                double distanceToPointTruckFrontBack =
                    calculateHeightOfTriangle(
                        sideA: _roadTrainModelOnTheMap.RoadTrainModel.Truck.Width,
                        sideB: fromRightSideToPointTruckFrontBack,
                        sideC: fromLeftSideToPointTruckFrontBack) -
                    _roadTrainModelOnTheMap.RoadTrainModel.Truck.Lenght / 2;

                //Определяем где находится точка относительно тягача, спереди/сзади или сбоку
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

                //Расчет расстояния от точки до борта прицепа
                double fromFrontToPointTrailerFlank = calculateDistance(pointFrontTrailer, (point.X, point.Y));
                double fromBackToPointTrailerFlank = calculateDistance(pointBackTrailer, (point.X, point.Y));

                double distanceToPointTrailerFlank = 
                    calculateHeightOfTriangle(
                        sideA: _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Lenght, 
                        sideB: fromFrontToPointTrailerFlank, 
                        sideC: fromBackToPointTrailerFlank) - 
                    _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Width / 2;

                //Расчет расстояния от точки до передней или задней части тягача
                double fromRightSideToPointTrailerFrontBack = calculateDistance(pointRightSideTrailer, (point.X, point.Y));
                double fromLeftSideToPointTrailerFrontBack = calculateDistance(pointLeftSideTrailer, (point.X, point.Y));

                double distanceToPointTrailerFrontBack =
                    calculateHeightOfTriangle(
                        sideA: _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Width,
                        sideB: fromRightSideToPointTrailerFrontBack,
                        sideC: fromLeftSideToPointTrailerFrontBack) -
                    _roadTrainModelOnTheMap.RoadTrainModel.Trailer.Lenght / 2;


                //Определяем где находится точка относительно прицепа, спереди/сзади или сбоку
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

                //Определяем к какой части автопоезда ближе точка
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

        private double calculateHeightOfTriangle(double sideA, double sideB, double sideC) 
        {
            double triangleHalfPerimeter = (sideA + sideB + sideC) / 2;
            double triangleArea = Math.Sqrt(
                triangleHalfPerimeter *
                (triangleHalfPerimeter - sideA) *
                (triangleHalfPerimeter - sideB) *
                (triangleHalfPerimeter - sideC));

            return 2 * triangleArea / sideA;
        }

        private double calculateDistance((double X, double Y) pointA, (double X, double Y) pointB) 
        {
            return Math.Sqrt((pointA.X - pointB.X) * (pointA.X - pointB.X) + (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y));
        }
    }
}
