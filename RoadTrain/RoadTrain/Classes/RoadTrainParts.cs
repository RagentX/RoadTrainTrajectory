using RoadTrain.Interfaces;
namespace RoadTrain.Classes
{
    public class RoadTrainParts : IRoadTrainParts
    {
        protected double _width;
        protected double _angleRotation;
        protected double _sinAngleRotation;
        protected double _cosAngleRotation;
        public RoadTrainParts(double angleRotation = 0)
        {
            AngleRotation = angleRotation;
        }
        public double Width 
        { 
            get { return _width; } 
            set { _width = value; } 
        }
        public double AngleRotation
        { 
            get { return _angleRotation; }
            set 
            {
                _sinAngleRotation = Math.Sin(value);
                _cosAngleRotation = Math.Cos(value);
                _angleRotation = value; 
            } 
        }
    }
}
