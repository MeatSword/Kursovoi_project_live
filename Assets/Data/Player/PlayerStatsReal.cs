using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsReal : MonoBehaviour
{
    public PlayerStats PlayerStats;
    public static PlayerStatsReal Instance;
    public int HP, EXP;

    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        HP = PlayerStats.Hp;
        EXP = PlayerStats.Exp;
        speed = PlayerStats.Speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
