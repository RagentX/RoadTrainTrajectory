namespace RoadTrain.Interfaces
{
    public interface IAxle: IRoadTrainParts
    {
        // ���������� �� �������� ����� ���� �� �������� �����
        double AxelPosition { get; set; }
    }
}