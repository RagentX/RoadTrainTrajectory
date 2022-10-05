using System.Drawing;
using RoadTrain.Classes;

namespace RoadTrain.Interfaces
{
    public interface ITruck: IBody
    {
        SteeringAxle SteeringAxle { get; set; }
        List<DrivingAxle> DrivingAxles { get; set; }
        double AvgDrivingAxlesPosition { get; }
        (double X, double Y)[] Coordinates { get;}
        (double X, double Y) SteeringAxleCoordinate { get; }
        (double X, double Y)[] DrivingAxlesCoordinates { get; }
        (double X, double Y) FiveWheelCoordinate{ get; }

    }
}
