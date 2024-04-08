using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAI : MonoBehaviour
{
    public static AnimatorAI Instance;
    public Animator player,enemy;
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
    }

    public void RunPlayer()
    {
        player.SetBool("IsRunPlayer",true);
        
    }

    public void StayPlayer()
    {
        player.SetBool("IsRunPlayer",false);
    }
    
    

    
}
