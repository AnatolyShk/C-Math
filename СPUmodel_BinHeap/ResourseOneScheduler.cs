using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeap
{
    class ResourseOneScheduler
    {

        private ResourseOne sresourse;
        private PriorityQueueBinHeap<Process> squeue;
        private Random srng = new Random();
        public ResourseOneScheduler(ResourseOne resourse,PriorityQueueBinHeap<Process> queue)
        {    
            sresourse = resourse;
            squeue = queue;
        }
        private int sqtTermProc = 0;
        public int SqtTermProc
        {
            get {return sqtTermProc; }
            set {; }
        }
        public bool Action = false;
        private int midWaitTime;
        public int MidWaitTime
        {
            get { return midWaitTime; }
            set {; }
        }
      private int midRoundTime;
       public int MidRoundTime
       {
get { return midRoundTime; }
           set {; }
       }

        public void Rescheduling()
        {
            if (Action == true)
            {

                if (!squeue.Empty())
                {



                    Process rOneProcess = squeue.Item(); 
                    sresourse.ActiveProcess = null;
                    sresourse.ActiveProcess = rOneProcess;
                    squeue.Remove();
                    Action = false;
                    sqtTermProc++;
                }
                else
                {
                    sresourse.ActiveProcess = null;
                }
            }
            if (sresourse.ActiveProcess != null && sqtTermProc != 0)
            {
                midWaitTime = (midWaitTime + sresourse.ActiveProcess.WaitTime) / sqtTermProc; //значение ожидания после завершения 
                midRoundTime = (midRoundTime + sresourse.ActiveProcess.RoundTime) / sqtTermProc;


            }
            if (!squeue.Empty())
            {

                if (sresourse.ActiveProcess == null)
                    {

                        Process rrOneProcess = squeue.Item();
                        sresourse.ActiveProcess = rrOneProcess;
                        squeue.Remove();
                    }
                }

            
         
 
        }
    }
}
