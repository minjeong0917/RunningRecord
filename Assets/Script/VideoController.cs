using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // VideoPlayer가 준비되었을 때
        videoPlayer.prepareCompleted += VideoStart;
        // VideoPlayer가 종료되었을 때 
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
