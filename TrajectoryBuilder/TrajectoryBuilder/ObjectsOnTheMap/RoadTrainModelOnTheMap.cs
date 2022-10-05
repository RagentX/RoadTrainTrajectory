using RoadTrain.Classes;

namespace TrajectoryBuilder.ObjectsOnTheMap
{
    public class RoadTrainModelOnTheMap : ObjectOnTheMap, IRoadTrainModelOnTheMap
    {
        protected RoadTrainModel _roadTrainModel;
        public RoadTrainModelOnTheMap(double x = 0, double y = 0)
        {
            _x = x;
            _y = y;
            _roadTrainModel = new RoadTrainModel();
        }
        public RoadTrainModel RoadTrainModel
        {
            get
            {
                return _roadTrainModel;
            }
            set 
            {
                _roadTrainModel = value;
            }
        }
        public void RidingForward()
        {
            for (int i = 0; i < 10; i++)
            {
                (double X, double Y) change = _roadTrainModel.RidingForward(10);
                _x += change.X;
                _y += change.Y;
            }
        }
    }
}
