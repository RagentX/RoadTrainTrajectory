using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class DrivingAxle : Axle, IDrivingAxle
    {
        public DrivingAxle(double width = 2200,
                           double angleRotation = 0,
                           double axlePosition = 1440 + 3600)
        {
            _width = width;
            AngleRotation = angleRotation;
            _axlePosition = axlePosition;
        }

        public Point[] Coordinates()
        {
            return new Point[2];
        }
    }
}
