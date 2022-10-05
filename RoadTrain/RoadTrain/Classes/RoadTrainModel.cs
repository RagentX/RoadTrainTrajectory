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

            // ðàäèóñ ïîâîðîòà òÿãî÷à 
            double truckR = truckWheelBase / Math.Tan(avgAngelWhell);

            if (avgAngelWhell != 0)
            {
                // óãëîâàÿ ñêîðîñòü p s îìåãà 1
                angelInCircle = speed / truckR;
                // ðàññ÷¸ò èçìåíåíèÿ ïîëîæåíèÿ òÿãî÷à âû÷èñëåìÿåì êîîðäèíàòû òî÷åê íà îêðóæíîñòè, äî è ïîñëå ïîâîðîòà
                // p s ñ÷èòàåì, ÷òî öåíòð ìãíîâåííîãî ïîâîðîòà ýòî 0, 0.
                changeX = truckR * Math.Sin(_truck.AngleRotation + angelInCircle) - _truck.SinAngleRotation * truckR;
                changeY = truckR * Math.Cos(_truck.AngleRotation + angelInCircle) - _truck.CosAngleRotation * truckR;
            }
            else
            {
                changeX = speed * _truck.CosAngleRotation;
                changeY = - speed * _truck.SinAngleRotation;
            }
            if (_truck.AngleRotation != _trailer.AngleRotation)
            {
                double trailerWheelBase = _trailer.AvgTrailerAxlesPosition - _truck.FiveWheelPosition;
                trailerR = trailerWheelBase / Math.Tan(((_trailer.AngleRotation - _truck.AngleRotation + Math.PI) % (Math.PI * 2) + (Math.PI * 2)) % (Math.PI * 2) - Math.PI);

                // âñå ðàññ÷¸òû âåäóòñÿ èñõîäÿ èç òîãî, ÷òî ïîëîæåíèå ÑÑÓ 0,0
                // ñ÷èòàåì ïîëîæåíèå ññó ïåðåä ïîâîðîòîì 
                double changeXFifthWeelBeforeTurning = -(_truck.AvgDrivingAxlesPosition - _truck.FiveWheelPosition)
                    * _truck.CosAngleRotation;
                double changeYFifthWeelBeforeTurning = -(_truck.AvgDrivingAxlesPosition - _truck.FiveWheelPosition)
                    * _truck.SinAngleRotation;
                // ñ÷èòàåì ïîëî÷åíèå ññó ïîñëå ïîâîðîòà 
                double changeXFifthWeelÀfterTurning = changeX + changeXFifthWeelBeforeTurning;
                double changeYFifthWeelÀfterTurning = -changeY + changeYFifthWeelBeforeTurning;

                // ñåðåäèíà õîäîâîé ïîëóïðèöåïà  
                double changeXTrailerRotationPoint = changeXFifthWeelBeforeTurning +
                    trailerWheelBase * _trailer.CosAngleRotation;
                double changeYTrailerRotationPoint = changeYFifthWeelBeforeTurning +
                    trailerWheelBase * _trailer.SinAngleRotation;

                // ðàññ÷¸ò öåíòðà îêðóæíîñòè.
                changeXTrailerRotationCenter = changeXTrailerRotationPoint + trailerR * _trailer.SinAngleRotation;
                changeYTrailerRotationCenter = changeYTrailerRotationPoint - trailerR * _trailer.CosAngleRotation;

                double changeYFifthWeelBeforeTurningSecondOption = -changeYTrailerRotationCenter + changeYFifthWeelBeforeTurning;
                double changeXFifthWeelBeforeTurningSecondOption = -changeXTrailerRotationCenter + changeXFifthWeelBeforeTurning;
                double changeYFifthWeelÀfterTurningSecondOption = -changeYTrailerRotationCenter + changeYFifthWeelÀfterTurning;
                double changeXFifthWeelÀfterTurningSecondOption = -changeXTrailerRotationCenter + changeXFifthWeelÀfterTurning;

                trailerChangingRotation = Math.Acos(
                    (changeXFifthWeelBeforeTurningSecondOption * changeXFifthWeelÀfterTurningSecondOption +
                    changeYFifthWeelBeforeTurningSecondOption * changeYFifthWeelÀfterTurningSecondOption) /
                    (Math.Sqrt(Math.Pow(changeXFifthWeelBeforeTurningSecondOption, 2) + Math.Pow(changeYFifthWeelBeforeTurningSecondOption, 2)) *
                    Math.Sqrt(Math.Pow(changeXFifthWeelÀfterTurningSecondOption, 2) + Math.Pow(changeYFifthWeelÀfterTurningSecondOption, 2)))
                    );
            }
            if (((_trailer.AngleRotation - _truck.AngleRotation + (Math.PI * 2)) % (Math.PI * 2) + (Math.PI)) % (Math.PI * 2) - (Math.PI) > 0)
                _trailer.AngleRotation = (_trailer.AngleRotation - trailerChangingRotation + (Math.PI * 2)) % (Math.PI * 2);
            else
                _trailer.AngleRotation = (_trailer.AngleRotation + trailerChangingRotation + (Math.PI * 2)) % (Math.PI * 2);
            _truck.AngleRotation = (_truck.AngleRotation - angelInCircle + (Math.PI * 2)) % (Math.PI * 2);
            return (changeX, changeY);
        }
    }
}