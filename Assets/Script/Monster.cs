using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3f;
    public float delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;
    public GameObject mosterDie;
    public GameObject Item = null;


    public int hp = 100;


    void Start()
    {
        Invoke("CreateBullet", delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);

        //¿Á±Õ»£√‚
        Invoke("CreateBullet", delay);
    }


    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PBullet"))
        {
            Destroy(collision.gameObject);

            StartCoroutine("Hit");
        }
        if (collision.CompareTag("Lazer"))
        {

            StartCoroutine("Hit");
        }
    }


    public void Damage(int attack)
    {
        hp -= attack;
        if(hp < 0)
        {
            GameObject go = Instantiate(mosterDie, transform.position, Quaternion.identity);
            Destroy(go, 1);
            int num = Random.Range(0, 100);
            if (num > 70)
            {
                Instantiate(Item, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
   


    IEnumerator Hit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(200/255, 200/255, 200/255, 255/255);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }






}
