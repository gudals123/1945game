using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator ani;   //애니메이터를 가져올 변수

    public Transform pos = null;
    public List<GameObject> bullet = new List<GameObject>();

    public GameObject playerdie;
    public bool shootCheck = true;

    public int power = 0;
    public int itemCount = 0;

    //레이져
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
            // 프리팹 위치 방향 생성
            shootCheck = false;
            StartCoroutine(Shoot());
        }

        //스페이스바 누르고 있을때
        else if (Input.GetKey(KeyCode.Q))
        {
            gValue += Time.deltaTime;
            gage.fillAmount = gValue;


            if (gValue >= 1)
            {
                //레이져 나가기
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

        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.
    }
    IEnumerator Shoot()
    {
        // 프리팹 위치 방향 생성
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
