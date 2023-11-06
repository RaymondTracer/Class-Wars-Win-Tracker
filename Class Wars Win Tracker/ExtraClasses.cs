using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Wars_Win_Tracker
{
    public class ClassWarsWinTracker
    {
        public BluClass[] Blu { get; } = new BluClass[9];

        public ClassWarsWinTracker()
        {
            for (int i = 0; i < 9; i++)
            {
                Blu[i] = new();
            }
        }
    }

    public class BluClass
    {
        public RedClass[] Red { get; } = new RedClass[9];

        public BluClass()
        {
            for (int i = 0; i < 9; i++)
            {
                Red[i] = new();
            }
        }
    }

    public class RedClass
    {
        public DustbowlStage[] Stage { get; } = new DustbowlStage[3];

        public RedClass()
        {
            for (int i = 0; i < 3; i++)
            {
                Stage[i] = new();
            }
        }
    }

    public class DustbowlStage
    {
        public StageControlPoint[] ControlPoint { get; } = new StageControlPoint[2];

        public DustbowlStage()
        {
            for (int i = 0; i < 2; i++)
            {
                ControlPoint[i] = new();
            }
        }
    }

    public class StageControlPoint
    {
        public byte BluWins { get; set; } = 0;
        public byte RedWins { get; set; } = 0;
    }
}
