using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeap
{
    class ResourseOne
    {
        public void NextTime()
        {
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
