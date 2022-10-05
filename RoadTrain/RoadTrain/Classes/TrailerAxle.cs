using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class TrailerAxle : Axle, ITrailerAxle
    {
        public TrailerAxle(double width = 2200,
                           double angleRotation = 0,
                           double axlePosition = 13600 - 2600)
        {
            _width = width;
            AngleRotation = angleRotation;
            _axlePosition = axlePosition;
        }


        public (double X, double Y)[] Coordinates
        {
            get
            {
                return new (double X, double Y)[] { };
            }
        }
    }
}
