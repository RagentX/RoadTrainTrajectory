namespace RoadTrain.Interfaces
{
    public interface IAxle: IRoadTrainParts
    {
        // Расстояние от передней части рамы до середины моста
        double AxlePosition { get; set; }
    }
}