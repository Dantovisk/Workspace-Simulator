using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
	private VideoPlayer videoPlayer;

	void Awake()
	{
		videoPlayer = GetComponent<VideoPlayer>();
	}

	void Update()
	{
		// Check if the video is not playing and has finished
		if (!videoPlayer.isPlaying && videoPlayer.frame >= (long)videoPlayer.frameCount - 1)
		{
			SceneManager.LoadScene("Workspace"); // Change scene
		}
	}
}
