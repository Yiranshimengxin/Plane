using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadManager
{
    public static List<StageData> stageDatas = new List<StageData>();
    public static GameObject LoadObj(string n)
    {
        return Resources.Load<GameObject>("Prefab/" + n);
    }

    public static GameObject LoadObj(string n, Vector3 pos)
    {
        GameObject obj = LoadObj(n);
        return GameObject.Instantiate(obj, pos, Quaternion.identity);
    }

    public static void LoadData(string str)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Data/" + str);
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(textAsset.text.ToString().Trim());
        XmlElement root = xml.DocumentElement;

        XmlElement node = (XmlElement)root.SelectSingleNode("Stage");

        XmlNodeList nodeList = node.SelectNodes("StageData");

        foreach (XmlElement item in nodeList)
        {
            stageDatas.Add(GetStageData(item));
        }
    }

    static StageData GetStageData(XmlElement p)
    {
        XmlElement data = (XmlElement)p.SelectSingleNode("Data");
        StageData stage = new StageData();
        stage.index = int.Parse(data.GetAttribute("Index"));
        stage.bgName = data.GetAttribute("BG");
        stage.stageTime = int.Parse(data.GetAttribute("StageTime"));

        XmlElement timeLineData= (XmlElement)p.SelectSingleNode("TimeLineData");
        XmlNodeList list = timeLineData.SelectNodes("TimePoint");
        foreach (XmlElement item in list)
        {
            stage.AddTimePoint(GetTimePoint(item));
        }
        return stage;
    }

    static TimePoint GetTimePoint(XmlElement p)
    {
        TimePoint point = new TimePoint();
        XmlElement data= (XmlElement)p.SelectSingleNode("Data");
        point.time= int.Parse(data.GetAttribute("TLD"));
        XmlElement node = (XmlElement)p.SelectSingleNode("TimePointData");

        XmlNodeList list = node.ChildNodes;
        foreach (XmlElement item in list)
        {
            point.AddData(GetTimeData(item));
        }
        return point;
    }

    static TimePointData GetTimeData(XmlElement p)
    {
        TimePointData data = new TimePointData();
        data.num = int.Parse(p.GetAttribute("Num"));
        data.time = float.Parse(p.GetAttribute("Time"));
        data.str = p.GetAttribute("Str");
        data.p = int.Parse(p.GetAttribute("P"));
        data.angle = int.Parse(p.GetAttribute("Angle"));
        MoveEnemy me = new MoveEnemy();
        me.speed = float.Parse(p.GetAttribute("MoveSpeed"));
        me.turnDirc = int.Parse(p.GetAttribute("TurnDirc"));
        me.flyTime = int.Parse(p.GetAttribute("FlyTime"));
        me.turnAngle = int.Parse(p.GetAttribute("TurnAngle"));
        me.angleSpeed = int.Parse(p.GetAttribute("AngleSpeed"));
        data.move = me;
        return data;
    }

}
