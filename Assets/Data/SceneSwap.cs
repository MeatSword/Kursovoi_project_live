using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void SceneSw(int k)
    {
        SceneManager.LoadScene(k);
    }
    public void SceneSwRazrab(int k)
    {
        SceneManager.LoadScene(k);
        StartData.razrabmode = true;
    }

    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
   
}
