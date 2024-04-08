using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHead : MonoBehaviour
{
    [SerializeField]
    GameObject bossBullet;
    public GameObject explosiveEffect;
    public int hp = 500;



    public void RightDownLaunch()
    {
        GameObject go = Instantiate(bossBullet,transform.position,Quaternion.identity);
        go.GetComponent<BossBullet>().Move(new Vector2(1, -1));
    }
    public void LeftDownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);

        go.GetComponent<BossBullet>().Move(new Vector2(-1, -1));

    }

    public void DownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);

        go.GetComponent<BossBullet>().Move(new Vector2(0, -1));

    }
    public void Damage(int attack)
    {
        hp -= attack;
        if (hp < 0)
        {
            GameObject go = Instantiate(explosiveEffect, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);

            GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>().colliderControll();

            Destroy(gameObject);
        }
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
    IEnumerator Hit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(200/255, 200/255, 200/255, 255/255);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
