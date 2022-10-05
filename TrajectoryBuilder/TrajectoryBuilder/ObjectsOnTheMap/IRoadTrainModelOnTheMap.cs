using RoadTrain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrajectoryBuilder.ObjectsOnTheMap
{
    public interface IRoadTrainModelOnTheMap : IObjectOnTheMap
    {
        RoadTrainModel RoadTrainModel { get; set; }
        void RidingForward();
    }
}
