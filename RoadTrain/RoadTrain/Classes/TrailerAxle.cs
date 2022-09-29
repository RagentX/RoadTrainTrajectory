using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class TrailerAxle : Axle, ITrailerAxle
    {
        public TrailerAxle()
        {
            _width = 2200;
            _angleRotation = 0;
            _axelPosition = 13600 - 2600;
        }
        public TrailerAxle(double axelPosition)
        {
            _width = 2200;
            _angleRotation = 0;
            _axelPosition = axelPosition;
        }
        public TrailerAxle(double width,
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
