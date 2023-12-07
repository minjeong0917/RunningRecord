using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // VideoPlayer�� �غ�Ǿ��� ��
        videoPlayer.prepareCompleted += VideoStart;
        // VideoPlayer�� ����Ǿ��� �� 
        videoPlayer.loopPointReached += VideoEnd;
    }

    void VideoStart(VideoPlayer vp)
    {
        videoPlayer.Play();
    }

    void VideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("Tutorial");
    }
}
