using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homming : MonoBehaviour
{
    GameObject target; //플레이어
    public float speed  = 3f;

    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");
        
        //A - B -> A를 바라보는 벡터 나온다.
        dir = target.transform.position - transform.position;
        //방향벡터만 구하기 반뒤벡터 1의 크기로 만든다.
        dirNo = dir.normalized;

        //Vector3.MoveTowards


    }

    void Update()
    {
        transform.Translate(dirNo * speed * Time.deltaTime);        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



}
