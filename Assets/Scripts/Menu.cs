using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject levelMenu;
	[SerializeField] private GameObject configMenu;

	[SerializeField] private Crossfade crossfade;

	public void Start()
	{
		mainMenu.SetActive(true);
		levelMenu.SetActive(false);
		configMenu.SetActive(false);
	}

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
		StartCoroutine(crossfade.LoadLevel(1));
	}

	public void Sair()
	{
		Application.Quit();
	}
}
