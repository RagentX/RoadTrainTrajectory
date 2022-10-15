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

        public SteeringAxle(SteeringAxle previousSteeringAxle)
        {
            _width = previousSteeringAxle._width;
            AngleRotation = previousSteeringAxle.AngleRotation;
            _axlePosition = previousSteeringAxle._axlePosition;
            _rightRotation = previousSteeringAxle._rightRotation;
            _leftRotation = previousSteeringAxle._leftRotation;
            WheelRotation = previousSteeringAxle._wheelRotation;
            _ackermanAngle = previousSteeringAxle._ackermanAngle;
            _leverLength = previousSteeringAxle._leverLength;
        }
        public SteeringAxle(double width = 1800,
                            double angleRotation = 0,
                            double axlePosition = 1440,
                            double rightRotation = 0, 
                            double leftRotation = 0,
                            double wheelRotation = 0,
                            double ackermanAngle = 1,
                            double leverLength = 150)
        {
            _width = width;
            AngleRotation = angleRotation;
            _axlePosition = axlePosition;
            _rightRotation = rightRotation;
            _leftRotation = leftRotation;
            WheelRotation = wheelRotation;
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
                if (value < Math.PI / 180 * 32 && -value < Math.PI / 180 * 32)
                    _wheelRotation = value;
                else
                    if (value < 0)
                        _wheelRotation = -Math.PI / 180 * 32;
                    else
                        _wheelRotation = Math.PI / 180 * 32;
            }
            get{ return _wheelRotation; }
        }
        
        public Point[] Coordinates()
        {
            return new Point[2];
        }
    }
}
