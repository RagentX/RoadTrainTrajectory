using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class SteeringAxle: Axle, ISteeringAxle
    {
        private double _rightRotation;
        private double _leftRotation;
        private double _wheelRotation;
        private double _ackermanAngle;
        private double _leverLength;

        public SteeringAxle(double width = 1800,
                            double angleRotation = 0,
                            double axelPosition = 1440,
                            double rightRotation = 0, 
                            double leftRotation = 0,
                            double wheelRotation = 0,
                            double ackermanAngle = 1,
                            double leverLength = 150)
        {
            _width = width;
            _angleRotation = angleRotation;
            _axelPosition = axelPosition;
            _rightRotation = rightRotation;
            _leftRotation = leftRotation;
            _wheelRotation = wheelRotation;
            _ackermanAngle = ackermanAngle;
            _leverLength = leverLength;
        }
        
        public double LeverLength
        {
            get { return _leverLength; }
            set { _leverLength = value; }
        }

        public double AckermanAngle
        {
            get { return _ackermanAngle; }
            set { _ackermanAngle = value; }
        }
        
        public double WheelRotation
        {
            set
            {
                if (value > 0)
                {
                    _rightRotation = value;
                    _leftRotation = value * _ackermanAngle * -1;
                }
                else
                {
                    _leftRotation = value * -1;
                    _rightRotation = value * _ackermanAngle;
                }
                _wheelRotation = value;
            }
            get{ return _wheelRotation; }
        }
        
        public Point[] Coordinates()
        {
            return new Point[2];
        }
    }
}
