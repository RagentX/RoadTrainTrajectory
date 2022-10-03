using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class RoadTrainModel : IRoadTrain
    {
        private Trailer _trailer;
        private Truck _truck;

        public RoadTrainModel()
        { 
            _trailer = new Trailer();
            _truck = new Truck();
        }

        public Trailer Trailer
        {
            get {return _trailer;}
            set {_trailer = value;}
        }

        public Truck Truck
        {
            get { return _truck;}
            set { _truck = value;}
        }
    }
}