using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject levelMenu;
	[SerializeField] private GameObject configMenu;

	[SerializeField] private Animator transition;
	[SerializeField] private float transitionTime = 0.5f;

	public void Jogar()
	{
		mainMenu.SetActive(false);
		levelMenu.SetActive(true);
	}

	public void Voltar()
	{
		configMenu.SetActive(false);
		levelMenu.SetActive(false);
		mainMenu.SetActive(true);
	}

	public void Configuracoes()
	{
		mainMenu.SetActive(false);
		configMenu.SetActive(true);
	}

	public void Level1()
	{
		StartCoroutine(LoadLevel(1));
	}

	public void Sair()
	{
		Application.Quit();
	}

	IEnumerator LoadLevel(int level)
	{
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);
		SceneManager.LoadScene(level);
	}
}
