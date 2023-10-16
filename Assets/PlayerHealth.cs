using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentLives;


    private void Start()
    {
        currentLives = maxHealth;//현재 생명 초기화

    }
    private void Update()
    {
        
    }
    
    public void TakeDamage()
    {
        Debug.Log("life");
        if (currentLives > 0)// 라이프가 남아있다면
        {
            // 현재 라이프 중 하나를 비활성화
            Transform lifeTransform = transform.Find("Life (" + currentLives + ")");
            if (lifeTransform != null)
            {
                lifeTransform.gameObject.SetActive(false);
            }

            currentLives--;

            if (currentLives <= 0)
            {
                // 라이프가 모두 소진되었을 때
                PlayerDied();
            }
        }
    }
    public void PlayerDied()
    {
        Debug.Log("You Died");
        //사망 시 반응 아직 안 만들었음
    }
}