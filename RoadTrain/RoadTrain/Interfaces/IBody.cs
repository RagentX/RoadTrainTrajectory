namespace RoadTrain.Interfaces
{
    public interface IBody: IRoadTrainParts
    {
        double Lenght { get; set; }
        // Расстояние от передней части рамы до места сцепки
        double FiveWheelPosition { get; set; }
    }
}
