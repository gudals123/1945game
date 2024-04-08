using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator ani;   //�ִϸ����͸� ������ ����

    public Transform pos = null;
    public List<GameObject> bullet = new List<GameObject>();

    public GameObject playerdie;
    public bool shootCheck = true;

    public int power = 0;
    public int itemCount = 0;

    //������
    public GameObject lazer;
    public float gValue = 0;
    public Image gage;


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

        //�����̽��� ������ ������
        else if (Input.GetKey(KeyCode.Q))
        {
            gValue += Time.deltaTime;
            gage.fillAmount = gValue;


            if (gValue >= 1)
            {
                //������ ������
                GameObject go = Instantiate(lazer, pos.position, Quaternion.identity);

                Destroy(go, 3);
                gValue = 0;
            }
        }
        else
        {
            gValue -= Time.deltaTime;

            if (gValue <=0)
            {
                gValue = 0;
            }

            //UI
            gage.fillAmount = gValue;
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
        yield return new WaitForSeconds(0.05f);
        Instantiate(bullet[power], pos.position, Quaternion.identity);
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
        if (collision.CompareTag("Item"))
        {
            itemCount +=1;

            if (itemCount >= 2)
            {
                power = 1;
            }
            if (itemCount >= 4)
            {
                power = 2;
            }
            if (itemCount >= 6)
            {
                power = 3;
            }
            //GameManager.Instance.AddItem();
            Destroy(collision.gameObject);
        }
    }
}
