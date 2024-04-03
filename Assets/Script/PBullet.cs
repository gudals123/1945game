using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PBullet: MonoBehaviour
{   
    public float bulletSpeed = 4.0f;
    public GameObject hit;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.up *bulletSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(go, 0.1f);
        }
    }


}
