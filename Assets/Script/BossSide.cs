using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSide : MonoBehaviour
{
    public int hp = 1000;
    public Sprite sestroyedSprite;
    public GameObject explosiveEffect;

    public GameObject ms;
    public Transform pos;
    bool msState = true;


    void Start()
    {
        StartCoroutine(BossMissle());
    }

    void Update()
    {
        
    }

    public void DamageL(int attack)
    {
        hp -= attack;
        if (hp < 0)
        {
            StopMissle();
            GameObject go = Instantiate(explosiveEffect, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            gameObject.GetComponent<SpriteRenderer>().sprite = sestroyedSprite;
            gameObject.transform.Translate(0.07f, 0, 0);
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }
    public void DamageR(int attack)
    {
        hp -= attack;
        if (hp < 0)
        {
            StopMissle();
            GameObject go = Instantiate(explosiveEffect, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            gameObject.GetComponent<SpriteRenderer>().sprite = sestroyedSprite;
            gameObject.transform.Translate(-0.14f, 0, 0);
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }

    public void StopMissle()
    {
        msState = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PBullet"))
        {
            Destroy(collision.gameObject);

            StartCoroutine("Hit");
        }
    }

    IEnumerator Hit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(200/255, 200/255, 200/255, 255/255);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator BossMissle()
    {
        while (true)
        {
            if (msState)
            {
                Instantiate(ms, pos.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
