using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class SecondStep : MonoBehaviour
{
    public TextMeshPro title;
    public TextMeshPro tmp;
    public GameObject player;
    bool set = false;
    bool isclear = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        title.gameObject.SetActive(true);
        if (PlayerPrefs.GetInt("Step") == 2)
        {
            if(set == false)
            {
                if (transform.position.x > 18f)
                {
                    transform.Translate(Vector3.up);
                    tmp.text = "발판의 높이 변화에 맞추어 점프하세요!";//텍스트 변경
                    set = true;
                    StartCoroutine(ChangeTitleAfterDelay());
                }
            }
            if (transform.position.x > 18f)
            {
                isclear = true;
            }
            if (transform.position.x < player.transform.position.x - 0.5f)
            {
                if (isclear)
                {
                    isclear = false;
                    tmp.text = "잘하셨습니다!";//텍스트 변경
                    transform.Translate(Vector3.down);
                    Invoke("NextStep", 1f);
                }
            }

        }
    }

    void NextStep()
    {
        PlayerPrefs.SetInt("Step", 3);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerPrefs.GetInt("Step") == 2)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isclear = false;
            }
        }
    }

    IEnumerator ChangeTitleAfterDelay()
    {
        title.enabled = true;
        yield return new WaitForSeconds(3f); // 3초 대기
        title.text = "Step 3\n라이프 회복하기"; // 텍스트 변경
        title.enabled = false; // 오브젝트 비활성화
    }
}
