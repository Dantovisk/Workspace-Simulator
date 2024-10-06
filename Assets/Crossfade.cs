using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crossfade : MonoBehaviour
{
	[SerializeField] private Animator transition;
	[SerializeField] private float transitionTime = 0.5f;

	public IEnumerator LoadLevel(int level)
	{
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);
		SceneManager.LoadScene(level);
	}
}
