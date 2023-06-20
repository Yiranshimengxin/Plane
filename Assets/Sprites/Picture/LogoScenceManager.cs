using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogoScenceManager : MonoBehaviour
{
    public AudioSource audioSource;
    public float time;
    private void Start()
    {
    }
    private void Update()
    {
        float timer = audioSource.clip.length;
        time += Time.deltaTime;
        if(time>=timer)
        {
            SceneManager.LoadScene(1);
        }
    }
}
