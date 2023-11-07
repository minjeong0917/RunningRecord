using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingController : MonoBehaviour
{

    static string nextScene;
    [SerializeField]
    Image progress;



    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;

        SceneManager.LoadScene("Loading");

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());


    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); //LoadSceneAsync -> 비동기 방식으로 씬 불러오는 도중에 다른 작업 가능
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f) // 씬 로딩이 90퍼센트까지 진행될때까지는 로딩 진행도에 맞춰 진행바를 채우고
            {
                progress.fillAmount = op.progress;
            }
            else //그 이후에는 페이크 로딩에 맞춰 1초간 시간 채운뒤 씬 불러옴
            {
                timer += Time.unscaledDeltaTime*0.3f; //*0.3은 로딩창 보여주려고 임시로 늘려놓음! 원래는 없어야함!
                progress.fillAmount = Mathf.Lerp(0.9f, 1.0f, timer);
                if (progress.fillAmount >= 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }

}
