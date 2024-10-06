using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour
{
	[SerializeField] private GameObject paused;
	[SerializeField] private GameObject pauseMenu;
	[SerializeField] private GameObject configMenu;

	[SerializeField] private Crossfade crossfade;

	public static bool GameIsPaused = false;


	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				VoltarJogo();
			}
			else
			{
				PausarJogo();
			}
		}
	}

	public void PausarJogo()
	{
		paused.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void VoltarJogo()
	{
		VoltarMenu();
		paused.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void VoltarMenu()
	{
		pauseMenu.SetActive(true);
		configMenu.SetActive(false);
	}

	public void Configuracoes()
	{
		pauseMenu.SetActive(false);
		configMenu.SetActive(true);
	}

	public void Sair()
	{
		StartCoroutine(crossfade.LoadLevel(0));
	}
}
