using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homming : MonoBehaviour
{
    GameObject target; //�÷��̾�
    public float speed  = 3f;

    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        //�÷��̾� �±׷� ã��
        target = GameObject.FindGameObjectWithTag("Player");
        
        //A - B -> A�� �ٶ󺸴� ���� ���´�.
        dir = target.transform.position - transform.position;
        //���⺤�͸� ���ϱ� �ݵں��� 1�� ũ��� �����.
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
