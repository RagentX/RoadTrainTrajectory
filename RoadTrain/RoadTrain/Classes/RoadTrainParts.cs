using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class RoadTrainParts : IRoadTrainParts
    {
        protected double _width;
        protected double _angleRotation;
        protected double _ratio;
        public RoadTrainParts(double ratio = 30, double angleRotation = 0)
        {
            _ratio = ratio;
            _angleRotation = angleRotation;
        }
        public double Width 
        { 
            get { return _width; } 
            set { _width = value; } 
        }
        public double AngleRotation
        { 
            get { return _angleRotation; }
            set { _angleRotation = value; } 
        }
        public double Ratio
        {
            get { return _ratio; }
            set { _ratio = value; }
        }
    }
}
