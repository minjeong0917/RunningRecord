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
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); //LoadSceneAsync -> �񵿱� ������� �� �ҷ����� ���߿� �ٸ� �۾� ����
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f) // �� �ε��� 90�ۼ�Ʈ���� ����ɶ������� �ε� ���൵�� ���� ����ٸ� ä���
            {
                progress.fillAmount = op.progress;
            }
            else //�� ���Ŀ��� ����ũ �ε��� ���� 1�ʰ� �ð� ä��� �� �ҷ���
            {
                timer += Time.unscaledDeltaTime*0.3f; //*0.3�� �ε�â �����ַ��� �ӽ÷� �÷�����! ������ �������!
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
