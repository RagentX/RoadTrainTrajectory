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

        public SteeringAxle()
        {
            _width = 1800;
            _angleRotation = 0;
            _axelPosition = 1440;
            _rightRotation = 0;
            _leftRotation = 0;
            _wheelRotation = 0;
            _ackermanAngle = 1;
            _leverLength = 150;
        }
        public SteeringAxle(double axelPosition)
        {
            _width = 1800;
            _angleRotation = 0;
            _axelPosition = axelPosition;
            _rightRotation = 0;
            _leftRotation = 0;
            _wheelRotation = 0;
            _ackermanAngle = 1;
            _leverLength = 150;
        }

        public SteeringAxle(double width,
                            double angleRotation,
                            double axelPosition,
                            double rightRotation, 
                            double leftRotation,
                            double wheelRotation,
                            double ackermanAngle,
                            double leverLength)
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
