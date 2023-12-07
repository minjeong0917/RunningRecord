using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    public bool isjumping = false;

    public Rigidbody2D rigid;
    public SpriteRenderer spriteRenderer;
    public Popup popup;


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
        rigid.gravityScale = 6;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isjumping == false) 
            {
                isjumping = true;
                rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else return;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")) // ???? ???? ??
            OnDamaged();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isjumping = false;
        }
        if (collision.gameObject.CompareTag("Clap"))
        {
            AudioManager.instance.PlaySFX("Clap");
        }


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
