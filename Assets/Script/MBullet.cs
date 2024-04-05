using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBullet : MonoBehaviour
{
    public float speed = 3f;
    Vector2 vec2 = Vector2.down;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }

    //충돌처리


}
