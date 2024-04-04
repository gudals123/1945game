using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody2D rig = null;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();  

        int num = Random.Range(0,4);

        if (num == 0 )
            rig.AddForce(new Vector3(-speed, speed, 0));
        if (num == 1)
            rig.AddForce(new Vector3(-speed, -speed, 0));
        if (num == 2)
            rig.AddForce(new Vector3(speed, -speed, 0));
        if (num == 3)
            rig.AddForce(new Vector3(speed, speed, 0));

    }
    void Update()
    {
        //gameObject.transform.Translate(vectorX * speed* Time.deltaTime, vectorY * speed* Time.deltaTime,0);

    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("XWall"))
        {
            vectorX *=-1;
        }
        if (collision.CompareTag("YWall"))
        {
            vectorY *=-1;
        }

    }*/


}
