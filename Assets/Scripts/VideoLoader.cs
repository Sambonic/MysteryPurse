using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    private void Awake()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        FindObjectOfType<NavigationController>().GoToLevelOneScene();
    }
}
