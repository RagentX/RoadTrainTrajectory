using TrajectoryBuilder.ObjectsOnTheMap;
using RoadTrain.Classes;

namespace TrajectoryBuilder
{
    public interface IMap
    {
        List<LidarPoint> LidarPoints { get; set;}
        RoadTrainModelOnTheMap RoadTrainModelOnTheMap { get; set; }
        void AddPoint(double x, double y);
        void RemovePoint(LidarPoint point);
    }
}
