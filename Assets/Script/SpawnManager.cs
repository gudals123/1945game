using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject monster;


    void Start()
    {
        InvokeRepeating("MonsterSpawn", 3, 1f);
    }

    void Update()
    {
        
    }

    void MonsterSpawn()
    {
        if (enableSpawn)
        {
            float numX = Random.Range(-2.5f, 2.5f);
            transform.position = new Vector2(numX, 4.32f);
            Instantiate(monster, transform.position,Quaternion.identity);
        }
    }
}
