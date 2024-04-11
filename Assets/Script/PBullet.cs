using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PBullet: MonoBehaviour
{   
    public float bulletSpeed = 10.0f;
    public GameObject hit;
    public int Attack = 10;

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
            collision.gameObject.GetComponent<Monster>().Damage(Attack);
        }
        if (collision.CompareTag("Boss"))
        {
            GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(go, 0.1f);
            collision.gameObject.GetComponent<Boss>().Damage(Attack);
        }
        if (collision.CompareTag("BossLeft"))
        {
            GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(go, 0.1f);
            collision.gameObject.GetComponent<BossSide>().DamageL(Attack);
        }
        if (collision.CompareTag("BossRight"))
        {
            GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(go, 0.1f);
            collision.gameObject.GetComponent<BossSide>().DamageR(Attack);
        }
        if (collision.CompareTag("BossHead"))
        {
            GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(go, 0.1f);
            collision.gameObject.GetComponent<BossHead>().Damage(Attack);
        }


    }


}
