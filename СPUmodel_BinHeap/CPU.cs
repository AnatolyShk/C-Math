using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeap
{
    class CPU
    {
        public void NextTime()
        {
            if (ActiveProcess != null)
            {
                ActiveProcess.WorkTime++;
                ActiveProcess.RoundTime++;
            }
        }
        public bool Free()
        {
            return ActiveProcess == null;
        }
        public void Clear()
        {
            ActiveProcess.WorkTime = 0;
        }
         public void SetActiveProcess(Process process)
            {
                ActiveProcess = process;
            }
        public Process ActiveProcess;
    }
}
