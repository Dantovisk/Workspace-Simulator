using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecao : MonoBehaviour
{
	[SerializeField] private GameObject texto;

	public void Selecionar()
	{
		texto.SetActive(true);
	}

	public void Deselecionar()
	{
		texto.SetActive(false);
	}
}
