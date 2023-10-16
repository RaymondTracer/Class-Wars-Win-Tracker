using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Wars_Win_Tracker
{
    public class ClassWarsWinTracker
    {
        public BluClass[] Classes { get; set; }

        public BluClass this[int tf2class]
        {
            get => Classes[tf2class];
        }
    }

    public class BluClass
    {
        public RedClass[] VsRed { get; set; }
    }

    public class RedClass
    {
        public DustbowlStage[] Stage { get; set; }
    }

    public class DustbowlStage
    {
        public StageControlPoint[] ControlPoint { get; set; }
    }

    public class StageControlPoint
    {
        public int BluWins { get; set; }
        public int RedWins { get; set; }
    }
}
