using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //장애물과 플레이어의 충돌 시 구현

    public Rigidbody2D rigid;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {//플레이어와 접촉 시 LifeObject에 부착된 PlayerHealth스크립트의 TakeDamage함수를 실행.
        if (other.CompareTag("Player"))
        {
            GameObject lives = GameObject.Find("LifeObject");
            lives.gameObject.GetComponent<PlayerHealth>().TakeDamage();

        }
    }

}

