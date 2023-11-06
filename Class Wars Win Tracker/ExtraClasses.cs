using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Wars_Win_Tracker
{
    public class ClassWarsWinTracker
    {
        public BluClass[] Blu { get; set; }
    }

    public class BluClass
    {
        public RedClass[] Red { get; set; }
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
        public byte BluWins { get; set; }
        public byte RedWins { get; set; }
    }
}
