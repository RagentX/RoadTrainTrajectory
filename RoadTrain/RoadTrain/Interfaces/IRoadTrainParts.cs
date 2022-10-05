namespace RoadTrain.Interfaces
{
    public interface IRoadTrainParts
    {
        double Width { get; set; }
        // угол поворота относительн оси OY(по часовой стрелке)
        double AngleRotation { get; set; }
        double SinAngleRotation { get; }
        double CosAngleRotation { get; }
    }
}
