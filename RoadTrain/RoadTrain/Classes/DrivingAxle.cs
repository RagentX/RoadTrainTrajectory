using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class DrivingAxle : Axle, IDrivingAxle
    {
        public DrivingAxle(double width = 2200,
                           double angleRotation = 0,
                           double axelPosition = 1440 + 3600)
        {
            _width = width;
            _angleRotation = angleRotation;
            _axelPosition = axelPosition;
        }

        public Point[] Coordinates()
        {
            return new Point[2];
        }
    }
}
