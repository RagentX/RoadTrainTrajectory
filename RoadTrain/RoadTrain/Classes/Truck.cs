using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class Truck : Body, ITruck
    {      
        private SteeringAxle? _steeringAxle;
        private List<DrivingAxle>? _drivingAxles;
        private double _avgDrivingAxlesPosition;

        public Truck(double width = 2550,
                     double lenght = 1440 + 3600 + 1080,
                     double angleRotation = 0,
                     SteeringAxle? steeringAxle = default(SteeringAxle),
                     List<DrivingAxle>? drivingAxles = default(List<DrivingAxle>)
                     )
        {
            _width = width;
            _lenght = lenght;
            AngleRotation = angleRotation;
            if(steeringAxle == default(SteeringAxle))
            {
                _steeringAxle = new SteeringAxle(1800, angleRotation, 1440);
            }
            else
            {
                _steeringAxle = steeringAxle;
            }
            if(drivingAxles == default(List<DrivingAxle>))
            {
                _drivingAxles = new List<DrivingAxle>
                {
                    new DrivingAxle(2200, angleRotation, 1440 + 3600)
                };
            }
            else
            {
                _drivingAxles = drivingAxles;
            }
            double sumDrivingAxlesPosition = 0;
            foreach(DrivingAxle drivingAxle in _drivingAxles)
            {
                sumDrivingAxlesPosition += drivingAxle.AxlePosition;
            }
            _avgDrivingAxlesPosition = sumDrivingAxlesPosition / _drivingAxles.Count;
        }

        public SteeringAxle SteeringAxle
        {
            get { return _steeringAxle; }
            set { _steeringAxle = value; }
        }

        public List<DrivingAxle> DrivingAxles 
        {
            get => _drivingAxles;
            set => _drivingAxles = value;
        }

        public (double X, double Y)[] Coordinates
        {
            get
            {
                return new (double X, double Y)[] 
                {
                    (_avgDrivingAxlesPosition * _cosAngleRotation + _width / 2 * _sinAngleRotation,
                    _avgDrivingAxlesPosition * _sinAngleRotation - _width / 2 * _cosAngleRotation),
                    (_avgDrivingAxlesPosition * _cosAngleRotation - _width / 2 * _sinAngleRotation,
                    _avgDrivingAxlesPosition * _sinAngleRotation + _width / 2 * _cosAngleRotation),
                    (-((_lenght - _avgDrivingAxlesPosition) * _cosAngleRotation) - _width / 2 * _sinAngleRotation,
                    -((_lenght - _avgDrivingAxlesPosition) * _sinAngleRotation) + _width / 2 * _cosAngleRotation),
                    (-((_lenght - _avgDrivingAxlesPosition) * _cosAngleRotation) + _width / 2 * _sinAngleRotation,
                    -((_lenght - _avgDrivingAxlesPosition) * _sinAngleRotation) - _width / 2 * _cosAngleRotation)
                    
                };
            }
        }

        public (double X, double Y) SteeringAxleCoordinates
        {
            get
            {
                return ((_avgDrivingAxlesPosition - _steeringAxle.AxlePosition) * _cosAngleRotation,
                        (_avgDrivingAxlesPosition - _steeringAxle.AxlePosition) * _sinAngleRotation);
            }
        }

        public (double X, double Y)[] DrivingAxlesCoordinates
        {
            get
            {
                (double X, double Y)[] rezult = new (double X, double Y)[_drivingAxles.Count];
                for (int i = 0; i < _drivingAxles.Count; i++)
                {
                    rezult[i] = ((_drivingAxles[i].AxlePosition - _steeringAxle.AxlePosition) * _cosAngleRotation,
                        (_drivingAxles[i].AxlePosition - _steeringAxle.AxlePosition) * _sinAngleRotation);
                }
                return rezult;
            }
        }

        public double AvgDrivingAxlesPosition
        {
            get { return _avgDrivingAxlesPosition; }
        }
    }
}
