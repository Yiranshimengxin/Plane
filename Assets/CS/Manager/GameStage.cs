using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage : MonoBehaviour
{
    public int index { set; get; }
    public string bgName { set; get; }
    public int stageTime { set; get; }
    public float startTime { set; get; }
    bool UITrue;

    public List<TimePoint> timeLine = new List<TimePoint>();
    public void SetGameStage(StageData data)
    {
        stageTime = data.stageTime;
        bgName = data.bgName;
        index = data.index;
        timeLine = data.timeLine;
    }

    public void StageStart()
    {
        startTime = Time.time;
        StartCoroutine(CheckPoint());
    }
    
    IEnumerator CheckPoint()
    {
        while (timeLine.Count!=0)
        {
            if (Time.time-startTime>timeLine[0].time)
            {
                EnemyManager._instance.EnemyGroup(timeLine[0]);
                timeLine.RemoveAt(0);
            }
            if (Time.time - startTime > stageTime&& !UITrue)
            {
                UITrue = true;
                GameManager._instance.ShowUI("Warning");
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        
    }
}
