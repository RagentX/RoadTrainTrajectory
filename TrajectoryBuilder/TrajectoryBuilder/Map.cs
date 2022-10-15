using TrajectoryBuilder.ObjectsOnTheMap;
using RoadTrain.Classes;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

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
        public RoadTrainModelCoordinates RoadTrainModelCoordinates(RoadTrainModelOnTheMap roadTrainModelOnTheMap)
        {
            (double X, double Y)[] truckCoordinates = roadTrainModelOnTheMap.RoadTrainModel.Truck.Coordinates;
            (double X, double Y)[] trailerCoordinates = roadTrainModelOnTheMap.RoadTrainModel.Trailer.Coordinates;
            (double X, double Y) fiveWheelCoordinates = roadTrainModelOnTheMap.RoadTrainModel.Truck.FiveWheelCoordinate;
            (double X, double Y) steeringAxleCoordinates = roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxleCoordinate;
            return new RoadTrainModelCoordinates
                (
                new (double X, double Y)[] 
                {
                    ((roadTrainModelOnTheMap.X + truckCoordinates[0].X) / _ratio, (-roadTrainModelOnTheMap.Y + truckCoordinates[0].Y) / _ratio),
                    ((roadTrainModelOnTheMap.X + truckCoordinates[1].X) / _ratio, (-roadTrainModelOnTheMap.Y + truckCoordinates[1].Y) / _ratio),
                    ((roadTrainModelOnTheMap.X + truckCoordinates[2].X) / _ratio, (-roadTrainModelOnTheMap.Y + truckCoordinates[2].Y) / _ratio),
                    ((roadTrainModelOnTheMap.X + truckCoordinates[3].X) / _ratio, (-roadTrainModelOnTheMap.Y + truckCoordinates[3].Y) / _ratio)
                },
                new (double X, double Y)[]
                {
                    ((roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[0].X) / _ratio, (-roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[0].Y) / _ratio),
                    ((roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[1].X) / _ratio, (-roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[1].Y) / _ratio),
                    ((roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[2].X) / _ratio, (-roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[2].Y) / _ratio),
                    ((roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[3].X) / _ratio, (-roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[3].Y) / _ratio)
                },
                new (double X, double Y)[] 
                { 
                    ((roadTrainModelOnTheMap.X + steeringAxleCoordinates.X + 800 * Math.Cos(roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)) / _ratio,
                    (-roadTrainModelOnTheMap.Y + steeringAxleCoordinates.Y + 800 * Math.Sin(roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)) / _ratio),
                    ((roadTrainModelOnTheMap.X + steeringAxleCoordinates.X - 800 * Math.Cos(roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)) / _ratio,
                    (-roadTrainModelOnTheMap.Y + steeringAxleCoordinates.Y - 800 * Math.Sin(roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)) / _ratio)
                }
                );
        }
        public RoadTrainModelCoordinates RoadTrainModelCoordinatesNoRatio(RoadTrainModelOnTheMap roadTrainModelOnTheMap)
        {
            (double X, double Y)[] truckCoordinates = roadTrainModelOnTheMap.RoadTrainModel.Truck.Coordinates;
            (double X, double Y)[] trailerCoordinates = roadTrainModelOnTheMap.RoadTrainModel.Trailer.Coordinates;
            (double X, double Y) fiveWheelCoordinates = roadTrainModelOnTheMap.RoadTrainModel.Truck.FiveWheelCoordinate;
            (double X, double Y) steeringAxleCoordinates = roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxleCoordinate;
            return new RoadTrainModelCoordinates
                (
                new (double X, double Y)[]
                {
                    ((roadTrainModelOnTheMap.X + truckCoordinates[0].X), (-roadTrainModelOnTheMap.Y + truckCoordinates[0].Y)),
                    ((roadTrainModelOnTheMap.X + truckCoordinates[1].X), (-roadTrainModelOnTheMap.Y + truckCoordinates[1].Y)),
                    ((roadTrainModelOnTheMap.X + truckCoordinates[2].X), (-roadTrainModelOnTheMap.Y + truckCoordinates[2].Y)),
                    ((roadTrainModelOnTheMap.X + truckCoordinates[3].X), (-roadTrainModelOnTheMap.Y + truckCoordinates[3].Y))
                },
                new (double X, double Y)[]
                {
                    ((roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[0].X), (-roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[0].Y)),
                    ((roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[1].X), (-roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[1].Y)),
                    ((roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[2].X), (-roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[2].Y)),
                    ((roadTrainModelOnTheMap.X + fiveWheelCoordinates.X + trailerCoordinates[3].X), (-roadTrainModelOnTheMap.Y + fiveWheelCoordinates.Y + trailerCoordinates[3].Y))
                },
                new (double X, double Y)[]
                {
                    ((roadTrainModelOnTheMap.X + steeringAxleCoordinates.X + 800 * Math.Cos(roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)),
                    (-roadTrainModelOnTheMap.Y + steeringAxleCoordinates.Y + 800 * Math.Sin(roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation))),
                    ((roadTrainModelOnTheMap.X + steeringAxleCoordinates.X - 800 * Math.Cos(roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)),
                    (-roadTrainModelOnTheMap.Y + steeringAxleCoordinates.Y - 800 * Math.Sin(roadTrainModelOnTheMap.RoadTrainModel.Truck.AngleRotation + roadTrainModelOnTheMap.RoadTrainModel.Truck.SteeringAxle.WheelRotation)))
                }
                );
        }
        public void AddPoint(double x, double y)
        {
            _lidarPoints.Add(new LidarPoint(x, y));
        }

        public void RemovePoint(LidarPoint point)
        {
            _lidarPoints.Remove(point);
        }
        public double SearchNearestPoint(RoadTrainModelOnTheMap roadTrainModelOnTheMap)
        {
            RoadTrainModelCoordinates roadTrainModelCoordinates = RoadTrainModelCoordinatesNoRatio(roadTrainModelOnTheMap);
            (double X, double Y)[] truckCoordinates = roadTrainModelCoordinates.TruckCoordinates;
            (double X, double Y)[] trailerCoordinates = roadTrainModelCoordinates.TrailerCoordinates;
            double minLenghtMain = double.MaxValue;
            (double X, double Y) fiveWheelCoordinates = roadTrainModelOnTheMap.RoadTrainModel.Truck.FiveWheelCoordinate;
            
            foreach (LidarPoint point in _lidarPoints)
            {
                //Расчет расстояния до точки по отношению к тягачу
                (double X, double Y) pointFrontTruck = ((truckCoordinates[0].X + truckCoordinates[1].X) / 2, (truckCoordinates[0].Y + truckCoordinates[1].Y) / 2);
                (double X, double Y) pointBackTruck = ((truckCoordinates[2].X + truckCoordinates[3].X) / 2, (truckCoordinates[2].Y + truckCoordinates[3].Y) / 2);
                (double X, double Y) pointRightSideTruck = ((truckCoordinates[0].X + truckCoordinates[3].X) / 2, (truckCoordinates[0].Y + truckCoordinates[3].Y) / 2);
                (double X, double Y) pointLeftSideTruck = ((truckCoordinates[1].X + truckCoordinates[2].X) / 2, (truckCoordinates[1].Y + truckCoordinates[2].Y) / 2);
                
                //Расчет расстояния от точки до борта тягача
                double fromFrontToPointTruckFlank = CalculateDistance(pointFrontTruck, (point.X, point.Y));
                double fromBackToPointTruckFlank = CalculateDistance(pointBackTruck, (point.X, point.Y));

                double distanceToPointTruckFlank =
                    CalculateHeightOfTriangle(
                        sideA: roadTrainModelOnTheMap.RoadTrainModel.Truck.Lenght,
                        sideB: fromFrontToPointTruckFlank,
                        sideC: fromBackToPointTruckFlank) -
                    roadTrainModelOnTheMap.RoadTrainModel.Truck.Width / 2;

                //Расчет расстояния от точки до передней или задней части тягача
                double fromRightSideToPointTruckFrontBack = CalculateDistance(pointRightSideTruck, (point.X, point.Y));
                double fromLeftSideToPointTruckFrontBack = CalculateDistance(pointLeftSideTruck, (point.X, point.Y));

                double distanceToPointTruckFrontBack =
                    CalculateHeightOfTriangle(
                        sideA: roadTrainModelOnTheMap.RoadTrainModel.Truck.Width,
                        sideB: fromRightSideToPointTruckFrontBack,
                        sideC: fromLeftSideToPointTruckFrontBack) -
                    roadTrainModelOnTheMap.RoadTrainModel.Truck.Lenght / 2;

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
                double fromFrontToPointTrailerFlank = CalculateDistance(pointFrontTrailer, (point.X, point.Y));
                double fromBackToPointTrailerFlank = CalculateDistance(pointBackTrailer, (point.X, point.Y));

                double distanceToPointTrailerFlank = 
                    CalculateHeightOfTriangle(
                        sideA: roadTrainModelOnTheMap.RoadTrainModel.Trailer.Lenght, 
                        sideB: fromFrontToPointTrailerFlank, 
                        sideC: fromBackToPointTrailerFlank) - 
                    roadTrainModelOnTheMap.RoadTrainModel.Trailer.Width / 2;

                //Расчет расстояния от точки до передней или задней части тягача
                double fromRightSideToPointTrailerFrontBack = CalculateDistance(pointRightSideTrailer, (point.X, point.Y));
                double fromLeftSideToPointTrailerFrontBack = CalculateDistance(pointLeftSideTrailer, (point.X, point.Y));

                double distanceToPointTrailerFrontBack =
                    CalculateHeightOfTriangle(
                        sideA: roadTrainModelOnTheMap.RoadTrainModel.Trailer.Width,
                        sideB: fromRightSideToPointTrailerFrontBack,
                        sideC: fromLeftSideToPointTrailerFrontBack) -
                    roadTrainModelOnTheMap.RoadTrainModel.Trailer.Lenght / 2;


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

        //Вычисление высоты треугольника, проведенного от угла к стороне А (sideA)
        private double CalculateHeightOfTriangle(double sideA, double sideB, double sideC) 
        {
            double triangleHalfPerimeter = (sideA + sideB + sideC) / 2;
            double triangleArea = Math.Sqrt(
                triangleHalfPerimeter *
                (triangleHalfPerimeter - sideA) *
                (triangleHalfPerimeter - sideB) *
                (triangleHalfPerimeter - sideC));

            return 2 * triangleArea / sideA;
        }

        private double CalculateDistance((double X, double Y) pointA, (double X, double Y) pointB) 
        {
            return Math.Sqrt((pointA.X - pointB.X) * (pointA.X - pointB.X) + (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y));
        }


        public List<double> TrajectoryBuild(RoadTrainModelOnTheMap roadTrainModelOnTheMapFin)
        {
            List<double> уголПоворотаРуляНаКаждойИзСтадии = new List<double>();
            RoadTrainModelCoordinates StrartCoordinatesRoadTrainModelOnTheMapFin = RoadTrainModelCoordinatesNoRatio(roadTrainModelOnTheMapFin);
            RoadTrainModelCoordinates CoordinatesRoadTrainModelOnTheMap = RoadTrainModelCoordinatesNoRatio(roadTrainModelOnTheMapFin);
            double roadTrainLenght = roadTrainModelOnTheMapFin.RoadTrainModel.Trailer.Lenght - roadTrainModelOnTheMapFin.RoadTrainModel.Trailer.FiveWheelPosition +
                        roadTrainModelOnTheMapFin.RoadTrainModel.Truck.FiveWheelPosition;
            while
                (
                    CalculateHeightOfTriangle
                        (
                            roadTrainModelOnTheMapFin.RoadTrainModel.Trailer.Width,
                            CalculateDistance
                            (
                                ((CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[2].X + CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[3].X) / 2,
                                (CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[2].Y + CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[3].Y) / 2),
                                (StrartCoordinatesRoadTrainModelOnTheMapFin.TrailerCoordinates[2].X, StrartCoordinatesRoadTrainModelOnTheMapFin.TrailerCoordinates[2].Y)
                            ),
                            CalculateDistance
                            (
                                ((CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[2].X + CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[3].X) / 2,
                                (CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[2].Y + CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[3].Y) / 2),
                                (StrartCoordinatesRoadTrainModelOnTheMapFin.TrailerCoordinates[3].X, StrartCoordinatesRoadTrainModelOnTheMapFin.TrailerCoordinates[3].Y)
                            )
                        ) < roadTrainLenght
                )
            {
                roadTrainModelOnTheMapFin.RoadTrainModel.Truck.SteeringAxle.WheelRotation += 1;

                while
                (
                   CalculateHeightOfTriangle
                       (
                           roadTrainModelOnTheMapFin.RoadTrainModel.Trailer.Width,
                           CalculateDistance
                           (
                               ((CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[2].X + CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[3].X) / 2,
                               (CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[2].Y + CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[3].Y) / 2),
                               (StrartCoordinatesRoadTrainModelOnTheMapFin.TrailerCoordinates[2].X, StrartCoordinatesRoadTrainModelOnTheMapFin.TrailerCoordinates[2].Y)
                           ),
                           CalculateDistance
                           (
                               ((CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[2].X + CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[3].X) / 2,
                               (CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[2].Y + CoordinatesRoadTrainModelOnTheMap.TrailerCoordinates[3].Y) / 2),
                               (StrartCoordinatesRoadTrainModelOnTheMapFin.TrailerCoordinates[3].X, StrartCoordinatesRoadTrainModelOnTheMapFin.TrailerCoordinates[3].Y)
                           )
                       ) < roadTrainLenght
                )
                {

                }

                    roadTrainModelOnTheMapFin.RidingForward();

                уголПоворотаРуляНаКаждойИзСтадии.Add(roadTrainModelOnTheMapFin.RoadTrainModel.Truck.SteeringAxle.WheelRotation);
                CoordinatesRoadTrainModelOnTheMap = RoadTrainModelCoordinatesNoRatio(roadTrainModelOnTheMapFin);
            }

            return уголПоворотаРуляНаКаждойИзСтадии;
        }
    }
}
