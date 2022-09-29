using System.Drawing;
using RoadTrain.Classes;

namespace RoadTrain.Interfaces
{
    public interface ITruck: IBody
    {
        SteeringAxle SteeringAxle { get; set; }
        List<DrivingAxle> DrivingAxles { get; set; }
        Point[] Coordinates();
    }
}
