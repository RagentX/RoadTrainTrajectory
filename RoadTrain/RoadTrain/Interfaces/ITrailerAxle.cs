using System.Drawing;

namespace RoadTrain.Interfaces
{
    public interface ITrailerAxle : IAxle
    {
        (double X, double Y)[] Coordinates { get; }
    }
}
