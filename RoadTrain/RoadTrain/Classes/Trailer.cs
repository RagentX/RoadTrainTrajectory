using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class Trailer : Body, ITrailer
    {
        private List<TrailerAxle>? _trailerAxles;
        public Trailer(double width = 2550,
                       double lenght = 13600,
                       double angleRotation = 0,
                       List<TrailerAxle>? trailerAxles = default(List<TrailerAxle>))
        {
            _width = width;
            _lenght = lenght;
            _angleRotation = angleRotation;
            if (trailerAxles == default(List<TrailerAxle>))
            {
                _trailerAxles = new List<TrailerAxle>()
                {
                    new TrailerAxle(2200, angleRotation, 13600 - 1600),
                    new TrailerAxle(2200, angleRotation, 13600 - 2600),
                    new TrailerAxle(2200, angleRotation, 13600 - 3600)
                };
            }
            else
            {
                _trailerAxles = trailerAxles;
            }
            
            //_trailerAxles = trailerAxles;
        }

        public List<TrailerAxle> TrailerAxles
        {
            get { return _trailerAxles; }
            set { _trailerAxles = value; }
        }

        public Point[] Coordinates()
        {
            return new Point[2];
        } 
    }
}
