using TrajectoryBuilder.ObjectsOnTheMap;
using RoadTrain.Classes;

namespace TrajectoryBuilder
{
    public class Map
    {
        private List<LidarPoint> _lidarPoints;
        private RoadTrainModelOnTheMap _roadTrainModelInMap;

        public Map()
        {
            _lidarPoints = new List<LidarPoint>();
            _roadTrainModelInMap = new RoadTrainModelOnTheMap();
        }

        public RoadTrainModelOnTheMap RoadTrainModelOnTheMap
        {
            get
            {
                return _roadTrainModelInMap;
            }
            set
            {
                _roadTrainModelInMap = value;
            }
        }

        public List<LidarPoint> LidarPoints 
        {
            get
            {
                return _lidarPoints;
            }
            set
            {
                _lidarPoints = value;
            }
        }

        public void AddPoint(double x, double y)
        {
            _lidarPoints.Add(new LidarPoint(x, y));
        }

        public void RemovePoint(LidarPoint point)
        {
            _lidarPoints.Remove(point);
        }
    }
}
