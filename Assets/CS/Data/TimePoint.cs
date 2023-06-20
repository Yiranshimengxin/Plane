using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct TimePointData
{
    public int num { set; get; }
    public float time { set; get; }
    public string str { set; get; }
    public int p { set; get; }
    public float angle { set; get; }

    public MoveEnemy move { set; get; }

    public TimePointData(int _num,float _time,string _str,int _p,float _angle,MoveEnemy _move)
    {
        num = _num;
        time = _time;
        str = _str;
        p = _p;
        angle = _angle;
        move = _move;
    }
    
}

public class TimePoint
{
    public float time { set; get; }
    public List<TimePointData> datas = new List<TimePointData>();

    public TimePoint(float _time,List<TimePointData> _data)
    {
        time = _time;
        datas = _data;
    }

    public TimePoint()
    {

    }

    public void AddData(TimePointData tpd)
    {
        datas.Add(tpd);
    }
}

