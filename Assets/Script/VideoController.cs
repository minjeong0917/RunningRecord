using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // VideoPlayer가 준비되었을 때 호출되는 이벤트 리스너를 등록합니다.
        videoPlayer.prepareCompleted += VideoPrepared;
        // VideoPlayer가 종료되었을 때 호출되는 이벤트 리스너를 등록합니다.
        videoPlayer.loopPointReached += VideoEnded;
    }

    void VideoPrepared(VideoPlayer vp)
    {
        // VideoPlayer가 준비되면 재생을 시작합니다.
        videoPlayer.Play();
    }

    void VideoEnded(VideoPlayer vp)
    {
        // 영상이 끝났을 때
        // 다음 씬으로 이동
        SceneManager.LoadScene("Tutorial");
    }
}
