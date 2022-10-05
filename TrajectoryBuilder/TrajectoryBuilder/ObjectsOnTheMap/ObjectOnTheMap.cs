 namespace TrajectoryBuilder.ObjectsOnTheMap
 {
    public class ObjectOnTheMap
    {
        protected double _x;
        protected double _y;
        public double X
        {
            get
            {
                return _x;
            }
            set 
            {
                _x = value;
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set 
            {
                _y = value;
            }
        }
    }
 }