using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrajectoryBuilder.ObjectsOnTheMap
{
    public class LidarPoint : ObjectOnTheMap, ILidarPoint
    {
        public LidarPoint( double x = 0, double y = 0)
        {
            _x = x;
            _y = y;
        }
    }
}
