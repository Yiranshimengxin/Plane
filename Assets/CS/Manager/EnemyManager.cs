using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Dictionary<string, GameObject> enemys = new Dictionary<string, GameObject>();
    public Transform pointParent;

    public static EnemyManager _instance;
    public Transform enmeyBox;
    private void Awake()
    {
        _instance = this;
    }

    private void Init()
    {
        for (int i = 0; i < 7; i++)
        {
            string str = "Enemy" + i;
            enemys.Add(str, Resources.Load<GameObject>("Enemy/"+str));
        }
    }

    IEnumerator GeneEnemyTeam(TimePointData d)
    {
        for (int i = 0; i < d.num; i++)
        {
            GeneraceEnemy(d);
            yield return new WaitForSeconds(d.time);
        }
    }
      
    public void EnemyGroup(TimePoint data)
    {
        for (int i = 0; i < data.datas.Count; i++)
        {
            StartCoroutine(GeneEnemyTeam(data.datas[i]));
        }
    }

    GameObject GeneraceEnemy(TimePointData d)
    {
        GameObject go = Instantiate(enemys[d.str], 
            pointParent.GetChild(d.p).position,Quaternion.Euler(0,0,d.angle));
        go.transform.parent = enmeyBox;
        MoveEnemy move = go.GetComponent<MoveEnemy>();
        if (move)
        {
            move.SetMoveData(d.move);
        }
        go.tag = "Enemy";
        return go;
    }


    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
