using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class Truck : Body, ITruck
    {      
        private SteeringAxle _steeringAxle;
        private List<DrivingAxle> _drivingAxles;

        public Truck()
        {
            _width = 2550;
            _lenght = 1440 + 3600 + 1080;
            _angleRotation = 0;
            _steeringAxle = new SteeringAxle(1440);
            _drivingAxles = new List<DrivingAxle>
            {
                new DrivingAxle(1440 + 3600)
            };
        }
        public Truck(double width,
                     double lenght,
                     double angleRotation,
                     SteeringAxle steeringAxle,
                     List<DrivingAxle> drivingAxles
                     )
        {
            _width = width;
            _lenght = lenght;
            _angleRotation = angleRotation;
            _steeringAxle = steeringAxle;
            _drivingAxles = drivingAxles;
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

        public Point[] Coordinates()
        {
            throw new NotImplementedException();
        }
    }
}
