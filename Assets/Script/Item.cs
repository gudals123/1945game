using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed = 5f;
    float vectorX = 0.5f;
    float vectorY = 1;
    void Update()
    {


        gameObject.transform.Translate(vectorX * speed* Time.deltaTime, vectorY * speed* Time.deltaTime,0);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("XWall"))
        {
            vectorX *=-1;
        }
        if (collision.CompareTag("YWall"))
        {
            vectorY *=-1;
        }
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddItem();
            Destroy(gameObject);
        }
    }


}
