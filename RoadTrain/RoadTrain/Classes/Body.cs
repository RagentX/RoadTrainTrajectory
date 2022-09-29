using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class Body : RoadTrainParts, IBody
    {
        protected double _lenght;
        protected double _fiveWheelPosition;
        public double Lenght
        {
            get { return _lenght; }
            set { _lenght = value; }
        }
        public double FiveWheelPosition
        {
            get { return _fiveWheelPosition; }
            set { _fiveWheelPosition = value; }
        }
    }
}
