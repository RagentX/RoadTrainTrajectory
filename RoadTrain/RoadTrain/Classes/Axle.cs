using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class Axle : RoadTrainParts, IAxle
    {
        protected double _axlePosition;

        public double AxlePosition
        {
            get { return _axlePosition; }
            set { _axlePosition = value; }
        }
    }
}