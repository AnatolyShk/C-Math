using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeap
{
    enum processStatus { readySt, runningSt, terminatedSt,waitingSt}
    class Process : IComparable
    {
        public Process(int clock)
        {
            // resourseNeed = 0;
            waitTime = workTime ;
            RoundTime = startTime - endTime;
            startTime = clock;
            name = "P" + startTime.ToString();
            identifyNumber =clock;
            Status = processStatus.readySt;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Process other = obj as Process;
            if (other == null)
                throw new ArgumentException("Object is not a Process");
            else
                return other.BurstTime.CompareTo(this.BurstTime);
        }

        public override string ToString()
        {
            if (resourseNeed == 0)
            {
                return "P" + StartTime.ToString() + "_" + "WT" + ":" + workTime.ToString() + "/" + BurstTime.ToString() + "status:" + Status + " " + "waitTime:" + waitTime;
            }
            else 
            {
                return "P" + StartTime.ToString() + "_" + "status:" + Status + " " + "waitTime:" +" " + waitTime;
            }
        }
        public int identifyNumber { get; set; }
        private string name;
        public string Name { get { return name; } }
        private int startTime;
        private int burstTime;
        private int workTime ;
        private int waitTime;
        private int endTime;
       public int resourseNeed = 0;
        public int StartTime { get { return startTime; }  set { startTime = value; } }
        public int BurstTime { get { return burstTime; }  set { burstTime = value; } }
        public  int WorkTime { get { return workTime;  }  set { workTime  = value; } }
        public int WaitTime  { get { return waitTime; }  set  { waitTime  = value;} }
        public int StartWorkTime { get; set; }
        public int RoundTime { get; set; }
        public int EndTime { get { return endTime; } set {endTime=value; } }
        public processStatus Status   { get; set; }

    }
}
