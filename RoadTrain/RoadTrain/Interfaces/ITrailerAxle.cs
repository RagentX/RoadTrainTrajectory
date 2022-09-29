using System.Drawing;

namespace RoadTrain.Interfaces
{
    public interface ITrailerAxle : IAxle
    {
        Point[] Coordinates();
    }
}
