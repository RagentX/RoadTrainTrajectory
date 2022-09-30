using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class TrailerAxle : Axle, ITrailerAxle
    {
        public TrailerAxle(double width = 2200,
                           double angleRotation = 0,
                           double axelPosition = 13600 - 2600)
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
