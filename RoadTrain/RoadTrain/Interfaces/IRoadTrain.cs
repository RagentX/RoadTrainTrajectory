using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoadTrain.Classes;

namespace RoadTrain.Interfaces
{
    internal interface IRoadTrain
    {
        Trailer Trailer { get; set; }
        Truck Truck { get; set; }
    }
}
