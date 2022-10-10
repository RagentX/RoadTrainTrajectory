using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrajectoryBuilder.ObjectsOnTheMap
{
    public class RoadTrainModelCoordinates
    {
        private (double X, double Y)[] _truckCoordinates;
        private (double X, double Y)[] _trailerCoordinates;
        private (double X, double Y)[] _truckSteeringAxleCoordinates;
        public RoadTrainModelCoordinates((double X, double Y)[] truckCoordinates, 
                                        (double X, double Y)[] trailerCoordinates, 
                                        (double X, double Y)[] truckSteeringAxleCoordinates)
        {
            _truckCoordinates = truckCoordinates;
            _trailerCoordinates = trailerCoordinates;
            _truckSteeringAxleCoordinates = truckSteeringAxleCoordinates;
        }

        public (double X, double Y)[] TruckCoordinates
        {
            get { return _truckCoordinates; }
        }
        public (double X, double Y)[] TrailerCoordinates
        {
            get { return _trailerCoordinates; }
        }
        public (double X, double Y)[] TruckSteeringAxleCoordinates
        {
            get { return _truckSteeringAxleCoordinates; }
        }

        
    }
}
