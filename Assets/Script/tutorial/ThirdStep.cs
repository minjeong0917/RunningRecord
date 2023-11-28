using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ThirdStep : MonoBehaviour
{
    public Camera mainCamera;
    public float speed;
    public float delay;
    public PlayerHealth health;
    public TextMeshPro tmp;
    public TextMeshPro title;
    bool loopStart = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Step") == 3)
        {

            if (loopStart)
            {//라이프 차감
                loopStart = false;
                tmp.text = "타이밍에 맞게 점프하여 아이템을 얻어보세요";
                health.TakeDamage();
                StartCoroutine(ChangeTitleAfterDelay());
            }
            else
            {
                //아이템 이동 코드
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
                    }
                }
            }
        }
    }

    void NextStep()
    {
        SceneManager.LoadScene("StageChoice");
    }
    IEnumerator ChangeTitleAfterDelay()
    {
        title.enabled = true;
        yield return new WaitForSeconds(1f); // 2초 대기
        title.enabled = false; // 오브젝트 비활성화
        title.text = "Step 4\n실전 플레이해보기"; // 텍스트 미리 변경
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//클리어 코드
        if (collision.CompareTag("Player"))
        {
            health.GetLife();
            PlayerPrefs.SetInt("Step", 4);
            tmp.text = "잘하셨습니다!";
            this.gameObject.SetActive(false);
            Invoke("NextStep", 1f);
        }
    }
}