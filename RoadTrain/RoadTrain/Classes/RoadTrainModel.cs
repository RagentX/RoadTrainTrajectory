using RoadTrain.Interfaces;

namespace RoadTrain.Classes
{
    public class RoadTrainModel : IRoadTrain
    {
        private Trailer _trailer;
        private Truck _truck;

        public RoadTrainModel()
        {
            _truck = new Truck();
            _trailer = new Trailer();

        }

        public Trailer Trailer
        {
            get { return _trailer; }
            set { _trailer = value; }
        }

        public Truck Truck
        {
            get { return _truck; }
            set { _truck = value; }
        }
        public (double X, double Y) RidingForward(double speed)
        {
            double changeX = 0;
            double changeY = 0;
            double angelInCircle = 0;
            double trailerChangingRotation = 0;
            double trailerR = 0;
            double changeXTrailerRotationCenter = 0;
            double changeYTrailerRotationCenter = 0;
            double avgAngelWhell = _truck.SteeringAxle.WheelRotation;

            double truckWheelBase = _truck.AvgDrivingAxlesPosition - _truck.SteeringAxle.AxlePosition;

            // ������ �������� ������ 
            double truckR = truckWheelBase / Math.Tan(avgAngelWhell);

            if (avgAngelWhell != 0)
            {
                // ������� �������� p s ����� 1
                angelInCircle = speed / truckR;
                // ������� ��������� ��������� ������ ����������� ���������� ����� �� ����������, �� � ����� ��������
                // p s �������, ��� ����� ����������� �������� ��� 0, 0.
                changeX = truckR * Math.Sin(_truck.AngleRotation + angelInCircle) - _truck.SinAngleRotation * truckR;
                changeY = _truck.CosAngleRotation * truckR - truckR * Math.Cos(_truck.AngleRotation + angelInCircle);
            }
            else
            {
                changeX = speed * _truck.CosAngleRotation;
                changeY = speed * _truck.SinAngleRotation;
            }
            if (_truck.AngleRotation != _trailer.AngleRotation)
            {
                double trailerWheelBase = _trailer.AvgTrailerAxlesPosition - _trailer.FiveWheelPosition;
                trailerR = trailerWheelBase / Math.Tan(((_trailer.AngleRotation - _truck.AngleRotation + Math.PI) % (Math.PI * 2) + (Math.PI * 2)) % (Math.PI * 2) - Math.PI);

                // ��� �������� ������� ������ �� ����, ��� ��������� ����� ������ ��� ����� ��������� 0,0
                // ������� ��������� ��� ����� ��������� 
                double changeXFifthWeelBeforeTurning = (_truck.AvgDrivingAxlesPosition - _truck.FiveWheelPosition)
                    * _truck.CosAngleRotation;
                double changeYFifthWeelBeforeTurning = (_truck.AvgDrivingAxlesPosition - _truck.FiveWheelPosition)
                    * _truck.SinAngleRotation;
                // ������� ��������� ��� ����� �������� 
                double changeXFifthWeel�fterTurning = changeX + (_truck.AvgDrivingAxlesPosition - _truck.FiveWheelPosition)
                    * Math.Cos(_truck.AngleRotation + angelInCircle);
                double changeYFifthWeel�fterTurning = changeY + (_truck.AvgDrivingAxlesPosition - _truck.FiveWheelPosition)
                    * Math.Sin(_truck.AngleRotation + angelInCircle);

                // �������� ������� �����������  
                double changeXTrailerRotationPoint = changeXFifthWeelBeforeTurning - trailerWheelBase * _trailer.CosAngleRotation;
                double changeYTrailerRotationPoint = changeYFifthWeelBeforeTurning - trailerWheelBase * _trailer.SinAngleRotation;

                // ������� ������ ����������.
                changeXTrailerRotationCenter = changeXTrailerRotationPoint + trailerR * _trailer.SinAngleRotation;
                changeYTrailerRotationCenter = changeYTrailerRotationPoint - trailerR * _trailer.CosAngleRotation;

                double changeYFifthWeelBeforeTurningSecondOption = -changeYTrailerRotationCenter + changeYFifthWeelBeforeTurning;
                double changeXFifthWeelBeforeTurningSecondOption = -changeXTrailerRotationCenter + changeXFifthWeelBeforeTurning;
                double changeYFifthWeel�fterTurningSecondOption = -changeYTrailerRotationCenter + changeYFifthWeel�fterTurning;
                double changeXFifthWeel�fterTurningSecondOption = -changeXTrailerRotationCenter + changeXFifthWeel�fterTurning;

                trailerChangingRotation = Math.Acos(
                    (changeXFifthWeelBeforeTurningSecondOption * changeXFifthWeel�fterTurningSecondOption +
                    changeYFifthWeelBeforeTurningSecondOption * changeYFifthWeel�fterTurningSecondOption) /
                    (Math.Sqrt(Math.Pow(changeXFifthWeelBeforeTurningSecondOption, 2) + Math.Pow(changeYFifthWeelBeforeTurningSecondOption, 2)) *
                    Math.Sqrt(Math.Pow(changeXFifthWeel�fterTurningSecondOption, 2) + Math.Pow(changeYFifthWeel�fterTurningSecondOption, 2)))
                    );
            }
            if (((_trailer.AngleRotation - _truck.AngleRotation + (Math.PI * 2)) % (Math.PI * 2) + (Math.PI)) % (Math.PI * 2) - (Math.PI) > 0)
                _trailer.AngleRotation = (_trailer.AngleRotation - trailerChangingRotation + (Math.PI * 2)) % (Math.PI * 2);
            else
                _trailer.AngleRotation = (_trailer.AngleRotation + trailerChangingRotation + (Math.PI * 2)) % (Math.PI * 2);
            _truck.AngleRotation = (_truck.AngleRotation + angelInCircle + (Math.PI * 2)) % (Math.PI * 2);
            return (changeX, changeY);
        }
        public (double X, double Y) RidingBackward(double speed)
        {
            double changeX = 0;
            double changeY = 0;
            double angelInCircle = 0;
            double trailerChangingRotation = 0;
            double trailerR = 0;
            double changeXTrailerRotationCenter = 0;
            double changeYTrailerRotationCenter = 0;
            double avgAngelWhell = _truck.SteeringAxle.WheelRotation;
            double truckWheelBase = _truck.AvgDrivingAxlesPosition - _truck.SteeringAxle.AxlePosition;
            speed = -speed;
            // ������ �������� ������ 
            double truckR = truckWheelBase / Math.Tan(avgAngelWhell);

            if (avgAngelWhell != 0)
            {
                // ������� �������� p s ����� 1
                angelInCircle = speed / truckR;
                // ������� ��������� ��������� ������ ����������� ���������� ����� �� ����������, �� � ����� ��������
                // p s �������, ��� ����� ����������� �������� ��� 0, 0.
                changeX = truckR * Math.Sin(_truck.AngleRotation + angelInCircle) - _truck.SinAngleRotation * truckR;
                changeY = _truck.CosAngleRotation * truckR - truckR * Math.Cos(_truck.AngleRotation + angelInCircle);
            }
            else
            {
                changeX = speed * _truck.CosAngleRotation;
                changeY = speed * _truck.SinAngleRotation;
            }
            if (_truck.AngleRotation != _trailer.AngleRotation)
            {
                double trailerWheelBase = _trailer.AvgTrailerAxlesPosition - _trailer.FiveWheelPosition;
                trailerR = trailerWheelBase / Math.Tan(((_trailer.AngleRotation - _truck.AngleRotation + Math.PI) % (Math.PI * 2) + (Math.PI * 2)) % (Math.PI * 2) - Math.PI);

                // ��� �������� ������� ������ �� ����, ��� ��������� ����� ������ ��� ����� ��������� 0,0
                // ������� ��������� ��� ����� ��������� 
                double changeXFifthWeelBeforeTurning = (_truck.AvgDrivingAxlesPosition - _truck.FiveWheelPosition)
                    * _truck.CosAngleRotation;
                double changeYFifthWeelBeforeTurning = (_truck.AvgDrivingAxlesPosition - _truck.FiveWheelPosition)
                    * _truck.SinAngleRotation;
                // ������� ��������� ��� ����� �������� 
                double changeXFifthWeel�fterTurning = changeX + (_truck.AvgDrivingAxlesPosition - _truck.FiveWheelPosition)
                    * Math.Cos(_truck.AngleRotation + angelInCircle);
                double changeYFifthWeel�fterTurning = changeY + (_truck.AvgDrivingAxlesPosition - _truck.FiveWheelPosition)
                    * Math.Sin(_truck.AngleRotation + angelInCircle);

                // �������� ������� �����������  
                double changeXTrailerRotationPoint = changeXFifthWeelBeforeTurning - trailerWheelBase * _trailer.CosAngleRotation;
                double changeYTrailerRotationPoint = changeYFifthWeelBeforeTurning - trailerWheelBase * _trailer.SinAngleRotation;

                // ������� ������ ����������.
                changeXTrailerRotationCenter = changeXTrailerRotationPoint + trailerR * _trailer.SinAngleRotation;
                changeYTrailerRotationCenter = changeYTrailerRotationPoint - trailerR * _trailer.CosAngleRotation;

                double changeYFifthWeelBeforeTurningSecondOption = -changeYTrailerRotationCenter + changeYFifthWeelBeforeTurning;
                double changeXFifthWeelBeforeTurningSecondOption = -changeXTrailerRotationCenter + changeXFifthWeelBeforeTurning;
                double changeYFifthWeel�fterTurningSecondOption = -changeYTrailerRotationCenter + changeYFifthWeel�fterTurning;
                double changeXFifthWeel�fterTurningSecondOption = -changeXTrailerRotationCenter + changeXFifthWeel�fterTurning;

                trailerChangingRotation = Math.Acos(
                    (changeXFifthWeelBeforeTurningSecondOption * changeXFifthWeel�fterTurningSecondOption +
                    changeYFifthWeelBeforeTurningSecondOption * changeYFifthWeel�fterTurningSecondOption) /
                    (Math.Sqrt(Math.Pow(changeXFifthWeelBeforeTurningSecondOption, 2) + Math.Pow(changeYFifthWeelBeforeTurningSecondOption, 2)) *
                    Math.Sqrt(Math.Pow(changeXFifthWeel�fterTurningSecondOption, 2) + Math.Pow(changeYFifthWeel�fterTurningSecondOption, 2)))
                    );
            }
            if (((_trailer.AngleRotation - _truck.AngleRotation + (Math.PI * 2)) % (Math.PI * 2) + (Math.PI)) % (Math.PI * 2) - (Math.PI) < 0)
                _trailer.AngleRotation = (_trailer.AngleRotation - trailerChangingRotation + (Math.PI * 2)) % (Math.PI * 2);
            else
                _trailer.AngleRotation = (_trailer.AngleRotation + trailerChangingRotation + (Math.PI * 2)) % (Math.PI * 2);
            _truck.AngleRotation = (_truck.AngleRotation + angelInCircle + (Math.PI * 2)) % (Math.PI * 2);
            return (changeX, changeY);
        }
    }
}