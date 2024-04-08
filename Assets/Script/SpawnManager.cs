using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public float ss = -2; //���� ���� x�� ó��
    public float es = 2;  //x�� ��
    public float StartTime = 1; //����
    public float SpawnStop = 10; //���������� �ð�
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

    //�ڷ�ƾ �Լ�
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            //1�ʸ���
            yield return new WaitForSeconds(StartTime);
            //x�� ����
            float x = Random.Range(ss, es);
            //x�� ���� y���� �ڱ��ڽŰ�
            Vector2 r = new Vector2(x, transform.position.y);

            //���� ����
            Instantiate(monster, r, Quaternion.identity);
        }
    }


    //�ڷ�ƾ �Լ�
    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            //3�ʸ���
            yield return new WaitForSeconds(StartTime+2);
            //x�� ����
            float x = Random.Range(ss, es);
            //x�� ���� y���� �ڱ��ڽŰ�
            Vector2 r = new Vector2(x, transform.position.y);

            //���� ����
            Instantiate(monster2, r, Quaternion.identity);
        }
    }

    private void Stop()
    {
        swi = false;
        StopCoroutine("RandomSpawn");

        //�ι�° ����
        StartCoroutine("RandomSpawn2");
        Invoke("Stop2", SpawnStop+20);

    }
    private void Stop2()
    {
        swi2 = false;
        StopCoroutine("RandomSpawn2");

        //��������
        textBossWarning.SetActive(true);

        Vector3 pos = new Vector3(0, 2.899f, 0);

        Instantiate(boss, pos, Quaternion.identity);

    }


    void Update()
    {

    }
}
