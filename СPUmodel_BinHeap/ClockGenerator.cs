using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeap
{
    class ClockGenerator
    {
        
        private int clock;
        public int Clock { get { return clock; } }
        public void NextTime()
        {
            clock++;
        }
        public void Clear()
        {
            clock = 0;
        }
    }
}
