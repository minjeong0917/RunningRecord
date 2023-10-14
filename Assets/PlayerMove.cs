using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 3.0f;
    public float jumpForce;
    public bool isjumping = false;

    public Rigidbody2D rigid;




    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();


    }



    // Update is called once per frame
    void Update()
    {


        // # �̵�
        float h = 1.0f;
        float v = Input.GetAxis("Vertical");
   

        // �̵� �Ÿ� ���� - ���ɿ� ���� �� �����ӿ� ������ ��� �� ����
        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;


        // ���� �̵� 
        transform.Translate(Vector3.right * h);



        // ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isjumping == false) // �ٴڿ� ������� ���� ���� �����ϵ���
            {

                rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // �������� ���� ��

                isjumping = true;

            }
            else return;
        }


    }


    private void OnCollisionEnter2D(Collision2D collision) // �浹 
    {
        if (collision.gameObject.CompareTag("ground")) // ĳ���Ͱ� ���� ����� �� ���� ����
        {
            isjumping = false;
        }

        if (collision.gameObject.CompareTag("start")) // ���� ���� ������ ������� �÷���!
        {
            AudioManager.instance.PlayBGM("BGM_1");
        }

    }
}
