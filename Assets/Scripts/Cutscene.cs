using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
	[SerializeField] private VideoPlayer videoPlayer;
	[SerializeField] private Crossfade crossfade;

	void Update()
	{
		if (!videoPlayer.isPlaying && videoPlayer.frame >= (long)videoPlayer.frameCount - 1)
		{
			StartCoroutine(crossfade.LoadLevel(2));
		}
	}


}
