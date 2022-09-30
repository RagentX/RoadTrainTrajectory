using System.Drawing;
using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class Truck : Body, ITruck
    {      
        private SteeringAxle? _steeringAxle;
        private List<DrivingAxle>? _drivingAxles;

        public Truck(double width = 2550,
                     double lenght = 1440 + 3600 + 1080,
                     double angleRotation = 0,
                     SteeringAxle? steeringAxle = default(SteeringAxle),
                     List<DrivingAxle>? drivingAxles = default(List<DrivingAxle>)
                     )
        {
            _width = width;
            _lenght = lenght;
            _angleRotation = angleRotation;
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
