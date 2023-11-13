using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentLives;
    public Popup popup;
    public Progress progress;

    private void Start()
    {
        currentLives = maxHealth;//현재 생명 초기화
        
    }
    private void Initialized()
    {
        currentLives = maxHealth;
    }
    
    public void TakeDamage()
    {
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
                //popup.Gameover();
                //progress.GameOver();
            }
        }
    }
    public void GetLife()
    {
        if (currentLives <maxHealth)// 라이프가 남아있다면
        {
            // 현재 라이프 중 하나를 비활성화
            Transform lifeTransform = transform.Find("Life (" + (currentLives+1) + ")");
            if (lifeTransform != null)
            {
                lifeTransform.gameObject.SetActive(true);
            }

            currentLives++;

            if (currentLives >= 3)
            {
                // 라이프가 이미 차있을 때
                Debug.Log("maxlife over");
            }
        }
    }
}
