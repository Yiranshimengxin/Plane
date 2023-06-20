using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData 
{
    public int index { set; get; }
    public string bgName { set; get; }
    public int stageTime { set; get; }

    public List<TimePoint> timeLine = new List<TimePoint>();

    public void AddTimePoint(TimePoint tp)
    {
        timeLine.Add(tp);
    }


}
