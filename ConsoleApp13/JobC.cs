using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class JobC 
{

    private double _jobLength;
    private double _arrivalTime;
    private double _timeTaken;
    private double _startTime;
    private double _endTime;

    public JobC() { }

    public JobC(double jobLength, double arrivalTime)
    {
        this._jobLength = jobLength;
        this._arrivalTime = arrivalTime;
        this._timeTaken = 0;
        this._startTime = 0;
        this._endTime = 0;
    }
    public double JobLength
    {
        get { return _jobLength; }
        set { this._jobLength = value; }
    }
    public double JobArrival
    {
        get { return _arrivalTime; }
        set { this._arrivalTime = value; }
    }

    public double TimeTaken
    {
        get { return _timeTaken; }
        set { this._timeTaken = value; }
    }

    public double starTime
    {
        get { return _startTime; }
        set { this._startTime = value; }
    }


    public double endTime
    {
        get { return _endTime; }
        set { this._endTime = value; }
    }

}
   



