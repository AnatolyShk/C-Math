using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinHeap
{
    public partial class Form1 : Form
    {
        int t = 0;
        Random rng = new Random();
        PriorityQueueBinHeap<Process> model = new PriorityQueueBinHeap<Process>();
        Model moodel;
        public Form1()
        {
            InitializeComponent();



        }
        public static int brst;
        public static int brstm;
        public static double intensity;
        private void button1_Click(object sender, EventArgs e)
        {
            if (brst <= brstm)
            {
                intensity = Convert.ToDouble(numericUpDown1.Value);
                brst = Convert.ToInt32(numericUpDown2.Value);
                brstm = Convert.ToInt32(numericUpDown3.Value);
                moodel = new Model(1, brst, brstm);
                timer1.Stop();
            }
            else
            {
                epDelete.SetError(button1, "Введите другие значения максимума и минимума");
            }
            timer1.Start();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (brst <= brstm && intensity!=0)
            {
                if (moodel != null)
                {
                    moodel.NextTime();
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    listBox5.Items.Clear();
                    listBox4.Items.Clear();
                    listBox4.Items.Add("Количество процессов: "+moodel.Qtprocess.ToString());
                    listBox4.Items.Add("Количество завершенных процессов: " + moodel.resourseOneScheduler.SqtTermProc.ToString());
                    listBox4.Items.Add("Среднее время ожидания: " + moodel.resourseOneScheduler.MidWaitTime.ToString());
                    listBox4.Items.Add("Максимальная длина очереди: " + moodel.MaxCount.ToString());
                    listBox4.Items.Add("Среднее время оборота процесса: " + moodel.resourseOneScheduler.MidRoundTime.ToString());
                    listBox2.Items.Add(moodel.Cpu.ActiveProcess.ToString());
                    if (moodel.resourse.ActiveProcess != null)
                    {
                        listBox5.Items.Add(moodel.resourse.ActiveProcess.ToString());
                    }
                    moodel.ReadyQueue.ToArray();
        
                    foreach(Process i in moodel.ReadyQueue)
                    {
                        listBox1.Items.Add(i.ToString());
                    }
                    if (moodel.QueueToOne!=null)
                    {
                        foreach (Process p in moodel.QueueToOne)
                        {
                            if (p != null)
                            {
                                listBox3.Items.Add(p.ToString());
                            }
                        }
                    }
                    t++;
                    textBox1.Text = t.ToString();
                }
            }
            else
            {
                epDelete.SetError(button1, "Введите другие значения максимума и минимума или интенсивности");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {


        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {


        }

     /*   private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (model.Count() != 0)
            {
                model.Remove();
                for (int i = 0; i < model.Count(); i++)
                {
                    model.heapify(i);
                    listBox1.Items.Add(model.get(i));
                }
            }
            else
            {
                epDelete.SetError(button4, "Попытка удаления из пустой очереди");
            }
        }
        */

        private void button5_Click(object sender, EventArgs e)
        {
            moodel.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            timer1.Stop();
            for (int i = 0; i < model.Count(); i++)
            {
                listBox1.Items.Add(model.get(i));
            }
        }

        private void button6_Click(object sender, EventArgs e)

        {

            listBox1.Items.Clear();
            if (model.Count() != 0)
            {
                listBox1.Items.Add(model.Item());
            }
            else
            {
                listBox1.Items.Add("Очередь пуста");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            brst = Convert.ToInt32(numericUpDown2.Value);
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Increment = 0.1M;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        public void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal value = numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            decimal value = numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (brst <= brstm && intensity != 0)
            {
                if (moodel != null)
                {
                    moodel.NextTime();
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    listBox5.Items.Clear();
                    listBox4.Items.Clear();
                    listBox4.Items.Add("Количество процессов: " + moodel.Qtprocess.ToString());
                    listBox4.Items.Add("Количество завершенных процессов: " + moodel.resourseOneScheduler.SqtTermProc.ToString());
                    listBox4.Items.Add("Среднее время ожидания: " + moodel.resourseOneScheduler.MidWaitTime.ToString());
                    listBox4.Items.Add("Максимальная длина очереди: " + moodel.MaxCount.ToString());
                    listBox4.Items.Add("Среднее время оборота процесса: " + moodel.resourseOneScheduler.MidRoundTime.ToString());
                    listBox2.Items.Add(moodel.Cpu.ActiveProcess.ToString());
                    if (moodel.resourse.ActiveProcess != null)
                    {
                        listBox5.Items.Add(moodel.resourse.ActiveProcess.ToString());
                    }
                    moodel.ReadyQueue.ToArray();

                    foreach (Process i in moodel.ReadyQueue)
                    {
                        listBox1.Items.Add(i.ToString());
                    }
                    if (moodel.QueueToOne != null)
                    {
                        foreach (Process p in moodel.QueueToOne)
                        {
                            if (p != null)
                            {
                                listBox3.Items.Add(p.ToString());
                            }
                        }
                    }
                    t++;
                    textBox1.Text = t.ToString();
                }
            }
            else
            {
                epDelete.SetError(button1, "Введите другие значения максимума и минимума или интенсивности");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox5.Items.Clear();

            if (moodel.resourse.ActiveProcess != null)
            {
                moodel.resourseOneScheduler.Action = true;
                moodel.resourseOneScheduler.Rescheduling();
            }
            else
            {
                epDelete.SetError(button3, "Нечего выполнять");
            }
            if (moodel.QueueToOne != null)
            {
                foreach (Process p in moodel.QueueToOne)
                {
                    if (p != null)
                    {
                        listBox3.Items.Add(p.ToString());
                    }
                }
            }
            if (moodel.resourse.ActiveProcess != null)
            {
                listBox5.Items.Add(moodel.resourse.ActiveProcess.ToString());
            }
    
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}