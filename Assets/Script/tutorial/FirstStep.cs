using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstStep : MonoBehaviour
{
    public Camera mainCamera;
    public float speed;
    public float delay;
    //스텝1: 장애물 하나를 뛰어넘기
    public GameObject health;
    public TextMeshPro tmp;
    public TextMeshPro title;

    private void Start()
    {
        PlayerPrefs.SetInt("Step", 1);
        StartCoroutine(ChangeTitleAfterDelay());
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Step") == 1)
        {
            //장애물 이동 코드
            float h = -1.0f;

            h = h * speed * Time.deltaTime;
            transform.Translate(Vector3.right * h);


            if (mainCamera != null)
            {
<<<<<<< Updated upstream
                Vector3 objectPosition = this.transform.position;
                Vector3 rightEndPosition = transform.position + transform.right * (transform.localScale.x / 2);
=======
                
                
                if (health.GetComponent<PlayerHealth>().currentLives == 3)
                {
                    tmp.text = "잘하셨습니다!";
                }
                else
                {
                    health.GetComponent<PlayerHealth>().GetLife();
                    objectPosition.x = objectPosition.x + delay;
                    transform.position = objectPosition;
                }
>>>>>>> Stashed changes

                Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0.5f, 0));


                if (rightEndPosition.x < leftEdge.x)
                {

                    objectPosition.x = objectPosition.x + delay;
                    transform.position = objectPosition;

                    if (health.GetComponent<PlayerHealth>().currentLives == 3)
                    {//장애물을 통과했는데 라이프를 잃지 않았다면
                        tmp.text = "잘하셨습니다!";//텍스트 변경
                        PlayerPrefs.SetInt("Step", 2);
                        
                    }
                    else
                    {
                        health.GetComponent<PlayerHealth>().GetLife();
                        //라이프 복구
                    }

                }
            }
        }
    }
    IEnumerator ChangeTitleAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 2초 대기
        title.enabled = false; // 오브젝트 비활성화
        title.text = "Step 2\n맵 변형에 대응하기"; // 텍스트 변경
    }
}