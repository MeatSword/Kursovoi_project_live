using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public float timeSec = 0, timeMin = 0, timeMinPast = 0,timeSecNull=0;
    public bool start;
    public TextMeshProUGUI value,notification;
    private Slider slider;
    public void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this; 
        }
        start = true;
        notification.gameObject.SetActive(false);
        slider= GameObject.Find("BossBar").GetComponent<Slider>();
        slider.gameObject.SetActive(false);
    }
    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(2f);
        notification.gameObject.SetActive(false);
    }

    public void TimerSet()
    {
        timeSec = 56f;
        timeMin = 4;
    }
    void FixedUpdate()
    {
        timeMinPast = timeMin;
        if (start&&value!=null) 
        {
            timeSec += Time.deltaTime;
            timeSecNull+=Time.deltaTime;
            value.text =timeMin+":"+ timeSec.ToString("00");
        }
        if (timeSec == 59f || timeSec > 59f)
        {
            timeSec = 0;
            timeMin++;
        }

        if (timeMin > timeMinPast && timeMin!=5)
        {
            notification.text = "Враги стали сильнее!";
            notification.gameObject.SetActive(true);
            StartCoroutine(Activate());
        }
        else if(timeMin==4 && timeSec>=58)
        {
            notification.text = "Появился босс!";
            notification.gameObject.SetActive(true);
            StartCoroutine(Activate());
            slider.gameObject.SetActive(true);
        }
        
        if (timeMin==0 && timeSec>=30 )
        {
            EnemyStatsReal.Instance.spawnReload = 1f;
        }
        if (timeMin==2)
        {
            EnemyStatsReal.Instance.spawnReload = 0.5f;
        }
        if (timeMin == 2)
        {
            
        }
        
    }
}
