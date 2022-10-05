using RoadTrain.Classes;
using System.Drawing;

namespace RoadTrain.Interfaces
{
    public interface ITrailer : IBody
    {
        List<TrailerAxle> TrailerAxles {get; set;}
        (double X, double Y)[] Coordinates { get; }
    }
}
