using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;

namespace ConsoleApp13

{


    class Program
    {


        static void Main(string[] args)
        {
            int jobCount = 5;
            JobC[] Process = Jobtype1(jobCount);// created a job object array that holds my job class
            JobC[] Process2 = JobType2(jobCount);
            JobC[] Process3 = JobType3(jobCount);

            // double global time variable
            // normal distrubuted arrival times for the jonbs
            double[] resposetime = new double[1000];// response time array. 
            double summ = 0;

            // have 25 job prcess created uing the for loop below 


            //
            int contextSwitches = fcfs(Process);
            // fcfs(Process2);
            // fcfs(Process3);
            // Print(Process, contextSwitches);
            //Print(Process2, contextSwitches);
            // Print(Process3, contextSwitches);

            Sjf(Process,0);
            Print(Process, contextSwitches);










            Console.ReadLine();
        }

        /* should i be using one array or instead switche to a que,`
         * 
         * how do i add up the first gaussian arrival time with the second job arrival time that is being created
         * */



        public static JobC[] Jobtype1(int numJobs)

        {
            var gausianarrtime = new Normal(160, 15);
            var firstInstance = new Normal(150, 20);
            double runtime1 = 0;
            JobC[] jobs = new JobC[numJobs];
            runtime1 = firstInstance.Sample();

            for (int i = 0; i < numJobs; i++)

            {
                jobs[i] = new JobC(runtime1, gausianarrtime.Sample());// instanianting the process job array with runtime and job arrival time and time taken


                // Console.WriteLine(" Jruntime :" + Process[i].JobLength + "   JArrivalTime: " + Process[i].JobArrival);

            }
            return jobs;


        }

        public static JobC[] JobType2(int numJobs)
        {
            Random rndm = new Random();

            var gausianarrtime = new Normal(160, 15);
            JobC[] jobs = new JobC[numJobs];
            double runtimel = 0;
            double runtime2 = 0;
            var large = new Normal(250, 50);
            var small = new Normal(50, 5);
            double rand = rndm.NextDouble() * (1 - 0);


            if (rand >= 0.8)
            {

                runtimel = large.Sample();

                for (int i = 0; i < numJobs; i++)

                {
                    jobs[i] = new JobC(runtimel, gausianarrtime.Sample());// instanianting the process job array with runtime and job arrival time and time taken




                }
            }
            else
            {


                runtime2 = small.Sample();


                for (int i = 0; i < numJobs; i++)

                {
                    jobs[i] = new JobC(runtime2, gausianarrtime.Sample());// instanianting the process job array with runtime and job arrival time and time taken


                    // Console.WriteLine(" Jruntime :" + Process[i].JobLength + "   JArrivalTime: " + Process[i].JobArrival);

                }



            }






            return jobs;
        }

        public static  JobC[]JobType3(int numJobs)
        {
            JobC[] jobs = new JobC[numJobs];
            Random rndm = new Random();
            var large = new Normal(250, 50);
            var small = new Normal(50, 5);
            var gausianarrtime = new Normal(160, 15);
            double runtime3 = 0;

            double rand = rndm.NextDouble() * (1 - 0);



            if (rand <= 0.8)
            {

                runtime3 = large.Sample();
                for (int i = 0; i < numJobs; i++)

                {
                    jobs[i] = new JobC(runtime3, gausianarrtime.Sample());// instanianting the process job array with runtime and job arrival time and time taken


                    // Console.WriteLine(" Jruntime :" + Process[i].JobLength + "   JArrivalTime: " + Process[i].JobArrival);

                }

            }
            else
            {
                runtime3 = small.Sample();

                for (int i = 0; i < numJobs; i++)

                {
                    jobs[i] = new JobC(runtime3, gausianarrtime.Sample());// instanianting the process job array with runtime and job arrival time and time taken


                    // Console.WriteLine(" Jruntime :" + Process[i].JobLength + "   JArrivalTime: " + Process[i].JobArrival);

                }
            }



            return jobs;
        }


        public static int fcfs(JobC[] Process)
        {
            double globalTime = 0;

            for (int j = 1; j < Process.Length; j++)
            {
                Process[j].JobArrival += Process[j - 1].JobArrival;     // incrementing the job arrival time by adding the job arrival to the next index of the arraywith itself 
            }

            for (int i = 0; i < Process.Length; i++)

            {
                if (globalTime < Process[i].JobArrival)// if the global time is 0 then set the startime to job arrival and global time to jobarrival+joblength+

                {
                    Process[i].starTime = Process[i].JobArrival;

                    globalTime = Process[i].JobArrival + Process[i].JobLength;

                    //Console.WriteLine(startTime);

                }

                else
                {
                    Process[i].starTime = globalTime;
                    globalTime += Process[i].JobLength;


                }

                Process[i].endTime = globalTime;



                //Console.WriteLine("GlobalTime :" + globalTime[i] + "    Jruntime :" + Process[i].JobLength + "   JArrivalTime: " + Process[i].JobArrival + "  JExecution   " + timeTaken[i]);
                //Console.WriteLine("Total Time "+globalTime[i] + "JobArrival " + Process[i].JobArrival+ " Job Runtime " + Process[i].JobLength);
            }

            return Process.Length;

        }

        public static int Sjf(JobC[] Process, int numJobs)
        {
            double globalTime = 0;
          
            for (int j = 1; j < Process.Length; j++)
            {
                Process[j].JobArrival += Process[j - 1].JobArrival;     // incrementing the job arrival time by adding the job arrival to the next index of the arraywith itself 
            }

            for (int i = 0; i < Process.Length; i++)
            {
                Process.Min();
            }
       

            
            






            //Console.WriteLine("GlobalTime :" + globalTime[i] + "    Jruntime :" + Process[i].JobLength + "   JArrivalTime: " + Process[i].JobArrival + "  JExecution   " + timeTaken[i]);
            //Console.WriteLine("Total Time "+globalTime[i] + "JobArrival " + Process[i].JobArrival+ " Job Runtime " + Process[i].JobLength);



            return Process.Length;
            }

            public static void Print(JobC[] Process, int contextSwitches)
        {
            double Tsum = 0;
            double Rsum = 0;

            for (int i = 0; i < Process.Length; i++)
            {
                Rsum += Process[i].starTime - Process[i].JobArrival;
                Tsum += Process[i].endTime - Process[i].JobArrival;


            }



            Tsum /= Process.Length;
            Rsum /= Process.Length;

           
            Console.WriteLine("{0}    {1}    {2}",Rsum,Tsum, contextSwitches);



            for (int i = 0; i < 10; i++)
            {
                // Console.WriteLine(startTime[i] + "  " + endTime[i]);
            }
        }

    }
}
// shorte job first  make sure to up the time to the when the job arrived and then after it leaves up the global time to that time 