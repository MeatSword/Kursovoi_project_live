using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Random = System.Random;

public class spawnerEmemies : MonoBehaviour
{
    
    private Random rnd = new Random();
    public Vector2[] SpawnPoints = new Vector2[50];
    public GameObject[] ListEnemies;
    public GameObject player;
    private int _rand, _radius = 40;
    private bool spawn=true,bossSpawn;
    void FixedUpdate()
    {
        if (spawn)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        spawn = false;
        _rand = rnd.Next(0, 7);
        SpawnPosition();
        if (_rand == 1)
        {
            Instantiate(ListEnemies[1], SpawnPoints[_rand], Quaternion.identity);
        }
        else
        {
            Instantiate(ListEnemies[0], SpawnPoints[_rand], Quaternion.identity);
        }

        if (!bossSpawn && Timer.Instance.timeMin == 5)
        {
            Instantiate(ListEnemies[2], new Vector3(SpawnPoints[_rand].x,SpawnPoints[_rand].y,-3), Quaternion.identity);
            bossSpawn = true;
        }

        StartCoroutine(SpawnCD());
    }

    private void SpawnPosition()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            if (i == 0)
            {
                SpawnPoints[i] = new Vector2(player.transform.position.x + _radius, player.transform.position.y);
                
            }

            if (i == 1)
            {
                SpawnPoints[i] = new Vector2(player.transform.position.x - _radius, player.transform.position.y);
                
            }

            if (i == 2)
            {
                SpawnPoints[i] = new Vector2(player.transform.position.x, player.transform.position.y + _radius);
                
            }

            if (i == 3)
            {
                SpawnPoints[i] = new Vector2(player.transform.position.x, player.transform.position.y - _radius);
                
            }

            if (i == 4)
            {
                SpawnPoints[i] = new Vector2(player.transform.position.x + _radius,
                    player.transform.position.y + _radius);
                
            }

            if (i == 5)
            {
                SpawnPoints[i] = new Vector2(player.transform.position.x - _radius,
                    player.transform.position.y - _radius);
                
            }

            if (i == 6)
            {
                SpawnPoints[i] = new Vector2(player.transform.position.x + _radius,
                    player.transform.position.y - _radius);
                
            }

            if (i == 7)
            {
                SpawnPoints[i] = new Vector2(player.transform.position.x - _radius,
                    player.transform.position.y + _radius);
                
            }
        }
    }
    private IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(EnemyStatsReal.Instance.spawnReload);
        spawn = true;
    }
}



        
    


