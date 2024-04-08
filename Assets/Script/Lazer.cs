using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject effect;
    Transform pos;
    int attack = 10;


    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<Player>().pos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos.position;  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().Damage(attack++);

            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go,1);
        }
        if (collision.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss>().Damage(attack++);

            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go, 1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().Damage(attack++);

            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go, 1);
        }
        if (collision.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss>().Damage(attack++);

            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go, 1);
        }
    }

}
