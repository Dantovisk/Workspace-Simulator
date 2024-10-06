using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
	[SerializeField] private VideoPlayer videoPlayer;

	[SerializeField] private Animator transition;
	[SerializeField] private float transitionTime = 0.5f;

	void Update()
	{
		if (!videoPlayer.isPlaying && videoPlayer.frame >= (long)videoPlayer.frameCount - 1)
		{
			StartCoroutine(LoadLevel(2));
		}
	}

	IEnumerator LoadLevel(int level)
	{
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);
		SceneManager.LoadScene(level);
	}
}
