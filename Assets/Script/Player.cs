using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator ani;   //�ִϸ����͸� ������ ����

    public Transform pos = null;
    public GameObject bullet;
    public GameObject playerdie;
    public bool shootCheck = true;



    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if(Input.GetAxis("Horizontal") <= -0.5f)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani.SetBool("left", false);
        }

        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }

        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }

        if (Input.GetKey(KeyCode.Space) && shootCheck)
        {
            // ������ ��ġ ���� ����
            shootCheck = false;
            StartCoroutine(Shoot());
        }

        transform.Translate(moveX, moveY, 0);

        //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//�ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos; //��ǥ�� �����Ѵ�.
    }
    IEnumerator Shoot()
    {
        // ������ ��ġ ���� ����
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, pos.position, Quaternion.identity);
        shootCheck = true;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MBullet"))
        {
/*            GameObject go = Instantiate(playerdie, gameObject.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);

            Destroy(collision.gameObject);

            Destroy(gameObject);*/
        }
    }
}