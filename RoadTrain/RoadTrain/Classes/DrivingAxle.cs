using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class DrivingAxle : Axle, IDrivingAxle
    {
        public DrivingAxle()
        {
            _width = 2200;
            _angleRotation = 0;
            _axelPosition = 1440 + 3600;
        }
        public DrivingAxle(double axelPosition)
        {
            _width = 2200;
            _angleRotation = 0;
            _axelPosition = axelPosition;
        }

        public DrivingAxle(double width,
                           double angleRotation,
                           double axelPosition)
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
