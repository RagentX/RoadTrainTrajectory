using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class Trailer : Body, ITrailer
    {
        private List<TrailerAxle> _trailerAxles;
        public Trailer()
        {
            _width = 2550;
            _lenght = 13600;
            _angleRotation = 0;
            _trailerAxles = new List<TrailerAxle>(){
            new TrailerAxle(13600 - 1600),
            new TrailerAxle(13600 - 2600),
            new TrailerAxle(13600 - 3600)
            };

        }
        public Trailer(double width,
                       double lenght,
                       double angleRotation,
                       List<TrailerAxle> trailerAxles)
        {
            _width = width;
            _lenght = lenght;
            _angleRotation = angleRotation;
            _trailerAxles = trailerAxles;
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
