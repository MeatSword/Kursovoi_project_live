using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChoiceWp(int k)
    {
        StartData.weaponchoice = k;
        SceneManager.LoadScene(2);
        Debug.Log("Click");
    }
    
}
