using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class Trailer : Body, ITrailer
    {
        private List<TrailerAxle>? _trailerAxles;
        private double _avgTrailerAxlesPosition;

        public Trailer(double width = 2550,
                       double lenght = 13600,
                       double angleRotation = 0,
                       double fiveWheelPosition = 1000,
                       List<TrailerAxle>? trailerAxles = default(List<TrailerAxle>))
        {
            _width = width;
            _lenght = lenght;
            AngleRotation = angleRotation;
            _fiveWheelPosition = fiveWheelPosition;
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
            double sumTrailerAxlesPosition = 0;
            foreach (TrailerAxle trailerAxle in _trailerAxles)
            {
                sumTrailerAxlesPosition += trailerAxle.AxlePosition;
            }
            _avgTrailerAxlesPosition = sumTrailerAxlesPosition / _trailerAxles.Count;
            //_trailerAxles = trailerAxles;
        }

        public List<TrailerAxle> TrailerAxles
        {
            get { return _trailerAxles; }
            set { _trailerAxles = value; }
        }

        public (double X, double Y)[] Coordinates
        {
            get
            {
                return new (double X, double Y)[]
                {
                    (_fiveWheelPosition * _cosAngleRotation + _width / 2 * _sinAngleRotation,
                    _fiveWheelPosition * _sinAngleRotation - _width / 2 * _cosAngleRotation),
                    (_fiveWheelPosition * _cosAngleRotation - _width / 2 * _sinAngleRotation,
                    _fiveWheelPosition * _sinAngleRotation + _width / 2 * _cosAngleRotation),
                    (-((_lenght - _fiveWheelPosition) * _cosAngleRotation) - _width / 2 * _sinAngleRotation,
                    -((_lenght - _fiveWheelPosition) * _sinAngleRotation) + _width / 2 * _cosAngleRotation),
                    (-((_lenght - _fiveWheelPosition) * _cosAngleRotation) + _width / 2 * _sinAngleRotation,
                    -((_lenght - _fiveWheelPosition) * _sinAngleRotation) - _width / 2 * _cosAngleRotation)

                };
            }
        }

        public double AvgTrailerAxlesPosition
        {
            get { return _avgTrailerAxlesPosition; }
        }
    }
}
