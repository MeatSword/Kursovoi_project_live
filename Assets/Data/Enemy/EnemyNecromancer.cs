using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class EnemyNecromancer : AIEnemy
{
    public Vector2[] SpawnPoints = new Vector2[7];
    public GameObject[] ListEnemies;
    
    private Slider slider;
    private int _rand, _radius = 10;
    private Random rnd = new Random();
    private bool reload;
    private float dist;
    private float range;

    private void Awake()
    {
        range=EnemyStatsReal.Instance._bossNecromancer.distance;
        slider = GameObject.Find("BossBar").GetComponent<Slider>();
        
    }
    private void Update()
    {
        if (an.GetBool("IsDeath") == false)
        {
            if (reload == false)
            {
                dist = Vector2.Distance(transform.position, player.transform.position);
            }
            
            if (dist > range)
            {
                an.SetBool("IsAttack", false);
                _may = true;
            }
            else
            {
                if (reload == false)
                {
                    StartCoroutine(Attack());
                }
                _may = false;
            }
        }
        slider.value = EnemyStatsReal.Instance._bossNecromancer.hp;
        
    }

    IEnumerator Attack()
    {
        reload = true;
        an.SetBool("IsAttack",true);
        
        yield return new WaitForSeconds(2f);
        if (an.GetBool("IsDeath") == false)
        {
            Spawn();
        }

        reload = false;
    }
    
    public void Spawn()
    {
        for (int i = 0; i < 2; i++)
        {
            _rand = rnd.Next(0, 7);
            SpawnPosition();
            if (_rand == 1)
            {
                Instantiate(ListEnemies[1], SpawnPoints[i], Quaternion.identity);
            }
            else
            {
                Instantiate(ListEnemies[0], SpawnPoints[i], Quaternion.identity);
            }
        }
        
    }

    private void SpawnPosition()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            if (i == 0)
            {
                SpawnPoints[i] = new Vector2(transform.position.x + _radius, transform.position.y);
                
            }

            if (i == 1)
            {
                SpawnPoints[i] = new Vector2(transform.position.x - _radius, transform.position.y);
                
            }

            if (i == 2)
            {
                SpawnPoints[i] = new Vector2(transform.position.x, transform.position.y + _radius);
                
            }

            if (i == 3)
            {
                SpawnPoints[i] = new Vector2(transform.position.x, transform.position.y - _radius);
                
            }

            if (i == 4)
            {
                SpawnPoints[i] = new Vector2(transform.position.x + _radius,
                    transform.position.y + _radius);
                
            }

            if (i == 5)
            {
                SpawnPoints[i] = new Vector2(transform.position.x - _radius,
                    transform.position.y - _radius);
                
            }

            if (i == 6)
            {
                SpawnPoints[i] = new Vector2(transform.position.x + _radius,
                    transform.position.y - _radius);
                
            }

            if (i == 7)
            {
                SpawnPoints[i] = new Vector2(transform.position.x - _radius,
                    transform.position.y + _radius);
                
            }
        }
    }
    
}
