using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed; //= 3.0f;
    public float jumpForce;
    public bool isjumping = false;

    public Rigidbody2D rigid;
    public SpriteRenderer spriteRenderer;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }



    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.instance.isStartGame)
        {
            rigid.gravityScale = 6; // 게임 시작 후 떨어지도록

            float h = 1.0f;
            float v = Input.GetAxis("Vertical");
   

     
            h = h * speed * Time.deltaTime;
            v = v * speed * Time.deltaTime;


        
            transform.Translate(Vector3.right * h);



        
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isjumping == false) 
                {

                    rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // ???????? ???? ??

                    isjumping = true;

                }
                else return;
            }

        }


    }


    private void OnCollisionEnter2D(Collision2D collision) // ???? 
    {
        if (collision.gameObject.CompareTag("ground")) // ???????? ???? ?????? ?? ???? ????
        {
            isjumping = false;
        }

        if (collision.gameObject.CompareTag("start")) // ???? ???? ?????? ???????? ??????!
        {
            AudioManager.instance.PlayBGM("BGM_1");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")) // ???? ???? ??
            OnDamaged();
    }


    public void OnDamaged()
    {
        gameObject.layer = 8; // ???? ?????? ?????? ???????? ????
        spriteRenderer.color = new Color(1, 1, 1, 0.4f); // ??????????
        
        Invoke("OffDamaged", 2f); // 2?? ?? OffDamaged ???? ????

    }

    public void OffDamaged()
    {
        gameObject.layer = 6; // ???? ?????? ???????? ????
        spriteRenderer.color = new Color(1, 1, 1, 1); // ???? ???? ????
    }
}
