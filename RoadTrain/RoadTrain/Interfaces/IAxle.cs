namespace RoadTrain.Interfaces
{
    public interface IAxle: IRoadTrainParts
    {
        // ���������� �� �������� ����� ���� �� �������� �����
        double AxlePosition { get; set; }
    }
}