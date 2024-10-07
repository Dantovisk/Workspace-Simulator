using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
	[SerializeField] private VideoPlayer videoPlayer;
	[SerializeField] private Crossfade crossfade;

	private bool hasStartedPlaying = false;

	void Start()
	{
		videoPlayer.loopPointReached += OnVideoEnd; // Automatically triggers when the video ends
		videoPlayer.Play(); // Starts the video
	}

	void Update()
	{
		if (videoPlayer.isPlaying && !hasStartedPlaying)
		{
			hasStartedPlaying = true; // The video has started
		}
	}

	private void OnVideoEnd(VideoPlayer vp)
	{
		// This is triggered when the video reaches the end
		StartCoroutine(crossfade.LoadLevel(2));
	}
}
