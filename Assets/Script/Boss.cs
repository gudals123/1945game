using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int flag = 1;
    int speed = 2;
    public int hp = 4000;
    public GameObject ms2;
    bool BoundaryCheck = false;


    void Start()
    {
        Invoke("Hide", 1);
        //코루틴 실행
        StartCoroutine(CicleFire());

    }

    void Hide()
    {
        GameObject.Find("TextBossWarning").SetActive(false);
    }


    public void colliderControll()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    //원 방향으로 미사일 발사
    IEnumerator CicleFire()
    {
        //공격 주기
        float attackRate = 3;
        //발사체 생성갯수
        int count = 30;
        //발사체 사이의 각도
        float intervalAngle = 360 / count;
        //가중되는 각도(항상 같은 위치로 발사하지 않도록 설정
        float weightAngle = 0f;

        //원 형태로 방사하는 발사체 생성(count 갯수 만큼)
        while (true)
        {
            for (int i = 0; i< count; ++i)
            {
                //발사체 생성
                GameObject clone = Instantiate(ms2, transform.position, Quaternion.identity);

                //발사체 이동 방향(각도)
                float angle = weightAngle + intervalAngle * i;
                //발사체 이동 방향(벡터)
                //Cos(각도)라디안 단위의 각도 표현을 위해  pi/ 180 을 곱함
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //sin(각도)라디안 단위의 각도 표현을 위해 PI/100을 곱함
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                //발사체 이동 방향 설정
                clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }

            //발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 1;

            //3초마다 미사일 발사
            yield return new WaitForSeconds(attackRate);
        }
    }



    public void Damage(int attack)
    {
        hp -= attack;
        if (hp < 0)
        {

            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(transform.position.x > 1 && BoundaryCheck == true)
        {
            flag *= -1;
            BoundaryCheck = false;
        }
        if(transform.position.x < -1 && BoundaryCheck == true)
        {
            flag *= -1;
            BoundaryCheck = false;
        }
        else if(transform.position.x < 1 && transform.position.x > -1)
        {
            BoundaryCheck = true;
        }

        //transform.Translate(flag * speed * Time.deltaTime, 0, 0);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PBullet"))
        {
            Destroy(collision.gameObject);

            StartCoroutine("Hit");
            //GameObject.FindGameObjectWithTag("BossHead").GetComponent<BossHead>().BeHit();

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
