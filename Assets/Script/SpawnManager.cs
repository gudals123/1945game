using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public float ss = -2; //몬스터 생성 x값 처음
    public float es = 2;  //x값 끝
    public float StartTime = 1; //시작
    public float SpawnStop = 10; //생성끝나는 시간
    [SerializeField]
    private GameObject monster;
    [SerializeField]
    private GameObject monster2;
    [SerializeField]
    private GameObject boss;

    bool swi = true;
    bool swi2 = true;

    [SerializeField]
    GameObject textBossWarning;


    private void Awake()
    {
        textBossWarning.SetActive(false);
    }

    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", SpawnStop);
    }

    //코루틴 함수
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            //1초마다
            yield return new WaitForSeconds(StartTime);
            //x값 랜덤
            float x = Random.Range(ss, es);
            //x값 랜덤 y값은 자기자신값
            Vector2 r = new Vector2(x, transform.position.y);

            //몬스터 생성
            Instantiate(monster, r, Quaternion.identity);
        }
    }


    //코루틴 함수
    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            //3초마다
            yield return new WaitForSeconds(StartTime+2);
            //x값 랜덤
            float x = Random.Range(ss, es);
            //x값 랜덤 y값은 자기자신값
            Vector2 r = new Vector2(x, transform.position.y);

            //몬스터 생성
            Instantiate(monster2, r, Quaternion.identity);
        }
    }

    private void Stop()
    {
        swi = false;
        StopCoroutine("RandomSpawn");

        //두번째 몬스터
        StartCoroutine("RandomSpawn2");
        Invoke("Stop2", SpawnStop+20);

    }
    private void Stop2()
    {
        swi2 = false;
        StopCoroutine("RandomSpawn2");

        //보스몬스터
        textBossWarning.SetActive(true);

        Vector3 pos = new Vector3(0, 2.899f, 0);

        Instantiate(boss, pos, Quaternion.identity);

    }


    void Update()
    {

    }
}
