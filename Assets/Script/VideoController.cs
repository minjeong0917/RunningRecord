using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // VideoPlayer�� �غ�Ǿ��� �� ȣ��Ǵ� �̺�Ʈ �����ʸ� ����մϴ�.
        videoPlayer.prepareCompleted += VideoPrepared;
        // VideoPlayer�� ����Ǿ��� �� ȣ��Ǵ� �̺�Ʈ �����ʸ� ����մϴ�.
        videoPlayer.loopPointReached += VideoEnded;
    }

    void VideoPrepared(VideoPlayer vp)
    {
        // VideoPlayer�� �غ�Ǹ� ����� �����մϴ�.
        videoPlayer.Play();
    }

    void VideoEnded(VideoPlayer vp)
    {
        // ������ ������ ��
        // ���� ������ �̵�
        SceneManager.LoadScene("Tutorial");
    }
}
