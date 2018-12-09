///////////////////////////////////////////////////////////////////////////////////
//                                                              
//  1. COIS 3320h Lab 2                       

//  2.  Oct 31st, 2018 - Batstone Christyanton & Nikolas Gordon

//  3.Purpose : "This project attempts to replicate different job type and job processes
//   to compare and measure the performance of each algorithm given different 
//   mixtures of job sizes. The metrics what are used for comparing all the 
//   process consist response times and turnaround times"

//  4. This is the main program that is calling on the methods and the properties from the job class and incorporating to run the passed values from the main.

//  5. Job count - is the amount of jobs that are being passed into each job methods to be created 
//     some of the quanta values are bing passed in as actual digits depending on which scheduling algorithim it is.
//     JOBc Object is being used to make diffrent types of jobs.
//     strings[] args are being passed as parameters into the main progra.
//
//  6.subroutines & libraries : random number gernartor for distrubtion of large and small jobs

//  7. we use two librarys in this program Math.numerics distrubution and also the math. numeric.statistics 
//   these librarys were altered to make random generated jobs with diffrent types of distrubutions
//
//  8 assumptions: this progam requires 2 librarys to creaate jobs and the jobs are sequentially added
//    using arrival times and then at the end we should have the avg respone time and turn around time for all the diffrent mehtods. 

//    The range of jobs can be between 1-2000 jobcounts. 
//
//                   
//
////////////////////////////////////////////////////////////////////
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
        static Random rndm = new Random(); //gloabl random
        /////////////////
        // Main Method //
        /////////////////
        /*holds in the the job creation, creation of the job types such as guassian and */
        static void Main(string[] args)
        {
            int jobCount = 2000; //creation of 1000 jobs
            JobC[] Process = Jobtype1(jobCount);// created a job object array that holds my job class
            JobC[] Process2 = JobType2(jobCount); // 80 small jobs 20 big jobs
            JobC[] Process3 = JobType3(jobCount); // 20 small jobs 80 big jobs
            int contextSwitches = 0;  // counts the number of switch from each job in the processor.

            // double global time variable
            // normal distrubuted arrival times for the jonbs

            // have 25 job prcess created uing the for loop below 
            // Layout of job process information 
            Console.WriteLine("Number of jobs: {0}", jobCount);
            Console.WriteLine("\t\t\t\tAvg Resp \t\t Avg Turn \t\t Context");
            Console.WriteLine(" \t\t\t\ttime \t\t\t time \t\t\t Switches ");
            Console.WriteLine(" _____________________________________________________________________________________ ");
            //string value used toget names for job process averages
            String[] JobString = { "FCFS normal   ", "FCFS 80/20   ", "FCFS 20/80   ", "SJF normal   ", "SJF 80/20    ", "SJF 20/80    ",
                                    "PSJF normal   ", "PSJF 80/20   ", "PSJF 20/80   ", "RR normal Q 50","RR normal Q 75",
                                        "RR 80/20 Q 50", "RR 80/20 Q 75", "RR 20/80 Q 50","RR 20/80 Q 75" };
            //FCFS processes
            //creates FCFS process and sends values to print method
            contextSwitches = FCFS(Process);
            Print(Process, contextSwitches, JobString[0]);

            contextSwitches = FCFS(Process2);
            Print(Process2, contextSwitches, JobString[1]);

            contextSwitches = FCFS(Process3);
            Print(Process3, contextSwitches, JobString[2]);

            //reset process values//
            //Reset values for each process due to there being more than one scheduler type
            for (int i = 1; i < jobCount; i++)
            {
                Process[i].ResetAll(); //calls reset function
            }
            Process = Jobtype1(jobCount);

            for (int i = 1; i < jobCount; i++)
            {
                Process2[i].ResetAll();
            }
            Process2 = JobType2(jobCount);

            for (int i = 1; i < jobCount; i++)
            {
                Process3[i].ResetAll();
            }
            Process3 = JobType3(jobCount);

            //SJF jobs
            //Reset values for each process due to there being more than one scheduler type
            contextSwitches = Sjf(Process, 40);
            Print(Process, contextSwitches, JobString[3]);

            contextSwitches = Sjf(Process2, 40);
            Print(Process2, contextSwitches, JobString[4]);

            contextSwitches = Sjf(Process3, 40);
            Print(Process3, contextSwitches, JobString[5]);

            //reset processs values
            for (int i = 1; i < jobCount; i++)
            {
                Process[i].ResetAll();
            }
            Process = Jobtype1(jobCount);

            for (int i = 1; i < jobCount; i++)
            {
                Process2[i].ResetAll();
            }
            Process2 = JobType2(jobCount);

            for (int i = 1; i < jobCount; i++)
            {
                Process3[i].ResetAll();
            }
            Process3 = JobType3(jobCount);

            //PSJF processes
            //Reset values for each process due to there being more than one scheduler type
            contextSwitches = PSjf(Process, 40);
            Print(Process, contextSwitches, JobString[6]);

            contextSwitches = PSjf(Process2, 40);
            Print(Process2, contextSwitches, JobString[7]);

            contextSwitches = PSjf(Process3, 40);
            Print(Process3, contextSwitches, JobString[8]);
            //reset process values
            for (int i = 1; i < jobCount; i++)
            {
                Process[i].ResetAll();
            }
            Process = Jobtype1(jobCount);

            for (int i = 1; i < jobCount; i++)
            {
                Process2[i].ResetAll();
            }
            Process2 = JobType2(jobCount);

            for (int i = 1; i < jobCount; i++)
            {
                Process3[i].ResetAll();
            }
            Process3 = JobType3(jobCount);
            //Round robin processes
            //Reset values for each process due to there being more than one scheduler type
            contextSwitches = RoundRobin(Process, 50);

            Print(Process, contextSwitches, JobString[9]);
            for (int i = 1; i < jobCount; i++)
            {
                Process[i].ResetAll();
            }
            Process = Jobtype1(jobCount);

            contextSwitches = RoundRobin(Process, 75);
            Print(Process, contextSwitches, JobString[10]);

            contextSwitches = RoundRobin(Process2, 50);

            Print(Process2, contextSwitches, JobString[11]);

            for (int i = 1; i < jobCount; i++)
            {
                Process2[i].ResetAll();
            }
            Process2 = JobType2(jobCount);

            contextSwitches = RoundRobin(Process2, 75);
            Print(Process2, contextSwitches, JobString[12]);

            contextSwitches = RoundRobin(Process3, 50);

            Print(Process3, contextSwitches, JobString[13]);

            for (int i = 1; i < jobCount; i++)
            {
                Process3[i].ResetAll();
            }
            Process3 = JobType3(jobCount);

            contextSwitches = RoundRobin(Process3, 75);
            Print(Process3, contextSwitches, JobString[14]);

            Console.ReadLine(); //holds screen
        }





        // creates the  guassian jobs based upon the parameters given from main returns job times
        public static JobC[] Jobtype1(int numJobs)

        {
            var gausianarrtime = new Normal(160, 15); //creation of normal disbution
            var firstInstance = new Normal(150, 20);  //initial job length of a class
            JobC[] jobs = new JobC[numJobs]; //job class creation, used to fill in each job with its times
            double arrival = 0; //initializes arrival to be 0
            for (int i = 0; i < numJobs; i++) //for loop used to populate each jobclass with the times used
            {
                arrival += gausianarrtime.Sample(); //sets the arrival for each incremeted job, 
                jobs[i] = new JobC(firstInstance.Sample(), arrival);// instanianting the process job array with runtime and job arrival time and time taken
                // Console.WriteLine(" Jruntime :" + Process[i].JobLength + "   JArrivalTime: " + Process[i].JobArrival)
            }
            return jobs;//returns the values of the job class

        }
        //80/20 jobs
        // creates the  80/20 jobs based upon the parameters given from main returns job times
        public static JobC[] JobType2(int numJobs)
        {
            var gausianarrtime = new Normal(160, 15); //guassian normal for arrival times
            JobC[] jobs = new JobC[numJobs]; //create jobs
            var large = new Normal(250, 50);//creation of large normal distrubution
            var small = new Normal(50, 5);  //creation of small normal distrubution
            double arrival = 0;

            for (int i = 0; i < numJobs; i++) //for loop used to populate jobs
            {
                arrival += gausianarrtime.Sample(); //arrival is set and incremented for each incomming job
                if (rndm.NextDouble() >= 0.8) //if the random number is greater than .8, it creates a large job, else makes a small job
                {
                    jobs[i] = new JobC(large.Sample(), arrival);// instanianting the process job array with runtime and job arrival time and time taken
                }
                else
                {
                    jobs[i] = new JobC(small.Sample(), arrival);// instanianting the process job array with runtime and job arrival time and time taken
                }
            }
            return jobs;//return job information
        }
        //20/80 jobs
        // creates the  20/80 jobs based upon the parameters given from main returns job times
        public static JobC[] JobType3(int numJobs)
        {
            JobC[] jobs = new JobC[numJobs]; //create jobs
            var large = new Normal(250, 50);//large jobs
            var small = new Normal(50, 5); //small jobs
            var gausianarrtime = new Normal(160, 15); //gussian normal
            double arrival = 0;//arrival initialized 

            for (int i = 0; i < numJobs; i++)//for lopp used to populate jobclass

            {
                arrival += gausianarrtime.Sample(); //creates arrival times based on guassian normal and increments for each job, a sum.
                if (rndm.NextDouble() <= 0.8)//if the random number between 0 and 1 is less than 0.8 creates a  large job and otherwise creates a small job
                {
                    jobs[i] = new JobC(large.Sample(), arrival);// instanianting the process job array with runtime and job arrival time and time taken

                }

                else
                {
                    jobs[i] = new JobC(small.Sample(), arrival);//creation of small jobs
                }

            }

            return jobs; //return job times

        }
        ////////////////////////////////////
        //  First Come Fist Serve method  //
        ////////////////////////////////////
        // The first come first serve method takes in the job process and returns length also known as context switches
        public static int FCFS(JobC[] Process)
        {
            double globalTime = 0; //globaltime variable used to imitate the time of each process


            for (int i = 0; i < Process.Length; i++)//forloop to process jobs

            {
                if (globalTime < Process[i].JobArrival)// if the global time is 0 then set the startime to job arrival and global time to jobarrival+joblength+

                {
                    globalTime = Process[i].JobArrival;
                    Process[i].StarTime = globalTime;// setting the start time of the jobs to the arrival times of the hobs
                    globalTime += Process[i].JobLength; // updating the global time of the clock to jobarrival time plus the job length time which equals the completion time 
                    //Console.WriteLine(Process[i].JobLength);

                }

                else
                {
                    Process[i].StarTime = globalTime;// if the global time is not less than job arrival time then set the start time to the global time 
                    globalTime += Process[i].JobLength;// adding the global time to the process job length time to increase it 


                }

                Process[i].EndTime = globalTime; // set the endtime to be global time. 



                //Console.WriteLine("GlobalTime :" + globalTime[i] + "    Jruntime :" + Process[i].JobLength + "   JArrivalTime: " + Process[i].JobArrival + "  JExecution   " + timeTaken[i]);
                //Console.WriteLine("Total Time "+globalTime[i] + "JobArrival " + Process[i].JobArrival+ " Job Runtime " + Process[i].JobLength);
            }

            return Process.Length; //returns the new job runtime

        }
        ////////////////////////////
        //   SHortest-Job First   //
        ////////////////////////////
        //shortest job first takes in process job class and the job number and returns context switches
        public static int Sjf(JobC[] Process, int numJobs)
        {
            JobC temp = new JobC(); //tempary jobClass used
            double globalTime = 0;

            // time taken 
            for (int i = 0; i < Process.Length; i++)// first for loop 
            {
                temp = null;

                // if (Process[i].JobLength > 0)// see if job has arrived 


                for (int j = 0; j < Process.Length; j++)// second for loop 
                {
                    if (Process[j].JobArrival <= globalTime && Process[j].Status == false) // checking if arrival time is less than global time 
                    {
                        if (temp == null) //if temp node is empty set it to the current process
                        {

                            temp = Process[j];
                        }
                        else if (Process[j].JobLength < temp.JobLength) //if the job unit time is less than the temporary job length, set it to the current process
                        {
                            temp = Process[j];

                        }
                    }
                }


                if (temp != null)// if shortest jobs 

                {
                    //if temp is not null set the temporray startitme to the global time
                    temp.StarTime = globalTime;

                    globalTime += temp.JobLength; //globalTime is the sum of temp job lengths
                    temp.EndTime = globalTime; //EndTime

                    temp.Status = true; //the tempory job is processed

                }
                else //if temp is empty
                {
                    globalTime = Process[i].JobArrival;//globaltime set to the process job arrival
                    Process[i].StarTime = globalTime;//startme set tothe value of global time
                    globalTime += Process[i].JobLength; //globalTime is the sum of process job lengths
                    Process[i].EndTime = globalTime; //endtime of the process is equal to this golbal time
                    Process[i].Status = true; //return process status as being done
                }
            }
            return Process.Length;
        }

        ////////////////////////////////////
        //  Preemptive Shortest Job First //
        ////////////////////////////////////
        //pre-emptive shortest job first takes in the initial job class and quanta time, returns 
        public static int PSjf(JobC[] Process, double pTime)
        {
            JobC temp = new JobC();// temp job object which has nothing in it 
            JobC Cswithc = new JobC();// making another temp job for context switches, used as comparison for the temp
            int switc = 0; //context switch
            double globalTime = 0; //clock that keeps track of the sum of job unit times

            // time taken 
            do
            {
                temp = null;

                // if (Process[i].JobLength > 0)// see if job has arrived 
                // makes the job arrive and sets temp to be equal the process job 
                for (int j = 0; j < Process.Length; j++)
                {

                    if (globalTime < Process[j].JobArrival && temp == null) //if globalTime is lest than the instance of the arrival time 
                    {                                                           //and there is no shortest job set the temp to this instance
                        temp = Process[j];
                        break;
                    }
                    else if (Process[j].JobArrival <= globalTime && Process[j].Status == false) // checking if arrival time is less than global time 
                    {
                        if (temp == null)
                        {
                            temp = Process[j];//if temporary node is empty, set to the instance of process
                        }
                        else if (Process[j].RemaningRuntime < temp.RemaningRuntime)
                        {
                            temp = Process[j]; //if remaining runtime of the instnce is less than the temporary
                                               //set temp equal to that process
                        }
                    }
                }
                if (temp != null)// if shortest jobs 

                {   ///procesinng jobs 
                    if (temp.JobArrival > globalTime) //if temp Arrival is less than global time, temp  is set
                    {
                        globalTime = temp.JobArrival;
                    }
                    //if temp.startTime is less than zero set temp startime to globall time
                    if (temp.StarTime < 0)
                    {
                        temp.StarTime = globalTime;
                    }

                    if (temp.RemaningRuntime <= pTime)
                    {
                        //if the remaining temp runtime is less than the quanta, finish the job
                        globalTime += temp.RemaningRuntime;
                        temp.RemaningRuntime = 0;
                        temp.EndTime = globalTime;
                        temp.Status = true;
                    }

                    else
                    {
                        globalTime += pTime;//global sum of the quanta
                        temp.RemaningRuntime -= pTime; //if temp is greater than quanta, subtract quanta to time remaining
                    }
                    if (temp != Cswithc)//every time temp is not equal to the normal job process, a contect switch occurs
                    {
                        switc++;
                    }

                    Cswithc = temp;

                }
            } while (temp != null); //while the temp node is not empty
            return switc;//return context switch
        }

        /////////////////////////////
        //   RoundRobin method     //
        /////////////////////////////
        // Roundrobin takes in the initial job process and quanta and returns 
        public static int RoundRobin(JobC[] Process, double pTime)
        {
            JobC temp = new JobC();// temp job object which has nothing in it 
            JobC Cswithc = new JobC();// making another temp job for context switches 
            int switc = 0;
            double globalTime = 0;

            // arrival of jobs 
            do
            {
                temp = null;
                // if (Process[i].JobLength > 0)// see if job has arrived 
                // makes the job arrive and sets temp to be equal the process job 
                for (int j = 0; j < Process.Length; j++)
                {

                    if (globalTime < Process[j].JobArrival && temp == null)
                    {
                        // clock to jobarrival time plus the job length time which equals the completion time 
                        temp = Process[j];
                    }
                    else if (Process[j].JobArrival <= globalTime && Process[j].Status == false) //else set temp to process instance
                    {
                        temp = Process[j];

                    }

                }

                if (temp != null)// if shortest jobs 

                {   ///procesinng jobs 
                    //same way of processing jobs of PSJF
                    if (temp.JobArrival > globalTime)
                    {
                        globalTime = temp.JobArrival;
                    }
                    if (temp.StarTime < 0)
                    {
                        temp.StarTime = globalTime;
                    }

                    if (temp.RemaningRuntime <= pTime)
                    {
                        globalTime += temp.RemaningRuntime;
                        temp.RemaningRuntime = 0;
                        temp.EndTime = globalTime;
                        temp.Status = true;
                    }

                    else
                    {
                        globalTime += pTime;
                        temp.RemaningRuntime -= pTime;

                    }

                    if (temp != Cswithc)
                    {
                        switc++;
                    }

                    Cswithc = temp;
                }
            } while (temp != null);

            return switc;//return context switches
        }
        ////////////////////////
        //    Print method   ///
        ////////////////////////
        //Print method takes in the current job process, context switch and scheduler description known as jobstring
        public static void Print(JobC[] Process, int contextSwitches, String JobString)
        {
            double Tsum = 0; //variable used as a sum of turn-around times
            double Rsum = 0; //variable used as a sum of response times

            for (int i = 0; i < Process.Length; i++) //for loop used to populate summation
            {
                Rsum += Process[i].StarTime - Process[i].JobArrival; //formulae for response time
                Tsum += Process[i].EndTime - Process[i].JobArrival;  //formulae for turnaraound time
            }
            Tsum /= Process.Length; //average of turnaround time formula
            Rsum /= Process.Length;  //average of rsponse time formula

            Console.WriteLine("{0}   \t\t {1} \t   {2}\t {3}", JobString, Rsum, Tsum, contextSwitches); //prints values

        }

    }
}
