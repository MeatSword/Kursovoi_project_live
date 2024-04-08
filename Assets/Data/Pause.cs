using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }

    public void PauseButton()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeButton()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
