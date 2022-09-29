using System.Drawing;

namespace RoadTrain.Interfaces
{
    public interface ISteeringAxle: IAxle
    {
        double AckermanAngle { get; set; }
        double LeverLength { get; set; }
        double WheelRotation { get; set; }
        Point[] Coordinates();
    }
}
