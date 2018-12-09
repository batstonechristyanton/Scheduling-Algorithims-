///////////////////////////////////////////////////////////////////////////////////
//                                                              
//  1. COIS 3320h Lab 2                       
//
//  2. Oct 31st, 2018 - Batstone Christyanton & Nikolas Gordon
//
//  3.Purpose : " Constructor class of our jobs being used by the main program "
//
//  4. This job class has default values and also properties are being made. The getters and setters of a job is being formed in this class.
//
//  6.subroutines & libraries : random number gernartor for distrubtion of large and small jobs and jobs of the normal gaussian amount.
//
//  7. we use two librarys in this program Math.numerics distrubution and also the math. numeric.statistics 
//   these librarys were altered to make random generated jobs with diffrent types of distrubutions
//
//  8. There is no assumption for this class because it is used in the methods in the program class where it is be get and set.
//
////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class JobC
{
    //fields for the jobs
    private double _jobLength;
    private double _arrivalTime;
    private bool _status;
    private double _startTime;
    private double _endTime;
    private double _remaningRuntime;

    public JobC() { } // no value costructor
    /*value constructor takes in job length and arrival times, and sets the the important notions to the defaults
     */
    public JobC(double jobLength, double arrivalTime) //
    {
        this._jobLength = jobLength;
        this._arrivalTime = arrivalTime;
        this._remaningRuntime = _jobLength;
        this._status = false;
        this._startTime = -1;
        this._endTime = -1;
    }
    //getters and setters
    //Joblength deals with joblength or sets values of job length
    public double JobLength
    {
        get { return _jobLength; }
        set { this._jobLength = value; }
    }
    //Jobarrival constrctor deals with job arrival or sets values of job arrival
    public double JobArrival
    {
        get { return _arrivalTime; }
        set { this._arrivalTime = value; }
    }
    // Status constructor deals with stuatus of the job or sets values of status
    public bool Status
    {
        get { return _status; }
        set { this._status = value; }
    }
    //Starttime contructor deals with getting Starttimes or sets values of Start times.
    public double StarTime
    {
        get { return _startTime; }
        set { this._startTime = value; }
    }

    //EndTime constructor deals with getiing endTimes and setting endtimes useful for schedulers that deal with quantas
    public double EndTime
    {
        get { return _endTime; }
        set { this._endTime = value; }
    }

    //RemainingRuntime constructor deals with RemainingRuntime or sets values of RemainingRuntime
    public double RemaningRuntime
    {
        get { return _remaningRuntime; }
        set { this._remaningRuntime = value; }
    }
    /*reset method used to clear process value used in the print method in main, does not take in parameters
     very usefull for */
    public void ResetAll()
    {
        //resets status, starttime, and endtime
        this._status = false;
        this._startTime = -1;
        this._endTime = -1;
    }




}




