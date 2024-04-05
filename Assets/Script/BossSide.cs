using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSide : MonoBehaviour
{
    public int hp = 1000;
    public Sprite sestroyedSprite;
    public GameObject explosiveEffect;

    public GameObject ms;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    bool msState = true;

    GameObject missile1;
    GameObject missile2;
    GameObject missile3;


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

                missile1 =  Instantiate(ms, pos1.position, Quaternion.identity);

                missile2.GetComponent<MBullet>().Move(Vector2.up);
                missile2 = Instantiate(ms, pos3.position, Quaternion.identity);

                if (gameObject.CompareTag("BossLeft"))
                {
                    missile3.GetComponent<MBullet>().Move(Vector2.left);
                    missile3 = Instantiate(ms, pos2.position, Quaternion.identity);
                }
                if (gameObject.CompareTag("BossRight"))
                {
                    missile3.GetComponent<MBullet>().Move(Vector2.right);
                    missile3 = Instantiate(ms, pos2.position, Quaternion.identity);
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
