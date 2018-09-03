using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BinHeap
{
    class Model
    {
        /// <summary>
        /// Конструктор: создание модели
        /// Аргументы – параметры модели
        /// </summary>
        public Model(double it, int burstMin, int burstMax)
        {
            // создание компонентов модели
            clockGen = new ClockGenerator();
            cpu = new CPU();
            readyQueue = new PriorityQueueBinHeap<Process>();
            queueToOne = new PriorityQueueBinHeap<Process>();
            Resourse = new ResourseOne();
            cpuScheduler = new CPUScheduler(cpu, readyQueue, queueToOne);
            ResourseOnescheduler = new ResourseOneScheduler(Resourse, queueToOne);
            processRand = new Random();
            // сохранение параметров системы
            intensityThreshold = it;
            this.burstMin = burstMin;
            this.burstMax = burstMax;
        }
        /// <summary>
        /// действия модели на такте работы
        /// </summary>
        /// 
        private int qtprocess;
        private int maxCount;
        public int  Qtprocess
            {
            get{return qtprocess;}
            set {; }
            }
        private int qtprocessTerminated;
        public int QtprocessTerminated
        {
            get { return qtprocessTerminated; }
            set {; }
        }
   
        public int MaxCount
        {
            get { return maxCount; }
            set {; }
        }
        public void NextTime()
        {
            clockGen.NextTime(); // увеличивается номер 
            if (processRand.NextDouble() < intensityThreshold) // порог интенсивности
                                                               // поступления процессов не превышен
            {
                Process newProcess = new Process(clockGen.Clock);
                qtprocess++;
                newProcess.BurstTime = processRand.Next(burstMin, burstMax + 1);
                readyQueue.Put(newProcess);
                newProcess.StartWorkTime = clockGen.Clock;
                cpuScheduler.Rescheduling();
             
                int newCount = readyQueue.Count();
                if (readyQueue.Count()!=0 && readyQueue.Count()>maxCount)
                {
                    maxCount = readyQueue.Count();
                }
            }
            cpu.NextTime();
            resourse.NextTime();
            ResourseOnescheduler.Rescheduling();
            if (!readyQueue.Empty())
            {
             foreach(Process i in readyQueue)
                {
                    if (Cpu.ActiveProcess != i)
                    {
                        i.WaitTime++;
                    }
                    i.RoundTime++;
                }
                foreach (Process i in queueToOne)
                {
                    if (resourse.ActiveProcess != i)
                    {
                        i.WaitTime++;
                    }
                    i.RoundTime++;
                }



                if (redevelopmentNeed())
                    cpuScheduler.Rescheduling();
                    
            }
        
        }
        public void Clear()
        {
            clockGen.Clear();
            cpu.Clear();
            readyQueue.Clear();
        }
        public ClockGenerator ClockGen
        {
            get
            {
                return clockGen;
            }
        }
        public CPU Cpu
        {
            get
            {
                return cpu;
            }
        }
        public CPUScheduler CpuScheduler
        {
            get
            {
                return cpuScheduler;
            }
        }
        public PriorityQueueBinHeap<Process> ReadyQueue
        {
            get
            {
                return readyQueue;
            }
        }
        public Random ProcessRand
        {
            get
            {
                return processRand;
            }
        }
        /// <summary>
        /// Компоненты модели
        /// </summary>

        /// <summary>
        /// Часы
        /// </summary>
        private ClockGenerator clockGen;

        /// <summary>
        /// центральный процессор
        /// </summary>
        private CPU cpu;

        /// <summary>
        /// планировщик центрального процессора
        /// </summary>
        private CPUScheduler cpuScheduler;
        private ResourseOneScheduler ResourseOnescheduler;
        public ResourseOneScheduler resourseOneScheduler
        {
            get
                {
                return ResourseOnescheduler;
            }
        }
        /// <summary>
        /// очередь готовых процессов
        /// </summary>
        private PriorityQueueBinHeap<Process> readyQueue;
        private PriorityQueueBinHeap<Process> queueToOne;
        public PriorityQueueBinHeap<Process> QueueToOne
        {
            get
            {
                return queueToOne;
            }
        }
        public ResourseOne resourse
        {
            get
            {
                return Resourse;
            }
        }
        private ResourseOne Resourse;
        /// <summary>
        /// генератор процессов
        /// </summary>
        private Random processRand;

        /// <summary>
        /// параметры модели
        /// </summary>

        /// <summary>
        /// Порог интенсивности поступления процессов
        /// </summary>
        private double intensityThreshold;

        /// <summary>
        /// Минимальная величина интервала обслуживания
        /// </summary>
        private int burstMin;

        /// <summary>
        /// Максимальная величина интервала обслуживания
        /// </summary>
        private int burstMax;

        // вспомогательный метод, определяющий, требуется ли перепланировк
        private bool redevelopmentNeed()
        {
            return (cpu.Free() || cpu.ActiveProcess.WorkTime ==
                        cpu.ActiveProcess.BurstTime);
        }
    
    }


}




