using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowOpen : MonoBehaviour
{
    public GameObject appWindow;  // Arraste o painel da janela que voc� quer que o bot�o abra no Inspector

    // Fun��o para ser chamada ao clicar no bot�o
    public void OpenAppWindow()
    {
        if (appWindow != null)
        {
            appWindow.SetActive(true);  // Torna a janela vis�vel

            // Coloca a janela no topo (�ltima na hierarquia)
            appWindow.transform.SetAsLastSibling();
        }
    }

    public void CloseAppWindow()
    {
        if (appWindow != null)
        {
            appWindow.SetActive(false);  // Torna a janela invis�vel
        }
    }
}
