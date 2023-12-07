using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstStep : MonoBehaviour
{
    public Camera mainCamera;
    public float speed;
    public float delay;
    public PlayerHealth health;
    public TextMeshPro tmp;
    public TextMeshPro title;

    //스텝1: 장애물 하나를 뛰어넘기
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
                Vector3 objectPosition = this.transform.position;
                Vector3 rightEndPosition = transform.position + transform.right * (transform.localScale.x);
                Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));


                if (rightEndPosition.x < leftEdge.x)
                {

                    objectPosition.x = objectPosition.x + delay;
                    transform.position = objectPosition;

                    if (health.currentLives == 3)
                    {//장애물을 통과했는데 라이프를 잃지 않았다면
                        AudioManager.instance.PlaySFX("Sucess2");
                        tmp.text = "잘하셨습니다!";//텍스트 변경
                        this.gameObject.SetActive(false);
                        Invoke("NextStep", 1f);
                        
                    }
                    else
                    {
                        health.GetLife();
                        //라이프 복구
                    }

                }
            }
        }
    }
    void NextStep()
    {
        PlayerPrefs.SetInt("Step", 2);
    }
    IEnumerator ChangeTitleAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 2초 대기
        title.enabled = false; // 오브젝트 비활성화
        title.text = "Step 2\n맵 변형에 대응하기"; // 텍스트 변경
    }
}