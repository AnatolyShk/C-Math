using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeap
{
    class CPUScheduler
    {
        private CPU scpu;
        private PriorityQueueBinHeap<Process> sPriorQ;
        private PriorityQueueBinHeap<Process> sresourse;
        private Random srng = new Random();

        public CPUScheduler(CPU cpu, PriorityQueueBinHeap<Process> PriorQ,  PriorityQueueBinHeap<Process> resourse)
        {
            scpu = cpu;
            sPriorQ = PriorQ;
            sresourse = resourse;

        }
        public void Rescheduling()
        {
            if (scpu.Free())
            {
                Process proc = sPriorQ.Item();
                sPriorQ.Remove();
                proc.Status = processStatus.runningSt;
              
                scpu.ActiveProcess = proc;
            }
            if (!sPriorQ.Empty() && !scpu.Free())
            {
                if (scpu.ActiveProcess.WorkTime == scpu.ActiveProcess.BurstTime)
                {
                    scpu.ActiveProcess.resourseNeed = srng.Next(0,2);
                    if (scpu.ActiveProcess.resourseNeed == 1)
                    {
                        scpu.ActiveProcess.Status = processStatus.waitingSt;

                      
                        
                        sresourse.Put(scpu.ActiveProcess);
                        scpu.ActiveProcess.WorkTime = 0;
                        Process proc = sPriorQ.Item();
                        sPriorQ.Remove();
                        proc.Status = processStatus.runningSt;
                        scpu.ActiveProcess = proc;

                        
                    }
                    
                    else
                    {
                        scpu.ActiveProcess.Status = processStatus.terminatedSt;
            
                   
                        
                        Process proc = sPriorQ.Item();
                        sPriorQ.Remove();
                        scpu.ActiveProcess = proc;
                    }

                }

                else // вытеснение
                {
                    if (!sPriorQ.Empty() && !scpu.Free())
                    {
                        Process proc = sPriorQ.Item();
                        if (proc.BurstTime.CompareTo(scpu.ActiveProcess.BurstTime) < 0 && (proc.BurstTime.CompareTo(scpu.ActiveProcess.BurstTime)!=0))
                        {
                            sPriorQ.Remove();
                            proc.Status = processStatus.runningSt;
                            scpu.ActiveProcess.Status = processStatus.readySt;
                            sPriorQ.Put(scpu.ActiveProcess);
                            scpu.ActiveProcess = proc;
                        }
                    }
                }
            }

        }

    }
}
