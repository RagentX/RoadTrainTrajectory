using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class Axle : RoadTrainParts, IAxle
    {
        protected double _axelPosition;

        public double AxelPosition
        {
            get { return _axelPosition; }
            set { _axelPosition = value; }
        }
    }
}