using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 3.0f;
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


        // # 이동
        float h = 1.0f;
        float v = Input.GetAxis("Vertical");
   

        // 이동 거리 보정 - 성능에 따라 한 프레임에 나오는 결과 값 보정
        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;


        // 실제 이동 
        transform.Translate(Vector3.right * h);



        // 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isjumping == false) // 바닥에 닿아있을 떄만 점프 가능하도록
            {

                rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // 위쪽으로 힘을 줌

                isjumping = true;

            }
            else return;
        }


    }


    private void OnCollisionEnter2D(Collision2D collision) // 충돌 
    {
        if (collision.gameObject.CompareTag("ground")) // 캐릭터가 땅에 닿았을 때 점프 가능
        {
            isjumping = false;
        }

        if (collision.gameObject.CompareTag("start")) // 시작 땅을 밟으면 배경음악 플레이!
        {
            AudioManager.instance.PlayBGM("BGM_1");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")) // 적과 충돌 시
            OnDamaged();
    }


    public void OnDamaged()
    {
        gameObject.layer = 8; // 무적 상태를 설정한 레이어로 바꿈
        spriteRenderer.color = new Color(1, 1, 1, 0.4f); // 반투명해짐
        
        Invoke("OffDamaged", 2f); // 2초 후 OffDamaged 함수 실행

    }

    public void OffDamaged()
    {
        gameObject.layer = 6; // 원래 상태의 레이어로 바꿈
        spriteRenderer.color = new Color(1, 1, 1, 1); // 투명 상태 해제
    }
}
