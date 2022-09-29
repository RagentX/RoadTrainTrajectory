using System.Drawing;

namespace RoadTrain.Interfaces
{
    public interface IDrivingAxle : IAxle
    {
        Point[] Coordinates();
    }
}