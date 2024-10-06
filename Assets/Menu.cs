using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject levelMenu;

	public void Jogar()
	{
		mainMenu.SetActive(false);
		levelMenu.SetActive(true);
	}

	public void Voltar()
	{
		levelMenu.SetActive(false);
		mainMenu.SetActive(true);
	}

	public void Level1()
	{
		SceneManager.LoadScene("Cutscene");
	}

	public void Sair()
	{
		Application.Quit();
	}
}
