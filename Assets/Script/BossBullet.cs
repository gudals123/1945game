using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 3f;
    Vector2 vec2 = Vector2.down;

    void Start()
    {
        
    }

    //방향을 전달하는 함수
    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }

    void Update()
    {
        transform.Translate(vec2 * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
