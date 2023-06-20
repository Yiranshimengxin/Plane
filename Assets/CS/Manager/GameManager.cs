using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ToolType { None=-1, Bomb=0, Health=1, Fire=2, Thunder=3, Heart=4 };

public class GameManager : MonoBehaviour
{
    int playerIndex = 0;
    public Transform playerSelectPanel;
    public Transform MainPanel;
    public static Vector2 xWidth = new Vector2(-2.2f, 2.2f);
    public static Vector2 yHeight = new Vector2(-4.5f, 4.5f);
    public static float planeZ = -5;

    int[] nums;


    public GameObject myPlane;

    public static GameManager _instance;

    public Transform bgParent;
    public GameObject UIPanel;
    public Transform textStar;
    public Text textGold;
    public Text textBomb;
    public Image imageHp;
    public Image imageHead;
    int goldNum;
    public int stageIdx { set; get; }
    public Transform bulletBox;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        LoadManager.LoadData("Xml");
        Weapon.SetMyWeapon();
    }

    private void ResetGame(int n)
    {
        CleanBox(bulletBox);
        CleanBox(EnemyManager._instance.enmeyBox);
        StageData data = LoadManager.stageDatas[n];
        GameStage gs = GetComponent<GameStage>();
        if (gs)
        {
            Destroy(gs);
        }
        SetBg(data.bgName);
        gs = gameObject.AddComponent<GameStage>();
        gs.SetGameStage(data);
        gs.StageStart();
        //
    }

    public void CleanBox(Transform t)
    {
        for (int i = 0; i < t.childCount; i++)
        {
            Destroy(t.GetChild(i).gameObject);
        }
    }

    public void ShowUI(string n)
    {
        StartCoroutine(Show(n));
    }

    IEnumerator Show(string n)
    {
        Sprite sprite = Resources.Load<Sprite>("UI/" + n);
        UIPanel.GetComponent<Image>().sprite = sprite;
        UIPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        UIPanel.SetActive(false);
    }

    public void NextStage()
    {
        stageIdx++;
        if (stageIdx>=LoadManager.stageDatas.Count)
        {
            return;
        }
        print(stageIdx);
        ResetGame(stageIdx);
    }

    public void AddGold(int num)
    {
        goldNum += num;
        textGold.text = goldNum.ToString();
    }

    public void AddStar()
    {
        GameObject go = LoadManager.LoadObj("Star");
        Instantiate(go,textStar);
    }

    public void UpdateHp(float f)
    {
        imageHp.fillAmount = f;
    }

    public void UpdateBomb(int num)
    {
        textBomb.text = num.ToString();
    }

    void SetBg(string bg)
    {
        Sprite sprite = Resources.Load<Sprite>("BG/"+bg);
        foreach (Transform item in bgParent)
        {
            foreach (Transform t in item)
            {
                t.GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
    }


    public void SelectPlayer(int num)
    {
        playerSelectPanel.GetChild(playerIndex).gameObject.SetActive(false);
        playerIndex += num;
        //foreach (Transform item in playerSelectPanel)
        //{
        //    item.gameObject.SetActive(false);
        //}
        playerIndex = Mathf.Clamp(playerIndex, 0, 2);
        playerSelectPanel.GetChild(playerIndex).gameObject.SetActive(true);
    }

    public void StartFight()
    {
        MainPanel.gameObject.SetActive(false);
        StartCoroutine(CloudManager());
        //playerIndex = Random.Range(0,3);
        myPlane = LoadManager.LoadObj("Plane" + playerIndex, new Vector3(0, 0, -5));
        myPlane.tag = "Player";
        myPlane.name = "Plane" + playerIndex;
        imageHead.sprite = Resources.Load<Sprite>("Head/"+playerIndex);
        ResetGame(0);
    }

    IEnumerator CloudManager()
    {
        while (true)
        {
            float r = Random.Range(1.5f, 5.5f);
            GeneraceCloud();
            yield return new WaitForSeconds(r);
        }
    }

    void GeneraceCloud()
    {
        float x = Random.Range(-2.5f, 2.5f);
        GameObject c = LoadManager.LoadObj("Cloud", new Vector3(x, 6.5f, -1));
        //GameObject c = Instantiate(Cloud,new Vector3(x,6.5f,-1),Quaternion.identity);
        float scale = Random.Range(0.3f, 0.8f);
        c.transform.localScale = Vector3.one * scale;
        float alpha = Random.Range(0.4f, 1);
        c.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
    }

    void Update()
    {
        
    }

    public static void PlayAudio(string n)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + n);
        AudioSource.PlayClipAtPoint(clip, _instance.transform.position);
    }

    public static Vector3 GetRandomPos()
    {
        float x = Random.Range(xWidth.x, xWidth.y);
        float y = Random.Range(yHeight.x, yHeight.y);
        return new Vector3(x, y, planeZ);
    }

    public static Vector3 GetRandomPosOut()
    {
        float x = Random.Range(5, 10) * Mathf.Pow(-1, Random.Range(0, 2));
        float y = Random.Range(5, 10) * Mathf.Pow(-1, Random.Range(0, 2)); 
        return new Vector3(x, y, planeZ);
    }
}
